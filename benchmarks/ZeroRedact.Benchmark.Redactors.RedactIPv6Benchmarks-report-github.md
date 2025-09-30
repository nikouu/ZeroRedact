```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 26.14 ns | 0.177 ns | 0.157 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 27.16 ns | 0.467 ns | 0.437 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 17.65 ns | 0.048 ns | 0.042 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 18.61 ns | 0.077 ns | 0.068 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 56.66 ns | 0.293 ns | 0.229 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 61.40 ns | 0.366 ns | 0.324 ns | 0.0248 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 61.74 ns | 0.444 ns | 0.415 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 61.94 ns | 0.334 ns | 0.296 ns | 0.0248 |     104 B |
