using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.Options.Internal
{
    internal readonly ref struct InternalEmailAddressRedactorOptions
    {
        public char RedactionCharacter { get; init; }
        public int FixedLengthSize { get; init; }
        public EmailAddressRedaction RedactorType { get; init; }

        public InternalEmailAddressRedactorOptions(RedactorOptions defaultOptions, EmailAddressRedactorOptions userOptions)
        {
            if (userOptions.HasFixedLengthSize)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(userOptions.FixedLengthSize, 1);
            }

            if (userOptions.HasRedactionCharacter)
            {
                RedactionCharacter = userOptions.RedactionCharacter;
            }
            else if (defaultOptions.EmailAddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.EmailAddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (userOptions.HasFixedLengthSize)
            {
                FixedLengthSize = userOptions.FixedLengthSize;
            }
            else if (defaultOptions.EmailAddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.EmailAddressRedactorOptions.FixedLengthSize;
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
                RedactorType = defaultOptions.EmailAddressRedactorOptions.RedactorType;
            }
        }

        public InternalEmailAddressRedactorOptions(RedactorOptions defaultOptions)
        {
            if (defaultOptions.EmailAddressRedactorOptions.HasRedactionCharacter)
            {
                RedactionCharacter = defaultOptions.EmailAddressRedactorOptions.RedactionCharacter;
            }
            else
            {
                RedactionCharacter = defaultOptions.RedactionCharacter;
            }

            if (defaultOptions.EmailAddressRedactorOptions.HasFixedLengthSize)
            {
                FixedLengthSize = defaultOptions.EmailAddressRedactorOptions.FixedLengthSize;
            }
            else
            {
                FixedLengthSize = defaultOptions.FixedLengthSize;
            }

            RedactorType = defaultOptions.EmailAddressRedactorOptions.RedactorType;
        }
    }
}
