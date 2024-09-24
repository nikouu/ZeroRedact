namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactMACAddressTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "00 1A 2B 3C 4D 5G", "********" };
            yield return new object[] { "00:1A:2B:3C:4D:5E", "*****************" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "***********************" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "00 1A 2B 3C 4D 5G", "********" };
            yield return new object[] { "00:1A:2B:3C:4D:5E", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };

        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "00 1A 2B 3C 4D 5G", "********" };
            yield return new object[] { "00:1A:2B:3C:4D:5E", "**:**:**:**:**:**" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "**:**:**:**:**:**:**:**" };

        }

        private static IEnumerable<object[]> ShowLastByte_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "00 1A 2B 3C 4D 5G", "********" };
            yield return new object[] { "00:1A:2B:3C:4D:5E", "**:**:**:**:**:5E" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "**:**:**:**:**:**:**:5E" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_All_ShouldReturnRedactedMacAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input, new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_All_ShouldReturnRedactedMacAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input.AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_FixedLength_ShouldReturnRedactedMacAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input, new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_FixedLength_ShouldReturnRedactedMacAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input.AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_Full_ShouldReturnRedactedMacAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input, new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_Full_ShouldReturnRedactedMacAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input.AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastByte_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_ShowLastByte_ShouldReturnRedactedMacAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input, new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.ShowLastByte });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastByte_TestData), DynamicDataSourceType.Method)]
        public void RedactMac_ShowLastByte_ShouldReturnRedactedMacAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactMACAddress(input.AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.ShowLastByte });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
