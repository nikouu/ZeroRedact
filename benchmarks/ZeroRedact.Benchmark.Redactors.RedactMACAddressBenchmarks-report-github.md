```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                        | MACAddressInput      | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| RedactMACAddress_String       | 00:1A(...)E:All [21] | 13.03 ns | 0.022 ns | 0.022 ns | 13.03 ns | 0.0036 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)E:All [21] | 14.68 ns | 0.304 ns | 0.508 ns | 15.01 ns | 0.0036 |      56 B |
| RedactMACAddress_String       | 00:1A(...)ength [29] | 10.66 ns | 0.030 ns | 0.028 ns | 10.65 ns |      - |         - |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)ength [29] | 10.92 ns | 0.233 ns | 0.370 ns | 10.66 ns |      - |         - |
| RedactMACAddress_String       | 00:1A(...):Full [22] | 17.03 ns | 0.038 ns | 0.035 ns | 17.03 ns | 0.0035 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...):Full [22] | 17.48 ns | 0.042 ns | 0.038 ns | 17.48 ns | 0.0035 |      56 B |
| RedactMACAddress_String       | 00:1A(...)tByte [30] | 18.26 ns | 0.058 ns | 0.054 ns | 18.25 ns | 0.0035 |      56 B |
| RedactMACAddress_ReadOnlySpan | 00:1A(...)tByte [30] | 18.76 ns | 0.246 ns | 0.205 ns | 18.76 ns | 0.0035 |      56 B |
