```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 23.48 ns | 0.070 ns | 0.066 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 23.72 ns | 0.089 ns | 0.079 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 17.56 ns | 0.026 ns | 0.024 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 18.49 ns | 0.040 ns | 0.031 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 36.00 ns | 0.085 ns | 0.079 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 36.39 ns | 0.100 ns | 0.089 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 44.92 ns | 0.123 ns | 0.115 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 40.35 ns | 0.102 ns | 0.096 ns | 0.0134 |      56 B |
