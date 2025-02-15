namespace ZeroRedact.Validators
{
    internal class MACAddressValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> macAddress)
        {
            var octetCountColon = macAddress.Count(':');
            var octetCountDash = macAddress.Count('-');

            return IsEui48(octetCountColon, octetCountDash) || IsEui64(octetCountColon, octetCountDash);
        }

        private static bool IsEui48(int octetCountColon, int octetCountDash)
        {
            return octetCountColon == 5 || octetCountDash == 5;
        }

        private static bool IsEui64(int octetCountColon, int octetCountDash)
        {
            return octetCountColon == 7 || octetCountDash == 7;
        }
    }
}
