```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  70.79 ns | 1.176 ns | 1.259 ns |  70.58 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  67.98 ns | 0.434 ns | 0.385 ns |  68.07 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 163.23 ns | 3.316 ns | 5.162 ns | 160.18 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 164.87 ns | 3.360 ns | 4.368 ns | 162.85 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 181.67 ns | 2.234 ns | 1.866 ns | 180.92 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 179.63 ns | 3.352 ns | 3.587 ns | 177.87 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 191.03 ns | 2.469 ns | 2.062 ns | 190.43 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 189.31 ns | 1.376 ns | 1.149 ns | 189.33 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  10.24 ns | 0.049 ns | 0.046 ns |  10.23 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  10.42 ns | 0.044 ns | 0.036 ns |  10.41 ns |      - |         - |
| RedactDate_DateTime | Full         |  73.90 ns | 0.612 ns | 0.542 ns |  73.67 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  78.14 ns | 0.476 ns | 0.398 ns |  78.21 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 166.88 ns | 2.053 ns | 1.603 ns | 166.22 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 170.96 ns | 3.446 ns | 5.262 ns | 168.34 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 194.14 ns | 0.826 ns | 0.645 ns | 194.15 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 195.85 ns | 1.171 ns | 1.150 ns | 195.55 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 175.10 ns | 2.094 ns | 1.749 ns | 174.67 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 175.08 ns | 3.496 ns | 3.270 ns | 173.70 ns | 0.0095 |      40 B |
