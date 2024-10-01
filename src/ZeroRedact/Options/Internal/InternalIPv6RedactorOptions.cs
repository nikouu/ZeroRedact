namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalIPv6RedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public IPv6AddressRedaction RedactorType { get; init; }

        public InternalIPv6RedactorOptions(RedactorOptions defaultOptions, IPv6RedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.IPv6RedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv6RedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.IPv6RedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv6RedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.IPv6RedactorOptions.RedactorType;
            }
        }

        public InternalIPv6RedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.IPv6RedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv6RedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.IPv6RedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv6RedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.IPv6RedactorOptions.RedactorType;
        }
    }
}
