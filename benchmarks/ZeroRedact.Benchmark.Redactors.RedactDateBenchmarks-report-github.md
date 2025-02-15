```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  90.05 ns | 1.830 ns | 2.955 ns |  88.30 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  86.23 ns | 0.397 ns | 0.332 ns |  86.13 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 194.55 ns | 1.853 ns | 1.733 ns | 193.93 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 206.84 ns | 3.838 ns | 3.590 ns | 204.55 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 212.15 ns | 1.844 ns | 1.440 ns | 211.91 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 212.99 ns | 1.266 ns | 0.988 ns | 212.71 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 225.42 ns | 4.256 ns | 4.180 ns | 222.75 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 220.84 ns | 2.350 ns | 1.835 ns | 220.23 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  14.32 ns | 0.052 ns | 0.043 ns |  14.31 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  13.25 ns | 0.042 ns | 0.035 ns |  13.25 ns |      - |         - |
| RedactDate_DateTime | Full         |  99.32 ns | 0.730 ns | 0.610 ns |  99.29 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  96.42 ns | 1.946 ns | 3.251 ns |  94.88 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 197.00 ns | 0.684 ns | 0.606 ns | 196.70 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 199.01 ns | 3.916 ns | 5.092 ns | 195.76 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 233.39 ns | 1.176 ns | 0.918 ns | 232.92 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 228.75 ns | 2.369 ns | 1.850 ns | 227.87 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 210.65 ns | 0.814 ns | 0.680 ns | 210.27 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 208.15 ns | 1.822 ns | 1.521 ns | 207.42 ns | 0.0095 |      40 B |
