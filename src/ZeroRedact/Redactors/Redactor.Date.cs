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

        private string RedactDateInternal(DateOnly date, DateRedactorOptions options)
        {
            var internalOptions = new InternalDateRedactorOptions(_baseRedactorOptions, options);
            return RedactDateInternal(date, internalOptions);
        }

        private string RedactDateInternal(DateOnly date, InternalDateRedactorOptions options)
        {
            try
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
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        private string CreateAllDateRedaction(DateOnly date, char redactionCharacter)
        {
            var formatProvider = CultureInfo.CurrentCulture;
            var dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold]; //todo can the zeroing be dodged since we know the space we're going to be writing?

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, formatProvider);

            return new string(redactionCharacter, charsWritten);
        }

        // 2.5 - 3x faster than using CreateDateRedaction()
        private string CreateFullDateRedaction(DateOnly date, char redactionCharacter)
        {
            var formatProvider = CultureInfo.CurrentCulture;
            var dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold]; //todo can the zeroing be dodged since we know the space we're going to be writing?

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, formatProvider);

            for (int i = 0; i < charsWritten; i++)
            {
                if (char.IsDigit(dateCharSpan[i]))
                {
                    dateCharSpan[i] = redactionCharacter;
                }
            }

            Span<char> result = dateCharSpan[..charsWritten];

            return result.ToString();
        }

        // todo improve this since it feels "magic number"y with formatCharacters
        private string CreateDateRedaction(DateOnly date, ReadOnlySpan<char> formatCharacters, char redactionCharacter)
        {
            var formatProvider = CultureInfo.CurrentCulture;
            var dateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            Span<char> dateCharSpan = stackalloc char[Constants.StackAllocThreshold];

            _ = date.TryFormat(dateCharSpan, out var charsWritten, dateFormat, formatProvider);

            // get the different date parts (day, month, year)
            ReadOnlySpan<char> cleanDate = dateCharSpan[..charsWritten];
            Span<Range> cleanDateParts = stackalloc Range[3];
            cleanDate.Split(cleanDateParts, CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);

            // get the different format parts e.g. (dd, mm, yyyy)
            var cleanFormat = dateFormat.AsSpan();
            Span<Range> cleanFormatParts = stackalloc Range[3];
            cleanFormat.Split(cleanFormatParts, CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);

            for (int i = 0; i < formatCharacters.Length; i++)
            {
                var formatChar = new ReadOnlySpan<char>(in formatCharacters[i]);

                for (int j = 0; j < 3; j++)
                {
                    // also accounts for when the date format has but the date number is two characters e.g. "d", being 31
                    if (cleanFormat[cleanFormatParts[j]].Contains(formatChar, StringComparison.OrdinalIgnoreCase))
                    {
                        dateCharSpan[cleanDateParts[j]].Fill(redactionCharacter);
                        break;
                    }
                }
            }

            return cleanDate.ToString();
        }
    }
}
