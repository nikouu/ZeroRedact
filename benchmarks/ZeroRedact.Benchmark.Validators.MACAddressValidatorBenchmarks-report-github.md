```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean      | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    |  4.575 ns | 0.0176 ns | 0.0147 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 13.653 ns | 0.0241 ns | 0.0214 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    |  4.843 ns | 0.0241 ns | 0.0202 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 14.339 ns | 0.0396 ns | 0.0371 ns |         - |
