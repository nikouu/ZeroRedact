namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalDateRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public DateRedaction RedactorType { get; init; }

        public InternalDateRedactorOptions(RedactorOptions defaultOptions, DateRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.DateRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.DateRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.DateRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.DateRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.DateRedactorOptions.RedactorType;
            }
        }

        public InternalDateRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.DateRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.DateRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.DateRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.DateRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.DateRedactorOptions.RedactorType;
        }
    }
}
