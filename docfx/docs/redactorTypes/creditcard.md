# Credit Card

The following show examples of all the credit card redactor types:

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