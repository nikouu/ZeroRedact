```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean      | Error     | StdDev    | Allocated |
|---------------------- |------------ |----------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    |  5.109 ns | 0.0418 ns | 0.0391 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 |  6.415 ns | 0.0373 ns | 0.0311 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 10.838 ns | 0.0269 ns | 0.0225 ns |         - |
