using ZeroRedact.Options.Internal;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactPhoneNumber(string phoneNumber)
           => RedactPhoneNumberInternal(phoneNumber);

        /// <inheritdoc />
        public string RedactPhoneNumber(string phoneNumber, PhoneNumberRedactorOptions redactorOptions)
            => RedactPhoneNumberInternal(phoneNumber, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactPhoneNumber(ReadOnlySpan<char> phoneNumber)
            => RedactPhoneNumberInternal(phoneNumber);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactPhoneNumber(ReadOnlySpan<char> phoneNumber, PhoneNumberRedactorOptions redactorOptions)
            => RedactPhoneNumberInternal(phoneNumber, redactorOptions);

        private string RedactPhoneNumberInternal(ReadOnlySpan<char> phoneNumber)
        {
            var internalOptions = new InternalPhoneNumberRedactorOptions(_baseRedactorOptions);
            return RedactPhoneNumberInternal(phoneNumber, internalOptions);
        }

        private string RedactPhoneNumberInternal(ReadOnlySpan<char> phoneNumber, PhoneNumberRedactorOptions redactorOptions)
        {
            var internalOptions = new InternalPhoneNumberRedactorOptions(_baseRedactorOptions, redactorOptions);
            return RedactPhoneNumberInternal(phoneNumber, internalOptions);
        }

        private string RedactPhoneNumberInternal(ReadOnlySpan<char> phoneNumber, InternalPhoneNumberRedactorOptions options)
        {
            try
            {
                if (phoneNumber.IsEmpty)
                {
                    return string.Empty;
                }

                return options.RedactorType switch
                {
                    PhoneNumberRedaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, phoneNumber.Length),
                    PhoneNumberRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    PhoneNumberRedaction.Full => CreateFullRedactionWithSymbols(phoneNumber, options.RedactionCharacter),
                    PhoneNumberRedaction.ShowLastFour => CreateShowLastFourDigitRedaction(phoneNumber, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };

            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }
    }
}
