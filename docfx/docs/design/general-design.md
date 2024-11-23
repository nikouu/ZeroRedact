# General Design

The following outlines general design thoughts for ZeroRedact for, during, and after development. 

## How is ZeroRedact used?

This question is the big driver ZeroRedact design. This library is used to redact a discrete piece of sensitive information - that is, a given piece will only be the sensitive information such as an email address. This is in contrast with larger DLP libraries/services which scan entire documents and apply redacting where necessary. 

With this in mind, ZeroRedact offers both full and partial redaction for all types covered and they can be broken into three main types:

1. Full redaction. The entire piece of sensitive information is replaced with a character and the length of the information is preserved.
1. Full redaction at a fixed width. The entire piece of sensitive information is replaced by a fixed width string of a character. This further obscures the data by not giving away length hints.
1. Partial redaction. Most redaction types in ZeroRedact are partial redactions.

| Redaction type                  | Explanation                                                                                                                                                   | Use cases                |
| ------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------ |
| Full redaction                  | The entire piece of sensitive information is replaced with a character and the length of the information is preserved.                                        | To safely display or log |
| Full redaction at a fixed width | The entire piece of sensitive information is replaced by a fixed width string of a character. This further obscures the data by not giving away length hints. | To safely display or log |
| Partial redaction               | Most redaction types in ZeroRedact are partial redactions as these can have the most nuance with use cases                                                    | <ul><li>For "We will send an email to {email}" messages</li><li>For "Payment will be made using this credit card {last four}" messages</li><li>Logging as much as a privacy policy allows for auditing or record keeping</li><li>Displaying as much as a privacy policy allows</li></ul>                         |

ZeroRedact does not redact with strings such as "[REDACTED]". Only single, repeated characters such as '*'.

While the main concern is sensitive information, string redaction can also be used to help censor unwanted words.

## No allocations	

The ultimate goal for this project is zero allocation; **Zero**Redact. 

However, there will most likely be an allocation for the final string that gets produced - because it has to be created at some point.

## Performance 

Performance is a close second goal which often comes from no allocations. However, there may be cases that even after GC pressure is accounted for that something like source generated Regex might be faster. Except in the case for Regex, that allocates and cannot be used. 

## Inspiration

Design inspiration came from a lot of the [.NET runtime repo](https://github.com/dotnet/runtime/), specifically [System.Text.Json](https://github.com/dotnet/runtime/tree/main/src/libraries/System.Text.Json/). Originally ZeroRedact was going to follow the [`JsonSerializer`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-8.0) class of being a static partial class with static methods. However for the sake of testability and giving the user options, ZeroRedact ended up with a regular class approach.

Maintability by having a partial class per type of redaction was also taken from the runtime repo.

## Option configuration

Redaction options can be configured at:
1. Redaction calling time
1. Redaction object creation time

And are layered, with a fallback to defaults if no options are ever specified. 

The idea of passing in options to a method is loosely based on [`JsonSerializerOptions`](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-8.0) and layering options based on [`ConfigurationManager'](https://learn.microsoft.com/en-us/dotnet/api/system.configuration.configurationmanager?view=net-8.0) (see this [great post by Andrew Lock](https://andrewlock.net/exploring-dotnet-6-part-1-looking-inside-configurationmanager-in-dotnet-6/)).

## Convenient overloads

Depending on redacting type, there are multiple overloads that may include different types (e.g. `DateTime` and `DateOnly` for date redaction) and having redaction options setup just for that method call which may be different from default options.


## Defaults

If there is a common enough consensus, that will be the default and it may not be the strongest redaction type. 

If there is no one strong redaction type, either a redaction that keeps the structure but the data hidden (such as \*\*/\*\*/\*\*\*\) or a full redaction will be the default.


## Data safety

Redacting exceptions are supressed and the safest form of redaction is returned: a fixed width redaction. This was chosen because:
1. The caller's execution is not interrupted.
1. It's better to be safe and return the most anonymous and strongest form of redaction in ZeroRedact as a caller's current use case is unknown. 

The decision to return a fixed width redaction was weighed up against the security concerns above and other use cases such as:
- Having useful logs due to partial redaction
- Having useful user messages due to partial redaction

Outside of exceptions, any failed data validation will also result in a fixed with redaction result.



### Invalid option exceptions

However, any invalid options will throw an exception, whether they are passed to the `Redactor` constructor, or in via one of the redaction methods. It is only during the actual redaction work that errors are suppressed.

## Data validation

ZeroRedact is not a data validation tool. Data is only validated enough to perform successful redactions. For example:
1. "email@example.com" is valid and will be redacted with the requested redaction type
1. "email..@example.com" is not a valid email due to ".." but will be redacted with the requested redaction type
1. "emailexample.com" is not a valid email due to no "@" and will be redacted with a fixed width redaction as the "@" symbol is important for redacting
1. "Call me @ your earliest convenience. Thanks." is not a valid email, but will be redacted with the requested redaction type

The reasons behind a lack of full validation are:
1. Often complex to write for all edge cases
1. Validation code may incur heap allocations
1. Speed, as only what is necessary for ZeroRedact to perform redactions is checked
1. It's expected the data is already validated

## Testing

A lot of Data Driven Testing is used to ensure that sensitive information is correctly redacted.

## Benchmarking

A lot of micro-benchmarking work is used to ensure ZeroRedact is a top performing library.

## No external dependencies

Keeps project light, easier to maintain, easier to get approved by having Microsoft-only packages, less supply chain issues.

## Unicode

Unicode is currently not supported. While single width unicode may work such as "かわいい猫" (Japanese for "cute cat")
```csharp
var redactor = new Redactor();

// correctly returns "*****"
var result = redactor.RedactString("かわいい猫");
```

However, when using multiple code points for a single character, such as the three code point character "葛󠄀" ("Kuzdu" or Chinese arrowroot), we get an unexpected result:
```csharp
var redactor = new Redactor();

// Incorrectly returns "***"
var result = redactor.RedactString("葛󠄀");
```

C# has the capability to deal with this with [Rune](https://learn.microsoft.com/en-us/dotnet/api/system.text.rune?view=net-8.0) however more effort needs to go into understanding whether this can happen without allocations.

Read more about these complexities via: [csharplang/Emoji character literals #4500](https://github.com/dotnet/csharplang/discussions/4500#discussioncomment-437052)

## Verbosity 

The method names end up being verbose, for example: `RedactEmailAddress()`, `EmailAddressRedactorOptions` and how combined they can be large. This is intentional in order to be as clear as possible with expectations. As more full redaction libraries take in whole objects or documents to find the sensitive information within and redact, whereas ZeroRedact only redacts the given discrete piece of sensitive information. 

Confusion could arise if the email address redaction method was called `redactor.RedactEmail()` and while the input type is string/ReadOnlySpan, a user may put the content of their email and expect it to be redacted. 