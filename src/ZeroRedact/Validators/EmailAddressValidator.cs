namespace ZeroRedact.Validators
{
    internal static class EmailAddressValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> email)
        {
            var atCount = 0;
            var finalAtIndex = -1;
            var finalDotIndex = -1;

            // Only go through the string once
            for (int i = 0; i < email.Length; i++)
            {
                var character = email[i];

                if (character == '@')
                {
                    atCount++;
                    finalAtIndex = i;
                }
                else if (character == '.')
                {
                    finalDotIndex = i;

                    // Check for consecutive dots
                    if (i > 0 && email[i - 1] == '.')
                    {
                        return false;
                    }
                }
            }

            if (atCount < 1 || finalDotIndex == -1 || finalAtIndex == -1 || finalAtIndex == 0)
            {
                return false;
            }

            var usernameLength = finalAtIndex;
            var domainLength = email.Length - finalAtIndex - 1;

            if (usernameLength == 0 || domainLength <= 1)
            {
                return false;
            }

            return true;
        }
    }
}
