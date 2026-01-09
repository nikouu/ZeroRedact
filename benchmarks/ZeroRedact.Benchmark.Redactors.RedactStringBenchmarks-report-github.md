```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              |  9.726 ns | 0.1205 ns | 0.1127 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              |  9.420 ns | 0.0836 ns | 0.0782 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 14.162 ns | 0.0531 ns | 0.0415 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 14.587 ns | 0.0696 ns | 0.0543 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  2.249 ns | 0.0210 ns | 0.0175 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      |  3.107 ns | 0.0204 ns | 0.0191 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 30.817 ns | 0.2929 ns | 0.2739 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 30.186 ns | 0.0984 ns | 0.0821 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 12.783 ns | 0.2378 ns | 0.2224 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 13.124 ns | 0.0828 ns | 0.0734 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast |  9.463 ns | 0.2060 ns | 0.1927 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast |  9.280 ns | 0.0568 ns | 0.0503 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               |  7.459 ns | 0.0716 ns | 0.0669 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               |  8.236 ns | 0.0758 ns | 0.0709 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 10.740 ns | 0.1322 ns | 0.1237 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 11.234 ns | 0.0987 ns | 0.0924 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  2.223 ns | 0.0165 ns | 0.0147 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       |  3.213 ns | 0.0378 ns | 0.0354 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     |  9.692 ns | 0.0630 ns | 0.0558 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     |  9.678 ns | 0.0579 ns | 0.0513 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        |  9.559 ns | 0.1377 ns | 0.1288 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        |  9.846 ns | 0.0780 ns | 0.0729 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  |  7.420 ns | 0.1080 ns | 0.0902 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  |  7.815 ns | 0.0375 ns | 0.0313 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               |  8.744 ns | 0.0904 ns | 0.0846 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:All               |  9.233 ns | 0.0639 ns | 0.0598 ns | 0.0096 |      40 B |
| RedactString_String       | 8:FirstHalf         | 10.512 ns | 0.0791 ns | 0.0701 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 10.800 ns | 0.0526 ns | 0.0439 ns | 0.0096 |      40 B |
| RedactString_String       | 8:FixedLength       |  2.258 ns | 0.0311 ns | 0.0291 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       |  3.094 ns | 0.0038 ns | 0.0030 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 12.958 ns | 0.2074 ns | 0.1839 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 12.932 ns | 0.0478 ns | 0.0400 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        |  9.909 ns | 0.1051 ns | 0.0983 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 10.239 ns | 0.1008 ns | 0.0943 ns | 0.0096 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  |  8.073 ns | 0.0517 ns | 0.0431 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  |  8.746 ns | 0.0735 ns | 0.0688 ns | 0.0096 |      40 B |
