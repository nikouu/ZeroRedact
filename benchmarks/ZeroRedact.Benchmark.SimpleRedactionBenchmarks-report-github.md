```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4894/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                 | value                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  29.37 ns | 0.636 ns | 1.195 ns | 0.0191 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] |  32.38 ns | 0.702 ns | 1.555 ns | 0.0421 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] |  32.47 ns | 0.701 ns | 1.190 ns | 0.0421 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] |  41.37 ns | 0.881 ns | 1.398 ns | 0.0497 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] |  72.16 ns | 1.411 ns | 2.196 ns | 0.0650 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 217.48 ns | 4.346 ns | 6.766 ns | 0.0401 |     168 B |
