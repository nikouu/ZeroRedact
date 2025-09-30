```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 23.60 ns | 0.158 ns | 0.148 ns | 0.0115 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 23.84 ns | 0.084 ns | 0.070 ns | 0.0115 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 16.57 ns | 0.106 ns | 0.094 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 17.70 ns | 0.067 ns | 0.060 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 31.38 ns | 0.121 ns | 0.101 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 30.41 ns | 0.115 ns | 0.102 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 32.20 ns | 0.215 ns | 0.201 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 31.48 ns | 0.155 ns | 0.138 ns | 0.0114 |      48 B |
