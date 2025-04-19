namespace ZeroRedact
{
    // TODO: Review static data locality of this class
    internal static class Constants
    {
        internal const int StackAllocThreshold = 128;
        internal const char DefaultRedactionCharacter = '*';
        internal const int DefaultFixedLengthSize = 8;

        internal static readonly string DefaultRedactionString = new(DefaultRedactionCharacter, DefaultFixedLengthSize);

        internal static readonly StringRedactorOptions DefaultStringRedactorOptions = new()
        {
            RedactorType = StringRedaction.All
        };

        internal static readonly EmailAddressRedactorOptions DefaultEmailAddressRedactorOptions = new()
        {
            RedactorType = EmailAddressRedaction.Full
        };

        internal static readonly DateRedactorOptions DefaultDateRedactorOptions = new()
        {
            RedactorType = DateRedaction.Full
        };

        internal static readonly CreditCardRedactorOptions DefaultCreditCardRedactorOptions = new()
        {
            RedactorType = CreditCardRedaction.Full
        };

        internal static readonly PhoneNumberRedactorOptions DefaultPhoneNumberRedactorOptions = new()
        {
            RedactorType = PhoneNumberRedaction.Full
        };

        internal static readonly IPv4AddressRedactorOptions DefaultIPv4AddressRedactorOptions = new()
        {
            RedactorType = IPv4AddressRedaction.Full
        };

        internal static readonly IPv6AddressRedactorOptions DefaultIPv6AddressRedactorOptions = new()
        {
            RedactorType = IPv6AddressRedaction.Full
        };

        internal static readonly MACAddressRedactorOptions DefaultMACAddressRedactorOptions = new()
        {
            RedactorType = MACAddressRedaction.Full
        };

        internal static readonly RedactorOptions DefaultRedactorOptions = new()
        {
            StringRedactorOptions = DefaultStringRedactorOptions,
            EmailAddressRedactorOptions = DefaultEmailAddressRedactorOptions,
            DateRedactorOptions = DefaultDateRedactorOptions,
            CreditCardRedactorOptions = DefaultCreditCardRedactorOptions,
            PhoneNumberRedactorOptions = DefaultPhoneNumberRedactorOptions,
            IPv4AddressRedactorOptions = DefaultIPv4AddressRedactorOptions,
            IPv6AddressRedactorOptions = DefaultIPv6AddressRedactorOptions,
            MACAddressRedactorOptions = DefaultMACAddressRedactorOptions
        };
    }
}
