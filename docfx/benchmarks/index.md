# Benchmarks

Performance benchmarks for ZeroRedact across different versions. Each benchmark shows the mean duration and memory allocation for various operations.

## Redactor Benchmarks

Performance benchmarks for redaction operations:

- [RedactCreditCard](ZeroRedact.Benchmark.Redactors.RedactCreditCardBenchmarks.md)
- [RedactDate](ZeroRedact.Benchmark.Redactors.RedactDateBenchmarks.md)
- [RedactEmailAddress](ZeroRedact.Benchmark.Redactors.RedactEmailAddressBenchmarks.md)
- [RedactIPv4](ZeroRedact.Benchmark.Redactors.RedactIPv4Benchmarks.md)
- [RedactIPv6](ZeroRedact.Benchmark.Redactors.RedactIPv6Benchmarks.md)
- [RedactMACAddress](ZeroRedact.Benchmark.Redactors.RedactMACAddressBenchmarks.md)
- [RedactPhoneNumber](ZeroRedact.Benchmark.Redactors.RedactPhoneNumberBenchmarks.md)
- [RedactString](ZeroRedact.Benchmark.Redactors.RedactStringBenchmarks.md)

## Validator Benchmarks

Performance benchmarks for validation operations:

- [CreditCardValidator](ZeroRedact.Benchmark.Validators.CreditCardValidatorBenchmarks.md)
- [EmailValidator](ZeroRedact.Benchmark.Validators.EmailValidatorBenchmarks.md)
- [IPv4Validator](ZeroRedact.Benchmark.Validators.IPv4ValidatorBenchmarks.md)
- [IPv6Validator](ZeroRedact.Benchmark.Validators.IPv6ValidatorBenchmarks.md)
- [MACAddressValidator](ZeroRedact.Benchmark.Validators.MACAddressValidatorBenchmarks.md)
- [PhoneNumberValidator](ZeroRedact.Benchmark.Validators.PhoneNumberValidatorBenchmarks.md)

## About the Benchmarks

These benchmarks are generated using [BenchmarkDotNet](https://benchmarkdotnet.org/). The charts display:

- **Duration Chart**: Shows the mean execution time in nanoseconds for each method across versions
- **Memory Chart**: Shows the bytes allocated per operation for each method across versions

Lower values indicate better performance.
