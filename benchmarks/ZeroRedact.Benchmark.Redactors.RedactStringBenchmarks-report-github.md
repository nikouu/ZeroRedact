```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5131/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 18.448 ns | 0.4203 ns | 0.4316 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 20.044 ns | 0.4267 ns | 0.5549 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 26.478 ns | 0.4151 ns | 0.3679 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 28.468 ns | 0.5911 ns | 0.5805 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  9.315 ns | 0.2013 ns | 0.1681 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      | 14.301 ns | 0.1751 ns | 0.1638 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 41.054 ns | 0.5776 ns | 0.5120 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 40.309 ns | 0.6638 ns | 0.5884 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 26.290 ns | 0.3168 ns | 0.2473 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 28.684 ns | 0.4567 ns | 0.4049 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 19.942 ns | 0.3375 ns | 0.2992 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 19.704 ns | 0.3939 ns | 0.7001 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               | 16.896 ns | 0.3452 ns | 0.3229 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 20.472 ns | 0.2876 ns | 0.2549 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 21.350 ns | 0.3553 ns | 0.3150 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 22.710 ns | 0.3504 ns | 0.3106 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  9.346 ns | 0.2376 ns | 0.2333 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       | 10.998 ns | 0.1905 ns | 0.1591 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 18.758 ns | 0.2442 ns | 0.2039 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 19.318 ns | 0.3934 ns | 0.3488 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 20.352 ns | 0.2963 ns | 0.2626 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 21.571 ns | 0.4591 ns | 0.5638 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  | 16.389 ns | 0.2334 ns | 0.1949 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 17.512 ns | 0.3694 ns | 0.3628 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               | 17.074 ns | 0.2547 ns | 0.2258 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 18.641 ns | 0.2828 ns | 0.2645 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf         | 24.656 ns | 0.3274 ns | 0.2902 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 23.156 ns | 0.2748 ns | 0.2436 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  9.835 ns | 0.1508 ns | 0.1259 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       | 14.316 ns | 0.1473 ns | 0.1305 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 22.341 ns | 0.3875 ns | 0.3025 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 24.790 ns | 0.2268 ns | 0.2121 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 21.559 ns | 0.2538 ns | 0.2374 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 24.189 ns | 0.3699 ns | 0.3279 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  | 17.800 ns | 0.3974 ns | 0.4081 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 18.374 ns | 0.2277 ns | 0.1902 ns | 0.0095 |      40 B |
