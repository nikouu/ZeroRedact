```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 10.088 ns | 0.0497 ns | 0.0441 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 10.537 ns | 0.0288 ns | 0.0255 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 17.072 ns | 0.0932 ns | 0.0826 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 17.619 ns | 0.3513 ns | 0.3114 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  3.380 ns | 0.0108 ns | 0.0101 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      |  4.643 ns | 0.0062 ns | 0.0055 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 32.506 ns | 0.0775 ns | 0.0725 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 32.125 ns | 0.1000 ns | 0.0835 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 16.336 ns | 0.0933 ns | 0.0827 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 17.527 ns | 0.0659 ns | 0.0584 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 10.760 ns | 0.0469 ns | 0.0416 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 15.105 ns | 0.0337 ns | 0.0281 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               |  8.548 ns | 0.0273 ns | 0.0242 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               |  9.775 ns | 0.0302 ns | 0.0268 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 14.170 ns | 0.0441 ns | 0.0391 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 14.083 ns | 0.0502 ns | 0.0469 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  3.398 ns | 0.0075 ns | 0.0062 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       |  4.644 ns | 0.0105 ns | 0.0093 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 11.947 ns | 0.0511 ns | 0.0427 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 11.929 ns | 0.0379 ns | 0.0336 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 13.405 ns | 0.0338 ns | 0.0300 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 13.092 ns | 0.0480 ns | 0.0449 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  |  8.968 ns | 0.0333 ns | 0.0312 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 11.037 ns | 0.0189 ns | 0.0168 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               |  9.240 ns | 0.0577 ns | 0.0539 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 10.067 ns | 0.0281 ns | 0.0263 ns | 0.0096 |      40 B |
| RedactString_String       | 8:FirstHalf         | 14.050 ns | 0.0509 ns | 0.0425 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 14.262 ns | 0.0667 ns | 0.0591 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  3.409 ns | 0.0090 ns | 0.0080 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       |  4.642 ns | 0.0069 ns | 0.0061 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 14.732 ns | 0.0427 ns | 0.0379 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 14.754 ns | 0.0431 ns | 0.0403 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 13.228 ns | 0.0641 ns | 0.0535 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 13.464 ns | 0.0379 ns | 0.0336 ns | 0.0096 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  |  9.745 ns | 0.0492 ns | 0.0436 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 10.773 ns | 0.0426 ns | 0.0378 ns | 0.0096 |      40 B |
