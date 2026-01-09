```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 21.98 ns | 0.163 ns | 0.144 ns | 0.0115 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 22.06 ns | 0.112 ns | 0.099 ns | 0.0115 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 14.47 ns | 0.018 ns | 0.014 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 15.61 ns | 0.048 ns | 0.038 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 28.23 ns | 0.155 ns | 0.129 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 29.21 ns | 0.368 ns | 0.326 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 30.92 ns | 0.442 ns | 0.413 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 31.36 ns | 0.214 ns | 0.201 ns | 0.0114 |      48 B |
