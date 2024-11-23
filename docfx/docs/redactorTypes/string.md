# String

The following show examples of all the string redactor types:

```csharp
var redactor = new Redactor();
var sensitiveInfo = "Hello, world!";

// Uses the default redactor (All)
// returns "*************"
var allRedaction = redactor.RedactString(sensitiveInfo);

// returns "********"
var fixedLengthOptions = new StringRedactorOptions { RedactorType = StringRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactString(sensitiveInfo, fixedLengthOptions);

// returns "*******world!"
var firstHalfOptions =  new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf };
var firstHalfRedaction = redactor.RedactString(sensitiveInfo, firstHalfOptions);

// returns "Hello,*******"
var secondHalfOptions =  new StringRedactorOptions { RedactorType = StringRedaction.SecondHalf };
var secondHalfRedaction = redactor.RedactString(sensitiveInfo, secondHalfOptions);

// returns "*****, *****!"
var ignoreSymbolsOptions = new StringRedactorOptions { RedactorType = StringRedaction.IgnoreSymbols };
var ignoreSymbolsRedaction = redactor.RedactString(sensitiveInfo, ignoreSymbolsOptions);

// returns "H***********!"
var showFirstAndLastCharacterOptions = new StringRedactorOptions { RedactorType = StringRedaction.ShowFirstAndLast };
var showFirstAndLastCharacterRedaction = redactor.RedactString(sensitiveInfo, showFirstAndLastCharacterOptions);
```