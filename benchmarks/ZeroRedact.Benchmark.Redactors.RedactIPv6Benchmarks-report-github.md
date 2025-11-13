```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 27.11 ns | 0.065 ns | 0.061 ns | 0.0249 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 28.93 ns | 0.063 ns | 0.059 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 17.54 ns | 0.024 ns | 0.022 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 18.97 ns | 0.025 ns | 0.022 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 58.60 ns | 0.188 ns | 0.157 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 59.28 ns | 0.208 ns | 0.194 ns | 0.0249 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 60.45 ns | 0.174 ns | 0.163 ns | 0.0248 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 63.77 ns | 0.276 ns | 0.258 ns | 0.0248 |     104 B |
