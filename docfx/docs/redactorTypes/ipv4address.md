# IPv4 Address

The following show examples of all the IPv4 address redactor types:

```csharp
var redactor = new Redactor();
var ipv4Address = "192.0.2.146";

// Uses default redactor (Full)
// returns "***.*.*.***"
var fullRedaction = redactor.RedactIPv4Address(ipv4Address);

// returns "***********"
var allOptions = new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.All };
var allRedaction = redactor.RedactIPv4Address(ipv4Address, allOptions);

// returns "********"
var fixedLengthOptions = new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactIPv4Address(ipv4Address, fixedLengthOptions);

// returns "***.*.*.146"
var showLastOctetOptions = new IPv4AddressRedactorOptions { RedactorType = IPv4AddressRedaction.ShowLastOctet };
var showLastOctetRedaction = redactor.RedactIPv4Address(ipv4Address, showLastOctetOptions);
```