# Phone Number

## Redaction types

| Redacted output          | Used | Type                                    | Notes                                                                                                                                                            |
| ------------------------ | ---- | --------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 212-456-7890             | -    | No redaction                            | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| \*\*\*\*\*\*\*\*\*\*\*\* | ✅   | Full redaction                          | Same length as the original string                                                                                                                               |
| \*\*\*\*\*\*\*\*         | ✅   | Fixed length full redaction             | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| \*\*\*-\*\*\*-\*\*\*\*   | ✅   | Full digit redaction, partial redaction | This will ignore all non digit characters. I.e. "+" and "()" will be preserved. It should be obvious this is a phone number.                                     |
| \*\*\*-\*\*\*-7890       | ✅   | Show four, partial redaction            | Useful due to log messages or user display (e.g. 2FA) without giving up too much                                                                                 |

The decision making to include a redaction type:
1. It should be clear a phone number is being redacted.

## Notes
- [E.164](https://en.wikipedia.org/wiki/E.164) phone number format preferred, but it should be fine without
- Example formats via [Why You Should Care About Phone Number Formatting In Your CRM (and How to Fix Them)](https://blog.insycle.com/phone-number-formatting-crm)
- The validation checks for redacting will not care which characters are used as separators, or if there are characters to indicate area code
- Phone number research
	- [Microsoft - Globalization for telephone number formats](https://learn.microsoft.com/en-us/globalization/locale/telephone-numbers)
	- [Microsoft - Canonical address format for phone numbers](https://learn.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2003/cc728034(v=ws.10)?redirectedfrom=MSDN)
	- [Wikipedia - National conventions for writing telephone numbers](https://en.wikipedia.org/wiki/National_conventions_for_writing_telephone_numbers) 
	- 