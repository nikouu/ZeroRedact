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

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
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

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
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

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
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

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactIpv4_All_ShouldReturnRedactedRedactIPv4_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactIPv4Address(input, new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.All });

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
            var result = redactor.RedactIPv4Address(input.AsSpan(), new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.All });

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
            var result = redactor.RedactIPv4Address(input, new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength });

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
            var result = redactor.RedactIPv4Address(input, new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength });

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
            var result = redactor.RedactIPv4Address(input, new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full });

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
            var result = redactor.RedactIPv4Address(input.AsSpan(), new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.Full });

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
            var result = redactor.RedactIPv4Address(input, new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.ShowLastOctet });

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
            var result = redactor.RedactIPv4Address(input.AsSpan(), new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.ShowLastOctet });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
