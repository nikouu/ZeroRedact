using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class PhoneNumberValidatorTests
    {
        public static IEnumerable<object[]> ValidPhoneNumbers()
        {
            yield return new object[] { "15551234567" };
            yield return new object[] { "+15551234567" };
            yield return new object[] { "+1 (555) 123-4567" };
            yield return new object[] { "+81-90-1234-5678" };
        }

        public static IEnumerable<object[]> InvalidPhoneNumbers()
        {
            yield return new object[] { "A15551234567" };
            yield return new object[] { "+1-800-FLOWERS" };
        }

        [TestMethod]
        [DynamicData(nameof(ValidPhoneNumbers), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidPhoneNumbers(string input)
        {
            bool result = PhoneNumberValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidPhoneNumbers), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidPhoneNumbers(string input)
        {
            bool result = PhoneNumberValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
