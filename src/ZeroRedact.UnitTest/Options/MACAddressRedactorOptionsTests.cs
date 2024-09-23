namespace ZeroRedact.UnitTest.Options
{
    [TestClass]
    public class MACAddressRedactorOptionsTests
    {
        [TestMethod]
        public void MACAddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedMACAddress_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "00:1A:2B:3C:4D:5E";

            // Act
            var redactedMACAddress = redactor.RedactMACAddress(input);

            // Assert
            Assert.AreEqual("XX:XX:XX:XX:XX:XX", redactedMACAddress);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithConstructorCharacterOptions_ShouldReturnRedactedMACAddress_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "00:1A:2B:3C:4D:5E";

            // Act
            var redactedMACAddress = redactor.RedactMACAddress(input.AsSpan());

            // Assert
            Assert.AreEqual("XX:XX:XX:XX:XX:XX", redactedMACAddress.ToString());
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedMACAddress_String()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    FixedLengthSize = 6
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "00:1A:2B:3C:4D:5E";

            // Act
            var redactedMACAddress = redactor.RedactMACAddress(input);

            // Assert
            Assert.AreEqual("**:**:**:**:**:**", redactedMACAddress);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithConstructorLengthOptions_ShouldReturnRedactedMACAddress_ReadOnlySpan()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    FixedLengthSize = 6
                }
            };
            var redactor = new Redactor(redactorOptions);
            var input = "00:1A:2B:3C:4D:5E";

            // Act
            var redactedMACAddress = redactor.RedactMACAddress(input.AsSpan());

            // Assert
            Assert.AreEqual("**:**:**:**:**:**", redactedMACAddress.ToString());
        }

        [TestMethod]
        public void MACAddressRedactorOptions_CustomRedactionCharacter_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'X'
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXXXXXXX", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_CustomLength_ShouldReturnRedactedMacAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    FixedLengthSize = 6
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("******", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_CustomRedactionCharacterCustomLength_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'X',
                    FixedLengthSize = 12
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual("XXXXXXXXXXXX", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MACAddressRedactorOptions_WhenFixedLengthSizeIsZero_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
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
        public void MACAddressRedactorOptions_WhenFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var options = new RedactorOptions
            {
                MACAddressRedactorOptions = new MACAddressRedactorOptions
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
        public void MACAddressRedactorOptions_WhenMethodFixedLengthSizeIsNegative_ShouldThrowException()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength, FixedLengthSize = -1 });

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithMethodCharacterOptions_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.Full, RedactionCharacter = 'A' });

            // Assert
            Assert.AreEqual("AA:AA:AA:AA:AA:AA", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithMethodLengthOptions_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength, FixedLengthSize = 1 });

            // Assert
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithConstructorOptions_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C',
                MACAddressRedactorOptions = new MACAddressRedactorOptions
                {
                    RedactionCharacter = 'B',
                }
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.Full });

            // Assert
            Assert.AreEqual("BB:BB:BB:BB:BB:BB", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithBaseConstructorOptions_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
                RedactionCharacter = 'C'
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.Full });

            // Assert
            Assert.AreEqual("CC:CC:CC:CC:CC:CC", result);
        }

        [TestMethod]
        public void MACAddressRedactorOptions_WithNoOptions_ShouldReturnRedactedMACAddress()
        {
            // Arrange
            var redactorOptions = new RedactorOptions
            {
            };
            var redactor = new Redactor(redactorOptions);

            // Act
            string result = redactor.RedactMACAddress("00:1A:2B:3C:4D:5E", new MACAddressRedactorOptions { });

            // Assert
            Assert.AreEqual("**:**:**:**:**:**", result);
        }
    }
}
