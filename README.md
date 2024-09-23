# ZeroRedact

An extremely fast, simple, zero allocation redacting library for .NET.

## Getting started

Install via NuGet:
```
Coming soon
```

The following shows the default redaction which aims to hide the sensitive information while still making it clear what the data type is.

```csharp
var redactor = new Redactor();

// returns "*************"
var stringResult = redactor.RedactString("Hello, World!");

// returns "*****@*******.***"
var emailAddressResult = redactor.RedactEmailAddress("email@example.com");

// returns "****-****-****-****"
var creditCardResult = redactor.RedactCreditCard("4111-1111-1111-1111");

// returns based on current culture
// en-NZ: "**/**/****"
// en-US: "*/**/****"
// ja-JP: "****/**/**"
// InvariantCulture: "**/**/****"
var dateResult = redactor.RedactDate(new DateTime(2023, 10, 5));

// returns "***-***-****"
var phoneNumberResult = redactor.RedactPhoneNumber("212-456-7890");

// returns "***.*.*.***"
var ipv4Result = redactor.RedactIPv4("192.0.2.146");

// returns "****:****:****:****:****:****:****:****"
var ipv6Result = redactor.RedactIPv6("2001:0000:130F:0000:0000:09C0:876A:130B");

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

## Redacting Types

The following outline the types of data that can be redacted with ZeroRedact. Each data type comes with various redaction types.

### Strings

See [String Redaction](docs/API%20Design/String%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var sensitiveInfo = "Hello, world!";

// Uses the default redactor (All)
// returns "*************"
var allRedaction = redactor.RedactString(sensitiveInfo);

// returns "********"
var fixedLengthOptions = new StringRedactorOptions { RedactorType = StringRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactString(sensitiveInfo, fixedLengthOptions);

// returns "Hello,*******"
var firsthalfOptions =  new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf };
var firstHalfRedaction = redactor.RedactString(sensitiveInfo, firsthalfOptions);

// returns "******, *****!"
var ignoreSymbolsOptions = new StringRedactorOptions { RedactorType = StringRedaction.IgnoreSymbols };
var ignoreSymbolsRedaction = redactor.RedactString(sensitiveInfo, ignoreSymbolsOptions)
```

### Email address

See [Email Address Redaction](docs/API%20Design/Email%20Address%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var emailAddress = "email@example.com";

// Uses the default redactor (Full)
// returns "*****@*******.***"
var fullRedaction = redactor.RedactEmailAddress(emailAddress);

// returns "*****************"
var allOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.All };
var allRedaction = redactor.RedactEmailAddress(emailAddress, allOptions);

// returns "********"
var fixedLengthOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactEmailAddress(emailAddress, fixedLengthOptions);

// returns "*****@example.com"
var usernameOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Username };
var usernameRedaction = redactor.RedactEmailAddress(emailAddress, usernameOptions);

// returns "***il@example.com"
var firstHalfUsernameOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.FirstHalfUsername };
var firstHalfUsernameRedaction = redactor.RedactEmailAddress(emailAddress, firstHalfUsernameOptions);

// returns "em*********le.com"
var middleOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.Middle };
var middleRedaction = redactor.RedactEmailAddress(emailAddress, middleOptions);

// returns "e***l@example.com"
var mostUsernameOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.MostUsername };
var mostUsernameRedaction = redactor.RedactEmailAddress(emailAddress, mostUsernameOptions);

// returns "e****@e******.com"
var showFirstCharactersOptions = new EmailAddressRedactorOptions { RedactorType = EmailAddressRedaction.ShowFirstCharacters };
var showFirstCharactersRedaction = redactor.RedactEmailAddress(emailAddress, showFirstCharactersOptions);
```

### Credit card

See [Credit Card Redaction](docs/API%20Design/Credit%20Card%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var creditCard = "4111-1111-1111-1111";

// Uses default redactor (Full)
// returns "****-****-****-****"
var fullRedaction = redactor.RedactCreditCard(creditCard);

// returns "*******************"
var allOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.All };
var allRedaction = redactor.RedactCreditCard(creditCard, allOptions);

// returns "********"
var fixedLengthOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactCreditCard(creditCard, fixedLengthOptions);

// returns "****-****-****-1111"
var showLastFourOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowLastFour };
var showLastFourRedaction = redactor.RedactCreditCard(creditCard, showLastFourOptions);

// returns "4111-11**-****-1111"
var showFirstSixLastFourOptions = new CreditCardRedactorOptions { RedactorType = CreditCardRedaction.ShowFirstSixLastFour };
var showFirstSixLastFourRedaction = redactor.RedactCreditCard(creditCard, showFirstSixLastFourOptions);
```

