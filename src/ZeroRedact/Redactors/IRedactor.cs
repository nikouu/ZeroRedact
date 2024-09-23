using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact;
using ZeroRedact.Options;

namespace ZeroRedact.Redactors
{
    /// <summary>
    /// Implements redaction capabilities.
    /// </summary>
    public interface IRedactor
    {
        /// <summary>
        /// Redacts the provided string.
        /// </summary>
        /// <param name="value">The string to redact.</param>
        string RedactString(string value);

        /// <summary>
        /// Redacts the provided string.
        /// </summary>
        /// <param name="value">The string to redact.</param>
        /// <param name="redactorOptions">The redactorOptions to control redaction behavior.</param>
        string RedactString(string value, StringRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided string.
        /// </summary>
        /// <param name="value">The string to redact.</param>
        ReadOnlySpan<char> RedactString(ReadOnlySpan<char> value);

        /// <summary>
        /// Redacts the provided string.
        /// </summary>
        /// <param name="value">The string to redact.</param>
        /// <param name="redactorOptions">The redactorOptions to control redaction behavior.</param>
        ReadOnlySpan<char> RedactString(ReadOnlySpan<char> value, StringRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        string RedactEmailAddress(string emailAddress);

        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactEmailAddress(string emailAddress, EmailAddressRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        ReadOnlySpan<char> RedactEmailAddress(ReadOnlySpan<char> emailAddress);


        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactEmailAddress(ReadOnlySpan<char> emailAddress, EmailAddressRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        string RedactEmailAddress(MailAddress emailAddress);

        /// <summary>
        /// Redacts the provided email address.
        /// </summary>
        /// <param name="emailAddress">The email address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactEmailAddress(MailAddress emailAddress, EmailAddressRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided date.
        /// </summary>
        /// <param name="date">The date to redact.</param>
        /// <returns>Returns redacted short date formatted for the current <see cref="System.Globalization.CultureInfo"/>.</returns>
        string RedactDate(DateTime date);

        /// <summary>
        /// Redacts the provided date.
        /// </summary>
        /// <param name="date">The date to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        /// <returns>Returns redacted short date formatted for the current <see cref="System.Globalization.CultureInfo"/>.</returns>
        string RedactDate(DateTime date, DateRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided date.
        /// </summary>
        /// <param name="date">The date to redact.</param>
        /// <returns>Returns redacted short date formatted for the current <see cref="System.Globalization.CultureInfo"/>.</returns>
        string RedactDate(DateOnly date);

        /// <summary>
        /// Redacts the provided date.
        /// </summary>
        /// <param name="date">The date to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        /// <returns>Returns redacted short date formatted for the current <see cref="System.Globalization.CultureInfo"/>.</returns>
        string RedactDate(DateOnly date, DateRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided credit card number.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number to redact.</param>
        string RedactCreditCard(string creditCardNumber);


        /// <summary>
        /// Redacts the provided credit card number.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactCreditCard(string creditCardNumber, CreditCardRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided credit card number.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number to redact.</param>
        ReadOnlySpan<char> RedactCreditCard(ReadOnlySpan<char> creditCardNumber);

        /// <summary>
        /// Redacts the provided credit card number.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactCreditCard(ReadOnlySpan<char> creditCardNumber, CreditCardRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to redact.</param>
        string RedactPhoneNumber(string phoneNumber);

        /// <summary>
        /// Redacts the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactPhoneNumber(string phoneNumber, PhoneNumberRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to redact.</param>
        ReadOnlySpan<char> RedactPhoneNumber(ReadOnlySpan<char> phoneNumber);

        /// <summary>
        /// Redacts the provided phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactPhoneNumber(ReadOnlySpan<char> phoneNumber, PhoneNumberRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided IPv4 address.
        /// </summary>
        /// <param name="ipAddress">The IPv4 address to redact.</param>
        string RedactIPv4Address(string ipAddress);

        /// <summary>
        /// Redacts the provided IPv4 address.
        /// </summary>
        /// <param name="ipAddress">The IPv4 address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactIPv4Address(string ipAddress, IPv4RedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided IPv4 address.
        /// </summary>
        /// <param name="ipAddress">The IPv4 address to redact.</param>
        ReadOnlySpan<char> RedactIPv4Address(ReadOnlySpan<char> ipAddress);

        /// <summary>
        /// Redacts the provided IPv4 address.
        /// </summary>
        /// <param name="ipAddress">The IPv4 address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactIPv4Address(ReadOnlySpan<char> ipAddress, IPv4RedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided IPv6 address.
        /// </summary>
        /// <param name="ipAddress">The IPv6 address to redact</param>
        string RedactIPv6Address(string ipAddress);

        /// <summary>
        /// Redacts the provided IPv6 address.
        /// </summary>
        /// <param name="ipAddress">The IPv6 address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactIPv6Address(string ipAddress, IPv6RedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided IPv6 address.
        /// </summary>
        /// <param name="ipAddress">The IPv6 address to redact</param>
        ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress);

        /// <summary>
        /// Redacts the provided IPv6 address.
        /// </summary>
        /// <param name="ipAddress">The IPv6 address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress, IPv6RedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided MAC address.
        /// </summary>
        /// <param name="macAddress">The MAC address to redact.</param>
        string RedactMACAddress(string macAddress);

        /// <summary>
        /// Redacts the provided MAC address.
        /// </summary>
        /// <param name="macAddress">The MAC address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        string RedactMACAddress(string macAddress, MACAddressRedactorOptions redactorOptions);

        /// <summary>
        /// Redacts the provided MAC address.
        /// </summary>
        /// <param name="macAddress">The MAC address to redact.</param>
        ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> macAddress);

        /// <summary>
        /// Redacts the provided MAC address.
        /// </summary>
        /// <param name="macAddress">The MAC address to redact.</param>
        /// <param name="redactorOptions">The options to control redaction behavior.</param>
        ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> macAddress, MACAddressRedactorOptions redactorOptions);
    }
}
