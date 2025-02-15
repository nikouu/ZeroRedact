```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  24.68 ns | 0.550 ns | 0.934 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  24.79 ns | 0.109 ns | 0.091 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  24.97 ns | 0.474 ns | 0.420 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  31.80 ns | 0.523 ns | 0.464 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  61.71 ns | 0.528 ns | 0.441 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 195.72 ns | 2.773 ns | 2.723 ns | 0.0401 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  20.67 ns | 0.116 ns | 0.103 ns | 0.0306 |     128 B |