### Date

See [Date Redaction](docs/API%20Design/Date%20Redaction.md) for more information.

Note: Date redaction depends on the current culture. Below show four culture examples.

```csharp
var redactor = new Redactor();
var date = new DateTime(2023, 06, 15);

// Uses default redactor (Full)
// returns 
// en-NZ: "**/**/****"
// en-US: "*/**/****"
// ja-JP: "****/**/**"
// InvariantCulture: "**/**/****"
var fullRedaction = redactor.RedactDate(date);

// returns
// en-NZ: "*********"
// en-US: "********"
// ja-JP: "*********"
// InvariantCulture: "*********"
var allOptions = new DateRedactorOptions { RedactorType = DateRedaction.All };
var allRedaction = redactor.RedactDate(date, allOptions);

// returns
// en-NZ: "********"
// en-US: "********"
// ja-JP: "********"
// InvariantCulture: "********"
var fixedLengthOptions = new DateRedactorOptions { RedactorType = DateRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactDate(date, fixedLengthOptions);

// returns
// en-NZ: "**/06/2023"
// en-US: "6/**/2023"
// ja-JP: "2023/06/**"
// InvariantCulture: "06/**/2023"
var dayOptions = new DateRedactorOptions { RedactorType = DateRedaction.Day };
var dayRedaction = redactor.RedactDate(date, dayOptions);

// returns
// en-NZ: "15/**/2023"
// en-US: "*/15/2023"
// ja-JP: "2023/**/15"
// InvariantCulture: "**/15/2023"
var monthOptions = new DateRedactorOptions { RedactorType = DateRedaction.Month };
var monthRedaction = redactor.RedactDate(date, monthOptions);

// returns
// en-NZ: "15/06/****"
// en-US: "6/15/****"
// ja-JP: "****/06/15"
// InvariantCulture: "06/15/****"
var yearOptions = new DateRedactorOptions { RedactorType = DateRedaction.Year };
var yearRedaction = redactor.RedactDate(date, yearOptions); 

// returns
// en-NZ: "**/**/2023"
// en-US: "*/**/2023"
// ja-JP: "2023/**/**"
// InvariantCulture: "**/**/2023"
var dayAndMonthOptions = new DateRedactorOptions { RedactorType = DateRedaction.DayAndMonth };
var dayAndMonthRedaction = redactor.RedactDate(date, dayAndMonthOptions); 

// returns
// en-NZ: "15/**/****"
// en-US: "*/15/****"
// ja-JP: "****/**/15"
// InvariantCulture: "**/15/****"
var monthAndYearOptions = new DateRedactorOptions { RedactorType = DateRedaction.DayAndMonth };
var monthAndYearRedaction = redactor.RedactDate(date, monthAndYearOptions); 

// returns
// en-NZ: "**/06/****"
// en-US: "6/**/****"
// ja-JP: "****/06/**"
// InvariantCulture: "06/**/****"
var dayAndYearOptions = new DateRedactorOptions { RedactorType = DateRedaction.DayAndYear };
var dayAndYearRedaction = redactor.RedactDate(date, dayAndYearOptions);
```

### Phone number

See [Phone Number Redaction](docs/API%20Design/Phone%20Number%20Redaction.md) for more information on redacting and number formats.

```csharp
var redactor = new Redactor();
var phoneNumber = "212-456-7890";

// Uses default redactor (Full)
// returns "***-***-****"
var fullRedaction = redactor.RedactPhoneNumber(phoneNumber);

// returns "************"
var allOptions = new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.All };
var allRedaction = redactor.RedactPhoneNumber(phoneNumber, allOptions);

// returns "********"
var fixedLengthOptions = new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactPhoneNumber(phoneNumber, fixedLengthOptions);

// returns "***-***-7890"
var showLastFourOptions = new PhoneNumberRedactorOptions { RedactorType = PhoneNumberRedaction.ShowLastFour };
var showLastFourRedaction = redactor.RedactPhoneNumber(phoneNumber, showLastFourOptions);
```

### IPv4 address

