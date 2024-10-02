# MAC Address

The following show examples of all the MAC address redactor types:

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