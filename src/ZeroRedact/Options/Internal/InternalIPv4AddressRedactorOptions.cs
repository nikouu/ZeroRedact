namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalIPv4AddressRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public IPv4AddressRedaction RedactorType { get; init; }

        public InternalIPv4AddressRedactorOptions(RedactorOptions defaultOptions, IPv4AddressRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.IPv4AddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv4AddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.IPv4AddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv4AddressRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.IPv4AddressRedactorOptions.RedactorType;
            }
        }

        public InternalIPv4AddressRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.IPv4AddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv4AddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.IPv4AddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv4AddressRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.IPv4AddressRedactorOptions.RedactorType;
        }
    }
}
