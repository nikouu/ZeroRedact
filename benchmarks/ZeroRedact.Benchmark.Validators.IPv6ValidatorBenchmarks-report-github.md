```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 4.291 ns | 0.0156 ns | 0.0138 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 4.423 ns | 0.0163 ns | 0.0144 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 3.067 ns | 0.0203 ns | 0.0170 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 3.297 ns | 0.0124 ns | 0.0110 ns |         - |
