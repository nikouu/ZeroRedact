```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 35.31 ns | 0.224 ns | 0.199 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 31.86 ns | 0.143 ns | 0.127 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 18.91 ns | 0.046 ns | 0.038 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 24.74 ns | 0.061 ns | 0.051 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 33.81 ns | 0.136 ns | 0.121 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 37.29 ns | 0.102 ns | 0.085 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 36.65 ns | 0.226 ns | 0.189 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 41.38 ns | 0.254 ns | 0.237 ns | 0.0114 |      48 B |
