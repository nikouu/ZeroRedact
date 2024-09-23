namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class PhoneNumberRedactorOptionsTests
    {
        [TestMethod]
        public void PhoneNumberRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedPhoneNumber_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "123-456-7890";

            // Act
            var redactedPhoneNumber = redactor.RedactPhoneNumber(input);

            // Assert
            Assert.AreEqual("AAA-AAA-AAAA", redactedPhoneNumber);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedPhoneNumber_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'A'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "123-456-7890";

            // Act
            var redactedPhoneNumber = redactor.RedactPhoneNumber(input.AsSpan());

            // Assert
            Assert.AreEqual("AAA-AAA-AAAA", redactedPhoneNumber.ToString());
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedPhoneNumber_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "123-456-7890";

            // Act
            var redactedPhoneNumber = redactor.RedactPhoneNumber(input);

            // Assert
            Assert.AreEqual("***-***-****", redactedPhoneNumber);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedPhoneNumber_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "123-456-7890";

            // Act
            var redactedPhoneNumber = redactor.RedactPhoneNumber(input.AsSpan());

            // Assert
            Assert.AreEqual("***-***-****", redactedPhoneNumber.ToString());
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full });

            // Assert
            Assert.AreEqual("XXX-XXX-XXXX", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_CustomLength_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 10
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PhoneNumberRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
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
        public void PhoneNumberRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
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
        public void PhoneNumberRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAA-AAA-AAAA", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithConstructorOptions_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full });

            // Assert
            Assert.AreEqual("BBB-BBB-BBBB", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.Full });

            // Assert
            Assert.AreEqual("CCC-CCC-CCCC", result);
        }

        [TestMethod]
        public void PhoneNumberRedactorOptions_WithNoOptions_ShouldReturnRedactedPhoneNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactPhoneNumber("123-456-7890", new PhoneNumberRedactorOptions { });

            // Assert
            Assert.AreEqual("***-***-****", result);
        }
    }
}
