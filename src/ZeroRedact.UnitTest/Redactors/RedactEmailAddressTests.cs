namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactEmailAddressTests
    {
        private static IEnumerable<object[]> All_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "*****************" };
            yield return new object[] { "firstname.lastname@example.com", "******************************" };
            yield return new object[] { "email@subdomain.example.com", "***************************" };
            yield return new object[] { "firstname+lastname@example.com", "******************************" };
            yield return new object[] { "1234567890@example.com", "**********************" };
            yield return new object[] { "email@example-one.com", "*********************" };
            yield return new object[] { "_______@example.com", "*******************" };
            yield return new object[] { "email@example.name", "******************" };
            yield return new object[] { "email@example.museum", "********************" };
            yield return new object[] { "email@example.co.jp", "*******************" };
            yield return new object[] { "firstname-lastname@example.com", "******************************" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "****************" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "*****************************" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "*************************" };
            yield return new object[] { ".email@example.com", "******************" };
            yield return new object[] { "email.@example.com", "******************" };
            yield return new object[] { "email..email@example.com", "************************" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****************************" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "******************" };
            yield return new object[] { "email@[123.123.123.123]", "***********************" };
            yield return new object[] { "email@123.123.123.123", "*********************" };
            yield return new object[] { "email@111.222.333.44444", "***********************" };
            yield return new object[] { "email@example..com", "******************" };
            yield return new object[] { "\"email\"@example.com", "*******************" };
            yield return new object[] { "Abc..123@example.com", "********************" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "***********************" };
            yield return new object[] { "just”not”right@example.com", "**************************" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "***************************************" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "********************************" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "*****************************************************************" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "****************************************" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> FixedLength_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "********" };
            yield return new object[] { "firstname.lastname@example.com", "********" };
            yield return new object[] { "email@subdomain.example.com", "********" };
            yield return new object[] { "firstname+lastname@example.com", "********" };
            yield return new object[] { "1234567890@example.com", "********" };
            yield return new object[] { "email@example-one.com", "********" };
            yield return new object[] { "_______@example.com", "********" };
            yield return new object[] { "email@example.name", "********" };
            yield return new object[] { "email@example.museum", "********" };
            yield return new object[] { "email@example.co.jp", "********" };
            yield return new object[] { "firstname-lastname@example.com", "********" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "********" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "********" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "********" };
            yield return new object[] { ".email@example.com", "********" };
            yield return new object[] { "email.@example.com", "********" };
            yield return new object[] { "email..email@example.com", "********" };
            yield return new object[] { "email@example.com (Joe Smith)", "********" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "********" };
            yield return new object[] { "email@[123.123.123.123]", "********" };
            yield return new object[] { "email@123.123.123.123", "********" };
            yield return new object[] { "email@111.222.333.44444", "********" };
            yield return new object[] { "email@example..com", "********" };
            yield return new object[] { "\"email\"@example.com", "********" };
            yield return new object[] { "Abc..123@example.com", "********" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "********" };
            yield return new object[] { "just”not”right@example.com", "********" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "********" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "********" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "********" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "********" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "*****@*******.***" };
            yield return new object[] { "firstname.lastname@example.com", "******************@*******.***" };
            yield return new object[] { "email@subdomain.example.com", "*****@*****************.***" };
            yield return new object[] { "firstname+lastname@example.com", "******************@*******.***" };
            yield return new object[] { "1234567890@example.com", "**********@*******.***" };
            yield return new object[] { "email@example-one.com", "*****@***********.***" };
            yield return new object[] { "_______@example.com", "*******@*******.***" };
            yield return new object[] { "email@example.name", "*****@*******.****" };
            yield return new object[] { "email@example.museum", "*****@*******.******" };
            yield return new object[] { "email@example.co.jp", "*****@**********.**" };
            yield return new object[] { "firstname-lastname@example.com", "******************@*******.***" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "**********@*.***" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "****************@*******.****" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "*************@*******.***" };
            yield return new object[] { ".email@example.com", "******@*******.***" };
            yield return new object[] { "email.@example.com", "******@*******.***" };
            yield return new object[] { "email..email@example.com", "************@*******.***" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****@*******.***************" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "*****@********.***" };
            yield return new object[] { "email@[123.123.123.123]", "*****@************.****" };
            yield return new object[] { "email@123.123.123.123", "*****@***********.***" };
            yield return new object[] { "email@111.222.333.44444", "*****@***********.*****" };
            yield return new object[] { "email@example..com", "*****@********.***" };
            yield return new object[] { "\"email\"@example.com", "*******@*******.***" };
            yield return new object[] { "Abc..123@example.com", "********@*******.***" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "***********@*******.***" };
            yield return new object[] { "just”not”right@example.com", "**************@*******.***" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "***************************@*******.***" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "********************@*******.***" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "*********************************************@***************.***" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "****************************@*******.***" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> Username_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "*****@example.com" };
            yield return new object[] { "firstname.lastname@example.com", "******************@example.com" };
            yield return new object[] { "email@subdomain.example.com", "*****@subdomain.example.com" };
            yield return new object[] { "firstname+lastname@example.com", "******************@example.com" };
            yield return new object[] { "1234567890@example.com", "**********@example.com" };
            yield return new object[] { "email@example-one.com", "*****@example-one.com" };
            yield return new object[] { "_______@example.com", "*******@example.com" };
            yield return new object[] { "email@example.name", "*****@example.name" };
            yield return new object[] { "email@example.museum", "*****@example.museum" };
            yield return new object[] { "email@example.co.jp", "*****@example.co.jp" };
            yield return new object[] { "firstname-lastname@example.com", "******************@example.com" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "**********@#.com" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "****************@example.com>" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "*************@example.com" };
            yield return new object[] { ".email@example.com", "******@example.com" };
            yield return new object[] { "email.@example.com", "******@example.com" };
            yield return new object[] { "email..email@example.com", "************@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****@example.com (Joe Smith)" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "*****@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "*****@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "*****@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "*****@111.222.333.44444" };
            yield return new object[] { "email@example..com", "*****@example..com" };
            yield return new object[] { "\"email\"@example.com", "*******@example.com" };
            yield return new object[] { "Abc..123@example.com", "********@example.com" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "***********@example.com" };
            yield return new object[] { "just”not”right@example.com", "**************@example.com" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "***************************@example.com" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "********************@example.com" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "*********************************************@strange.example.com" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "****************************@example.com" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> HalfUsername_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "***il@example.com" };
            yield return new object[] { "firstname.lastname@example.com", "*********.lastname@example.com" };
            yield return new object[] { "email@subdomain.example.com", "***il@subdomain.example.com" };
            yield return new object[] { "firstname+lastname@example.com", "*********+lastname@example.com" };
            yield return new object[] { "1234567890@example.com", "*****67890@example.com" };
            yield return new object[] { "email@example-one.com", "***il@example-one.com" };
            yield return new object[] { "_______@example.com", "****___@example.com" };
            yield return new object[] { "email@example.name", "***il@example.name" };
            yield return new object[] { "email@example.museum", "***il@example.museum" };
            yield return new object[] { "email@example.co.jp", "***il@example.co.jp" };
            yield return new object[] { "firstname-lastname@example.com", "*********-lastname@example.com" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "*****#$@#$@#.com" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "********h <email@example.com>" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "*******xample@example.com" };
            yield return new object[] { ".email@example.com", "***ail@example.com" };
            yield return new object[] { "email.@example.com", "***il.@example.com" };
            yield return new object[] { "email..email@example.com", "******.email@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "***il@example.com (Joe Smith)" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "***il@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "***il@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "***il@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "***il@111.222.333.44444" };
            yield return new object[] { "email@example..com", "***il@example..com" };
            yield return new object[] { "\"email\"@example.com", "****il\"@example.com" };
            yield return new object[] { "Abc..123@example.com", "****.123@example.com" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "******<>[\\]@example.com" };
            yield return new object[] { "just”not”right@example.com", "*******t”right@example.com" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "**************y\"not\\allowed@example.com" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "**********\\ unusual”@example.com" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "***********************very@\\\\ \"very”.unusual@strange.example.com" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "**************@”.unusual.com@example.com" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> Middle_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "em*********le.com" };
            yield return new object[] { "firstname.lastname@example.com", "firstname***************le.com" };
            yield return new object[] { "email@subdomain.example.com", "em**************example.com" };
            yield return new object[] { "firstname+lastname@example.com", "firstname***************le.com" };
            yield return new object[] { "1234567890@example.com", "12345***********le.com" };
            yield return new object[] { "email@example-one.com", "em***********-one.com" };
            yield return new object[] { "_______@example.com", "___**********le.com" };
            yield return new object[] { "email@example.name", "em**********e.name" };
            yield return new object[] { "email@example.museum", "em***********.museum" };
            yield return new object[] { "email@example.co.jp", "em**********e.co.jp" };
            yield return new object[] { "firstname-lastname@example.com", "firstname***************le.com" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "#@%^%********com" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "Joe Smit***************e.com>" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "email@*************le.com" };
            yield return new object[] { ".email@example.com", ".em*********le.com" };
            yield return new object[] { "email.@example.com", "ema*********le.com" };
            yield return new object[] { "email..email@example.com", "email.************le.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "em*************** (Joe Smith)" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "em**********le.com" };
            yield return new object[] { "email@[123.123.123.123]", "em************.123.123]" };
            yield return new object[] { "email@123.123.123.123", "em***********.123.123" };
            yield return new object[] { "email@111.222.333.44444", "em************333.44444" };
            yield return new object[] { "email@example..com", "em**********e..com" };
            yield return new object[] { "\"email\"@example.com", "\"em**********le.com" };
            yield return new object[] { "Abc..123@example.com", "Abc.**********le.com" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "”(),:************le.com" };
            yield return new object[] { "just”not”right@example.com", "just”no*************le.com" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "this\\ is\"real********************le.com" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "much.”more****************le.com" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "very.”(),:;<>[]”.VERY.*********************************xample.com" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "very.unusual.”********************le.com" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> MostUsername_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "e***l@example.com" };
            yield return new object[] { "firstname.lastname@example.com", "f****************e@example.com" };
            yield return new object[] { "email@subdomain.example.com", "e***l@subdomain.example.com" };
            yield return new object[] { "firstname+lastname@example.com", "f****************e@example.com" };
            yield return new object[] { "1234567890@example.com", "1********0@example.com" };
            yield return new object[] { "email@example-one.com", "e***l@example-one.com" };
            yield return new object[] { "_______@example.com", "_*****_@example.com" };
            yield return new object[] { "email@example.name", "e***l@example.name" };
            yield return new object[] { "email@example.museum", "e***l@example.museum" };
            yield return new object[] { "email@example.co.jp", "e***l@example.co.jp" };
            yield return new object[] { "firstname-lastname@example.com", "f****************e@example.com" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "#********$@#.com" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "J**************l@example.com>" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "e***********e@example.com" };
            yield return new object[] { ".email@example.com", ".****l@example.com" };
            yield return new object[] { "email.@example.com", "e****.@example.com" };
            yield return new object[] { "email..email@example.com", "e**********l@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "e***l@example.com (Joe Smith)" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "e***l@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "e***l@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "e***l@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "e***l@111.222.333.44444" };
            yield return new object[] { "email@example..com", "e***l@example..com" };
            yield return new object[] { "\"email\"@example.com", "\"*****\"@example.com" };
            yield return new object[] { "Abc..123@example.com", "A******3@example.com" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "”*********]@example.com" };
            yield return new object[] { "just”not”right@example.com", "j************t@example.com" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "t*************************d@example.com" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "m******************”@example.com" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "v*******************************************l@strange.example.com" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "v**************************m@example.com" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }

        private static IEnumerable<object[]> ShowFirstCharacters_TestData()
        {
            yield return new object[] { "", "" };
            yield return new object[] { "email@example.com", "e****@e******.com" };
            yield return new object[] { "firstname.lastname@example.com", "f*****************@e******.com" };
            yield return new object[] { "email@subdomain.example.com", "e****@s****************.com" };
            yield return new object[] { "firstname+lastname@example.com", "f*****************@e******.com" };
            yield return new object[] { "1234567890@example.com", "1*********@e******.com" };
            yield return new object[] { "email@example-one.com", "e****@e**********.com" };
            yield return new object[] { "_______@example.com", "_******@e******.com" };
            yield return new object[] { "email@example.name", "e****@e******.name" };
            yield return new object[] { "email@example.museum", "e****@e******.museum" };
            yield return new object[] { "email@example.co.jp", "e****@e*********.jp" };
            yield return new object[] { "firstname-lastname@example.com", "f*****************@e******.com" };
            yield return new object[] { "plainaddress", "********" };
            yield return new object[] { "#@%^%#$@#$@#.com", "#*********@#.com" };
            yield return new object[] { "@example.com", "********" };
            yield return new object[] { "Joe Smith <email@example.com>", "J***************@e******.com>" };
            yield return new object[] { "email.example.com", "********" };
            yield return new object[] { "email@example@example.com", "e************@e******.com" };
            yield return new object[] { ".email@example.com", ".*****@e******.com" };
            yield return new object[] { "email.@example.com", "e*****@e******.com" };
            yield return new object[] { "email..email@example.com", "e***********@e******.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "e****@e******.com (Joe Smith)" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "e****@-*******.com" };
            yield return new object[] { "email@[123.123.123.123]", "e****@[***********.123]" };
            yield return new object[] { "email@123.123.123.123", "e****@1**********.123" };
            yield return new object[] { "email@111.222.333.44444", "e****@1**********.44444" };
            yield return new object[] { "email@example..com", "e****@e*******.com" };
            yield return new object[] { "\"email\"@example.com", "\"******@e******.com" };
            yield return new object[] { "Abc..123@example.com", "A*******@e******.com" };
            yield return new object[] { "”(),:;<>[\\]@example.com", "”**********@e******.com" };
            yield return new object[] { "just”not”right@example.com", "j*************@e******.com" };
            yield return new object[] { "this\\ is\"really\"not\\allowed@example.com", "t**************************@e******.com" };
            yield return new object[] { "much.”more\\ unusual”@example.com", "m*******************@e******.com" };
            yield return new object[] { "very.”(),:;<>[]”.VERY.”very@\\\\ \"very”.unusual@strange.example.com", "v********************************************@s**************.com" };
            yield return new object[] { "very.unusual.”@”.unusual.com@example.com", "v***************************@e******.com" };
            yield return new object[] { null, "" };

            yield return new object[] { "4111 1111 1111 1111", "********" };
            yield return new object[] { "2023/06/15", "********" };
            yield return new object[] { "100.100.100.100", "********" };
            yield return new object[] { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", "********" };
            yield return new object[] { "00:1A:2B:FF:FE:3C:4D:5E", "********" };
            yield return new object[] { "+1 (555) 123-4567", "********" };
            yield return new object[] { "abc123 !@#", "********" };
        }


        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_All_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_All_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Full_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Full_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_FixedLength_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_FixedLength_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Username_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Username_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Username });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Username_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Username_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Username });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(HalfUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_HalfUsername_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FirstHalfUsername });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(HalfUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_HalfUsername_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FirstHalfUsername });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(Middle_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Middle_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Middle });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Middle_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_Middle_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Middle });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(MostUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_MostUsername_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.MostUsername });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(MostUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_MostUsername_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.MostUsername });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }

        [TestMethod]
        [DynamicData(nameof(ShowFirstCharacters_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_ShowFirstCharacters_ShouldReturnRedactedEmailAddress_String(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.ShowFirstCharacters });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowFirstCharacters_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddressAddress_ShowFirstCharacters_ShouldReturnRedactedEmailAddress_ReadOnlySpan(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(input.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.ShowFirstCharacters });

            // Assert
            Assert.AreEqual(expected, result.ToString());
        }
    }
}
