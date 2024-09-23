using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class IPv6ValidatorTests
    {
        public static IEnumerable<object[]> ValidIPv6Addresses()
        {
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334" };
            yield return new object[] { "fe80::1ff:fe23:4567:890a" };
            yield return new object[] { "::1" };
            yield return new object[] { "2001:db8::2:1" };
        }

        public static IEnumerable<object[]> InvalidIPv6Addresses()
        {
            yield return new object[] { ":1" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334/64" };
        }

        [TestMethod]
        [DynamicData(nameof(ValidIPv6Addresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidIPv6Addresses(string input)
        {
            bool result = IPv6Validator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidIPv6Addresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidIPv6Addresses(string input)
        {
            bool result = IPv6Validator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
