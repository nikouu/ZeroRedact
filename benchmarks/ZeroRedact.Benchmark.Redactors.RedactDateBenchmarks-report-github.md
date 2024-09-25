```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method               | DateInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|--------------------- |------------- |----------:|---------:|---------:|-------:|----------:|
| RedactkDate_DateTime | All          |  92.39 ns | 1.182 ns | 1.106 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | All          |  90.19 ns | 1.846 ns | 2.335 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | Day          | 198.50 ns | 1.812 ns | 1.695 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | Day          | 191.43 ns | 2.287 ns | 2.139 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | DayAndMonth  | 214.90 ns | 3.879 ns | 3.628 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | DayAndMonth  | 216.08 ns | 2.218 ns | 1.853 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | DayAndYear   | 233.21 ns | 2.846 ns | 2.523 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | DayAndYear   | 223.14 ns | 2.841 ns | 2.372 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | FixedLength  |  14.09 ns | 0.139 ns | 0.130 ns |      - |         - |
| RedactDate_DateOnly  | FixedLength  |  13.56 ns | 0.066 ns | 0.062 ns |      - |         - |
| RedactkDate_DateTime | Full         |  99.04 ns | 1.895 ns | 1.680 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | Full         |  99.60 ns | 1.272 ns | 1.062 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | Month        | 198.24 ns | 1.893 ns | 1.678 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | Month        | 202.23 ns | 1.657 ns | 1.469 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | MonthAndYear | 237.88 ns | 2.798 ns | 2.617 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | MonthAndYear | 232.05 ns | 3.644 ns | 3.230 ns | 0.0095 |      40 B |
| RedactkDate_DateTime | Year         | 213.30 ns | 1.851 ns | 1.546 ns | 0.0095 |      40 B |
| RedactDate_DateOnly  | Year         | 216.71 ns | 3.736 ns | 3.494 ns | 0.0095 |      40 B |
