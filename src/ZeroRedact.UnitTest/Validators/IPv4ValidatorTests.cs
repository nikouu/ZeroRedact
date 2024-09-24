using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class IPv4ValidatorTests
    {
        public static IEnumerable<object[]> ValidIPv4Addresses()
        {
            yield return new object[] { "192.168.1.1" };
            yield return new object[] { "10.0.0.1" };
            yield return new object[] { "172.16.0.1" };
            yield return new object[] { "8.8.8.8" };
        }

        public static IEnumerable<object[]> InvalidIPv4Addresses()
        {
            yield return new object[] { "192.168.1" };
            yield return new object[] { "192.168.1.1/24" };
            yield return new object[] { "192.168.1.1.1" };
        }

        [TestMethod]
        [DynamicData(nameof(ValidIPv4Addresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidIPv4Addresses(string input)
        {
            bool result = IPv4Validator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidIPv4Addresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidIPv4Addresses(string input)
        {
            bool result = IPv4Validator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
