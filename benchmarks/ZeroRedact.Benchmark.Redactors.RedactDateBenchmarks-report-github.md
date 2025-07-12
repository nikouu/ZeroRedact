```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  86.02 ns | 1.782 ns | 2.774 ns |  84.32 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  83.79 ns | 0.848 ns | 0.662 ns |  83.49 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 187.00 ns | 1.433 ns | 1.196 ns | 186.70 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 188.33 ns | 1.700 ns | 1.507 ns | 187.89 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 208.31 ns | 0.363 ns | 0.283 ns | 208.27 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 206.11 ns | 1.480 ns | 1.236 ns | 206.05 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 225.09 ns | 3.892 ns | 3.641 ns | 223.12 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 227.25 ns | 2.038 ns | 1.807 ns | 226.58 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  11.24 ns | 0.041 ns | 0.036 ns |  11.23 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  10.82 ns | 0.074 ns | 0.066 ns |  10.79 ns |      - |         - |
| RedactDate_DateTime | Full         |  96.35 ns | 0.461 ns | 0.360 ns |  96.21 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  93.72 ns | 1.410 ns | 1.250 ns |  93.16 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 199.13 ns | 1.398 ns | 1.239 ns | 198.42 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 200.45 ns | 1.044 ns | 0.925 ns | 200.16 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 228.69 ns | 0.432 ns | 0.383 ns | 228.54 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 228.87 ns | 1.312 ns | 1.096 ns | 228.41 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 206.94 ns | 0.592 ns | 0.494 ns | 206.88 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 209.30 ns | 4.137 ns | 4.427 ns | 208.11 ns | 0.0095 |      40 B |
