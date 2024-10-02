namespace ZeroRedact
{
    /// <summary>
    /// Provides options to be used with <see cref="Redactor"/>
    /// </summary>
    public readonly struct RedactorOptions
    {
        /// <summary>
        /// The options for redacting strings.
        /// </summary>
        public StringRedactorOptions StringRedactorOptions { get; init; } = Constants.DefaultStringRedactorOptions;

        /// <summary>
        /// The options for redacting email addresses.
        /// </summary>
        public EmailAddressRedactorOptions EmailAddressRedactorOptions { get; init; } = Constants.DefaultEmailAddressRedactorOptions;

        /// <summary>
        /// The options for redacting dates.
        /// </summary>
        public DateRedactorOptions DateRedactorOptions { get; init; } = Constants.DefaultDateRedactorOptions;

        /// <summary>
        /// The options for redacting credit card numbers.
        /// </summary>
        public CreditCardRedactorOptions CreditCardRedactorOptions { get; init; } = Constants.DefaultCreditCardRedactorOptions;

        /// <summary>
        /// The options for redacting phone numbers.
        /// </summary>
        public PhoneNumberRedactorOptions PhoneNumberRedactorOptions { get; init; } = Constants.DefaultPhoneNumberRedactorOptions;

        /// <summary>
        /// The options for redacting IPv4 addresses.
        /// </summary>
        public IPv4AddressRedactorOptions IPv4AddressRedactorOptions { get; init; } = Constants.DefaultIPv4AddressRedactorOptions;

        /// <summary>
        /// The options for redacting IPv6 addresses.
        /// </summary>
        public IPv6AddressRedactorOptions IPv6AddressRedactorOptions { get; init; } = Constants.DefaultIPv6AddressRedactorOptions;

        /// <summary>
        /// The MAC address redactor options.
        /// </summary>
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
