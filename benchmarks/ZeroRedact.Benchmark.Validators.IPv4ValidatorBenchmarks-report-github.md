```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean      | Error     | StdDev    | Allocated |
|---------------------- |------------ |----------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    |  4.891 ns | 0.0511 ns | 0.0453 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 |  6.471 ns | 0.0771 ns | 0.0644 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 10.928 ns | 0.0907 ns | 0.0849 ns |         - |
