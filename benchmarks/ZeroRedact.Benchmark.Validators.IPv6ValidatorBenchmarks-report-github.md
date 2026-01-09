```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 4.273 ns | 0.0183 ns | 0.0162 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 4.413 ns | 0.0323 ns | 0.0287 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 3.068 ns | 0.0279 ns | 0.0261 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 3.271 ns | 0.0036 ns | 0.0028 ns |         - |
