```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 12.81 ns | 0.031 ns | 0.027 ns | 12.81 ns | 0.0030 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 13.14 ns | 0.274 ns | 0.450 ns | 12.84 ns | 0.0031 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 10.50 ns | 0.238 ns | 0.284 ns | 10.62 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 10.45 ns | 0.016 ns | 0.013 ns | 10.46 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 14.50 ns | 0.317 ns | 0.521 ns | 14.12 ns | 0.0030 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 15.98 ns | 0.329 ns | 0.353 ns | 16.11 ns | 0.0030 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 14.72 ns | 0.032 ns | 0.027 ns | 14.72 ns | 0.0030 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 16.16 ns | 0.337 ns | 0.553 ns | 16.56 ns | 0.0030 |      48 B |
