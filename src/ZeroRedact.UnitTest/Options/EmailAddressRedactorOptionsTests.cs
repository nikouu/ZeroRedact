namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class EmailAddressRedactorOptionsTests
    {
        [TestMethod]
        public void EmailAddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedEmailAddress_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "user@example.com";

            // Act
            var redactedEmail = redactor.RedactEmailAddress(input);

            // Assert
            Assert.AreEqual("XXXX@XXXXXXX.XXX", redactedEmail);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedEmailAddress_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "user@example.com";

            // Act
            var redactedEmail = redactor.RedactEmailAddress(input.AsSpan());

            // Assert
            Assert.AreEqual("XXXX@XXXXXXX.XXX", redactedEmail.ToString());
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedEmailAddress_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "user@example.com";

            // Act
            var redactedEmail = redactor.RedactEmailAddress(input);

            // Assert
            Assert.AreEqual("****@*******.***", redactedEmail);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedEmailAddress_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "user@example.com";

            // Act
            var redactedEmail = redactor.RedactEmailAddress(input.AsSpan());

            // Assert
            Assert.AreEqual("****@*******.***", redactedEmail.ToString());
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("user@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXXXXXX", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_CustomLength_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("user@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("user@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmailAddressRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
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
        public void EmailAddressRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
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
        public void EmailAddressRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAAAA@AAAAAAA.AAA", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithConstructorOptions_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                EmailAddressRedactorOptions = new EmailAddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full });

            // Assert
            Assert.AreEqual("BBBBB@BBBBBBB.BBB", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full });

            // Assert
            Assert.AreEqual("CCCCC@CCCCCCC.CCC", result);
        }

        [TestMethod]
        public void EmailAddressRedactorOptions_WithNoOptions_ShouldReturnRedactedEmailAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactEmailAddress("email@example.com", new EmailAddressRedactorOptions { });

            // Assert
            Assert.AreEqual("*****@*******.***", result);
        }
    }
}
