using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalMACAddressRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public MACAddressRedaction RedactorType { get; init; }

        public InternalMACAddressRedactorOptions(RedactorOptions defaultOptions, MACAddressRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.MACAddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.MACAddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.MACAddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.MACAddressRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.MACAddressRedactorOptions.RedactorType;
            }
        }

        public InternalMACAddressRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.MACAddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.MACAddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.MACAddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.MACAddressRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.MACAddressRedactorOptions.RedactorType;
        }
    }
}
