namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalPhoneNumberRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public PhoneNumberRedaction RedactorType { get; init; }

        public InternalPhoneNumberRedactorOptions(RedactorOptions defaultOptions, PhoneNumberRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.PhoneNumberRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.PhoneNumberRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.PhoneNumberRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.PhoneNumberRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            if (userOptions.HasRedactorType)
            {
                RedactorType = userOptions.RedactorType;
            }
            else
            {
                RedactorType = defaultOptions.PhoneNumberRedactorOptions.RedactorType;
            }
        }

        public InternalPhoneNumberRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.PhoneNumberRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.PhoneNumberRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.PhoneNumberRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.PhoneNumberRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.PhoneNumberRedactorOptions.RedactorType;
        }
    }
}
