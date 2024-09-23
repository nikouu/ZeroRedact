using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalIPv4RedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public IPv4Redaction RedactorType { get; init; }

        public InternalIPv4RedactorOptions(RedactorOptions defaultOptions, IPv4RedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.IPv4RedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv4RedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.IPv4RedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv4RedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.IPv4RedactorOptions.RedactorType;
            }
        }

        public InternalIPv4RedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.IPv4RedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.IPv4RedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.IPv4RedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.IPv4RedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.IPv4RedactorOptions.RedactorType;
        }
    }
}
