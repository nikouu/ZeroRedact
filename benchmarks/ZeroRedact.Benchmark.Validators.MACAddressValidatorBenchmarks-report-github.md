```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean     | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    | 3.266 ns | 0.0071 ns | 0.0063 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 3.481 ns | 0.0094 ns | 0.0088 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    | 3.253 ns | 0.0084 ns | 0.0074 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 3.269 ns | 0.0074 ns | 0.0066 ns |         - |
