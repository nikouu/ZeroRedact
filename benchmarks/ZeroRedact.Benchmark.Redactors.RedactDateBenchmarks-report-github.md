```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean       | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |------------- |-----------:|----------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  71.337 ns | 1.4398 ns | 1.7140 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  68.534 ns | 0.5177 ns | 0.4042 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 158.363 ns | 0.9305 ns | 0.8248 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 152.024 ns | 0.9399 ns | 0.9231 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 164.412 ns | 1.6292 ns | 1.2720 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 160.597 ns | 1.2792 ns | 1.0682 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 164.655 ns | 3.1160 ns | 2.6020 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 159.199 ns | 2.8259 ns | 3.6745 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |  10.224 ns | 0.0697 ns | 0.0652 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |   9.990 ns | 0.0665 ns | 0.0622 ns |      - |         - |
| RedactDate_DateTime | Full         |  77.141 ns | 1.0748 ns | 0.8392 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  75.732 ns | 0.8700 ns | 0.7712 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 151.292 ns | 1.9252 ns | 1.5030 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 152.603 ns | 1.1092 ns | 0.9833 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 159.882 ns | 1.2960 ns | 1.0822 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 158.375 ns | 3.1064 ns | 3.9286 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 155.303 ns | 2.5324 ns | 2.2449 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 148.211 ns | 0.6912 ns | 0.5396 ns | 0.0095 |      40 B |
