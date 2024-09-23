using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class EmailAddressValidatorTests
    {
        public static IEnumerable<object[]> ValidEmailAddresses()
        {
            yield return new object[] { "test@example.com" };
            yield return new object[] { "user.name+tag+sorting@example.com" };
            yield return new object[] { "x@example.com" };
            yield return new object[] { "example-indeed@strange-example.com" };
        }

        public static IEnumerable<object[]> InvalidEmailAddresses()
        {
            yield return new object[] { "plainaddress" };
            yield return new object[] { "@missingusername.com" };
            yield return new object[] { "username@com" };
            yield return new object[] { "username@" };
            yield return new object[] { "username@." };
        }

        [TestMethod]
        [DynamicData(nameof(ValidEmailAddresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnTrue_ForValidEmailAddresses(string input)
        {
            bool result = EmailAddressValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DynamicData(nameof(InvalidEmailAddresses), DynamicDataSourceType.Method)]
        public void IsValidForRedaction_ShouldReturnFalse_ForInvalidEmailAddresses(string input)
        {
            bool result = EmailAddressValidator.IsValidForRedaction(input.AsSpan());
            Assert.IsFalse(result);
        }
    }
}
