using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class MACAddressValidatorTests
    {
        public static IEnumerable<object[]> ValidMACAddresses()
        {
            yield return new object[] { "00:1A:2B:3C:4D:5E" };
            yield return new object[] { "00-1A-2B-3C-4D-5E" };
            yield return new object[] { "00:1A:2B:3C:4D:5E:6F:70" };
            yield return new object[] { "00-1A-2B-3C-4D-5E-6F-70" };
        }

        public static IEnumerable<object[]> InvalidMACAddresses()
        {
            yield return new object[] { "00:1A:2B:3C:4D" }; 
            yield return new object[] { "00-1A-2B-3C-4D-5E-6F" }; 
            yield return new object[] { "00:1A:2B:3C:4D:5E:6F:70:80" }; 
            yield return new object[] { "00 1A 2B 3C 4D 5G" }; 
        }

        [TestMethod]
        [DynamicData(nameof(ValidMACAddresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidMACAddresses(string input)
        {
            bool result = MACAddressValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidMACAddresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidMACAddresses(string input)
        {
            bool result = MACAddressValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
