```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  70.44 ns | 1.169 ns | 0.977 ns |  70.01 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  69.71 ns | 1.400 ns | 1.169 ns |  69.59 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 153.18 ns | 0.452 ns | 0.353 ns | 153.07 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 157.99 ns | 3.198 ns | 4.587 ns | 155.94 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 164.34 ns | 3.339 ns | 5.392 ns | 162.34 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 160.36 ns | 3.206 ns | 4.991 ns | 157.89 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 159.44 ns | 3.102 ns | 4.644 ns | 157.07 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 164.98 ns | 3.352 ns | 5.219 ns | 164.05 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  10.25 ns | 0.054 ns | 0.050 ns |  10.22 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  10.44 ns | 0.047 ns | 0.044 ns |  10.42 ns |      - |         - |
| RedactDate_DateTime | Full         |  76.46 ns | 1.016 ns | 1.457 ns |  76.20 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  80.83 ns | 1.674 ns | 4.410 ns |  83.10 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 158.15 ns | 3.218 ns | 4.914 ns | 155.97 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 153.59 ns | 3.108 ns | 6.206 ns | 150.37 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 168.21 ns | 3.261 ns | 3.202 ns | 167.16 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 160.97 ns | 3.206 ns | 5.698 ns | 162.73 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 154.04 ns | 3.068 ns | 5.040 ns | 157.08 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 156.48 ns | 3.158 ns | 5.276 ns | 159.73 ns | 0.0095 |      40 B |
