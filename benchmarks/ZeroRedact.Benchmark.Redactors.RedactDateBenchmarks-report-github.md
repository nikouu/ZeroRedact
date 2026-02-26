```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method              | DateInput    | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|-------------------- |------------- |----------:|----------:|----------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          | 29.515 ns | 0.1051 ns | 0.0931 ns | 29.514 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | All          | 29.333 ns | 0.0989 ns | 0.0925 ns | 29.341 ns | 0.0025 |      40 B |
| RedactDate_DateTime | Day          | 69.519 ns | 1.3942 ns | 2.2113 ns | 71.050 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | Day          | 66.666 ns | 0.2155 ns | 0.2016 ns | 66.657 ns | 0.0025 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 72.012 ns | 0.1270 ns | 0.1060 ns | 72.042 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 73.156 ns | 0.2398 ns | 0.2126 ns | 73.144 ns | 0.0025 |      40 B |
| RedactDate_DateTime | DayAndYear   | 75.358 ns | 0.1548 ns | 0.1448 ns | 75.336 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 76.066 ns | 1.5297 ns | 2.1444 ns | 74.917 ns | 0.0025 |      40 B |
| RedactDate_DateTime | FixedLength  |  7.809 ns | 0.0326 ns | 0.0272 ns |  7.803 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  7.990 ns | 0.0191 ns | 0.0169 ns |  7.989 ns |      - |         - |
| RedactDate_DateTime | Full         | 34.332 ns | 0.7047 ns | 1.1966 ns | 33.658 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | Full         | 33.461 ns | 0.0750 ns | 0.0701 ns | 33.459 ns | 0.0025 |      40 B |
| RedactDate_DateTime | Month        | 69.236 ns | 0.1806 ns | 0.1689 ns | 69.199 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | Month        | 71.478 ns | 1.4396 ns | 2.3247 ns | 69.738 ns | 0.0025 |      40 B |
| RedactDate_DateTime | MonthAndYear | 78.084 ns | 0.1658 ns | 0.1628 ns | 78.109 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 81.733 ns | 1.6442 ns | 2.7471 ns | 79.762 ns | 0.0025 |      40 B |
| RedactDate_DateTime | Year         | 74.019 ns | 1.4746 ns | 2.2518 ns | 72.347 ns | 0.0025 |      40 B |
| RedactDate_DateOnly | Year         | 71.949 ns | 0.7230 ns | 0.5645 ns | 71.738 ns | 0.0025 |      40 B |
