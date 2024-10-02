# Phone Number

The following show examples of all the phone number redactor types:

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