using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.Validators
{
    internal static class IPv4Validator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> ipAddress)
        {
            var octetCount = ipAddress.Count('.');
            if (octetCount != 3)
            {
                return false;
            }

            var hasSubnet = ipAddress.Contains('/');
            if (hasSubnet)
            {
                return false;
            }

            return true;
        }
    }
}
