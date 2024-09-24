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
        }

        public static IEnumerable<object[]> InvalidCreditCardNumbers()
        {
            yield return new object[] { "4111" };
            yield return new object[] { "4111 1111 1111 111X" };
            yield return new object[] { "4111_1111_1111_1111" };
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
