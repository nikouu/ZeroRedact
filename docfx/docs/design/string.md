# String

## Redaction types

The following redaction types were considered at for ZeroRedact. 

| Redacted output | Used | Type                                                            | Notes                                                                                                                                                            |
| --------------- | ---- | --------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Hello, world!   | -    | No redaction                                                    | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| *************   | ✅   | Full redaction                                                  | Same length as the original string                                                                                                                               |
| ********        | ✅   | Fixed length full redaction                                     | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| *******world!   | ✅   | First half partial redacted (rounded up)                        | Possibly useful for another type of sensitive information                                                                                                        |
| Hello,*******   | ✅   | Second half partial redacted (rounded up)                       | Possibly useful for another type of sensitive information                                                                                                        |
| *****, *****!   | ✅   | All redacted except symbols, partial redaction                  | Possibly useful for another type of sensitive information                                                                                                        |
| H***********!   | ✅   | All redacted except first and last character, partial redaction | Possibly useful for another type of sensitive information, or censoring                                                                                          |

The decision making to include a redaction type:

1. This should be lightweight with few types. If more types are needed, it might be a sign there needs to be a new redaction type

## Notes
- With no structure to a raw string, there is no format to respect and work off of