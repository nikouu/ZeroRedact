```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                 | value                | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
| RedactFirstHalfString0 | abcde(...)vwxyz [26] |  7.557 ns | 0.1860 ns | 0.5485 ns |  7.111 ns | 0.0051 |      80 B |
| RedactFirstHalfString1 | abcde(...)vwxyz [26] | 12.020 ns | 0.2723 ns | 0.5180 ns | 11.712 ns | 0.0112 |     176 B |
| RedactFirstHalfString2 | abcde(...)vwxyz [26] | 11.795 ns | 0.0359 ns | 0.0479 ns | 11.781 ns | 0.0112 |     176 B |
| RedactFirstHalfString3 | abcde(...)vwxyz [26] | 15.028 ns | 0.1800 ns | 0.1684 ns | 15.075 ns | 0.0133 |     208 B |
| RedactFirstHalfString4 | abcde(...)vwxyz [26] | 25.056 ns | 0.5251 ns | 0.9863 ns | 24.837 ns | 0.0173 |     272 B |
| RedactFirstHalfString5 | abcde(...)vwxyz [26] | 62.530 ns | 0.8365 ns | 0.6985 ns | 62.674 ns | 0.0106 |     168 B |
| RedactFirstHalfString6 | abcde(...)vwxyz [26] |  9.958 ns | 0.0329 ns | 0.0292 ns |  9.960 ns | 0.0082 |     128 B |
