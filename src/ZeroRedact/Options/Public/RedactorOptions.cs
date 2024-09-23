namespace ZeroRedact
{
    /// <summary>
    /// Provides options to be used with <see cref="Redactor"/>
    /// </summary>
    public readonly struct RedactorOptions
    {
        public StringRedactorOptions StringRedactorOptions { get; init; } = Constants.DefaultStringRedactorOptions;

        public EmailAddressRedactorOptions EmailAddressRedactorOptions { get; init; } = Constants.DefaultEmailAddressRedactorOptions;

        public DateRedactorOptions DateRedactorOptions { get; init; } = Constants.DefaultDateRedactorOptions;

        public CreditCardRedactorOptions CreditCardRedactorOptions { get; init; } = Constants.DefaultCreditCardRedactorOptions;

        public PhoneNumberRedactorOptions PhoneNumberRedactorOptions { get; init; } = Constants.DefaultPhoneNumberRedactorOptions;

        public IPv4RedactorOptions IPv4RedactorOptions { get; init; } = Constants.DefaultIPv4RedactorOptions;

        public IPv6RedactorOptions IPv6RedactorOptions { get; init; } = Constants.DefaultIPv6RedactorOptions;

        public MACAddressRedactorOptions MACAddressRedactorOptions { get; init; } = Constants.DefaultMACAddressRedactorOptions;

        /// <summary>
        /// The character used for the redaction.
        /// </summary>
        public char RedactionCharacter { get; init; } = Constants.DefaultRedactionCharacter;

        /// <summary>
        /// The fixed length size of the redaction.
        /// </summary>
        public int FixedLengthSize { get; init; } = Constants.DefaultFixedLengthSize;

        /// <summary>
        /// Constructs a new <see cref="RedactorOptions"/> instance.
        /// </summary>
        public RedactorOptions()
        {
        }
    }
}
