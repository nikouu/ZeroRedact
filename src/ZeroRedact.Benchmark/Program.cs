using BenchmarkDotNet.Running;
using ZeroRedact;

Console.WriteLine("Hello, World!");

var options = new RedactorOptions
{
    RedactionCharacter = 'O',
    FixedLengthSize = 10,
    StringRedactorOptions = new StringRedactorOptions
    {
        RedactionCharacter = 'X',
        FixedLengthSize = 5,
        RedactorType = StringRedaction.FixedLength
    },
    EmailAddressRedactorOptions = new EmailAddressRedactorOptions
    {
        RedactionCharacter = 'X',
        FixedLengthSize = 6,
        RedactorType = EmailAddressRedaction.ShowFirstCharacters
    },
    CreditCardRedactorOptions = new CreditCardRedactorOptions
    {
        RedactionCharacter = '&',
        FixedLengthSize = 7,
        RedactorType = CreditCardRedaction.ShowFirstSixLastFour
    },
    DateRedactorOptions = new DateRedactorOptions
    {
        RedactionCharacter = '-',
        FixedLengthSize = 8,
        RedactorType = DateRedaction.DayAndYear
    },
    PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions
    {
        RedactionCharacter = '#',
        FixedLengthSize = 9,
        RedactorType = PhoneNumberRedaction.ShowLastFour
    },
    IPv4RedactorOptions = new IPv4RedactorOptions
    {
        RedactionCharacter = '!',
        FixedLengthSize = 11,
        RedactorType = IPv4AddressRedaction.Full
    },
    IPv6RedactorOptions = new IPv6RedactorOptions
    {
        RedactionCharacter = '^',
        FixedLengthSize = 12,
        RedactorType = IPv6AddressRedaction.All
    },
    MACAddressRedactorOptions = new MACAddressRedactorOptions
    {
        RedactionCharacter = '?',
        FixedLengthSize = 13,
        RedactorType = MACAddressRedaction.ShowLastByte
    }
};

var redactor = new Redactor();

var options = new StringRedactorOptions
{
    RedactorType = StringRedaction.SecondHalf,
    RedactionCharacter = '#'
};

// returns ""
var result = redactor.RedactString("Personal data", options);

Console.WriteLine(result);

#if !DEBUG
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
#endif

