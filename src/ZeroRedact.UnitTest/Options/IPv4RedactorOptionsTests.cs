namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class IPv4RedactorOptionsTests
    {
        [TestMethod]
        public void IPv4RedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv4_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void IPv4RedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv4_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void IPv4RedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv4_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void IPv4RedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv4_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void IPv4RedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full });

            // Assert
            Assert.AreEqual("XXX.XXX.X.X", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_CustomLength_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
                {
                    FixedLengthSize = 4
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength });

            // Assert
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IPv4RedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void IPv4RedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv4RedactorOptions = new IPv4RedactorOptions
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
        public void Ipv4RedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void IPv4RedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv4RedactorOptions = new IPv4RedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAA.AAA.A.A", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_WithConstructorOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv4RedactorOptions = new IPv4RedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full });

            // Assert
            Assert.AreEqual("BBB.BBB.B.B", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full });

            // Assert
            Assert.AreEqual("CCC.CCC.C.C", result);
        }

        [TestMethod]
        public void IPv4RedactorOptions_WithNoOptions_ShouldReturnRedactedIPv4()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv4Address("192.168.1.1", new IPv4RedactorOptions { });

            // Assert
            Assert.AreEqual("***.***.*.*", result);
        }
    }
}
