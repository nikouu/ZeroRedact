namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to an email address.
    /// </summary>
    public enum EmailAddressRedaction
    {
        /// <summary>
        /// the email address is redacted.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "*****************"</remarks>
        All,

        /// <summary>
        /// the email address is redacted with a fixed width.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "********"</remarks>
        FixedLength,

        /// <summary>
        /// Only the @ symbol and final dot is shown.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "*****@*******.***"</remarks>
        Full,

        /// <summary>
        /// The local-part/username is redacted.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "*****@example.com"</remarks>
        Username,

        /// <summary>
        /// The first half of the username is redacted.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "***il@example.com"</remarks>
        FirstHalfUsername,


        /// <summary>
        /// The second half of the username and the first half of the domain are redacted.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "em*********le.com"</remarks>
        Middle,

        /// <summary>
        /// Only the first and last characters of the username are shown along with showing the full domain.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "e***l@example.com"</remarks>
        MostUsername,

        /// <summary>
        /// Only the first character of the username and host are shown along with showing the full domain.
        /// </summary>
        /// <remarks>Example: "email@example.com" becomes "e****@e******.com"</remarks>
        ShowFirstCharacters
    }
}
