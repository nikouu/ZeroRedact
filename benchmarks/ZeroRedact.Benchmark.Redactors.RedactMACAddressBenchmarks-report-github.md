```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                      | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------- |--------------------- |---------:|---------:|---------:|-------:|----------:|
| MaskMACAddress_String       | 00:1A(...)E:All [21] | 34.78 ns | 0.260 ns | 0.231 ns | 0.0134 |      56 B |
| MaskMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 34.89 ns | 0.384 ns | 0.321 ns | 0.0134 |      56 B |
| MaskMACAddress_String       | 00:1A(...)ength [29] | 27.39 ns | 0.269 ns | 0.225 ns |      - |         - |
| MaskMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 27.15 ns | 0.154 ns | 0.137 ns |      - |         - |
| MaskMACAddress_String       | 00:1A(...):Full [22] | 47.44 ns | 0.368 ns | 0.307 ns | 0.0134 |      56 B |
| MaskMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 46.19 ns | 0.488 ns | 0.433 ns | 0.0134 |      56 B |
| MaskMACAddress_String       | 00:1A(...)tByte [30] | 53.07 ns | 0.470 ns | 0.393 ns | 0.0134 |      56 B |
| MaskMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 52.61 ns | 0.694 ns | 0.579 ns | 0.0134 |      56 B |
