```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 21.54 ns | 0.080 ns | 0.062 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 22.11 ns | 0.134 ns | 0.112 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 15.54 ns | 0.014 ns | 0.011 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 16.67 ns | 0.021 ns | 0.017 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 34.34 ns | 0.311 ns | 0.291 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 33.15 ns | 0.117 ns | 0.098 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 66.72 ns | 0.159 ns | 0.133 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 39.86 ns | 0.233 ns | 0.195 ns | 0.0134 |      56 B |
