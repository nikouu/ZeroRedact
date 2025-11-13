```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 4.245 ns | 0.0065 ns | 0.0061 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 4.385 ns | 0.0124 ns | 0.0116 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 3.044 ns | 0.0044 ns | 0.0037 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 3.331 ns | 0.0403 ns | 0.0336 ns |         - |
