```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------- |------------- |----------:|---------:|---------:|-------:|----------:|
| RedactDate_DateTime | All          |  73.70 ns | 0.163 ns | 0.144 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  74.61 ns | 0.142 ns | 0.126 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 168.28 ns | 1.124 ns | 0.938 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 167.09 ns | 0.130 ns | 0.109 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 185.90 ns | 0.937 ns | 0.783 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 186.64 ns | 1.070 ns | 0.894 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 201.79 ns | 0.228 ns | 0.190 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 195.51 ns | 0.341 ns | 0.285 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  11.98 ns | 0.040 ns | 0.035 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |  11.94 ns | 0.005 ns | 0.004 ns |      - |         - |
| RedactDate_DateTime | Full         |  79.15 ns | 0.073 ns | 0.057 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  80.05 ns | 0.250 ns | 0.195 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 177.02 ns | 0.163 ns | 0.145 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 178.53 ns | 0.152 ns | 0.118 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 205.09 ns | 2.763 ns | 2.307 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 200.48 ns | 0.307 ns | 0.256 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 184.65 ns | 0.840 ns | 0.744 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 185.88 ns | 0.183 ns | 0.162 ns | 0.0095 |      40 B |
