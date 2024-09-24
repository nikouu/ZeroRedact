namespace ZeroRedact
{
    /// <summary>
    /// Email address redactor options.
    /// </summary>
    public readonly struct EmailAddressRedactorOptions
    {
        private readonly char? _redactionCharacter;
        private readonly int? _fixedLengthSize;
        private readonly EmailAddressRedaction? _redactorType;

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
        public EmailAddressRedaction RedactorType
        {
            get => _redactorType ?? Constants.DefaultEmailAddressRedactorOptions.RedactorType;
            init => _redactorType = value;
        }

        internal bool HasRedactorType => _redactorType.HasValue;

        /// <summary>
        /// Constructs a new <see cref="EmailAddressRedactorOptions"/> instance.
        /// </summary>
        public EmailAddressRedactorOptions() { }
    }
}
