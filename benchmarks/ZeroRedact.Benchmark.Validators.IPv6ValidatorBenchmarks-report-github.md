```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 6.465 ns | 0.0098 ns | 0.0087 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 9.913 ns | 0.0477 ns | 0.0422 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 5.274 ns | 0.0278 ns | 0.0232 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 8.838 ns | 0.0362 ns | 0.0321 ns |         - |
