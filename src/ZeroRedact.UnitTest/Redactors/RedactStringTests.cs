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

            yield return new object[] { "4111 1111 1111 1111", "*******************" };
            yield return new object[] { "2023/06/15", "**********" };
            yield return new object[] { "email@example.com", "*****************" };
            yield return new object[] { "100.100.100.100", "***************" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "***************************************" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "***********************" };
            yield return new object[] { "+1 (555) 123-4567", "*****************" };
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

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "100.100.100.100", "********"};
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
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

            yield return new object[] { "4111 1111 1111 1111", "**********1111 1111" };
            yield return new object[] { "2023/06/15", "*****06/15" };
            yield return new object[] { "email@example.com", "*********mple.com" };
            yield return new object[] { "100.100.100.100", "********100.100" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********************0000:8a2e:0370:7334" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "************FE:3C:4D:5E" };
            yield return new object[] { "+1 (555) 123-4567", "*********123-4567" };
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

            yield return new object[] { "4111 1111 1111 1111", "4111 1111**********" };
            yield return new object[] { "2023/06/15", "2023/*****" };
            yield return new object[] { "email@example.com", "email@ex*********" };
            yield return new object[] { "100.100.100.100", "100.100********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "2001:0db8:85a3:0000********************" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "00:1A:2B:FF************" };
            yield return new object[] { "+1 (555) 123-4567", "+1 (555)*********" };
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

            yield return new object[] { "4111 1111 1111 1111", "**** **** **** ****" };
            yield return new object[] { "2023/06/15", "****/**/**" };
            yield return new object[] { "email@example.com", "*****@*******.***" };
            yield return new object[] { "100.100.100.100", "***.***.***.***" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "****:****:****:****:****:****:****:****" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "**:**:**:**:**:**:**:**" };
            yield return new object[] { "+1 (555) 123-4567", "+* (***) ***-****" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactString_AllRedaction_ShouldReturnRedactedString_String(string input, string expected)
        {
            // Act
            string result = _redactor.RedactString(input, new StringRedactorOptions { RedactorType = StringRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactString_AllRedaction_ShouldReturnRedactedString_ReadOnlySpan(string input, string expected)
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
