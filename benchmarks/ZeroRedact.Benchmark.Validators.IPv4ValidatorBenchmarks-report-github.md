```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean     | Error     | StdDev    | Allocated |
|---------------------- |------------ |---------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    | 2.617 ns | 0.0128 ns | 0.0100 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 | 3.059 ns | 0.0181 ns | 0.0151 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 7.293 ns | 0.0323 ns | 0.0286 ns |         - |
