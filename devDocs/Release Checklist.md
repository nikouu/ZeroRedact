# Release Checklist

## New API Checklist

When adding or updating a new API:

1. Tests
	1. Tests for checking overwriting in the contiguous memory too
1. Update public API check
1. Bump version
1. Code coverage
1. Benchmarks
1. Update docs
	1. Regenerate public API docs with the script `BuildAndRunDocs.ps1`. This will also update the benchmarks tab via `GenerateBenchmarkPages.cs`. The json files need to be moved to their version folder under /benchmarks
	1. Change any doc examples that might be impacted
	1. Write new docs
		1. Add to /redactorTypes
		1. Update /design
		1. Update the readme
1. Ensure demo works

## New LTS Version Checklist

When .NET releases a new LTS version, the following should happen:

1. Add that version to both the ZeroRedact and ZeroRedact.UnitTest projects under `TargetFrameworks`.
	1. Ensure that the unit tests run
	1. Ensure that there is complete parity between versions. It may mean introducing a breaking change to a prior .NET package version.
	1. Follow the [New API Checklist.md](<New API Checklist.md>) to bump version, code coverage, etc
2. Update the `TargetFramework` version in ZeroRedact.Benchmark and ZeroRedact.DemoSite to be the new LTS version.