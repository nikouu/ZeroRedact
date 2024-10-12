# ZeroRedact

[![NuGet](https://img.shields.io/nuget/v/Nikouu.ZeroRedact)](https://www.nuget.org/packages/Nikouu.ZeroRedact)
[![GitHub Release](https://img.shields.io/github/v/release/nikouu/zeroredact)](https://github.com/nikouu/ZeroRedact/releases)
[![Official Docs](https://img.shields.io/badge/Official_Docs-blue?logo=gitbook)](https://nikouu.github.io/ZeroRedact/)
[![Demo](https://img.shields.io/badge/Demo-dd2257)](https://nikouu.github.io/ZeroRedact/demo/)
[![GitHub License](https://img.shields.io/github/license/nikouu/zeroredact)](https://github.com/nikouu/ZeroRedact/blob/main/LICENSE)
[![Blog](https://img.shields.io/badge/blog-nikouusitalo.com-8A2BE2)](https://www.nikouusitalo.com/)

A fast, simple, zero allocation redacting library for .NET, with no extra dependencies.

Read more in the [official docs](https://nikouu.github.io/ZeroRedact/).

## Getting started

Install via [NuGet](https://www.nuget.org/packages/Nikouu.ZeroRedact/):
```
dotnet add package Nikouu.ZeroRedact
```

The following shows example redactions with varying configs. For more see the [official docs](https://nikouu.github.io/ZeroRedact/).

```csharp
var redactor = new Redactor();

// returns "*************"
var stringResult = redactor.RedactString("Hello, World!");

// returns "*****@*******.***"
var emailAddressResult = redactor.RedactEmailAddress("email@example.com");

// returns "****-****-****-1111"
var creditCardOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowLastFour };
var creditCardResult = redactor.RedactCreditCard("4111-1111-1111-1111", creditCardOptions);

// returns based on current culture
// en-NZ: "6/**/2023"
// en-US: "*/**/****"
// ja-JP: "2023/06/**"
// InvariantCulture: "06/**/2023"
var dateOptions = new DateRedactorOptions { RedactorType = DateRedaction.Day };
var dateResult = redactor.RedactDate(new DateTime(2023, 10, 5), dateOptions);

// returns "###-###-####"
var phoneNumberOptions = new PhoneNumberRedactorOptions { RedactionCharacter = '#' };
var phoneNumberResult = redactor.RedactPhoneNumber("212-456-7890");

// returns "@@@.@.@.146"
var ipv4AddressOptions = new IPv4AddressRedactorOptions
{
    RedactionCharacter = '@',
    RedactorType = IPv4AddressRedaction.ShowLastOctet
};
var ipv4Result = redactor.RedactIPv4Address("192.0.2.146", ipv4AddressOptions);

// returns "****:****:****:****:****:****:****:****"
var ipv6Result = redactor.RedactIPv6Address("2001:0000:130F:0000:0000:09C0:876A:130B");

// "**:**:**:**:**:**"
var macResult = redactor.RedactMACAddress("00:B0:D0:63:C2:26");
```

## Configuration

ZeroRedact can be configured in two ways: via constructor, and via a redaction method. Both using the appropriate redactor option object.

Configuration has three layers with least to most priority:
1. Base defaults within the `Redactor` object.
2. Passed in options to the `Redactor` object constructor
3. Passed in options to a redaction method at the time of redaction

This example shows changing the base defaults. This will apply to every redaction, whether it's a string or email address, etc.

```csharp
// Example 1: Changing base defaults
var options = new RedactorOptions
{
    RedactionCharacter = 'X'
};

var redactor = new Redactor(options);

// returns "XXXXXXXXXXXXX"
var result = redactor.RedactString("Hello, World!");
```

This example shows `StringRedactorOptions` being passed into the `Redactor` constructor. Only string redactions will now use 'A' as the redaction character, all others will continue to use the default character of '*'.
```csharp
// Example 2: Changing specific redaction type options
var options = new RedactorOptions
{
    StringRedactorOptions = new StringRedactorOptions
    {
        RedactionCharacter = 'A'
    }
};

var redactor = new Redactor(options);

// returns "AAAAAAAAAAAAA"
var result = redactor.RedactString("Hello, World!");
```

This example shows passing in `StringRedactorOptions` at the time of redaction, which takes precedence over the constructor options.
```csharp
// Example 3: Changing redaction options at redaction time
var options = new RedactorOptions
{
    StringRedactorOptions = new StringRedactorOptions
    {
        RedactionCharacter = 'A'
    }
};

var redactor = new Redactor(options);
var specificOptions = new StringRedactorOptions { RedactionCharacter = 'B' };

// returns "BBBBBBBBBBBBB"
var result = redactor.RedactString("Hello, World!", specificOptions);
```

## Layered configuration

Users should have a fine grained customization experience which allows for an easy to reuse item that can setup default behaviours but when needed, can adapt to the need of the redaction call at the time.

## Error handling

Redacting will not throw exceptions - that is, the string manipulation logic. Any exception during the redacting process will return a fixed length redaction with a default redacting character. This is to avoid disrupting the important real work happening in a user's codebase while still preventing PII from being exposed.

However exceptions can occur by passing invalid options to the redactor, whether that's via the constructor, or via a redaction method.

## No external dependencies

No extra NuGet packages are pulled in when using ZeroRedact. 

## Microsoft.Extensions.Compliance.Redaction

ZeroRedact can be integrated into [Microsoft.Extensions.Compliance.Redaction](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.compliance.redaction) to provide full and partial redacting. 

See [Compliance.Redaction-with-ZeroRedact](https://github.com/nikouu/Compliance.Redaction-with-ZeroRedact) for an example project.

## Performance

### Benchmarks
See [benchmarks](benchmarks).

## License

[MIT](LICENSE)
