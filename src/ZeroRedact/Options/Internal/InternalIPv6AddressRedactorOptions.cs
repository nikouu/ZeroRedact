namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalIPv6AddressRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public IPv6AddressRedaction RedactorType { get; init; }

        public InternalIPv6AddressRedactorOptions(RedactorOptions defaultOptions, IPv6AddressRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.IPv6AddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv6AddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.IPv6AddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv6AddressRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.IPv6AddressRedactorOptions.RedactorType;
            }
        }

        public InternalIPv6AddressRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.IPv6AddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv6AddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.IPv6AddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv6AddressRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.IPv6AddressRedactorOptions.RedactorType;
        }
    }
}
