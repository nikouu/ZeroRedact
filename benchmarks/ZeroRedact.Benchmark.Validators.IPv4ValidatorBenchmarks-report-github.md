```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean     | Error     | StdDev    | Allocated |
|---------------------- |------------ |---------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    | 2.606 ns | 0.0063 ns | 0.0056 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 | 3.046 ns | 0.0060 ns | 0.0056 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 7.251 ns | 0.0150 ns | 0.0133 ns |         - |
