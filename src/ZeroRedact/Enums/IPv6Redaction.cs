using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact
{
    /// <summary>
    /// Defines the different types of redactions that can be applied to an IPv6 address.
    /// </summary>
    public enum IPv6Redaction
    {
        /// <summary>
        /// the IPv6 address is redacted.
        /// </summary>
        /// <remarks>Example: "2001:0000:130F:0000:0000:09C0:876A:130B" becomes "***************************************"</remarks> 
        All,

        /// <summary>
        /// The IPv4 address is redacted with a fixed length.
        /// </summary>
        /// <remarks>Example: "2001:0000:130F:0000:0000:09C0:876A:130B" becomes "********"</remarks> 
        FixedLength,

        /// <summary>
        /// the IPv4 address is redacted, preserving symbols.
        /// </summary>
        /// <remarks>Example: "2001:0000:130F:0000:0000:09C0:876A:130B" becomes "****:****:****:****:****:****:****:****"</remarks> 
        Full,

        /// <summary>
        /// The last quartet of the IPv6 address are shown.
        /// </summary>
        /// <remarks>Example: "2001:0000:130F:0000:0000:09C0:876A:130B" becomes "****:****:****:****:****:****:****:130B"</remarks> 
        ShowLastQuartet
    }
}
