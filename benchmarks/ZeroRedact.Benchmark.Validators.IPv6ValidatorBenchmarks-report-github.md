```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean      | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  |  6.654 ns | 0.1315 ns | 0.1230 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 10.040 ns | 0.0950 ns | 0.0794 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        |  5.515 ns | 0.0770 ns | 0.0643 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] |  9.204 ns | 0.1018 ns | 0.0903 ns |         - |
