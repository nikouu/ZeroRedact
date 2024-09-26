# IPv6 Address Redaction API Design

| Redacted output                                                                | Used | Type                                    | Notes                                                                                                                                                            |
| ------------------------------------------------------------------------------ | ---- | --------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 2001:0000:130F:0000:0000:09C0:876A:130B                                        | -    | No redaction                            | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\* | ✅   | Full redaction                          | Same length as the original string                                                                                                                               |
| \*\*\*\*\*\*\*\*                                                               | ✅   | Fixed length full redaction             | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| \*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*        | ✅   | Full digit redaction, partial redaction | Preserves separators, obvious it's an IPv6 address                                                                                                               |
| \*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:\*\*\*\*:130B            | ✅   | Show last quartet, partial redaction    | Useful due to log messages or user display without giving up too much                                                                                            |

The decision making to include a redaction type:
1. It should be clear an IPv6 address is being redacted.

## Notes
- Subnets aren't supported