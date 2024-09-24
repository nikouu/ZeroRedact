namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to a MAC address.
    /// </summary>
    public enum MACAddressRedaction
    {
        /// <summary>
        /// The MAC address is redacted.
        /// </summary>
        /// <remarks>
        /// Example: "00:B0:D0:63:C2:26" becomes "*****************"</remarks>
        All,

        /// <summary>
        /// The MAC address is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "00:B0:D0:63:C2:26" becomes "********"</remarks> 
        FixedLength,

        /// <summary>
        /// The MAC address is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "00:B0:D0:63:C2:26" becomes "**:**:**:**:**:**"</remarks> 
        Full,

        /// <summary>
        /// The last byte of the MAC address is shown.
        /// </summary>
        /// <remarks>Example: "00:B0:D0:63:C2:26" becomes "**:**:**:**:**:26"</remarks> 
        ShowLastByte
    }
}
