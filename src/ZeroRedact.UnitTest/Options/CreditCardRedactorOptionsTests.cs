namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class CreditCardRedactorOptionsTests
    {
        [TestMethod]
        public void CreditCardRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedCreditCardNumber_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "4111-1111-1111-1111";

            // Act
            var redactedCreditCard = redactor.RedactCreditCard(input);

            // Assert
            Assert.AreEqual("XXXX-XXXX-XXXX-XXXX", redactedCreditCard);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedCreditCardNumber_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "4111-1111-1111-1111";

            // Act
            var redactedCreditCard = redactor.RedactCreditCard(input.AsSpan());

            // Assert
            Assert.AreEqual("XXXX-XXXX-XXXX-XXXX", redactedCreditCard.ToString());
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedCreditCardNumber_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "4111-1111-1111-1111";

            // Act
            var redactedCreditCard = redactor.RedactCreditCard(input);

            // Assert
            Assert.AreEqual("****-****-****-****", redactedCreditCard);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedCreditCardNumber_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "4111-1111-1111-1111";

            // Act
            var redactedCreditCard = redactor.RedactCreditCard(input.AsSpan());

            // Assert
            Assert.AreEqual("****-****-****-****", redactedCreditCard.ToString());
        }

        [TestMethod]
        public void CreditCardRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXXXXXXXXX", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_CustomLength_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreditCardRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
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
        public void CreditCardRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                CreditCardRedactorOptions = new CreditCardRedactorOptions
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
        public void CreditCardRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAAA-AAAA-AAAA-AAAA", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithConstructorOptions_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                CreditCardRedactorOptions = new CreditCardRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.Full });

            // Assert
            Assert.AreEqual("BBBB-BBBB-BBBB-BBBB", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.Full });

            // Assert
            Assert.AreEqual("CCCC-CCCC-CCCC-CCCC", result);
        }

        [TestMethod]
        public void CreditCardRedactorOptions_WithNoOptions_ShouldReturnRedactedCreditCardNumber()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactCreditCard("4111-1111-1111-1111", new CreditCardRedactorOptions { });

            // Assert
            Assert.AreEqual("****-****-****-****", result);
        }
    }
}
