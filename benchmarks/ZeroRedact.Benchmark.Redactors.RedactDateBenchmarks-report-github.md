```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|-------:|----------:|
| RedactDate_DateTime | All          |  74.75 ns | 0.668 ns | 0.558 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  74.23 ns | 0.473 ns | 0.419 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 170.24 ns | 0.893 ns | 0.746 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 170.61 ns | 1.271 ns | 0.992 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 190.58 ns | 0.796 ns | 0.706 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 191.55 ns | 0.986 ns | 0.922 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 200.76 ns | 0.735 ns | 0.651 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 199.58 ns | 0.833 ns | 0.738 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  11.99 ns | 0.033 ns | 0.028 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  11.95 ns | 0.037 ns | 0.033 ns |      - |         - |
| RedactDate_DateTime | Full         |  81.17 ns | 0.625 ns | 0.521 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  82.97 ns | 0.494 ns | 0.462 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 180.08 ns | 2.333 ns | 1.948 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 181.62 ns | 1.111 ns | 0.985 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 208.43 ns | 0.806 ns | 0.715 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 215.55 ns | 1.306 ns | 1.158 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 192.18 ns | 0.933 ns | 0.779 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 193.13 ns | 1.128 ns | 1.000 ns | 0.0095 |      40 B |
