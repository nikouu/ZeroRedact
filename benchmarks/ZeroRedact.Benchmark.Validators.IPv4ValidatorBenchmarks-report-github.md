```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                | ipAddress   | Mean      | Error     | StdDev    | Allocated |
|---------------------- |------------ |----------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    |  5.250 ns | 0.0775 ns | 0.0687 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 |  7.837 ns | 0.0802 ns | 0.0711 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 11.058 ns | 0.0870 ns | 0.0771 ns |         - |
