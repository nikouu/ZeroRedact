namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class IPv4AddressRedactorOptionsTests
    {
        [TestMethod]
        public void IPv4AddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv4_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "192.168.1.1";

            // Act
            var redactedIPv4 = redactor.RedactIPv4Address(input);

            // Assert
            Assert.AreEqual("XXX.XXX.X.X", redactedIPv4);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv4_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "192.168.1.1";

            // Act
            var redactedIPv4 = redactor.RedactIPv4Address(input.AsSpan());

            // Assert
            Assert.AreEqual("XXX.XXX.X.X", redactedIPv4.ToString());
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv4_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "192.168.1.1";

            // Act
            var redactedIPv4 = redactor.RedactIPv4Address(input);

            // Assert
            Assert.AreEqual("***.***.*.*", redactedIPv4);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv4_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "192.168.1.1";

            // Act
            var redactedIPv4 = redactor.RedactIPv4Address(input.AsSpan());

            // Assert
            Assert.AreEqual("***.***.*.*", redactedIPv4.ToString());
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full });

            // Assert
            Assert.AreEqual("XXX.XXX.X.X", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_CustomLength_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IPv4AddressRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
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
        public void IPv4AddressRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
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
        public void IPv4AddressRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAA.AAA.A.A", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithConstructorOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full });

            // Assert
            Assert.AreEqual("BBB.BBB.B.B", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full });

            // Assert
            Assert.AreEqual("CCC.CCC.C.C", result);
        }

        [TestMethod]
        public void IPv4AddressRedactorOptions_WithNoOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4AddressRedactorOptions { });

            // Assert
            Assert.AreEqual("***.***.*.*", result);
        }
    }
}
