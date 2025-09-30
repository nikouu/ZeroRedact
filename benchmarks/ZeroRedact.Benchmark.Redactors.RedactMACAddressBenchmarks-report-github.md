```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 24.17 ns | 0.136 ns | 0.121 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 24.43 ns | 0.133 ns | 0.118 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 17.93 ns | 0.087 ns | 0.081 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 19.02 ns | 0.036 ns | 0.034 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 37.19 ns | 0.193 ns | 0.171 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 36.75 ns | 0.108 ns | 0.096 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 41.18 ns | 0.119 ns | 0.100 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 41.91 ns | 0.209 ns | 0.195 ns | 0.0134 |      56 B |
