using System.Globalization;
using ZeroRedact.Options.Internal;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactDate(DateTime date)
           => RedactDateInternal(DateOnly.FromDateTime(date));

        /// <inheritdoc />
        public string RedactDate(DateTime date, DateRedactorOptions redactorOptions)
            => RedactDateInternal(DateOnly.FromDateTime(date), redactorOptions);

        /// <inheritdoc />
        public string RedactDate(DateOnly date)
            => RedactDateInternal(date);

        /// <inheritdoc />
        public string RedactDate(DateOnly date, DateRedactorOptions redactorOptions)
            => RedactDateInternal(date, redactorOptions);

        private string RedactDateInternal(DateOnly date)
        {
            var internalOptions = new InternalDateRedactorOptions(_baseRedactorOptions);
            return RedactDateInternal(date, internalOptions);
        }

        private string RedactDateInternal(DateOnly date, in DateRedactorOptions options)
        {
            var internalOptions = new InternalDateRedactorOptions(_baseRedactorOptions, options);
            return RedactDateInternal(date, internalOptions);
        }

        private static string RedactDateInternal(DateOnly date, in InternalDateRedactorOptions options)
        {
            return options.RedactorType switch
            {
                DateRedaction.All => CreateAllDateRedaction(date, options.RedactionCharacter),
                DateRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                DateRedaction.Full => CreateFullDateRedaction(date, options.RedactionCharacter),
                DateRedaction.Day => CreateDateRedaction(date, "d", options.RedactionCharacter),
                DateRedaction.Month => CreateDateRedaction(date, "m", options.RedactionCharacter),
                DateRedaction.Year => CreateDateRedaction(date, "y", options.RedactionCharacter),
                DateRedaction.DayAndMonth => CreateDateRedaction(date, "dm", options.RedactionCharacter),
                DateRedaction.MonthAndYear => CreateDateRedaction(date, "my", options.RedactionCharacter),
                DateRedaction.DayAndYear => CreateDateRedaction(date, "dy", options.RedactionCharacter),
                _ => throw new NotImplementedException()
            };
        }

        private static string CreateAllDateRedaction(DateOnly date, char redactionCharacter)
        {
            var culture = CultureInfo.CurrentCulture;
            var dateFormat = culture.DateTimeFormat.ShortDatePattern;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold];

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, culture);

            return new string(redactionCharacter, charsWritten);
        }

        // 2.5 - 3x faster than using CreateDateRedaction()
        private static string CreateFullDateRedaction(DateOnly date, char redactionCharacter)
        {
            var culture = CultureInfo.CurrentCulture;
            var dateFormat = culture.DateTimeFormat.ShortDatePattern;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold];

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, culture);

            for (int i = 0; i < charsWritten; i++)
            {
                if (char.IsDigit(dateCharSpan[i]))
                {
                    dateCharSpan[i] = redactionCharacter;
                }
            }

            return dateCharSpan[..charsWritten].ToString();
        }

        private static string CreateDateRedaction(DateOnly date, ReadOnlySpan<char> formatCharacters, char redactionCharacter)
        {
            var culture = CultureInfo.CurrentCulture;
            var dateTimeFormat = culture.DateTimeFormat;
            var dateFormat = dateTimeFormat.ShortDatePattern;
            var dateSeparator = dateTimeFormat.DateSeparator;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold];

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, culture);

            // Get the different date parts (day, month, year)
            ReadOnlySpan<char> cleanDate = dateCharSpan[..charsWritten];
            Span<Range> cleanDateParts = stackalloc Range[3];
            Span<Range> cleanFormatParts = stackalloc Range[3];
            
            // Fast path for single-char separator (most cultures)
            if (dateSeparator.Length == 1)
            {
                char sep = dateSeparator[0];
                cleanDate.Split(cleanDateParts, sep);
                dateFormat.AsSpan().Split(cleanFormatParts, sep);
            }
            else
            {
                cleanDate.Split(cleanDateParts, dateSeparator);
                dateFormat.AsSpan().Split(cleanFormatParts, dateSeparator);
            }

            var cleanFormat = dateFormat.AsSpan();

            // Iterate over format parts first (always 3), then check against target chars
            for (int j = 0; j < 3; j++)
            {
                var formatPart = cleanFormat[cleanFormatParts[j]];
                if (formatPart.IsEmpty) continue;

                // Check if any of the target format characters exist in this part
                for (int i = 0; i < formatCharacters.Length; i++)
                {
                    char target = formatCharacters[i];                    
                    
                    if (ContainsCharIgnoreCase(formatPart, target))
                    {
                        dateCharSpan[cleanDateParts[j]].Fill(redactionCharacter);
                        break;
                    }
                }
            }

            return cleanDate.ToString();
        }

        // Manual case-insensitive search (faster than Contains with StringComparison).
        // Note: We search the entire format part rather than just checking the first character
        // (e.g., 'd' in "dd") to remain defensive against custom cultures with unusual
        // ShortDatePattern formats. Standard patterns always have single-type specifiers
        // per part (d/dd, M/MM, y/yy/yyyy), but we don't assume this.
        // TODO: Spend time properly understand whether we can move to checking just the first character.
        private static bool ContainsCharIgnoreCase(ReadOnlySpan<char> span, char target)
        {
            char lowerTarget = char.ToLowerInvariant(target);
            
            for (int i = 0; i < span.Length; i++)
            {
                if (char.ToLowerInvariant(span[i]) == lowerTarget)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
