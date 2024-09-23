# Email Address Redaction API Design

## Redaction types

The following redaction types were considered at for ZeroRedact. 

| Redacted output              | Used | Type                                                                                       | Notes                                                                                                                                                            |
| ---------------------------- | ---- | ------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| email@example.com            | -    | No redaction                                                                               | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| *****************            | ✅   | All characters full redaction                                                              | Same length as the original string                                                                                                                               |
| ********                     | ✅   | Fixed length full redaction                                                                | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| *****@*\*\*\*\*\*\*.\*\*\*   | ✅   | Showing symbols, partial redaction                                                         | Showing only the symbols that matter such as the final '@' and the final '.', as the email address spec allows multiple of those characters in an email          |
| *****@\*\*\*\*\*\*\*.com     | -    | Showing only the TLD, partial redaction                                                    | Showing what is probably the least important bit of the email address (for most cases). Probably not too useful                                                  |
| *****@example.*\*\*          | -    | Showing the domain without the TLD, partial redaction                                      | This doesn't seem useful in being able to partially identity data, because example below is probably better                                                      |
| *****@example.com            | ✅   | Showing the full domain, partial redaction                                                 | Preserving the username length while showing the potentially lesser important domain                                                                             |
| email@\*\*\*\*\*\*\*.\*\*\*  | -    | Showing the username with the TLD dot, partial redaction                                   | This partial redaction might be counterintuitive to most purposes                                                                                                |
| email@\*\*\*\*\*\*\*.com     | -    | Showing the username with the TLD, partial redaction                                       | Similar to above                                                                                                                                                 |
| email@example.***            | -    | Redacting only the TLD, partial redaction                                                  | Probably useless for any important use case                                                                                                                      |
| ***il@example.com            | ✅   | Redacting only the first half (rounded up) of the username, partial redaction              | Probably useful in cases where a user is told "an email has been sent to x", reveals enough to be useful to the right people                                     |
| em\*\*\*\*\*\*\*\*\*le.com   | ✅   | Redacting half of the useraname up to the @ and half after the @, partial redaction        | Similar use case to above                                                                                                                                        |
| e***l@example.com            | ✅   | Redacting the username except the first and last characters, partial redaction             | Similar use case to above                                                                                                                                        |
| e\*\*\*\*@\*\*\*\*\*\*\*.com | -   | Redacting the username except the first character and all of the domain, partial redaction | Similar use case to above                                                                                                                                        |
| e\*\*\*\*@e\*\*\*\*\*\*.com | ✅   | Redacting the username except the first character and all of the domain, partial redaction | Similar use case to above, but better than the one just above                                                                                                                                        |

The decision making to include a redaction type:

1. Does it work on redacting the most identifiable part, the username?
1. What are common use cases for redacted email addresses?
1. What are commonly expected redaction types for email addresses?
1. it should be clear an email address is being redacted

## Notes
- IP domain email addresses are not supported but may function
- A good [list of email addresses](https://gist.github.com/cjaoude/fd9910626629b53c4d25)