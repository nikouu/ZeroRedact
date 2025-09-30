```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean     | Error     | StdDev    | Allocated |
|---------------------- |------------ |---------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    | 2.640 ns | 0.0241 ns | 0.0201 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 | 3.058 ns | 0.0097 ns | 0.0086 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 7.285 ns | 0.0387 ns | 0.0362 ns |         - |
