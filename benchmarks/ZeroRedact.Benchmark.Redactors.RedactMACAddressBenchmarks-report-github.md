```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 28.48 ns | 0.126 ns | 0.112 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 34.79 ns | 0.121 ns | 0.113 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 21.39 ns | 0.074 ns | 0.065 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 27.94 ns | 0.058 ns | 0.048 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 43.72 ns | 0.171 ns | 0.152 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 44.75 ns | 0.052 ns | 0.043 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 46.17 ns | 0.162 ns | 0.143 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 51.61 ns | 0.219 ns | 0.194 ns | 0.0134 |      56 B |
