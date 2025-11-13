```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean     | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    | 3.301 ns | 0.0261 ns | 0.0231 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 3.502 ns | 0.0140 ns | 0.0117 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    | 3.284 ns | 0.0276 ns | 0.0258 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 3.299 ns | 0.0249 ns | 0.0233 ns |         - |
