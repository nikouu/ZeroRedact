namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class RedactorOptionsTests
    {
        [TestMethod]
        public void RedactorOptions_WithConstructorOptions_ShouldHaveDefaultRedactionCharacter()
        {
            // Arrange
            var options = new RedactorOptions();
            var Redactor = new Redactor(options);
            var input = "test";
            var expected = new string(Constants.DefaultRedactionCharacter, input.Length);

            // Act
            var redactedString = Redactor.RedactString(input);

            // Assert
            Assert.AreEqual(expected, redactedString);
        }

        [TestMethod]
        public void RedactorOptions_ShouldHaveDefaultFixedLengthSize()
        {
            // Arrange
            var options = new RedactorOptions();
            var Redactor = new Redactor(options);
            var input = "test";
            var expected = new string(Constants.DefaultRedactionCharacter, Constants.DefaultFixedLengthSize);

            // Act
            var redactedString = Redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.FixedLength});

            // Assert
            Assert.AreEqual(expected, redactedString);
        }

        [TestMethod]
        public void RedactorOptions_WithConstructorOptions_ShouldAllowCustomRedactionCharacter()
        {
            // Arrange
            var customRedactionCharacter = '#';
            var options = new RedactorOptions
            {
                RedactionCharacter = customRedactionCharacter
            };
            var Redactor = new Redactor(options);
            var input = "test";
            var expected = new string(customRedactionCharacter, input.Length);

            // Act
            var redactedString = Redactor.RedactString(input);

            // Assert
            Assert.AreEqual(expected, redactedString);
        }

        [TestMethod]
        public void RedactorOptions_WithConstructorOptions_ShouldAllowCustomFixedLengthSize()
        {
            // Arrange
            var customFixedLengthSize = 10;
            var options = new RedactorOptions
            {
                FixedLengthSize = customFixedLengthSize
            };
            var Redactor = new Redactor(options);
            var input = "test";
            var expected = new string(Constants.DefaultRedactionCharacter, customFixedLengthSize);

            // Act
            var redactedString = Redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, redactedString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                FixedLengthSize = 0
            };

            // Act
            var Redactor = new Redactor(options);
            var redactedString = Redactor.RedactString("test");

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                FixedLengthSize = -1
            };

            // Act
            var Redactor = new Redactor(options);
            var redactedString = Redactor.RedactString("test");

            // Assert is handled by ExpectedException
        }
    }
}
