#pragma warning disable CS8618

using System.Net.Mail;

namespace ZeroRedact.UnitTest.Redactors
{
    [TestClass]
    public class RedactEmailAddressWithMailAddressClass
    {
        private static IEnumerable<object[]> All_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "*****************" };
            yield return new object[] { "email.@example.com", "******************" };
            yield return new object[] { "email..email@example.com", "************************" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****************" };
            yield return new object[] { "email@example", "*************" };
            yield return new object[] { "email@-example.com", "******************" };
            yield return new object[] { "email@[123.123.123.123]", "***********************" };
            yield return new object[] { "email@123.123.123.123", "*********************" };
            yield return new object[] { "email@111.222.333.44444", "***********************" };
            yield return new object[] { "email@example..com", "******************" };
            yield return new object[] { "\"email\"@example.com", "*******************" };
            yield return new object[] { "Abc..123@example.com", "********************" };
            yield return new object[] { "just”not”right@example.com", "**************************" };
        }
        private static IEnumerable<object[]> FixedLength_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "********" };
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
            yield return new object[] { "just”not”right@example.com", "********" };
        }

        private static IEnumerable<object[]> Full_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "*****@*******.***" };
            yield return new object[] { "email.@example.com", "******@*******.***" };
            yield return new object[] { "email..email@example.com", "************@*******.***" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****@*******.***" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "*****@********.***" };
            yield return new object[] { "email@[123.123.123.123]", "*****@************.****" };
            yield return new object[] { "email@123.123.123.123", "*****@***********.***" };
            yield return new object[] { "email@111.222.333.44444", "*****@***********.*****" };
            yield return new object[] { "email@example..com", "*****@********.***" };
            yield return new object[] { "\"email\"@example.com", "*******@*******.***" };
            yield return new object[] { "Abc..123@example.com", "********@*******.***" };
            yield return new object[] { "just”not”right@example.com", "**************@*******.***" };
        }

        private static IEnumerable<object[]> OnlyAtSymbol_TestData()
        {
            yield return new object[] { "email@example.com", "*****@***********" };
            yield return new object[] { "firstname.lastname@example.com", "******************@***********" };
            yield return new object[] { "email@subdomain.example.com", "*****@*********************" };
            yield return new object[] { "firstname+lastname@example.com", "******************@***********" };
            yield return new object[] { "1234567890@example.com", "**********@***********" };
            yield return new object[] { "email@example-one.com", "*****@***************" };
            yield return new object[] { "_______@example.com", "*******@***********" };
            yield return new object[] { "email@example.name", "*****@************" };
            yield return new object[] { "email@example.museum", "*****@**************" };
            yield return new object[] { "email@example.co.jp", "*****@*************" };
            yield return new object[] { "firstname-lastname@example.com", "******************@***********" };
            yield return new object[] { "Joe Smith <email@example.com>", "*****@***********" };
            yield return new object[] { "email.@example.com", "******@***********" };
            yield return new object[] { "email..email@example.com", "************@***********" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****@***********" };
            yield return new object[] { "email@example", "*****@*******" };
            yield return new object[] { "email@-example.com", "*****@************" };
            yield return new object[] { "email@[123.123.123.123]", "*****@*****************" };
            yield return new object[] { "email@123.123.123.123", "*****@***************" };
            yield return new object[] { "email@111.222.333.44444", "*****@*****************" };
            yield return new object[] { "email@example..com", "*****@************" };
            yield return new object[] { "\"email\"@example.com", "*******@***********" };
            yield return new object[] { "Abc..123@example.com", "********@***********" };
            yield return new object[] { "just”not”right@example.com", "**************@***********" };
        }

        private static IEnumerable<object[]> Username_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "*****@example.com" };
            yield return new object[] { "email.@example.com", "******@example.com" };
            yield return new object[] { "email..email@example.com", "************@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "*****@example.com" };
            yield return new object[] { "email@example", "*****@example" };
            yield return new object[] { "email@-example.com", "*****@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "*****@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "*****@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "*****@111.222.333.44444" };
            yield return new object[] { "email@example..com", "*****@example..com" };
            yield return new object[] { "\"email\"@example.com", "*******@example.com" };
            yield return new object[] { "Abc..123@example.com", "********@example.com" };
            yield return new object[] { "just”not”right@example.com", "**************@example.com" };
        }

        private static IEnumerable<object[]> Domain_TestData()
        {
            yield return new object[] { "email@example.com", "email@***********" };
            yield return new object[] { "firstname.lastname@example.com", "firstname.lastname@***********" };
            yield return new object[] { "email@subdomain.example.com", "email@*********************" };
            yield return new object[] { "firstname+lastname@example.com", "firstname+lastname@***********" };
            yield return new object[] { "1234567890@example.com", "1234567890@***********" };
            yield return new object[] { "email@example-one.com", "email@***************" };
            yield return new object[] { "_______@example.com", "_______@***********" };
            yield return new object[] { "email@example.name", "email@************" };
            yield return new object[] { "email@example.museum", "email@**************" };
            yield return new object[] { "email@example.co.jp", "email@*************" };
            yield return new object[] { "firstname-lastname@example.com", "firstname-lastname@***********" };
            yield return new object[] { "Joe Smith <email@example.com>", "email@***********" };
            yield return new object[] { "email.@example.com", "email.@***********" };
            yield return new object[] { "email..email@example.com", "email..email@***********" };
            yield return new object[] { "email@example.com (Joe Smith)", "email@***********" };
            yield return new object[] { "email@example", "email@*******" };
            yield return new object[] { "email@-example.com", "email@************" };
            yield return new object[] { "email@[123.123.123.123]", "email@*****************" };
            yield return new object[] { "email@123.123.123.123", "email@***************" };
            yield return new object[] { "email@111.222.333.44444", "email@*****************" };
            yield return new object[] { "email@example..com", "email@************" };
            yield return new object[] { "\"email\"@example.com", "\"email\"@***********" };
            yield return new object[] { "Abc..123@example.com", "Abc..123@***********" };
            yield return new object[] { "just”not”right@example.com", "just”not”right@***********" };
        }

        private static IEnumerable<object[]> HalfUsername_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "***il@example.com" };
            yield return new object[] { "email.@example.com", "***il.@example.com" };
            yield return new object[] { "email..email@example.com", "******.email@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "***il@example.com" };
            yield return new object[] { "email@example", "***il@example" };
            yield return new object[] { "email@-example.com", "***il@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "***il@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "***il@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "***il@111.222.333.44444" };
            yield return new object[] { "email@example..com", "***il@example..com" };
            yield return new object[] { "\"email\"@example.com", "****il\"@example.com" };
            yield return new object[] { "Abc..123@example.com", "****.123@example.com" };
            yield return new object[] { "just”not”right@example.com", "*******t”right@example.com" };
        }

        private static IEnumerable<object[]> Middle_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "em*********le.com" };
            yield return new object[] { "email.@example.com", "ema*********le.com" };
            yield return new object[] { "email..email@example.com", "email.************le.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "em*********le.com" };
            yield return new object[] { "email@example", "em*******mple" };
            yield return new object[] { "email@-example.com", "em**********le.com" };
            yield return new object[] { "email@[123.123.123.123]", "em************.123.123]" };
            yield return new object[] { "email@123.123.123.123", "em***********.123.123" };
            yield return new object[] { "email@111.222.333.44444", "em************333.44444" };
            yield return new object[] { "email@example..com", "em**********e..com" };
            yield return new object[] { "\"email\"@example.com", "\"em**********le.com" };
            yield return new object[] { "Abc..123@example.com", "Abc.**********le.com" };
            yield return new object[] { "just”not”right@example.com", "just”no*************le.com" };
        }

        private static IEnumerable<object[]> MostUsername_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "e***l@example.com" };
            yield return new object[] { "email.@example.com", "e****.@example.com" };
            yield return new object[] { "email..email@example.com", "e**********l@example.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "e***l@example.com" };
            yield return new object[] { "email@example", "e***l@example" };
            yield return new object[] { "email@-example.com", "e***l@-example.com" };
            yield return new object[] { "email@[123.123.123.123]", "e***l@[123.123.123.123]" };
            yield return new object[] { "email@123.123.123.123", "e***l@123.123.123.123" };
            yield return new object[] { "email@111.222.333.44444", "e***l@111.222.333.44444" };
            yield return new object[] { "email@example..com", "e***l@example..com" };
            yield return new object[] { "\"email\"@example.com", "\"*****\"@example.com" };
            yield return new object[] { "Abc..123@example.com", "A******3@example.com" };
            yield return new object[] { "just”not”right@example.com", "j************t@example.com" };
        }

        private static IEnumerable<object[]> ShowFirstCharacters_TestData()
        {
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
            yield return new object[] { "Joe Smith <email@example.com>", "e****@e******.com" };
            yield return new object[] { "email.@example.com", "e*****@e******.com" };
            yield return new object[] { "email..email@example.com", "e***********@e******.com" };
            yield return new object[] { "email@example.com (Joe Smith)", "e****@e******.com" };
            yield return new object[] { "email@example", "********" };
            yield return new object[] { "email@-example.com", "e****@-*******.com" };
            yield return new object[] { "email@[123.123.123.123]", "e****@[***********.123]" };
            yield return new object[] { "email@123.123.123.123", "e****@1**********.123" };
            yield return new object[] { "email@111.222.333.44444", "e****@1**********.44444" };
            yield return new object[] { "email@example..com", "e****@e*******.com" };
            yield return new object[] { "\"email\"@example.com", "\"******@e******.com" };
            yield return new object[] { "Abc..123@example.com", "A*******@e******.com" };
            yield return new object[] { "just”not”right@example.com", "j*************@e******.com" };
        }


        [TestMethod]
        [DynamicData(nameof(All_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_All_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(FixedLength_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_FixedLength_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_Full_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Full });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Full_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_DefaultFull_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input));

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Username_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_Username_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Username });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(HalfUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_HalfUsername_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FirstHalfUsername });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(Middle_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_Middle_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Middle });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(MostUsername_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_MostUsername_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.MostUsername });

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(ShowFirstCharacters_TestData), DynamicDataSourceType.Method)]
        public void RedactEmailAddress_ShowFirstCharacters_ShouldReturnRedactedEmailAddress_MailAddress(string input, string expected)
        {
            // Arrange
            var redactor = new Redactor();

            // Act
            var result = redactor.RedactEmailAddress(new MailAddress(input), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.ShowFirstCharacters });

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
