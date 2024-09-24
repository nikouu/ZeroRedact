namespace ZeroRedact.Validators
{
    internal class MACAddressValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> macAddress)
        {
            var octetCountColon = macAddress.Count(':');
            var octetCountDash = macAddress.Count('-');

            return IsEui48(macAddress, octetCountColon, octetCountDash) || IsEui64(macAddress, octetCountColon, octetCountDash);
        }

        private static bool IsEui48(ReadOnlySpan<char> macAddress, int octetCountColon, int octetCountDash)
        {
            return octetCountColon == 5 || octetCountDash == 5;
        }

        private static bool IsEui64(ReadOnlySpan<char> macAddress, int octetCountColon, int octetCountDash)
        {
            return octetCountColon == 7 || octetCountDash == 7;
        }
    }
}
