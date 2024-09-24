namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a phone number.
    /// </summary>
    public enum PhoneNumberRedaction
    {
        /// <summary>
        /// The phone number is redacted.
        /// </summary>
        /// <remarks>
        /// Example: "212-456-7890" becomes "************"</remarks>
        All,

        /// <summary>
        /// The phone number is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "212-456-7890" becomes "********"</remarks> 
        FixedLength,

        /// <summary>
        /// The phone number is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "212-456-7890" becomes "***-***-****"</remarks> 
        Full,

        /// <summary>
        /// The last four digits of the credit card number are shown.
        /// </summary>
        /// <remarks>Example: "212-456-7890" becomes "***-***-7890"</remarks>
        ShowLastFour
    }
}
