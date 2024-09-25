```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 35.57 ns | 0.302 ns | 0.282 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 34.79 ns | 0.263 ns | 0.219 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 27.02 ns | 0.158 ns | 0.148 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 26.96 ns | 0.157 ns | 0.147 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 46.58 ns | 0.437 ns | 0.409 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 45.24 ns | 0.415 ns | 0.388 ns | 0.0134 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 51.67 ns | 0.272 ns | 0.241 ns | 0.0134 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 54.12 ns | 0.290 ns | 0.271 ns | 0.0134 |      56 B |
