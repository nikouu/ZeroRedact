namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class IPv6RedactorOptionsTests
    {
        [TestMethod]
        public void IPv6RedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv6_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";

            // Act
            var redactedIPv6 = redactor.RedactIPv6(input);

            // Assert
            Assert.AreEqual("XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX", redactedIPv6);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedIPv6_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";

            // Act
            var redactedIPv6 = redactor.RedactIPv6(input.AsSpan());

            // Assert
            Assert.AreEqual("XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX:XXXX", redactedIPv6.ToString());
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv6_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";

            // Act
            var redactedIPv6 = redactor.RedactIPv6(input);

            // Assert
            Assert.AreEqual("****:****:****:****:****:****:****:****", redactedIPv6);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedIPv6_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    FixedLengthSize = 1
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";

            // Act
            var redactedIPv6 = redactor.RedactIPv6(input.AsSpan());

            // Assert
            Assert.AreEqual("****:****:****:****:****:****:****:****", redactedIPv6.ToString());
        }

        [TestMethod]
        public void IPv6RedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.All });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_CustomLength_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    FixedLengthSize = 8
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength });

            // Assert
            Assert.AreEqual("********", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 16
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IPv6RedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
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
        public void IPv6RedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                IPv6RedactorOptions = new IPv6RedactorOptions
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
        public void Ipv6RedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithConstructorOptions_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AAAA:AAAA:AAAA:AAAA:AAAA:AAAA:AAAA:AAAA", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                IPv6RedactorOptions = new IPv6RedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.Full });

            // Assert
            Assert.AreEqual("BBBB:BBBB:BBBB:BBBB:BBBB:BBBB:BBBB:BBBB", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.Full });

            // Assert
            Assert.AreEqual("CCCC:CCCC:CCCC:CCCC:CCCC:CCCC:CCCC:CCCC", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void IPv6RedactorOptions_WithNoOptions_ShouldReturnRedactedIPv6()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactIPv6("2001:0db8:85a3:0000:0000:8a2e:0370:7334", new IPv6RedactorOptions { });

            // Assert
            Assert.AreEqual("****:****:****:****:****:****:****:****", result);
        }
    }
}
