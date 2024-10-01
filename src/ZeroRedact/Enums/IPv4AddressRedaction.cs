namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to an IPv4 address.
    /// </summary>
    public enum IPv4AddressRedaction
    {
        /// <summary>
        /// The IPv4 address is redacted.
        /// </summary>
        /// <remarks>Example: "192.0.2.146" becomes "***********"</remarks>
        All,

        /// <summary>
        /// The IPv4 address is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "192.0.2.146" becomes "********"</remarks> 
        FixedLength,

        /// <summary>
        /// The IPv4 address is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "192.0.2.146" becomes "***.*.*.***"</remarks> 
        Full,

        /// <summary>
        /// The last octet of the IPv4 address are shown.
        /// </summary>
        /// <remarks>Example: "192.0.2.146" becomes "***.*.*.146"</remarks> 
        ShowLastOctet
    }
}
