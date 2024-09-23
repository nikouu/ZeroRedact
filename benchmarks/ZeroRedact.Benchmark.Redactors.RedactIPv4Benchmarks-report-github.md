```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                | IPv4Input            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactIPv4_String       | 192.168.0.1:All      | 37.16 ns | 0.399 ns | 0.354 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:All      | 35.91 ns | 0.307 ns | 0.272 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)ength [23] | 27.69 ns | 0.220 ns | 0.195 ns |      - |         - |
| RedactIPv4_ReadOnlySpan | 192.1(...)ength [23] | 27.76 ns | 0.252 ns | 0.224 ns |      - |         - |
| RedactIPv4_String       | 192.168.0.1:Full     | 41.97 ns | 0.335 ns | 0.297 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.168.0.1:Full     | 43.78 ns | 0.333 ns | 0.312 ns | 0.0114 |      48 B |
| RedactIPv4_String       | 192.1(...)Octet [25] | 47.02 ns | 0.822 ns | 0.728 ns | 0.0114 |      48 B |
| RedactIPv4_ReadOnlySpan | 192.1(...)Octet [25] | 46.11 ns | 0.403 ns | 0.358 ns | 0.0114 |      48 B |
