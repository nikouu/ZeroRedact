using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZeroRedact.UnitTest.Redactors
{
    // Tests to ensure that the redactors aren't manipulating the input data itself
    // https://stackoverflow.com/a/10779478
    [TestClass]
    public class CheckForOverwriteTests
    {
        [TestMethod]
        public void CheckForOverwrite_RedactCreditCard_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "4111111111111111";
            var expected = new string("4111111111111111".ToArray());

            // Act
            _ = redactor.RedactCreditCard(input, new CreditCardRedactorOptions
            {
                RedactorType = CreditCardRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactCreditCard_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "4111111111111111";
            var expected = new string("4111111111111111".ToArray());

            // Act
            _ = redactor.RedactCreditCard(input, new CreditCardRedactorOptions
            {
                RedactorType = CreditCardRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactCreditCard_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "4111111111111111";
            var expected = new string("4111111111111111".ToArray());

            // Act
            _ = redactor.RedactCreditCard(input, new CreditCardRedactorOptions
            {
                RedactorType = CreditCardRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactCreditCard_ShowLastFour()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "4111111111111111";
            var expected = new string("4111111111111111".ToArray());

            // Act
            _ = redactor.RedactCreditCard(input, new CreditCardRedactorOptions
            {
                RedactorType = CreditCardRedaction.ShowLastFour
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactCreditCard_ShowFirstSixLastFour()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "4111111111111111";
            var expected = new string("4111111111111111".ToArray());

            // Act
            _ = redactor.RedactCreditCard(input, new CreditCardRedactorOptions
            {
                RedactorType = CreditCardRedaction.ShowFirstSixLastFour
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_Day()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.Day
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_Month()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.Month
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_Year()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.Year
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_DayAndMonth()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.DayAndMonth
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_MonthAndYear()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.MonthAndYear
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_RedactDate_DayAndYear()
        {
            // Arrange
            var redactor = new Redactor();
            var input = new DateOnly(2023, 12, 31);
            var expected = new DateOnly(2023, 12, 31);

            // Act
            _ = redactor.RedactDate(input, new DateRedactorOptions
            {
                RedactorType = DateRedaction.DayAndYear
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_Username()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.Username
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_FirstHalfUsername()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.FirstHalfUsername
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_Middle()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.Middle
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_MostUsername()
        {
            /// Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.MostUsername
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_EmailAddress_ShowFirstCharacters()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "email@example.com";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactEmailAddress(input, new EmailAddressRedactorOptions
            {
                RedactorType = EmailAddressRedaction.ShowFirstCharacters
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv4Address_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "100.100.100.100";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv4Address(input, new IPv4RedactorOptions
            {
                RedactorType = IPv4AddressRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv4Address_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "100.100.100.100";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv4Address(input, new IPv4RedactorOptions
            {
                RedactorType = IPv4AddressRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv4Address_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "100.100.100.100";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv4Address(input, new IPv4RedactorOptions
            {
                RedactorType = IPv4AddressRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv4Address_ShowLastOctet()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "100.100.100.100";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv4Address(input, new IPv4RedactorOptions
            {
                RedactorType = IPv4AddressRedaction.ShowLastOctet
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv6Address_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv6Address(input, new IPv6RedactorOptions
            {
                RedactorType = IPv6AddressRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv6Address_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv6Address(input, new IPv6RedactorOptions
            {
                RedactorType = IPv6AddressRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv6Address_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv6Address(input, new IPv6RedactorOptions
            {
                RedactorType = IPv6AddressRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_IPv6Address_ShowLastQuartet()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactIPv6Address(input, new IPv6RedactorOptions
            {
                RedactorType = IPv6AddressRedaction.ShowLastQuartet
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_MACAddress_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "00:1A:2B:FF:FE:3C:4D:5E";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactMACAddress(input, new MACAddressRedactorOptions
            {
                RedactorType = MACAddressRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_MACAddress_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "00:1A:2B:FF:FE:3C:4D:5E";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactMACAddress(input, new MACAddressRedactorOptions
            {
                RedactorType = MACAddressRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_MACAddress_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "00:1A:2B:FF:FE:3C:4D:5E";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactMACAddress(input, new MACAddressRedactorOptions
            {
                RedactorType = MACAddressRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_MACAddress_ShowLastByte()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "00:1A:2B:FF:FE:3C:4D:5E";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactMACAddress(input, new MACAddressRedactorOptions
            {
                RedactorType = MACAddressRedaction.ShowLastByte
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_PhoneNumber_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "+1 (555) 123-4567";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions
            {
                RedactorType = PhoneNumberRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_PhoneNumber_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "+1 (555) 123-4567";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions
            {
                RedactorType = PhoneNumberRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_PhoneNumber_Full()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "+1 (555) 123-4567";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions
            {
                RedactorType = PhoneNumberRedaction.Full
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_PhoneNumber_ShowLastFour()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "+1 (555) 123-4567";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactPhoneNumber(input, new PhoneNumberRedactorOptions
            {
                RedactorType = PhoneNumberRedaction.ShowLastFour
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_String_All()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "Hello, world!";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactString(input, new StringRedactorOptions
            {
                RedactorType = StringRedaction.All
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_String_FixedLength()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "Hello, world!";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactString(input, new StringRedactorOptions
            {
                RedactorType = StringRedaction.FixedLength
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_String_FirstHalf()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "Hello, world!";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactString(input, new StringRedactorOptions
            {
                RedactorType = StringRedaction.FirstHalf
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_String_SecondHalf()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "Hello, world!";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactString(input, new StringRedactorOptions
            {
                RedactorType = StringRedaction.SecondHalf
            });

            // Assert
            Assert.AreEqual(expected, input);
        }

        [TestMethod]
        public void CheckForOverwrite_String_IgnoreSymbols()
        {
            // Arrange
            var redactor = new Redactor();
            var input = "Hello, world!";
            var expected = new string(input.ToArray());

            // Act
            _ = redactor.RedactString(input, new StringRedactorOptions
            {
                RedactorType = StringRedaction.IgnoreSymbols
            });

            // Assert
            Assert.AreEqual(expected, input);
        }
    }
}
