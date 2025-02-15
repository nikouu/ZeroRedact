```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 6.475 ns | 0.0116 ns | 0.0097 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 9.904 ns | 0.0398 ns | 0.0353 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 5.272 ns | 0.0274 ns | 0.0257 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 8.864 ns | 0.0414 ns | 0.0387 ns |         - |
