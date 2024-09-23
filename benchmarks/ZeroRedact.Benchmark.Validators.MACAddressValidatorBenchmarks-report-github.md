```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean      | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    |  4.687 ns | 0.0533 ns | 0.0473 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 13.985 ns | 0.2652 ns | 0.2351 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    |  4.982 ns | 0.0651 ns | 0.0577 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 13.951 ns | 0.1605 ns | 0.1340 ns |         - |
