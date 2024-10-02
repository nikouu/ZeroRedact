# Email Address

The following show examples of all the email address redactor types:

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