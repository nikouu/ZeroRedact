using System.Globalization;

namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class DateRedactorOptionsTests
    {
#pragma warning disable
        private CultureInfo _existingCulture;
#pragma warning restore CS8618
        [TestInitialize]
        public void Initialize()
        {
            _existingCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("en-NZ");
        }

        [TestCleanup]
        public void Cleanup()
        {
            CultureInfo.CurrentCulture = _existingCulture;
        }

        [TestMethod]
        public void DateRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedDate_DateTime()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = new DateTime(2023, 10, 5);

            // Act
            var redactedDate = redactor.RedactDate(input);

            // Assert
            Assert.AreEqual("X/XX/XXXX", redactedDate);
        }

        [TestMethod]
        public void DateRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedDate_DateOnly()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = new DateTime(2023, 10, 5);

            // Act
            var redactedDate = redactor.RedactDate(DateOnly.FromDateTime(input));

            // Assert
            Assert.AreEqual("X/XX/XXXX", redactedDate);
        }

        [TestMethod]
        public void DateRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedDate_DateTime()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = new DateTime(2023, 10, 5);

            // Act
            var redactedDate = redactor.RedactDate(input);

            // Assert
            Assert.AreEqual("*/**/****", redactedDate);
        }

        [TestMethod]
        public void DateRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedDate_DateOnly()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = new DateTime(2023, 10, 5);

            // Act
            var redactedDate = redactor.RedactDate(DateOnly.FromDateTime(input));

            // Assert
            Assert.AreEqual("*/**/****", redactedDate);
        }

        [TestMethod]
        public void DateRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.Full });

            // Assert
            Assert.AreEqual("X/XX/XXXX", result);
        }

        [TestMethod]
        public void DateRedactorOptions_CustomLength_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void DateRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
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
        public void DateRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                DateRedactorOptions = new DateRedactorOptions
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
        public void DateRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void DateRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("A/AA/AAAA", result);
        }

        [TestMethod]
        public void DateRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void DateRedactorOptions_WithConstructorOptions_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                DateRedactorOptions = new DateRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.Full });

            // Assert
            Assert.AreEqual("B/BB/BBBB", result);
        }

        [TestMethod]
        public void DateRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { RedactorType = DateRedaction.Full });

            // Assert
            Assert.AreEqual("C/CC/CCCC", result);
        }

        [TestMethod]
        public void DateRedactorOptions_WithNoOptions_ShouldReturnRedactedDate()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactDate(new DateTime(2023, 10, 5), new DateRedactorOptions { });

            // Assert
            Assert.AreEqual("*/**/****", result);
        }

    }
}
