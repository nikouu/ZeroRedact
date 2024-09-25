```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                  | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 35.25 ns | 0.222 ns | 0.207 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 34.97 ns | 0.128 ns | 0.114 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 27.09 ns | 0.167 ns | 0.156 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 27.49 ns | 0.056 ns | 0.047 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 41.92 ns | 0.413 ns | 0.387 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 40.20 ns | 0.170 ns | 0.142 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 45.72 ns | 0.624 ns | 0.584 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 46.65 ns | 0.285 ns | 0.253 ns | 0.0114 |      48 B |
