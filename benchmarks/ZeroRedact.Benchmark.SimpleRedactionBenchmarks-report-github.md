```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  15.83 ns | 0.092 ns | 0.077 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  20.46 ns | 0.184 ns | 0.172 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  20.71 ns | 0.231 ns | 0.216 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  29.52 ns | 0.205 ns | 0.171 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  53.96 ns | 0.453 ns | 0.401 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 143.78 ns | 0.881 ns | 0.736 ns | 0.0401 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  16.87 ns | 0.217 ns | 0.203 ns | 0.0306 |     128 B |
