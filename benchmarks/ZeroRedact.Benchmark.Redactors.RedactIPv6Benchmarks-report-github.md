```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 24.47 ns | 0.129 ns | 0.107 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 24.86 ns | 0.126 ns | 0.105 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 16.10 ns | 0.128 ns | 0.119 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 16.96 ns | 0.068 ns | 0.057 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 54.11 ns | 0.326 ns | 0.305 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 53.60 ns | 0.220 ns | 0.195 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 60.36 ns | 0.391 ns | 0.366 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 60.34 ns | 0.393 ns | 0.348 ns | 0.0248 |     104 B |
