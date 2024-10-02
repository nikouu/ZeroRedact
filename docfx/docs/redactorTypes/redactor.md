# Redactor

`Redactor` is the root object for ZeroRedact. It exposes the various methods to redact specific types of sensitive information.

## Configuration

It's simple to use and defaults to having `*` as a redaction character.

```csharp
var redactor = new Redactor();
```

Base redaction characters, and fixed length redaction length can be configured via the `RedactorOptions` struct.

```csharp
var options = new RedactorOptions
{
    FixedLengthSize = 5,
    RedactionCharacter = 'X'
};

var redactor = new Redactor(options);
```

Each method that deals with a specific type of sensitive information can also be configured at the `Redactor` level. This allows for your own defaults to be setup at object creation time:

```csharp
// Options will only apply to RedactEmailAddress() calls
var options = new RedactorOptions
{
    EmailAddressRedactorOptions = new EmailAddressRedactorOptions
    {
        RedactionCharacter = 'X'
    }
};

var redactor = new Redactor(options);
```

All redactor options can be configured here:

```csharp
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
    IPv4AddressRedactorOptions = new IPv4AddressRedactorOptions
    {
        RedactionCharacter = '!',
        FixedLengthSize = 11,
        RedactorType = IPv4AddressRedaction.Full
    },
    IPv6AddressRedactorOptions = new IPv6AddressRedactorOptions
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
```