# MAC Address

## Redaction types

| Redacted output                    | Used | Type                                       | Notes                                                                                                                                                            |
| ---------------------------------- | ---- | ------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 00:1A:2B:3C:4D:5E                  | -    | No redaction                               | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\* | ✅   | All characters full redaction              | Same length as the original MAC address. This includes separators.                                                                                               |
| \*\*\*\*\*\*\*\*                   | ✅   | Fixed length full redaction                | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| \*\*:\*:\*:\*:\*:\*\*              | ✅   | Full character redaction partial redaction | Preserves separators, obvious it's an IPv4 address                                                                                                               |
| \*\*:\*:\*:\*:\*:5E                | ✅   | Showing last byte partial redaction        | Useful due to log messages or user display without giving up too much                                                                                            |

The decision making to include a redaction type:
1. It should be clear a MAC address is being redacted.

## Notes
- EUI-48 and EUI-64 formats are supported
- Space and dash separators are supported