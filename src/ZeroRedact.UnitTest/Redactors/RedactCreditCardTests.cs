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
            yield return new object[] { "4111111111111111", "****************" };
            yield return new object[] { "4111 1111 1111 1111", "*******************" };
            yield return new object[] { "4111-1111-1111-1111", "*******************" };
            yield return new object[] { "411111111111111", "***************" };
            yield return new object[] { "4111 1111 1111 111", "******************" };
            yield return new object[] { "4111-1111-1111-111", "******************" };
            yield return new object[] { "41111111111111", "**************" };
            yield return new object[] { "4111 1111 1111 11", "*****************" };
            yield return new object[] { "4111-1111-1111-11", "*****************" };
            yield return new object[] { "4111111111111", "*************" };
            yield return new object[] { "4111 1111 1111 1", "****************" };
            yield return new object[] { "4111-1111-1111-1", "****************" };

            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "4111111111111111", "********" };
            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "4111-1111-1111-1111", "********" };
            yield return new object[] { "411111111111111", "********" };
            yield return new object[] { "4111 1111 1111 111", "********" };
            yield return new object[] { "4111-1111-1111-111", "********" };
            yield return new object[] { "41111111111111", "********" };
            yield return new object[] { "4111 1111 1111 11", "********" };
            yield return new object[] { "4111-1111-1111-11", "********" };
            yield return new object[] { "4111111111111", "********" };
            yield return new object[] { "4111 1111 1111 1", "********" };
            yield return new object[] { "4111-1111-1111-1", "********" };

            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "4111111111111111", "****************" };
            yield return new object[] { "4111 1111 1111 1111", "**** **** **** ****" };
            yield return new object[] { "4111-1111-1111-1111", "****-****-****-****" };
            yield return new object[] { "411111111111111", "***************" };
            yield return new object[] { "4111 1111 1111 111", "**** **** **** ***" };
            yield return new object[] { "4111-1111-1111-111", "****-****-****-***" };
            yield return new object[] { "41111111111111", "**************" };
            yield return new object[] { "4111 1111 1111 11", "**** **** **** **" };
            yield return new object[] { "4111-1111-1111-11", "****-****-****-**" };
            yield return new object[] { "4111111111111", "*************" };
            yield return new object[] { "4111 1111 1111 1", "**** **** **** *" };
            yield return new object[] { "4111-1111-1111-1", "****-****-****-*" };

            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> ShowLastFour_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "4111111111111111", "************1111" };
            yield return new object[] { "4111 1111 1111 1111", "**** **** **** 1111" };
            yield return new object[] { "4111-1111-1111-1111", "****-****-****-1111" };
            yield return new object[] { "411111111111111", "***********1111" };
            yield return new object[] { "4111 1111 1111 111", "**** **** ***1 111" };
            yield return new object[] { "4111-1111-1111-111", "****-****-***1-111" };
            yield return new object[] { "41111111111111", "**********1111" };
            yield return new object[] { "4111 1111 1111 11", "**** **** **11 11" };
            yield return new object[] { "4111-1111-1111-11", "****-****-**11-11" };
            yield return new object[] { "4111111111111", "*********1111" };
            yield return new object[] { "4111 1111 1111 1", "**** **** *111 1" };
            yield return new object[] { "4111-1111-1111-1", "****-****-*111-1" };

            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };

        }

        private static IEnumerable<object[]> ShowFirstSixLastFour_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "4111 1111 1111 111X", "********" };
            yield return new object[] { "4111111111111111", "411111******1111" };
            yield return new object[] { "4111 1111 1111 1111", "4111 11** **** 1111" };
            yield return new object[] { "4111-1111-1111-1111", "4111-11**-****-1111" };
            yield return new object[] { "411111111111111", "411111*****1111" };
            yield return new object[] { "4111 1111 1111 111", "4111 11** ***1 111" };
            yield return new object[] { "4111-1111-1111-111", "4111-11**-***1-111" };
            yield return new object[] { "41111111111111", "411111****1111" };
            yield return new object[] { "4111 1111 1111 11", "4111 11** **11 11" };
            yield return new object[] { "4111-1111-1111-11", "4111-11**-**11-11" };
            yield return new object[] { "4111111111111", "411111***1111" };
            yield return new object[] { "4111 1111 1111 1", "4111 11** *111 1" };
            yield return new object[] { "4111-1111-1111-1", "4111-11**-*111-1" };

            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
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
