```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 33.42 ns | 0.235 ns | 0.208 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 38.56 ns | 0.174 ns | 0.154 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 24.29 ns | 0.043 ns | 0.038 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 30.43 ns | 0.043 ns | 0.038 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 73.35 ns | 0.345 ns | 0.322 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 74.57 ns | 0.241 ns | 0.213 ns | 0.0248 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 76.23 ns | 0.635 ns | 0.531 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 83.11 ns | 0.225 ns | 0.199 ns | 0.0248 |     104 B |
