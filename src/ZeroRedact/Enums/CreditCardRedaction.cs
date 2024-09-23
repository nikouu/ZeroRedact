namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a credit card number.
    /// </summary>
    public enum CreditCardRedaction
    {
        /// <summary>
        /// the credit card number is redacted.
        /// </summary>
        /// <remarks>Example: "0000-0000-0000-0000" becomes "*******************"</remarks>
        All,

        /// <summary>
        /// the credit card number is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "0000-0000-0000-0000" becomes "********"</remarks>
        FixedLength,

        /// <summary>
        /// the credit card number is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "0000-0000-0000-0000" becomes "****-****-****-****"</remarks>
        Full,

        /// <summary>
        /// The last four digits of the credit card number are shown.
        /// </summary>
        /// <remarks>Example: "0000-0000-0000-0000" becomes "****-****-****-0000"</remarks>
        ShowLastFour,

        /// <summary>
        /// The first six digits and the last four digits of the credit card number are shown.
        /// </summary>
        /// <remarks>Example: "0000-0000-0000-0000" becomes "0000-00**-****-0000"</remarks>
        ShowFirstSixLastFour
    }
}
