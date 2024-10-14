# Quick Start

Redact your sensitive data with ZeroRedact. ZeroRedact fully or partially redacts various formats of sensitive data quickly and easily. 

## Install via NuGet

Either with the NuGet Package Manager UI or via:
```
dotnet add package Nikouu.ZeroRedact
```

## First redaction

Create the `Redactor` object, and use a method fitting for your sensitive data:

```csharp
var redactor = new Redactor();

// returns "*************"
var result = redactor.RedactString("Personal data");
```

## Redacting with options

To customise the redaction, use the respective options object for the redaction type:

```csharp
var redactor = new Redactor();

var options = new StringRedactorOptions
{
    RedactorType = StringRedaction.SecondHalf,
    RedactionCharacter = '#'
};

// returns "Person#######"
var result = redactor.RedactString("Personal data", options);
```

## Service builder

In the case of a service builder with `IServiceCollection`:
```csharp
// Default
builder.Services.AddZeroRedact();

// Or to configure
builder.Services.AddZeroRedact(new RedactorOptions
{
    CreditCardRedactorOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowLastFour },
    EmailAddressRedactorOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.ShowFirstCharacters },
    DateRedactorOptions = new DateRedactorOptions { RedactorType = DateRedaction.Day },
    PhoneNumberRedactorOptions = new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.ShowLastFour }
});
```