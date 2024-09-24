namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a credit card number.
    /// </summary>
    public enum CreditCardRedaction
    {
        /// <summary>
        /// The credit card number is redacted.
        /// </summary>
        /// <remarks>Example: "4111-1111-1111-1111" becomes "*******************"</remarks>
        All,

        /// <summary>
        /// The credit card number is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "4111-1111-1111-1111" becomes "********"</remarks>
        FixedLength,

        /// <summary>
        /// The credit card number is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "4111-1111-1111-1111" becomes "****-****-****-****"</remarks>
        Full,

        /// <summary>
        /// The last four digits of the credit card number are shown.
        /// </summary>
        /// <remarks>Example: "4111-1111-1111-1111" becomes "****-****-****-1111"</remarks>
        ShowLastFour,

        /// <summary>
        /// The first six digits and the last four digits of the credit card number are shown.
        /// </summary>
        /// <remarks>Example: "4111-1111-1111-1111" becomes "4111-11**-****-1111"</remarks>
        ShowFirstSixLastFour
    }
}
