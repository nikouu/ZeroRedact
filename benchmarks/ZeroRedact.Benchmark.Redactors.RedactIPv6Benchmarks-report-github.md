```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 41.35 ns | 0.527 ns | 0.493 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 41.06 ns | 0.570 ns | 0.534 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 30.41 ns | 0.302 ns | 0.252 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 31.29 ns | 0.282 ns | 0.264 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 71.11 ns | 0.679 ns | 0.602 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 71.21 ns | 0.781 ns | 0.730 ns | 0.0248 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 81.76 ns | 1.065 ns | 0.944 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 84.45 ns | 0.726 ns | 0.679 ns | 0.0248 |     104 B |
