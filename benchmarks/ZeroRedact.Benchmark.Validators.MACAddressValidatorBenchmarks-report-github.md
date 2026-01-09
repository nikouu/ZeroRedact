```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean     | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    | 3.294 ns | 0.0294 ns | 0.0261 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 3.496 ns | 0.0279 ns | 0.0247 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    | 3.266 ns | 0.0167 ns | 0.0140 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 3.269 ns | 0.0045 ns | 0.0035 ns |         - |
