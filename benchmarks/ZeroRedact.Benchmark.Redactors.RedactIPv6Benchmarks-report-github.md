```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 39.90 ns | 0.432 ns | 0.404 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 39.08 ns | 0.231 ns | 0.216 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 29.59 ns | 0.216 ns | 0.192 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 30.86 ns | 0.063 ns | 0.053 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 80.46 ns | 0.844 ns | 0.748 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 68.07 ns | 0.510 ns | 0.452 ns | 0.0248 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 78.50 ns | 0.603 ns | 0.535 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 78.41 ns | 0.585 ns | 0.547 ns | 0.0248 |     104 B |
