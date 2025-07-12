```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 31.13 ns | 0.093 ns | 0.073 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 36.52 ns | 0.127 ns | 0.119 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 21.82 ns | 0.052 ns | 0.046 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 27.71 ns | 0.103 ns | 0.091 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 72.56 ns | 0.350 ns | 0.293 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 70.05 ns | 0.208 ns | 0.174 ns | 0.0248 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 72.06 ns | 0.219 ns | 0.183 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 74.65 ns | 0.245 ns | 0.204 ns | 0.0248 |     104 B |
