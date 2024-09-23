namespace ZeroRedact.Validators
{
    // https://en.wikipedia.org/wiki/Payment_card_number
    internal static class CreditCardValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> value)
        {
            int digitCount = 0;

            foreach (char c in value)
            {
                if (c >= '0' && c <= '9')
                {
                    digitCount++;
                }
                else if (c != ' ' && c != '-')
                {
                    return false; // Invalid character found
                }
            }

            return value.Length >= 12 && value.Length <= 19;
        }
    }
}
