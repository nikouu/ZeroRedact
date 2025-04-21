#pragma warning disable CA1822

namespace ZeroRedact.UnitTest.Scoping
{

    // These tests check for CS8347 and CS8352. While these are compiler errors and not runtime errors, there needs to be a way to be surfaced during development
    // They are deliberately not decorated as tests
    // Date redactions aren't represented here as they only return strings
    public class ScopingTests
    {
        public ReadOnlySpan<char> RedactCreditCard_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactCreditCard("4111111111111111".AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All });
        }

        public ReadOnlySpan<char> RedactCreditCard_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var creditCardNumber = "4111111111111111".AsSpan();
            var options = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All };

            // Act
            var result = redactor.RedactCreditCard(creditCardNumber, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactString_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactString("Hello World".AsSpan(), new StringRedactorOptions { RedactorType = StringRedaction.All });
        }

        public ReadOnlySpan<char> RedactString_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var value = "Hello World".AsSpan();
            var options = new StringRedactorOptions { RedactorType = StringRedaction.All };

            // Act
            var result = redactor.RedactString(value, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactEmailAddress_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactEmailAddress("email@example.com".AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All });
        }

        public ReadOnlySpan<char> RedactEmailAddress_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var emailAddress = "email@example.com".AsSpan();
            var options = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All };

            // Act
            var result = redactor.RedactEmailAddress(emailAddress, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactPhoneNumber_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactPhoneNumber("1234567890".AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.All });
        }

        public ReadOnlySpan<char> RedactPhoneNumber_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var phoneNumber = "1234567890".AsSpan();
            var options = new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.All };

            // Act
            var result = redactor.RedactPhoneNumber(phoneNumber, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactIPv4Address_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactIPv4Address("192.168.1.1".AsSpan(), new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.All });
        }

        public ReadOnlySpan<char> RedactIPv4Address_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var ipAddress = "192.168.1.1".AsSpan();
            var options = new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.All };

            // Act
            var result = redactor.RedactIPv4Address(ipAddress, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactIPv6Address_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactIPv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334".AsSpan(), new IPv6AddressRedactorOptions { RedactorType = IPv6AddressRedaction.All });
        }

        public ReadOnlySpan<char> RedactIPv6Address_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var ipAddress = "2001:0db8:85a3:0000:0000:8a2e:0370:7334".AsSpan();
            var options = new IPv6AddressRedactorOptions { RedactorType = IPv6AddressRedaction.All };

            // Act
            var result = redactor.RedactIPv6Address(ipAddress, options);

            // Return
            return result;
        }

        public ReadOnlySpan<char> RedactMACAddress_ShouldStopCS8347()
        {
            // Arrange
            var redactor = new Redactor();

            return redactor.RedactMACAddress("00:1A:2B:3C:4D:5E".AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All });
        }

        public ReadOnlySpan<char> RedactMACAddress_ShouldStopCS8352()
        {
            // Arrange
            var redactor = new Redactor();
            var macAddress = "00:1A:2B:3C:4D:5E".AsSpan();
            var options = new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All };

            // Act
            var result = redactor.RedactMACAddress(macAddress, options);

            // Return
            return result;
        }
    }
}
