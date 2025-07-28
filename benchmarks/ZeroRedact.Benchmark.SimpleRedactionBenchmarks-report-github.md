```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  24.39 ns | 0.462 ns | 0.432 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  26.49 ns | 0.566 ns | 0.556 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  26.54 ns | 0.462 ns | 0.432 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  32.57 ns | 0.489 ns | 0.502 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  64.27 ns | 0.858 ns | 0.802 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 203.79 ns | 4.116 ns | 8.220 ns | 0.0401 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  22.04 ns | 0.438 ns | 0.389 ns | 0.0306 |     128 B |
