```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | DateInput    | Mean       | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |------------- |-----------:|----------:|----------:|-------:|----------:|
| RedactDate_DateTime | All          |  70.407 ns | 1.1523 ns | 1.0779 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | All          |  68.600 ns | 0.9220 ns | 0.8174 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Day          | 148.998 ns | 1.1642 ns | 1.0320 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Day          | 147.815 ns | 0.8581 ns | 0.7165 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndMonth  | 171.713 ns | 1.6107 ns | 1.3450 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndMonth  | 169.107 ns | 0.6630 ns | 0.5536 ns | 0.0095 |      40 B |
| RedactDate_DateTime | DayAndYear   | 180.665 ns | 2.7388 ns | 2.4279 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | DayAndYear   | 176.566 ns | 1.9170 ns | 1.6008 ns | 0.0095 |      40 B |
| RedactDate_DateTime | FixedLength  |   9.968 ns | 0.0430 ns | 0.0381 ns |      - |         - |
| RedactDate_DateOnly | FixedLength  |   9.959 ns | 0.0243 ns | 0.0203 ns |      - |         - |
| RedactDate_DateTime | Full         |  78.682 ns | 1.0108 ns | 0.8441 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Full         |  77.422 ns | 0.8659 ns | 0.7230 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Month        | 156.056 ns | 0.5817 ns | 0.5157 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Month        | 156.711 ns | 1.3790 ns | 1.2899 ns | 0.0095 |      40 B |
| RedactDate_DateTime | MonthAndYear | 183.741 ns | 1.4160 ns | 1.1824 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | MonthAndYear | 176.029 ns | 0.4578 ns | 0.3574 ns | 0.0095 |      40 B |
| RedactDate_DateTime | Year         | 165.751 ns | 1.2961 ns | 1.0823 ns | 0.0095 |      40 B |
| RedactDate_DateOnly | Year         | 161.091 ns | 1.9733 ns | 1.6478 ns | 0.0095 |      40 B |
