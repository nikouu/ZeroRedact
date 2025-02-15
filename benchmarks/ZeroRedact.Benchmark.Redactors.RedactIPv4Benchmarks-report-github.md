```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 29.54 ns | 0.123 ns | 0.115 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 35.18 ns | 0.175 ns | 0.164 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 22.68 ns | 0.042 ns | 0.040 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 28.03 ns | 0.069 ns | 0.061 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 35.63 ns | 0.216 ns | 0.192 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 41.67 ns | 0.150 ns | 0.140 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 39.11 ns | 0.083 ns | 0.070 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 44.55 ns | 0.112 ns | 0.093 ns | 0.0114 |      48 B |
