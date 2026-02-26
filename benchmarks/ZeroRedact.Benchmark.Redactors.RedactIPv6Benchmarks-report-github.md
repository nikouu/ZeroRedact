```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                  | IPv6Input            | Mean     | Error    | StdDev   | Median    | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|----------:|-------:|----------:|
| RedactIPv6_String       | 2001:(...)4:All [43] | 15.45 ns | 0.035 ns | 0.029 ns | 15.451 ns | 0.0066 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)4:All [43] | 16.18 ns | 0.025 ns | 0.021 ns | 16.177 ns | 0.0066 |     104 B |
| RedactIPv6_String       | 2001:(...)ength [51] | 10.03 ns | 0.230 ns | 0.358 ns |  9.780 ns |      - |         - |
| RedactIPv6_ReadOnlySpan | 2001:(...)ength [51] | 11.03 ns | 0.035 ns | 0.033 ns | 11.033 ns |      - |         - |
| RedactIPv6_String       | 2001:(...):Full [44] | 27.34 ns | 0.221 ns | 0.184 ns | 27.302 ns | 0.0066 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...):Full [44] | 28.90 ns | 0.596 ns | 1.149 ns | 28.100 ns | 0.0066 |     104 B |
| RedactIPv6_String       | 2001:(...)artet [55] | 28.88 ns | 0.086 ns | 0.072 ns | 28.882 ns | 0.0066 |     104 B |
| RedactIPv6_ReadOnlySpan | 2001:(...)artet [55] | 29.40 ns | 0.100 ns | 0.094 ns | 29.374 ns | 0.0066 |     104 B |
