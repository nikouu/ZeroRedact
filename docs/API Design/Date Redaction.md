# Date Redaction API Design

## Redaction types

The following redaction types were considered at for ZeroRedact. 

These examples are using dd/mm/yyyy, though the redactor will respect the caller's `CultureInfo.CurrentCulture`.

| Redacted output  | Used | Type                                                  | Notes                                                                                                                                                            |
| ---------------- | ---- | ----------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 15/06/2023       | -    | No redaction                                          | Not the goal for this project. While there could be an option for it, that would be more "moving parts" to maintain and test                                     |
| **********       | ✅   | All characters full redaction                         | Same length as the original date short string representation                                                                                                     |
| ********         | ✅   | Fixed length full redaction                           | Fixed size, probably doesn't give away the underlying data length, only that there is redacted data (unless the redaction length is the same as the data length) |
| \*\*/**/****     | ✅   | Full number partial redaction                         | Preserves the date delimiters. Obvious it's a date, and may give away 1st-9th of a month if a culture's format doesn't use 01-09 for day or month.               |
| \**/**/2023      | ✅   | Redact day and month, but not year, partial redaction | Date redactions in all forms probably fit a niche                                                                                                                |
| \*\*/06/\*\*\*\* | ✅   | Redact day and year, but not month, partial redaction | See above                                                                                                                                                        |
| **/06/2023       | ✅   | Redact day, but not month and year, partial redaction | See above                                                                                                                                                        |
| 15/**/****       | ✅   | Redact month and year, but not day, partial redaction | See above                                                                                                                                                        |
| 15/**/2023       | ✅   | Redact month, but not day and year, partial redaction | See above                                                                                                                                                        |
| 15/06/****       | ✅   | Redact year, but not day and month, partial redaction | See above                                                                                                                                                        |

The decision making to include a redaction type:

1. Providing a full redaction suite for the different date combinations isn't too big, they can all go in
1. It should be clear it's a date being redacted

## Notes

- The date redaction only accept the known .NET date objects `DateTime` and `DateOnly`. This is because the date validations, and culture formatting would be too much to manually write.
- Date redaction only returns the short date format to mimic [`DateOnly.ToString()`](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly.tostring?view=net-8.0#system-dateonly-tostring).
- Date delimiter is preserved based on what .NET is using.
- There is no custom date formatting for a redacted date string.
