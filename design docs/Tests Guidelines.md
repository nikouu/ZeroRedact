# Test Guidelines

- Tests against both the `string` and `ReadOnlySpan<char>` versions.
	- Tests are done by dynamic data sources in order to be applied to both
- Data driven

## Test naming schemes

| Test type                       | Naming                                                 |
| ------------------------------- | ------------------------------------------------------ |
| Redaction method tests          | Redact\<Type>_\<RedactionType>\_\<Result>\_\<Overload> |
| Data for redaction method tests | \<RedactionType>_TestData                              |
| Other                           | \<Type>\_\<Case>_\<Result>                             |
