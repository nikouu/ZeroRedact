namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalCreditCardRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public CreditCardRedaction RedactorType { get; init; }

        public InternalCreditCardRedactorOptions(RedactorOptions defaultOptions, CreditCardRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.CreditCardRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.CreditCardRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.CreditCardRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.CreditCardRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.CreditCardRedactorOptions.RedactorType;
            }
        }

        public InternalCreditCardRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.CreditCardRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.CreditCardRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.CreditCardRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.CreditCardRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.CreditCardRedactorOptions.RedactorType;
        }
    }
}
