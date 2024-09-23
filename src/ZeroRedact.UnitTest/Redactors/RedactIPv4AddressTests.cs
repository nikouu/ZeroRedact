namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactIPv4AddressTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "0", "********" };
            yield return new object[] { "0.0", "********" };
            yield return new object[] { "0.0.0", "********" };
            yield return new object[] { "0.0.0.0.0", "********" };
            yield return new object[] { "0.0.0.0/24", "********" };

            yield return new object[] { "1.1.1.1", "*******" };
            yield return new object[] { "1.1.1.10", "********" };
            yield return new object[] { "1.1.1.100", "*********" };
            yield return new object[] { "1.1.10.1", "********" };
            yield return new object[] { "1.1.10.10", "*********" };
            yield return new object[] { "1.1.10.100", "**********" };
            yield return new object[] { "1.1.100.1", "*********" };
            yield return new object[] { "1.1.100.10", "**********" };
            yield return new object[] { "1.1.100.100", "***********" };
            yield return new object[] { "1.10.1.1", "********" };
            yield return new object[] { "1.10.1.10", "*********" };
            yield return new object[] { "1.10.1.100", "**********" };
            yield return new object[] { "1.10.10.1", "*********" };
            yield return new object[] { "1.10.10.10", "**********" };
            yield return new object[] { "1.10.10.100", "***********" };
            yield return new object[] { "1.10.100.1", "**********" };
            yield return new object[] { "1.10.100.10", "***********" };
            yield return new object[] { "1.10.100.100", "************" };
            yield return new object[] { "1.100.1.1", "*********" };
            yield return new object[] { "1.100.1.10", "**********" };
            yield return new object[] { "1.100.1.100", "***********" };
            yield return new object[] { "1.100.10.1", "**********" };
            yield return new object[] { "1.100.10.10", "***********" };
            yield return new object[] { "1.100.10.100", "************" };
            yield return new object[] { "1.100.100.1", "***********" };
            yield return new object[] { "1.100.100.10", "************" };
            yield return new object[] { "1.100.100.100", "*************" };
            yield return new object[] { "10.1.1.1", "********" };
            yield return new object[] { "10.1.1.10", "*********" };
            yield return new object[] { "10.1.1.100", "**********" };
            yield return new object[] { "10.1.10.1", "*********" };
            yield return new object[] { "10.1.10.10", "**********" };
            yield return new object[] { "10.1.10.100", "***********" };
            yield return new object[] { "10.1.100.1", "**********" };
            yield return new object[] { "10.1.100.10", "***********" };
            yield return new object[] { "10.1.100.100", "************" };
            yield return new object[] { "10.10.1.1", "*********" };
            yield return new object[] { "10.10.1.10", "**********" };
            yield return new object[] { "10.10.1.100", "***********" };
            yield return new object[] { "10.10.10.1", "**********" };
            yield return new object[] { "10.10.10.10", "***********" };
            yield return new object[] { "10.10.10.100", "************" };
            yield return new object[] { "10.10.100.1", "***********" };
            yield return new object[] { "10.10.100.10", "************" };
            yield return new object[] { "10.10.100.100", "*************" };
            yield return new object[] { "10.100.1.1", "**********" };
            yield return new object[] { "10.100.1.10", "***********" };
            yield return new object[] { "10.100.1.100", "************" };
            yield return new object[] { "10.100.10.1", "***********" };
            yield return new object[] { "10.100.10.10", "************" };
            yield return new object[] { "10.100.10.100", "*************" };
            yield return new object[] { "10.100.100.1", "************" };
            yield return new object[] { "10.100.100.10", "*************" };
            yield return new object[] { "10.100.100.100", "**************" };
            yield return new object[] { "100.1.1.1", "*********" };
            yield return new object[] { "100.1.1.10", "**********" };
            yield return new object[] { "100.1.1.100", "***********" };
            yield return new object[] { "100.1.10.1", "**********" };
            yield return new object[] { "100.1.10.10", "***********" };
            yield return new object[] { "100.1.10.100", "************" };
            yield return new object[] { "100.1.100.1", "***********" };
            yield return new object[] { "100.1.100.10", "************" };
            yield return new object[] { "100.1.100.100", "*************" };
            yield return new object[] { "100.10.1.1", "**********" };
            yield return new object[] { "100.10.1.10", "***********" };
            yield return new object[] { "100.10.1.100", "************" };
            yield return new object[] { "100.10.10.1", "***********" };
            yield return new object[] { "100.10.10.10", "************" };
            yield return new object[] { "100.10.10.100", "*************" };
            yield return new object[] { "100.10.100.1", "************" };
            yield return new object[] { "100.10.100.10", "*************" };
            yield return new object[] { "100.10.100.100", "**************" };
            yield return new object[] { "100.100.1.1", "***********" };
            yield return new object[] { "100.100.1.10", "************" };
            yield return new object[] { "100.100.1.100", "*************" };
            yield return new object[] { "100.100.10.1", "************" };
            yield return new object[] { "100.100.10.10", "*************" };
            yield return new object[] { "100.100.10.100", "**************" };
            yield return new object[] { "100.100.100.1", "*************" };
            yield return new object[] { "100.100.100.10", "**************" };
            yield return new object[] { "100.100.100.100", "***************" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "0", "********" };
            yield return new object[] { "0.0", "********" };
            yield return new object[] { "0.0.0", "********" };
            yield return new object[] { "0.0.0.0.0", "********" };
            yield return new object[] { "0.0.0.0/24", "********" };

            yield return new object[] { "1.1.1.1", "********" };
            yield return new object[] { "1.1.1.10", "********" };
            yield return new object[] { "1.1.1.100", "********" };
            yield return new object[] { "1.1.10.1", "********" };
            yield return new object[] { "1.1.10.10", "********" };
            yield return new object[] { "1.1.10.100", "********" };
            yield return new object[] { "1.1.100.1", "********" };
            yield return new object[] { "1.1.100.10", "********" };
            yield return new object[] { "1.1.100.100", "********" };
            yield return new object[] { "1.10.1.1", "********" };
            yield return new object[] { "1.10.1.10", "********" };
            yield return new object[] { "1.10.1.100", "********" };
            yield return new object[] { "1.10.10.1", "********" };
            yield return new object[] { "1.10.10.10", "********" };
            yield return new object[] { "1.10.10.100", "********" };
            yield return new object[] { "1.10.100.1", "********" };
            yield return new object[] { "1.10.100.10", "********" };
            yield return new object[] { "1.10.100.100", "********" };
            yield return new object[] { "1.100.1.1", "********" };
            yield return new object[] { "1.100.1.10", "********" };
            yield return new object[] { "1.100.1.100", "********" };
            yield return new object[] { "1.100.10.1", "********" };
            yield return new object[] { "1.100.10.10", "********" };
            yield return new object[] { "1.100.10.100", "********" };
            yield return new object[] { "1.100.100.1", "********" };
            yield return new object[] { "1.100.100.10", "********" };
            yield return new object[] { "1.100.100.100", "********" };
            yield return new object[] { "10.1.1.1", "********" };
            yield return new object[] { "10.1.1.10", "********" };
            yield return new object[] { "10.1.1.100", "********" };
            yield return new object[] { "10.1.10.1", "********" };
            yield return new object[] { "10.1.10.10", "********" };
            yield return new object[] { "10.1.10.100", "********" };
            yield return new object[] { "10.1.100.1", "********" };
            yield return new object[] { "10.1.100.10", "********" };
            yield return new object[] { "10.1.100.100", "********" };
            yield return new object[] { "10.10.1.1", "********" };
            yield return new object[] { "10.10.1.10", "********" };
            yield return new object[] { "10.10.1.100", "********" };
            yield return new object[] { "10.10.10.1", "********" };
            yield return new object[] { "10.10.10.10", "********" };
            yield return new object[] { "10.10.10.100", "********" };
            yield return new object[] { "10.10.100.1", "********" };
            yield return new object[] { "10.10.100.10", "********" };
            yield return new object[] { "10.10.100.100", "********" };
            yield return new object[] { "10.100.1.1", "********" };
            yield return new object[] { "10.100.1.10", "********" };
            yield return new object[] { "10.100.1.100", "********" };
            yield return new object[] { "10.100.10.1", "********" };
            yield return new object[] { "10.100.10.10", "********" };
            yield return new object[] { "10.100.10.100", "********" };
            yield return new object[] { "10.100.100.1", "********" };
            yield return new object[] { "10.100.100.10", "********" };
            yield return new object[] { "10.100.100.100", "********" };
            yield return new object[] { "100.1.1.1", "********" };
            yield return new object[] { "100.1.1.10", "********" };
            yield return new object[] { "100.1.1.100", "********" };
            yield return new object[] { "100.1.10.1", "********" };
            yield return new object[] { "100.1.10.10", "********" };
            yield return new object[] { "100.1.10.100", "********" };
            yield return new object[] { "100.1.100.1", "********" };
            yield return new object[] { "100.1.100.10", "********" };
            yield return new object[] { "100.1.100.100", "********" };
            yield return new object[] { "100.10.1.1", "********" };
            yield return new object[] { "100.10.1.10", "********" };
            yield return new object[] { "100.10.1.100", "********" };
            yield return new object[] { "100.10.10.1", "********" };
            yield return new object[] { "100.10.10.10", "********" };
            yield return new object[] { "100.10.10.100", "********" };
            yield return new object[] { "100.10.100.1", "********" };
            yield return new object[] { "100.10.100.10", "********" };
            yield return new object[] { "100.10.100.100", "********" };
            yield return new object[] { "100.100.1.1", "********" };
            yield return new object[] { "100.100.1.10", "********" };
            yield return new object[] { "100.100.1.100", "********" };
            yield return new object[] { "100.100.10.1", "********" };
            yield return new object[] { "100.100.10.10", "********" };
            yield return new object[] { "100.100.10.100", "********" };
            yield return new object[] { "100.100.100.1", "********" };
            yield return new object[] { "100.100.100.10", "********" };
            yield return new object[] { "100.100.100.100", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "0", "********" };
            yield return new object[] { "0.0", "********" };
            yield return new object[] { "0.0.0", "********" };
            yield return new object[] { "0.0.0.0.0", "********" };
            yield return new object[] { "0.0.0.0/24", "********" };

            yield return new object[] { "1.1.1.1", "*.*.*.*" };
            yield return new object[] { "1.1.1.10", "*.*.*.**" };
            yield return new object[] { "1.1.1.100", "*.*.*.***" };
            yield return new object[] { "1.1.10.1", "*.*.**.*" };
            yield return new object[] { "1.1.10.10", "*.*.**.**" };
            yield return new object[] { "1.1.10.100", "*.*.**.***" };
            yield return new object[] { "1.1.100.1", "*.*.***.*" };
            yield return new object[] { "1.1.100.10", "*.*.***.**" };
            yield return new object[] { "1.1.100.100", "*.*.***.***" };
            yield return new object[] { "1.10.1.1", "*.**.*.*" };
            yield return new object[] { "1.10.1.10", "*.**.*.**" };
            yield return new object[] { "1.10.1.100", "*.**.*.***" };
            yield return new object[] { "1.10.10.1", "*.**.**.*" };
            yield return new object[] { "1.10.10.10", "*.**.**.**" };
            yield return new object[] { "1.10.10.100", "*.**.**.***" };
            yield return new object[] { "1.10.100.1", "*.**.***.*" };
            yield return new object[] { "1.10.100.10", "*.**.***.**" };
            yield return new object[] { "1.10.100.100", "*.**.***.***" };
            yield return new object[] { "1.100.1.1", "*.***.*.*" };
            yield return new object[] { "1.100.1.10", "*.***.*.**" };
            yield return new object[] { "1.100.1.100", "*.***.*.***" };
            yield return new object[] { "1.100.10.1", "*.***.**.*" };
            yield return new object[] { "1.100.10.10", "*.***.**.**" };
            yield return new object[] { "1.100.10.100", "*.***.**.***" };
            yield return new object[] { "1.100.100.1", "*.***.***.*" };
            yield return new object[] { "1.100.100.10", "*.***.***.**" };
            yield return new object[] { "1.100.100.100", "*.***.***.***" };
            yield return new object[] { "10.1.1.1", "**.*.*.*" };
            yield return new object[] { "10.1.1.10", "**.*.*.**" };
            yield return new object[] { "10.1.1.100", "**.*.*.***" };
            yield return new object[] { "10.1.10.1", "**.*.**.*" };
            yield return new object[] { "10.1.10.10", "**.*.**.**" };
            yield return new object[] { "10.1.10.100", "**.*.**.***" };
            yield return new object[] { "10.1.100.1", "**.*.***.*" };
            yield return new object[] { "10.1.100.10", "**.*.***.**" };
            yield return new object[] { "10.1.100.100", "**.*.***.***" };
            yield return new object[] { "10.10.1.1", "**.**.*.*" };
            yield return new object[] { "10.10.1.10", "**.**.*.**" };
            yield return new object[] { "10.10.1.100", "**.**.*.***" };
            yield return new object[] { "10.10.10.1", "**.**.**.*" };
            yield return new object[] { "10.10.10.10", "**.**.**.**" };
            yield return new object[] { "10.10.10.100", "**.**.**.***" };
            yield return new object[] { "10.10.100.1", "**.**.***.*" };
            yield return new object[] { "10.10.100.10", "**.**.***.**" };
            yield return new object[] { "10.10.100.100", "**.**.***.***" };
            yield return new object[] { "10.100.1.1", "**.***.*.*" };
            yield return new object[] { "10.100.1.10", "**.***.*.**" };
            yield return new object[] { "10.100.1.100", "**.***.*.***" };
            yield return new object[] { "10.100.10.1", "**.***.**.*" };
            yield return new object[] { "10.100.10.10", "**.***.**.**" };
            yield return new object[] { "10.100.10.100", "**.***.**.***" };
            yield return new object[] { "10.100.100.1", "**.***.***.*" };
            yield return new object[] { "10.100.100.10", "**.***.***.**" };
            yield return new object[] { "10.100.100.100", "**.***.***.***" };
            yield return new object[] { "100.1.1.1", "***.*.*.*" };
            yield return new object[] { "100.1.1.10", "***.*.*.**" };
            yield return new object[] { "100.1.1.100", "***.*.*.***" };
            yield return new object[] { "100.1.10.1", "***.*.**.*" };
            yield return new object[] { "100.1.10.10", "***.*.**.**" };
            yield return new object[] { "100.1.10.100", "***.*.**.***" };
            yield return new object[] { "100.1.100.1", "***.*.***.*" };
            yield return new object[] { "100.1.100.10", "***.*.***.**" };
            yield return new object[] { "100.1.100.100", "***.*.***.***" };
            yield return new object[] { "100.10.1.1", "***.**.*.*" };
            yield return new object[] { "100.10.1.10", "***.**.*.**" };
            yield return new object[] { "100.10.1.100", "***.**.*.***" };
            yield return new object[] { "100.10.10.1", "***.**.**.*" };
            yield return new object[] { "100.10.10.10", "***.**.**.**" };
            yield return new object[] { "100.10.10.100", "***.**.**.***" };
            yield return new object[] { "100.10.100.1", "***.**.***.*" };
            yield return new object[] { "100.10.100.10", "***.**.***.**" };
            yield return new object[] { "100.10.100.100", "***.**.***.***" };
            yield return new object[] { "100.100.1.1", "***.***.*.*" };
            yield return new object[] { "100.100.1.10", "***.***.*.**" };
            yield return new object[] { "100.100.1.100", "***.***.*.***" };
            yield return new object[] { "100.100.10.1", "***.***.**.*" };
            yield return new object[] { "100.100.10.10", "***.***.**.**" };
            yield return new object[] { "100.100.10.100", "***.***.**.***" };
            yield return new object[] { "100.100.100.1", "***.***.***.*" };
            yield return new object[] { "100.100.100.10", "***.***.***.**" };
            yield return new object[] { "100.100.100.100", "***.***.***.***" };
        }

        private static IEnumerable<object[]> ShowLastOctet_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { null!, "" };
            yield return new object[] { "0", "********" };
            yield return new object[] { "0.0", "********" };
            yield return new object[] { "0.0.0", "********" };
            yield return new object[] { "0.0.0.0.0", "********" };
            yield return new object[] { "0.0.0.0/24", "********" };

            yield return new object[] { "1.1.1.1", "*.*.*.1" };
            yield return new object[] { "1.1.1.10", "*.*.*.10" };
            yield return new object[] { "1.1.1.100", "*.*.*.100" };
            yield return new object[] { "1.1.10.1", "*.*.**.1" };
            yield return new object[] { "1.1.10.10", "*.*.**.10" };
            yield return new object[] { "1.1.10.100", "*.*.**.100" };
            yield return new object[] { "1.1.100.1", "*.*.***.1" };
            yield return new object[] { "1.1.100.10", "*.*.***.10" };
            yield return new object[] { "1.1.100.100", "*.*.***.100" };
            yield return new object[] { "1.10.1.1", "*.**.*.1" };
            yield return new object[] { "1.10.1.10", "*.**.*.10" };
            yield return new object[] { "1.10.1.100", "*.**.*.100" };
            yield return new object[] { "1.10.10.1", "*.**.**.1" };
            yield return new object[] { "1.10.10.10", "*.**.**.10" };
            yield return new object[] { "1.10.10.100", "*.**.**.100" };
            yield return new object[] { "1.10.100.1", "*.**.***.1" };
            yield return new object[] { "1.10.100.10", "*.**.***.10" };
            yield return new object[] { "1.10.100.100", "*.**.***.100" };
            yield return new object[] { "1.100.1.1", "*.***.*.1" };
            yield return new object[] { "1.100.1.10", "*.***.*.10" };
            yield return new object[] { "1.100.1.100", "*.***.*.100" };
            yield return new object[] { "1.100.10.1", "*.***.**.1" };
            yield return new object[] { "1.100.10.10", "*.***.**.10" };
            yield return new object[] { "1.100.10.100", "*.***.**.100" };
            yield return new object[] { "1.100.100.1", "*.***.***.1" };
            yield return new object[] { "1.100.100.10", "*.***.***.10" };
            yield return new object[] { "1.100.100.100", "*.***.***.100" };
            yield return new object[] { "10.1.1.1", "**.*.*.1" };
            yield return new object[] { "10.1.1.10", "**.*.*.10" };
            yield return new object[] { "10.1.1.100", "**.*.*.100" };
            yield return new object[] { "10.1.10.1", "**.*.**.1" };
            yield return new object[] { "10.1.10.10", "**.*.**.10" };
            yield return new object[] { "10.1.10.100", "**.*.**.100" };
            yield return new object[] { "10.1.100.1", "**.*.***.1" };
            yield return new object[] { "10.1.100.10", "**.*.***.10" };
            yield return new object[] { "10.1.100.100", "**.*.***.100" };
            yield return new object[] { "10.10.1.1", "**.**.*.1" };
            yield return new object[] { "10.10.1.10", "**.**.*.10" };
            yield return new object[] { "10.10.1.100", "**.**.*.100" };
            yield return new object[] { "10.10.10.1", "**.**.**.1" };
            yield return new object[] { "10.10.10.10", "**.**.**.10" };
            yield return new object[] { "10.10.10.100", "**.**.**.100" };
            yield return new object[] { "10.10.100.1", "**.**.***.1" };
            yield return new object[] { "10.10.100.10", "**.**.***.10" };
            yield return new object[] { "10.10.100.100", "**.**.***.100" };
            yield return new object[] { "10.100.1.1", "**.***.*.1" };
            yield return new object[] { "10.100.1.10", "**.***.*.10" };
            yield return new object[] { "10.100.1.100", "**.***.*.100" };
            yield return new object[] { "10.100.10.1", "**.***.**.1" };
            yield return new object[] { "10.100.10.10", "**.***.**.10" };
            yield return new object[] { "10.100.10.100", "**.***.**.100" };
            yield return new object[] { "10.100.100.1", "**.***.***.1" };
            yield return new object[] { "10.100.100.10", "**.***.***.10" };
            yield return new object[] { "10.100.100.100", "**.***.***.100" };
            yield return new object[] { "100.1.1.1", "***.*.*.1" };
            yield return new object[] { "100.1.1.10", "***.*.*.10" };
            yield return new object[] { "100.1.1.100", "***.*.*.100" };
            yield return new object[] { "100.1.10.1", "***.*.**.1" };
            yield return new object[] { "100.1.10.10", "***.*.**.10" };
            yield return new object[] { "100.1.10.100", "***.*.**.100" };
            yield return new object[] { "100.1.100.1", "***.*.***.1" };
            yield return new object[] { "100.1.100.10", "***.*.***.10" };
            yield return new object[] { "100.1.100.100", "***.*.***.100" };
            yield return new object[] { "100.10.1.1", "***.**.*.1" };
            yield return new object[] { "100.10.1.10", "***.**.*.10" };
            yield return new object[] { "100.10.1.100", "***.**.*.100" };
            yield return new object[] { "100.10.10.1", "***.**.**.1" };
            yield return new object[] { "100.10.10.10", "***.**.**.10" };
            yield return new object[] { "100.10.10.100", "***.**.**.100" };
            yield return new object[] { "100.10.100.1", "***.**.***.1" };
            yield return new object[] { "100.10.100.10", "***.**.***.10" };
            yield return new object[] { "100.10.100.100", "***.**.***.100" };
            yield return new object[] { "100.100.1.1", "***.***.*.1" };
            yield return new object[] { "100.100.1.10", "***.***.*.10" };
            yield return new object[] { "100.100.1.100", "***.***.*.100" };
            yield return new object[] { "100.100.10.1", "***.***.**.1" };
            yield return new object[] { "100.100.10.10", "***.***.**.10" };
            yield return new object[] { "100.100.10.100", "***.***.**.100" };
            yield return new object[] { "100.100.100.1", "***.***.***.1" };
            yield return new object[] { "100.100.100.10", "***.***.***.10" };
            yield return new object[] { "100.100.100.100", "***.***.***.100" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_All_ShouldReturnRedactedRedactIPv4_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input, new IPv4RedactorOptions { RedactorType = IPv4Redaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_All_ShouldReturnRedactedRedactIPv4_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input.AsSpan(), new IPv4RedactorOptions { RedactorType = IPv4Redaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_FixedLength_ShouldReturnRedactedRedactIPv4_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input, new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_FixedLength_ShouldReturnRedactedRedactIPv4_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input, new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_Full_ShouldReturnRedactedRedactIPv4_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input, new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_Full_ShouldReturnRedactedRedactIPv4_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input.AsSpan(), new IPv4RedactorOptions { RedactorType = IPv4Redaction.Full });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastOctet_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_ShowLastOctet_ShouldReturnRedactedRedactIPv4_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input, new IPv4RedactorOptions { RedactorType = IPv4Redaction.ShowLastOctet });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowLastOctet_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_ShowLastOctet_ShouldReturnRedactedRedactIPv4_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4(input.AsSpan(), new IPv4RedactorOptions { RedactorType = IPv4Redaction.ShowLastOctet });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
