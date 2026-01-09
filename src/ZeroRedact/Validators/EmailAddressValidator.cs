namespace ZeroRedact.Validators
{
    internal static class EmailAddressValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> email)
        {
            // Use SIMD-optimized operations
            var atCount = email.Count('@');
            if (atCount < 1)
            {
                return false;
            }

            var finalAtIndex = email.LastIndexOf('@');
            var finalDotIndex = email.LastIndexOf('.');

            if (finalDotIndex == -1 || finalAtIndex == 0)
            {
                return false;
            }

            if (email.Contains("..".AsSpan(), StringComparison.Ordinal))
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