See [IPv4 Address Redaction](docs/API%20Design/IPv4%20Address%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var ipv4Address = "192.0.2.146";

// Uses default redactor (Full)
// returns "***.*.*.***"
var fullRedaction = redactor.RedactIPv4(ipv4Address);

// returns "***********"
var allOptions = new IPv4RedactorOptions { RedactorType = IPv4Redaction.All };
var allRedaction = redactor.RedactIPv4(ipv4Address, allOptions);

// returns "********"
var fixedLengthOptions = new IPv4RedactorOptions { RedactorType = IPv4Redaction.FixedLength };
var fixedLengthRedaction = redactor.RedactIPv4(ipv4Address, fixedLengthOptions);

// returns "***.*.*.146"
var showLastOctetOptions = new IPv4RedactorOptions { RedactorType = IPv4Redaction.ShowLastOctet };
var showLastOctetRedaction = redactor.RedactIPv4(ipv4Address, showLastOctetOptions);

```

### IPv6 address

See [IPv6 Address Redaction](docs/API%20Design/IPv6%20Address%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var ipv6Address = "2001:0000:130F:0000:0000:09C0:876A:130B";

// Uses default redactor (Full)
// returns "****:****:****:****:****:****:****:****"
var fullRedaction = redactor.RedactIPv6(ipv6Address);

// returns "***************************************"
var allOptions = new IPv6RedactorOptions { RedactorType = IPv6Redaction.All };
var allRedaction = redactor.RedactIPv6(ipv6Address, allOptions);

// returns "********"
var fixedLengthOptions = new IPv6RedactorOptions { RedactorType = IPv6Redaction.FixedLength };
var fixedLengthRedaction = redactor.RedactIPv6(ipv6Address, fixedLengthOptions);

// returns "****:****:****:****:****:****:****:130B"
var showLastQuartetOptions = new IPv6RedactorOptions { RedactorType = IPv6Redaction.ShowLastQuartet };
var showLastQuartetRedaction = redactor.RedactIPv6(ipv4Address, showLastQuartetOptions);

```

### MAC address

See [MAC Address Redaction](docs/API%20Design/MAC%20Address%20Redaction.md) for more information.

```csharp
var redactor = new Redactor();
var macAddress = "00:B0:D0:63:C2:26";

// Uses default redactor (Full)
// returns "****:****:****:****:****:****:****:****"
var fullRedaction = redactor.RedactMACAddress(macAddress);

// returns "***************************************"
var allOptions = new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.All };
var allRedaction = redactor.RedactMACAddress(macAddress, allOptions);

// returns "********"
var fixedLengthOptions = new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactMACAddress(macAddress, fixedLengthOptions);

// returns "****:****:****:****:****:****:****:130B"
var showLastByteOptions = new MACAddressRedactorOptions { RedactorType = MACAddressRedaction.ShowLastByte };
var showLastByteRedaction = redactor.RedactMACAddress(macAddress, showLastByteOptions);

```
## Concepts

### API Design

Read more in the [General Design document](<docs/API Design/00 General Design.md>).

### Permissive inputs

There is an assumption that the data coming into ZeroRedact is already well formed, however there are often multiple opinions or standards of what "well formed" means. ZeroRedact does not fully validate incoming data as the only validation is whether key shapes of the data are present for redaction. For example:

```csharp
var invalidEmail = ".email@example.com"
var redactor = new Redactor();

// result "******@*******.***"
var result = redactor.RedactEmailAddress(invalidEmail)
```

While it is invalid, it has what ZeroRedact requires:
1. An '@' sign
1. Left of the final '@' sign not being empty
2. A '.'
3. The right of the final '.' not being empty

Assuming the incoming data is well formed, this means ZeroRedact has an advantage of being able to accept all sorts of formats such as for telephone numbers:
1. +1 (555) 123-4567
1. +86 137 1234 5678
1. 555 123 456
1. 555123456
1. +7 495 123-45-67

### Layered configuration

Users should have a fine grained customization experience which allows for an easy to reuse item that can setup default behaviours but when needed, can adapt to the need of the redaction call at the time.

### Error handling

Redacting will not throw exceptions - that is, the string manipulation logic. Any exception during the redacting process will return a fixed length redaction with a default redacting character. This is to avoid disrupting the important real work happening in a user's codebase while still preventing PII from being exposed.

However exceptions can occur by passing invalid options to the redactor, whether that's via the constructor, or via a redaction method.

### No external dependencies

No extra NuGet packages are pulled in when using ZeroRedact. 

## Performance

### Benchmarks
See [benchmarks](benchmarks).

## License

[MIT](LICENSE)