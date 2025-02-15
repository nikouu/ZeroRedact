```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 35.68 ns | 0.194 ns | 0.182 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 35.59 ns | 0.091 ns | 0.085 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 27.26 ns | 0.089 ns | 0.083 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 27.71 ns | 0.136 ns | 0.114 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 41.72 ns | 0.274 ns | 0.229 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 41.82 ns | 0.185 ns | 0.164 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 44.78 ns | 0.135 ns | 0.127 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 44.26 ns | 0.186 ns | 0.165 ns | 0.0114 |      48 B |
