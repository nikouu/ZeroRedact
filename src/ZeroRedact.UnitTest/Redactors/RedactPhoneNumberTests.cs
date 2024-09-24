namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactPhoneNumberTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "15551hello234567", "****************" };

            yield return new object[] { "+15551234567", "************" };
            yield return new object[] { "+441632960961", "*************" };
            yield return new object[] { "+8613712345678", "**************" };

            yield return new object[] { "+1 (555) 123-4567", "*****************" };
            yield return new object[] { "+1 555 123 4567", "***************" };
            yield return new object[] { "+1-555-123-4567", "***************" };
            yield return new object[] { "+44 1632 960961", "***************" };
            yield return new object[] { "+44-1632-960961", "***************" };
            yield return new object[] { "+86 137 1234 5678", "*****************" };
            yield return new object[] { "+81-3-1234-5678", "***************" };

            yield return new object[] { "5551234567", "**********" };
            yield return new object[] { "(555) 123-4567", "**************" };
            yield return new object[] { "555-123-4567", "************" };
            yield return new object[] { "555.123.4567", "************" };
            yield return new object[] { "555 123 4567", "************" };
            yield return new object[] { "555123456", "*********" };
            yield return new object[] { "555 123 456", "***********" };
            yield return new object[] { "(555) 123-456", "*************" };
            yield return new object[] { "555-123-456", "***********" };
            yield return new object[] { "555.123.456", "***********" };

            yield return new object[] { "+33 1 23 45 67 89", "*****************" };
            yield return new object[] { "+49 30 123456", "*************" };
            yield return new object[] { "+91-9876543210", "**************" };
            yield return new object[] { "+81-90-1234-5678", "****************" };
            yield return new object[] { "+61 2 1234 5678", "***************" };
            yield return new object[] { "+55 11 91234-5678", "*****************" };
            yield return new object[] { "+27 21 123 4567", "***************" };
            yield return new object[] { "+34 612 34 56 78", "****************" };
            yield return new object[] { "+39 06 1234 5678", "****************" };
            yield return new object[] { "+7 495 123-45-67", "****************" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "15551hello234567", "********" };

            yield return new object[] { "+15551234567", "********" };
            yield return new object[] { "+441632960961", "********" };
            yield return new object[] { "+8613712345678", "********" };

            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "+1 555 123 4567", "********" };
            yield return new object[] { "+1-555-123-4567", "********" };
            yield return new object[] { "+44 1632 960961", "********" };
            yield return new object[] { "+44-1632-960961", "********" };
            yield return new object[] { "+86 137 1234 5678", "********" };
            yield return new object[] { "+81-3-1234-5678", "********" };

            yield return new object[] { "5551234567", "********" };
            yield return new object[] { "(555) 123-4567", "********" };
            yield return new object[] { "555-123-4567", "********" };
            yield return new object[] { "555.123.4567", "********" };
            yield return new object[] { "555 123 4567", "********" };
            yield return new object[] { "555123456", "********" };
            yield return new object[] { "555 123 456", "********" };
            yield return new object[] { "(555) 123-456", "********" };
            yield return new object[] { "555-123-456", "********" };
            yield return new object[] { "555.123.456", "********" };

            yield return new object[] { "+33 1 23 45 67 89", "********" };
            yield return new object[] { "+49 30 123456", "********" };
            yield return new object[] { "+91-9876543210", "********" };
            yield return new object[] { "+81-90-1234-5678", "********" };
            yield return new object[] { "+61 2 1234 5678", "********" };
            yield return new object[] { "+55 11 91234-5678", "********" };
            yield return new object[] { "+27 21 123 4567", "********" };
            yield return new object[] { "+34 612 34 56 78", "********" };
            yield return new object[] { "+39 06 1234 5678", "********" };
            yield return new object[] { "+7 495 123-45-67", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "15551hello234567", "****************" };

            yield return new object[] { "+15551234567", "+***********" };
            yield return new object[] { "+441632960961", "+************" };
            yield return new object[] { "+8613712345678", "+*************" };

            yield return new object[] { "+1 (555) 123-4567", "+* (***) ***-****" };
            yield return new object[] { "+1 555 123 4567", "+* *** *** ****" };
            yield return new object[] { "+1-555-123-4567", "+*-***-***-****" };
            yield return new object[] { "+44 1632 960961", "+** **** ******" };
            yield return new object[] { "+44-1632-960961", "+**-****-******" };
            yield return new object[] { "+86 137 1234 5678", "+** *** **** ****" };
            yield return new object[] { "+81-3-1234-5678", "+**-*-****-****" };

            yield return new object[] { "5551234567", "**********" };
            yield return new object[] { "(555) 123-4567", "(***) ***-****" };
            yield return new object[] { "555-123-4567", "***-***-****" };
            yield return new object[] { "555.123.4567", "***.***.****" };
            yield return new object[] { "555 123 4567", "*** *** ****" };
            yield return new object[] { "555123456", "*********" };
            yield return new object[] { "555 123 456", "*** *** ***" };
            yield return new object[] { "(555) 123-456", "(***) ***-***" };
            yield return new object[] { "555-123-456", "***-***-***" };
            yield return new object[] { "555.123.456", "***.***.***" };

            yield return new object[] { "+33 1 23 45 67 89", "+** * ** ** ** **" };
            yield return new object[] { "+49 30 123456", "+** ** ******" };
            yield return new object[] { "+91-9876543210", "+**-**********" };
            yield return new object[] { "+81-90-1234-5678", "+**-**-****-****" };
            yield return new object[] { "+61 2 1234 5678", "+** * **** ****" };
            yield return new object[] { "+55 11 91234-5678", "+** ** *****-****" };
            yield return new object[] { "+27 21 123 4567", "+** ** *** ****" };
            yield return new object[] { "+34 612 34 56 78", "+** *** ** ** **" };
            yield return new object[] { "+39 06 1234 5678", "+** ** **** ****" };
            yield return new object[] { "+7 495 123-45-67", "+* *** ***-**-**" };
        }

        private static IEnumerable<object[]> ShowLastFour_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "15551hello234567", "*****hello**4567" };

            yield return new object[] { "+15551234567", "+*******4567" };
            yield return new object[] { "+441632960961", "+********0961" };
            yield return new object[] { "+8613712345678", "+*********5678" };

            yield return new object[] { "+1 (555) 123-4567", "+* (***) ***-4567" };
            yield return new object[] { "+1 555 123 4567", "+* *** *** 4567" };
            yield return new object[] { "+1-555-123-4567", "+*-***-***-4567" };
            yield return new object[] { "+44 1632 960961", "+** **** **0961" };
            yield return new object[] { "+44-1632-960961", "+**-****-**0961" };
            yield return new object[] { "+86 137 1234 5678", "+** *** **** 5678" };
            yield return new object[] { "+81-3-1234-5678", "+**-*-****-5678" };

            yield return new object[] { "5551234567", "******4567" };
            yield return new object[] { "(555) 123-4567", "(***) ***-4567" };
            yield return new object[] { "555-123-4567", "***-***-4567" };
            yield return new object[] { "555.123.4567", "***.***.4567" };
            yield return new object[] { "555 123 4567", "*** *** 4567" };
            yield return new object[] { "555123456", "*****3456" };
            yield return new object[] { "555 123 456", "*** **3 456" };
            yield return new object[] { "(555) 123-456", "(***) **3-456" };
            yield return new object[] { "555-123-456", "***-**3-456" };
            yield return new object[] { "555.123.456", "***.**3.456" };

            yield return new object[] { "+33 1 23 45 67 89", "+** * ** ** 67 89" };
            yield return new object[] { "+49 30 123456", "+** ** **3456" };
            yield return new object[] { "+91-9876543210", "+**-******3210" };
            yield return new object[] { "+81-90-1234-5678", "+**-**-****-5678" };
            yield return new object[] { "+61 2 1234 5678", "+** * **** 5678" };
            yield return new object[] { "+55 11 91234-5678", "+** ** *****-5678" };
            yield return new object[] { "+27 21 123 4567", "+** ** *** 4567" };
            yield return new object[] { "+34 612 34 56 78", "+** *** ** 56 78" };
            yield return new object[] { "+39 06 1234 5678", "+** ** **** 5678" };
            yield return new object[] { "+7 495 123-45-67", "+* *** ***-45-67" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_All_ShouldReturnRedactedPhoneNumber_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_All_ShouldReturnRedactedPhoneNumber_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactPhoneNumber(input.AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_FixedLength_ShouldReturnRedactedPhoneNumber_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_FixedLength_ShouldReturnRedactedPhoneNumber_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactPhoneNumber(input.AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_Full_ShouldReturnRedactedPhoneNumber_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_Full_ShouldReturnRedactedPhoneNumber_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactPhoneNumber(input.AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_ShowLastFour_ShouldReturnRedactedPhoneNumber_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.ShowLastFour });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastFour_TestData), DynamicDataSourceType.Method)]
        public void RedactPhoneNumber_ShowLastFour_ShouldReturnRedactedPhoneNumber_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactPhoneNumber(input.AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.ShowLastFour });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
