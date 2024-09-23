namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class StringRedactorOptionsTests
    {
        [TestMethod]
        public void StringRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedString_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "test";

            // Act
            var redactedString = redactor.RedactString(input);

            // Assert
            Assert.AreEqual("AAAA", redactedString);

            // Example 1: Changing base defaults
            var options = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
        }

        [TestMethod]
        public void StringRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedString_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "test";

            // Act
            var redactedString = redactor.RedactString(input.AsSpan());

            // Assert
            Assert.AreEqual("AAAA", redactedString.ToString());
        }

        [TestMethod]
        public void StringRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedString_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var Redactor = new Redactor(redactorOptions);
            var input = "test";

            // Act
            var redactedString = Redactor.RedactString(input);

            // Assert
            Assert.AreEqual("****", redactedString);
        }

        [TestMethod]
        public void StringRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedString_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "test";

            // Act
            var redactedString = redactor.RedactString(input.AsSpan());

            // Assert
            Assert.AreEqual("****", redactedString.ToString());
        }

        [TestMethod]
        public void StringRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual("AAAAAAAAAAAAA", result);
        }

        [TestMethod]
        public void StringRedactorOptions_CustomLength_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    FixedLengthSize = 2
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.FixedLength });

            // Assert
            Assert.AreEqual("**", result);
        }

        [TestMethod]
        public void StringRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 5
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringRedactorOptions_ShouldThrowException_WhenFixedLengthSizeIsZero()
        {
            // Arrange
            var options = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = '*',
                    FixedLengthSize = 0
                }
            };

            // Act
            var redactor = new Redactor(options);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringRedactorOptions_ShouldThrowException_WhenFixedLengthSizeIsNegative()
        {
            // Arrange
            var options = new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = '*',
                    FixedLengthSize = -1
                }
            };

            // Act
            var redactor = new Redactor(options);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StringRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void StringRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.All, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAAAAAAAAAAAA", result);
        }

        [TestMethod]
        public void StringRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedString()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void StringRedactorOptions_WithConstructorOptions_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                StringRedactorOptions = new StringRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual("BBBBBBBBBBBBB", result);
        }

        [TestMethod]
        public void StringRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual("CCCCCCCCCCCCC", result);
        }

        [TestMethod]
        public void StringRedactorOptions_WithNoOptions_ShouldReturnRedactedString()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactString("Hello, World!", new StringRedactorOptions { });

            // Assert
            Assert.AreEqual("*************", result);
        }
    }
}
