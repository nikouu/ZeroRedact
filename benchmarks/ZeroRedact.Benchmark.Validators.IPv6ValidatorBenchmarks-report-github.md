```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 6.491 ns | 0.0361 ns | 0.0320 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 9.385 ns | 0.0846 ns | 0.0706 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 5.410 ns | 0.0533 ns | 0.0499 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 8.877 ns | 0.0373 ns | 0.0312 ns |         - |
