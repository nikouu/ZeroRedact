```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  16.47 ns | 0.098 ns | 0.082 ns |  16.45 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  20.76 ns | 0.470 ns | 0.811 ns |  20.33 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  20.07 ns | 0.075 ns | 0.070 ns |  20.06 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  29.22 ns | 0.112 ns | 0.105 ns |  29.20 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  51.77 ns | 0.160 ns | 0.142 ns |  51.78 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 143.95 ns | 1.789 ns | 2.129 ns | 143.32 ns | 0.0401 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  16.46 ns | 0.080 ns | 0.071 ns |  16.44 ns | 0.0306 |     128 B |
