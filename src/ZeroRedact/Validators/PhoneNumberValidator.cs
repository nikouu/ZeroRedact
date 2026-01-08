namespace ZeroRedact.Validators
{
    internal static class PhoneNumberValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (char.IsLetter(phoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
