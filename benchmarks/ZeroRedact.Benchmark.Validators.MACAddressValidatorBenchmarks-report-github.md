```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean      | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    |  4.617 ns | 0.0570 ns | 0.0533 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 13.766 ns | 0.0629 ns | 0.0558 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    |  4.872 ns | 0.0360 ns | 0.0337 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 13.740 ns | 0.1489 ns | 0.1320 ns |         - |
