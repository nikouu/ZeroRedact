```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 16.924 ns | 0.1647 ns | 0.1541 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 16.743 ns | 0.1233 ns | 0.1093 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 23.752 ns | 0.1987 ns | 0.1858 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 24.240 ns | 0.2948 ns | 0.2614 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  8.244 ns | 0.1904 ns | 0.1590 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      | 10.277 ns | 0.1811 ns | 0.1694 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 38.989 ns | 0.4715 ns | 0.3937 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 38.775 ns | 0.7074 ns | 0.6617 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 26.037 ns | 0.5679 ns | 0.6312 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 25.507 ns | 0.2199 ns | 0.1836 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 18.561 ns | 0.3883 ns | 0.3632 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 18.221 ns | 0.3279 ns | 0.2907 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               | 15.231 ns | 0.1751 ns | 0.1552 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 16.291 ns | 0.2622 ns | 0.2190 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 20.647 ns | 0.1281 ns | 0.1000 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 21.229 ns | 0.3780 ns | 0.3351 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  8.269 ns | 0.1143 ns | 0.1014 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       |  9.928 ns | 0.0520 ns | 0.0434 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 17.858 ns | 0.4122 ns | 0.4048 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 17.851 ns | 0.2404 ns | 0.2131 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 18.966 ns | 0.4288 ns | 0.5266 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 21.218 ns | 0.1417 ns | 0.1256 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  | 15.743 ns | 0.3194 ns | 0.2987 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 16.278 ns | 0.2637 ns | 0.2338 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               | 16.316 ns | 0.1840 ns | 0.1536 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 18.417 ns | 0.3068 ns | 0.2870 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf         | 20.913 ns | 0.2542 ns | 0.2253 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 21.297 ns | 0.2778 ns | 0.2598 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  9.410 ns | 0.1329 ns | 0.1243 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       | 10.182 ns | 0.0786 ns | 0.0657 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 20.939 ns | 0.3554 ns | 0.3324 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 20.173 ns | 0.2188 ns | 0.1827 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 19.481 ns | 0.4312 ns | 0.3822 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 20.465 ns | 0.0954 ns | 0.0797 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  | 17.124 ns | 0.3755 ns | 0.3329 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 17.401 ns | 0.3622 ns | 0.3720 ns | 0.0095 |      40 B |
