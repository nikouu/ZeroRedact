```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  17.33 ns | 0.215 ns | 0.201 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  20.98 ns | 0.150 ns | 0.126 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  21.73 ns | 0.127 ns | 0.106 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  28.78 ns | 0.510 ns | 0.452 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  54.21 ns | 0.437 ns | 0.409 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 147.63 ns | 1.152 ns | 0.962 ns | 0.0401 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  17.19 ns | 0.325 ns | 0.288 ns | 0.0306 |     128 B |
