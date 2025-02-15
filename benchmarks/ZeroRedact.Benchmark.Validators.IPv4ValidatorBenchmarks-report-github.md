```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean      | Error     | StdDev    | Allocated |
|---------------------- |------------ |----------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    |  4.835 ns | 0.0110 ns | 0.0098 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 |  6.431 ns | 0.0370 ns | 0.0346 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 10.871 ns | 0.0370 ns | 0.0346 ns |         - |
