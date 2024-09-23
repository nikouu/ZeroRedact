using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact
{
    public readonly struct StringRedactorOptions
    {
        private readonly char? _redactionCharacter;
        private readonly int? _fixedLengthSize;
        private readonly StringRedaction? _redactorType;

        /// <summary>
        /// The character used for the redaction.
        /// </summary>
        public char RedactionCharacter
        {
            get => _redactionCharacter ?? Constants.DefaultRedactionCharacter;
            init => _redactionCharacter = value;
        }

        internal bool HasRedactionCharacter => _redactionCharacter.HasValue;

        /// <summary>
        /// The fixed length size of the redaction.
        /// </summary>
        public int FixedLengthSize
        {
            get => _fixedLengthSize ?? Constants.DefaultFixedLengthSize;
            init => _fixedLengthSize = value;
        }

        internal bool HasFixedLengthSize => _fixedLengthSize.HasValue;

        /// <summary>
        /// The type of redactor to apply.
        /// </summary>
        public StringRedaction RedactorType
        {
            get => _redactorType ?? Constants.DefaultStringRedactorOptions.RedactorType;
            init => _redactorType = value;
        }

        internal bool HasRedactorType => _redactorType.HasValue;

        public StringRedactorOptions() { }
    }
}
