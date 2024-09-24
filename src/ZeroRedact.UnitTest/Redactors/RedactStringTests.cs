#pragma warning disable CS8625
#pragma warning disable CS8618

namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactStringTests
    {
        private Redactor _redactor;

        [TestInitialize]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "a", "*" };
            yield return new object[] { "ab", "**" };
            yield return new object[] { "abcdefghi", "*********" };
            yield return new object[] { "abc123 !@#", "**********" };
            yield return new object[] { new string('a', 10_000), new string('*', 10_000) };
            yield return new object[] { null, "" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "a", "********" };
            yield return new object[] { "ab", "********" };
            yield return new object[] { "abcdefghi", "********" };
            yield return new object[] { "abc123 !@#", "********" };
            yield return new object[] { new string('a', 10_000), "********" };
            yield return new object[] { null, "" };
        }

        private static IEnumerable<object[]> FirstHalf_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "a", "*" };
            yield return new object[] { "ab", "*b" };
            yield return new object[] { "abcdefghi", "*****fghi" };
            yield return new object[] { "abc123 !@#", "*****3 !@#" };
            yield return new object[] { new string('a', 10_000), new string('*', 5_000) + new string('a', 5_000) };
            yield return new object[] { null, "" };
        }

        private static IEnumerable<object[]> SecondHalf_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "a", "*" };
            yield return new object[] { "ab", "a*" };
            yield return new object[] { "abcdefghi", "abcd*****" };
            yield return new object[] { "abc123 !@#", "abc12*****" };
            yield return new object[] { new string('a', 10_000), new string('a', 5_000) + new string('*', 5_000) };
            yield return new object[] { null, "" };
        }

        private static IEnumerable<object[]> IgnoreSymbols_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "a", "*" };
            yield return new object[] { "ab", "**" };
            yield return new object[] { "abcdefghi", "*********" };
            yield return new object[] { "abc123 !@#", "****** !@#" };
            yield return new object[] { new string('a', 10_000), new string('*', 10_000) };
            yield return new object[] { null, "" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FullRedaction_ShouldReturnRedactedString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FullRedaction_ShouldReturnRedactedString_ReadOnlySpan(string input, string expected)
        {
            // Act
            ReadOnlySpan<char> result = _redactor.RedactString(input.AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FixedLength_ShouldReturnRedactedString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FixedLength_ShouldReturnRedactedString_ReadOnlySpan(string input, string expected)
        {
            // Act
            ReadOnlySpan<char> result = _redactor.RedactString(input.AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FirstHalf_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FirstHalf_ShouldReturnRedactedString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FirstHalf_TestData), DynamicDataSourceType.Method)]
        public void RedactString_FirstHalf_ShouldReturnRedactedString_ReadOnlySpan(string input, string expected)
        {
            // Act
            ReadOnlySpan<char> result = _redactor.RedactString(input.AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(SecondHalf_TestData), DynamicDataSourceType.Method)]
        public void RedactString_SecondHalf_ShouldReturnRedactedString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.SecondHalf });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(SecondHalf_TestData), DynamicDataSourceType.Method)]
        public void RedactString_SecondHalf_ShouldReturnRedactedString_ReadOnlySpan(string input, string expected)
        {
            // Act
            ReadOnlySpan<char> result = _redactor.RedactString(input.AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.SecondHalf });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }


        [TestMethod]
        [DynamicData(nameof(IgnoreSymbols_TestData), DynamicDataSourceType.Method)]
        public void RedactString_IgnoreSymbols_ShouldReturnCorrectString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.IgnoreSymbols });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(IgnoreSymbols_TestData), DynamicDataSourceType.Method)]
        public void RedactString_IgnoreSymbols_ShouldReturnCorrectString_ReadOnlySpan(string input, string expected)
        {
            // Act
            ReadOnlySpan<char> result = _redactor.RedactString(input.AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.IgnoreSymbols });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
