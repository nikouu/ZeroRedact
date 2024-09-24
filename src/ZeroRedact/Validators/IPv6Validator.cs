namespace ZeroRedact.Validators
{
    internal static class IPv6Validator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> ipAddress)
        {
            var octetCount = ipAddress.Count(':');
            if (octetCount < 2)
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
