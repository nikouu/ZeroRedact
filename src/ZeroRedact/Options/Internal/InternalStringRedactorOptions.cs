namespace ZeroRedact.Options.Internal
{
    // rudimentary options merger/flattener
    internal readonly ref struct InternalStringRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public StringRedaction RedactorType { get; init; }

        // todo see if the defaults can go here? or if it's better to have them in the RedactorOptions
        public InternalStringRedactorOptions(RedactorOptions defaultOptions, StringRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.StringRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.StringRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.StringRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.StringRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.StringRedactorOptions.RedactorType;
            }
        }

        public InternalStringRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.StringRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.StringRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.StringRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.StringRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.StringRedactorOptions.RedactorType;
        }
    }
}
