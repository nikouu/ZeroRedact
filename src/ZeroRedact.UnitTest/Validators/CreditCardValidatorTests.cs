using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class CreditCardValidatorTests
    {
        public static IEnumerable<object[]> ValidCreditCardNumbers()
        {
            yield return new object[] { "4111 1111 1111 1111" };
            yield return new object[] { "4111-1111-1111-1111" };
            yield return new object[] { "4111 1111 1111 111" };
            yield return new object[] { "4111 1111 1111 11" };
            yield return new object[] { "4111111111111111" };      // 16 digits, no separators
            yield return new object[] { "1234567890123" };         // 13 digits (minimum valid)
            yield return new object[] { "1234567890123456789" };   // 19 digits (maximum valid)
            yield return new object[] { "123456789012" };          // 12 digits (minimum valid)
        }

        public static IEnumerable<object[]> InvalidCreditCardNumbers()
        {
            yield return new object[] { "4111" };
            yield return new object[] { "4111 1111 1111 111X" };
            yield return new object[] { "4111_1111_1111_1111" };
            // Too few digits
            yield return new object[] { "1234-5678-901" };             // 11 digits
            yield return new object[] { "123-456-789-0" };             // 10 digits
            yield return new object[] { "1-2-3-4-5-6-7-8-9-0-1" };     // 11 digits
            yield return new object[] { "1234 5678 901" };             // 11 digits
            // Too many digits
            yield return new object[] { "12345678901234567890" };      // 20 digits
            yield return new object[] { "1234-5678-9012-3456-7890" };  // 20 digits
        }

        [TestMethod]
        [DynamicData(nameof(ValidCreditCardNumbers), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidCreditCardNumbers(string input)
        {
            bool result = CreditCardValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidCreditCardNumbers), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidCreditCardNumbers(string input)
        {
            bool result = CreditCardValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
