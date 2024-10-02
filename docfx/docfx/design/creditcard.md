# Credit Card

## Redaction types

The following redaction types were considered at for ZeroRedact. 

| Redacted output                     | Used | Type                                                                    | Notes                                                                                                                                                                                                                                      |
| ----------------------------------- | ---- | ----------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 0000-0000-0000-0000                 | -    | No redaction                                                            | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                                                                                               |
| *******************                 | ✅   | All characters full redaction                                           | Same length as the original credit card redaction. This includes the spaces or dashes between digit groups. While keeping the symbols would be better, this is kept in to preserve consistency of a "full" redaction across all redactors. |
| ********                            | ✅   | Fixed length full redaction                                             | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length)                                                                           |
| \*\*\*\*-\*\*\*\*-\*\*\*\*-\*\*\*\* | ✅   | Full digit partial redaction                                            | Redacts everything except symbols. If the input has no symbols, it would just be a full redaction at the length of the input digits                                                                                                        |
| ***************0000                 | -    | Showing last four, with symbols redacted too, partial redaction         | Superseded by below.                                                                                                                                                                                                                       |
| \*\*\*\*-\*\*\*\*-\*\*\*\*-0000     | ✅   | Showing last four, not redacting symbols, partial redaction             | More useful than above because log investigations, or messages to users will have a little more context that this is a credit card                                                                                                         |
| 0000-00\*\*\*\*\*\*\*\*0000         | -    | Show first six, last four, with symbols redacted too, partial redaction | Superseded by below                                                                                                                                                                                                                        |
| 0000-00\*\*-\*\*\*\*-0000           | ✅   | Show first six, last four, not redacting symbols, partial redaction     | More useful than above because log investigations, or messages to users will have a little more context that this is a credit card                                                                                                         |

The decision making to include a redaction type:

1. It should cover all redacted
1. It should cover the last four scenario
1. It should cover the first six, last four scenario
1. It should be clear it's a credit card number being redacted

## Notes
- Credit cards don't have to be 16 digits ([Wikipedia](https://en.wikipedia.org/wiki/Payment_card_number))
- Redaction should work regardless of separator symbols, i.e. one big number
- [Credit card testing info](https://www.windcave.com/support-merchant-frequently-asked-questions-testing-details)