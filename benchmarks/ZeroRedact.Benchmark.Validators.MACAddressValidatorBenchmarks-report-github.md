```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method               | macAddress           | Mean      | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    |  4.697 ns | 0.0386 ns | 0.0342 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 13.694 ns | 0.0766 ns | 0.0717 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    |  4.932 ns | 0.0156 ns | 0.0131 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 13.581 ns | 0.0575 ns | 0.0481 ns |         - |
