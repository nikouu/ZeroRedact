#pragma warning disable CS8618

namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactCreditCardTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "1234567812345678", "****************" };
            yield return new object[] { "1234 5678 1234 5678", "*******************" };
            yield return new object[] { "1234-5678-1234-5678", "*******************" };
            yield return new object[] { "123456781234567", "***************" };
            yield return new object[] { "1234 5678 1234 567", "******************" };
            yield return new object[] { "1234-5678-1234-567", "******************" };
            yield return new object[] { "12345678123456", "**************" };
            yield return new object[] { "1234 5678 1234 56", "*****************" };
            yield return new object[] { "1234-5678-1234-56", "*****************" };
            yield return new object[] { "1234567812345", "*************" };
            yield return new object[] { "1234 5678 1234 5", "****************" };
            yield return new object[] { "1234-5678-1234-5", "****************" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "1234567812345678", "********" };
            yield return new object[] { "1234 5678 1234 5678", "********" };
            yield return new object[] { "1234-5678-1234-5678", "********" };
            yield return new object[] { "123456781234567", "********" };
            yield return new object[] { "1234 5678 1234 567", "********" };
            yield return new object[] { "1234-5678-1234-567", "********" };
            yield return new object[] { "12345678123456", "********" };
            yield return new object[] { "1234 5678 1234 56", "********" };
            yield return new object[] { "1234-5678-1234-56", "********" };
            yield return new object[] { "1234567812345", "********" };
            yield return new object[] { "1234 5678 1234 5", "********" };
            yield return new object[] { "1234-5678-1234-5", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "1234567812345678", "****************" };
            yield return new object[] { "1234 5678 1234 5678", "**** **** **** ****" };
            yield return new object[] { "1234-5678-1234-5678", "****-****-****-****" };
            yield return new object[] { "123456781234567", "***************" };
            yield return new object[] { "1234 5678 1234 567", "**** **** **** ***" };
            yield return new object[] { "1234-5678-1234-567", "****-****-****-***" };
            yield return new object[] { "12345678123456", "**************" };
            yield return new object[] { "1234 5678 1234 56", "**** **** **** **" };
            yield return new object[] { "1234-5678-1234-56", "****-****-****-**" };
            yield return new object[] { "1234567812345", "*************" };
            yield return new object[] { "1234 5678 1234 5", "**** **** **** *" };
            yield return new object[] { "1234-5678-1234-5", "****-****-****-*" };
        }

        private static IEnumerable<object[]> ShowLastFour_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "1234567812345678", "************5678" };
            yield return new object[] { "1234 5678 1234 5678", "**** **** **** 5678" };
            yield return new object[] { "1234-5678-1234-5678", "****-****-****-5678" };
            yield return new object[] { "123456781234567", "***********4567" };
            yield return new object[] { "1234 5678 1234 567", "**** **** ***4 567" };
            yield return new object[] { "1234-5678-1234-567", "****-****-***4-567" };
            yield return new object[] { "12345678123456", "**********3456" };
            yield return new object[] { "1234 5678 1234 56", "**** **** **34 56" };
            yield return new object[] { "1234-5678-1234-56", "****-****-**34-56" };
            yield return new object[] { "1234567812345", "*********2345" };
            yield return new object[] { "1234 5678 1234 5", "**** **** *234 5" };
            yield return new object[] { "1234-5678-1234-5", "****-****-*234-5" };

        }

        private static IEnumerable<object[]> ShowFirstSixLastFour_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "1234567812345678", "123456******5678" };
            yield return new object[] { "1234 5678 1234 5678", "1234 56** **** 5678" };
            yield return new object[] { "1234-5678-1234-5678", "1234-56**-****-5678" };
            yield return new object[] { "123456781234567", "123456*****4567" };
            yield return new object[] { "1234 5678 1234 567", "1234 56** ***4 567" };
            yield return new object[] { "1234-5678-1234-567", "1234-56**-***4-567" };
            yield return new object[] { "12345678123456", "123456****3456" };
            yield return new object[] { "1234 5678 1234 56", "1234 56** **34 56" };
            yield return new object[] { "1234-5678-1234-56", "1234-56**-**34-56" };
            yield return new object[] { "1234567812345", "123456***2345" };
            yield return new object[] { "1234 5678 1234 5", "1234 56** *234 5" };
            yield return new object[] { "1234-5678-1234-5", "1234-56**-*234-5" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_All_ShouldReturnRedactedCreditCard_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input, new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_All_ShouldReturnRedactedCreditCard_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All }).ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_FixedLength_ShouldReturnRedactedCreditCard_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input, new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_FixedLength_ShouldReturnRedactedCreditCard_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength }).ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_Full_ShouldReturnRedactedCreditCard_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input, new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_Full_ShouldReturnRedactedCreditCard_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.Full }).ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        [DynamicData(nameof(ShowLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_ShowLastFour_ShouldReturnRedactedCreditCard_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input, new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowLastFour });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_ShowLastFour_ShouldReturnRedactedCreditCard_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowLastFour }).ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowFirstSixLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_ShowFirstSixLastFour_ShouldReturnRedactedCreditCard_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input, new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowFirstSixLastFour });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowFirstSixLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactCreditCard_ShowFirstSixLastFour_ShouldReturnRedactedCreditCard_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactCreditCard(input.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowFirstSixLastFour }).ToString();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
