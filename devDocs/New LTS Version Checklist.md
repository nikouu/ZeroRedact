# New LTS Version Checklist

When .NET releases a new LTS version, the following should happen:

1. Add that version to both the ZeroRedact and ZeroRedact.UnitTest projects under `TargetFrameworks`.
	1. Ensure that the unit tests run
	1. Ensure that there is complete parity between versions. It may mean introducing a breaking change to a prior .NET package version.
	1. Follow the [New API Checklist.md](<New API Checklist.md>) to bump version, code coverage, etc
2. Update the `TargetFramework` version in ZeroRedact.Benchmark and ZeroRedact.DemoSite to be the new LTS version.