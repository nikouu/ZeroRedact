```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 22.42 ns | 0.044 ns | 0.036 ns | 0.0115 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 22.94 ns | 0.077 ns | 0.065 ns | 0.0115 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 16.23 ns | 0.046 ns | 0.043 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 17.19 ns | 0.026 ns | 0.020 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 30.05 ns | 0.100 ns | 0.089 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 30.60 ns | 0.087 ns | 0.077 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 31.17 ns | 0.071 ns | 0.063 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 31.97 ns | 0.119 ns | 0.100 ns | 0.0114 |      48 B |
