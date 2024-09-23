using System;

namespace ZeroRedact.Validators
{
    internal static class EmailAddressValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> email)
        {
            var atCount = email.Count('@');
            if (atCount < 1)
            {
                return false;
            }

            var finalAtIndex = email.LastIndexOf('@');
            var finalDotIndex = email.LastIndexOf('.');

            if (finalDotIndex == -1)
            {
                return false;
            }

            var username = email[..finalAtIndex];
            var domain = email[(finalAtIndex + 1)..]; // +1 to skip over the @ sign

            if (username.IsEmpty)
            {
                return false;
            }

            if (domain.Length <= 1)
            {
                return false;
            }

            return true;
        }
    }
}
