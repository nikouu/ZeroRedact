```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method            | DateInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------ |------------- |----------:|---------:|---------:|-------:|----------:|
| MaskDate_DateTime | All          |  94.16 ns | 1.942 ns | 1.816 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | All          |  94.14 ns | 1.813 ns | 3.449 ns | 0.0095 |      40 B |
| MaskDate_DateTime | Day          | 201.72 ns | 4.009 ns | 5.070 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | Day          | 198.02 ns | 3.939 ns | 4.045 ns | 0.0095 |      40 B |
| MaskDate_DateTime | DayAndMonth  | 220.88 ns | 4.434 ns | 5.445 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | DayAndMonth  | 224.76 ns | 4.450 ns | 5.465 ns | 0.0095 |      40 B |
| MaskDate_DateTime | DayAndYear   | 229.43 ns | 4.546 ns | 5.749 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | DayAndYear   | 232.96 ns | 4.592 ns | 7.283 ns | 0.0095 |      40 B |
| MaskDate_DateTime | FixedLength  |  14.65 ns | 0.173 ns | 0.153 ns |      - |         - |
| MaskDate_DateOnly | FixedLength  |  13.65 ns | 0.134 ns | 0.119 ns |      - |         - |
| MaskDate_DateTime | Full         | 103.86 ns | 2.127 ns | 3.434 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | Full         | 104.43 ns | 2.084 ns | 2.710 ns | 0.0095 |      40 B |
| MaskDate_DateTime | Month        | 206.42 ns | 4.159 ns | 4.271 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | Month        | 207.43 ns | 3.692 ns | 2.883 ns | 0.0095 |      40 B |
| MaskDate_DateTime | MonthAndYear | 242.83 ns | 4.004 ns | 3.746 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | MonthAndYear | 243.15 ns | 4.917 ns | 7.052 ns | 0.0095 |      40 B |
| MaskDate_DateTime | Year         | 219.10 ns | 2.807 ns | 2.192 ns | 0.0095 |      40 B |
| MaskDate_DateOnly | Year         | 227.27 ns | 4.516 ns | 5.546 ns | 0.0095 |      40 B |
