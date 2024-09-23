using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Validators;

namespace ZeroRedact.UnitTest.Validators
{
    [TestClass]
    public class CreditCardValidatorTests
    {
        public static IEnumerable<object[]> ValidCreditCardNumbers()
        {
            yield return new object[] { "4111 1111 1111 1111" };
            yield return new object[] { "5500-0000-0000-0004" };
            yield return new object[] { "3400 0000 0000 009" };
            yield return new object[] { "3000 0000 0000 04" };
        }

        public static IEnumerable<object[]> InvalidCreditCardNumbers()
        {
            yield return new object[] { "1234" };
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
