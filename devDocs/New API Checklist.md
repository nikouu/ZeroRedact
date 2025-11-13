# New API Checklist

When adding or updating a new API:

1. Tests
	1. Tests for checking overwriting in the contiguous memory too
1. Update public API check
1. Bump version
1. Code coverage
1. Update docs
	1. Regenerate public API docs with the script
	1. Change any doc examples that might be impacted
	1. Write new docs
		1. Add to /redactorTypes
		1. Update /design
		1. Update the readme
1. Ensure demo works
1. Benchmarks