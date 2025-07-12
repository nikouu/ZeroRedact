```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 16.332 ns | 0.2320 ns | 0.2170 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 17.016 ns | 0.1344 ns | 0.1192 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 24.118 ns | 0.1662 ns | 0.1555 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 23.213 ns | 0.1900 ns | 0.1685 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      | 11.173 ns | 0.0445 ns | 0.0394 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      | 10.159 ns | 0.1851 ns | 0.1546 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 37.244 ns | 0.1820 ns | 0.1613 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 37.438 ns | 0.3999 ns | 0.3741 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 23.683 ns | 0.2558 ns | 0.2267 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 23.647 ns | 0.2655 ns | 0.2484 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 17.069 ns | 0.2494 ns | 0.2333 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 17.038 ns | 0.0934 ns | 0.0730 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               | 15.121 ns | 0.1194 ns | 0.0997 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 15.953 ns | 0.1088 ns | 0.0964 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 19.661 ns | 0.1332 ns | 0.1246 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 19.856 ns | 0.0788 ns | 0.0658 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  8.211 ns | 0.0513 ns | 0.0480 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       | 10.064 ns | 0.0452 ns | 0.0401 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 16.947 ns | 0.3035 ns | 0.2690 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 18.446 ns | 0.1209 ns | 0.1072 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 18.774 ns | 0.1387 ns | 0.1297 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 19.916 ns | 0.1230 ns | 0.1151 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  | 15.469 ns | 0.1231 ns | 0.1092 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 15.992 ns | 0.1688 ns | 0.1579 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               | 17.397 ns | 0.3777 ns | 0.3709 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 17.322 ns | 0.1948 ns | 0.1822 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf         | 23.350 ns | 0.2582 ns | 0.2289 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 20.455 ns | 0.1654 ns | 0.1547 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  8.272 ns | 0.0877 ns | 0.0732 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       | 10.757 ns | 0.0895 ns | 0.0838 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 21.568 ns | 0.3656 ns | 0.3420 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 21.416 ns | 0.1783 ns | 0.1668 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 19.642 ns | 0.2062 ns | 0.1722 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 19.160 ns | 0.1394 ns | 0.1235 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  | 17.627 ns | 0.3035 ns | 0.2690 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 17.152 ns | 0.2314 ns | 0.2164 ns | 0.0095 |      40 B |
