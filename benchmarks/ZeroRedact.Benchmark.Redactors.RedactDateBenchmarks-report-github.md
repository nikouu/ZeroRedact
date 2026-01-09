```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|-------:|----------:|
| RedactDate_DateTime | All          |  70.35 ns | 0.485 ns | 0.405 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  71.98 ns | 1.466 ns | 1.440 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 169.70 ns | 0.912 ns | 0.762 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 167.82 ns | 0.732 ns | 0.649 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 185.32 ns | 0.953 ns | 0.892 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 187.44 ns | 1.685 ns | 1.493 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 195.07 ns | 3.935 ns | 3.681 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 192.47 ns | 0.847 ns | 0.707 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  10.21 ns | 0.041 ns | 0.039 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  10.22 ns | 0.042 ns | 0.039 ns |      - |         - |
| RedactDate_DateTime | Full         |  77.61 ns | 0.953 ns | 0.744 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  78.81 ns | 1.520 ns | 1.347 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 173.86 ns | 1.076 ns | 0.840 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 174.22 ns | 1.808 ns | 1.603 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 203.27 ns | 1.902 ns | 1.485 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 200.21 ns | 1.269 ns | 1.059 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 182.73 ns | 1.957 ns | 1.634 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 184.93 ns | 0.872 ns | 0.773 ns | 0.0095 |      40 B |
