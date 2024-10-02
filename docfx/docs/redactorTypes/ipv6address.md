# IPv6 Address

The following show examples of all the IPv6 address redactor types:

```csharp
var redactor = new Redactor();
var ipv6Address = "2001:0000:130F:0000:0000:09C0:876A:130B";

// Uses default redactor (Full)
// returns "****:****:****:****:****:****:****:****"
var fullRedaction = redactor.RedactIPv6Address(ipv6Address);

// returns "***************************************"
var allOptions = new IPv6AddressRedactorOptions { RedactorType = IPv6AddressRedaction.All };
var allRedaction = redactor.RedactIPv6Address(ipv6Address, allOptions);

// returns "********"
var fixedLengthOptions = new IPv6AddressRedactorOptions { RedactorType = IPv6AddressRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactIPv6Address(ipv6Address, fixedLengthOptions);

// returns "****:****:****:****:****:****:****:130B"
var showLastQuartetOptions = new IPv6AddressRedactorOptions { RedactorType = IPv6AddressRedaction.ShowLastQuartet };
var showLastQuartetRedaction = redactor.RedactIPv6Address(ipv4Address, showLastQuartetOptions);
```