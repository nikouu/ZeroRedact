```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                  | StringInput      | Mean      | Error     | StdDev    | Gen0   | Allocated |
|------------------------ |----------------- |----------:|----------:|----------:|-------:|----------:|
|RedactString_String       | 26:All           | 18.520 ns | 0.2063 ns | 0.1611 ns | 0.0191 |      80 B |
|RedactString_ReadOnlySpan | 26:All           | 19.002 ns | 0.3590 ns | 0.2998 ns | 0.0191 |      80 B |
|RedactString_String       | 26:FirstHalf     | 24.775 ns | 0.2171 ns | 0.1813 ns | 0.0191 |      80 B |
|RedactString_ReadOnlySpan | 26:FirstHalf     | 28.074 ns | 0.3814 ns | 0.3185 ns | 0.0191 |      80 B |
|RedactString_String       | 26:FixedLength   | 10.489 ns | 0.1597 ns | 0.1415 ns |      - |         - |
|RedactString_ReadOnlySpan | 26:FixedLength   | 10.923 ns | 0.1462 ns | 0.1368 ns |      - |         - |
|RedactString_String       | 26:IgnoreSymbols | 40.099 ns | 0.8279 ns | 0.6913 ns | 0.0191 |      80 B |
|RedactString_ReadOnlySpan | 26:IgnoreSymbols | 42.753 ns | 0.8743 ns | 0.8979 ns | 0.0191 |      80 B |
|RedactString_String       | 26:SecondHalf    | 24.868 ns | 0.4249 ns | 0.3766 ns | 0.0191 |      80 B |
|RedactString_ReadOnlySpan | 26:SecondHalf    | 26.149 ns | 0.3840 ns | 0.3592 ns | 0.0191 |      80 B |
|RedactString_String       | 5:All            | 15.924 ns | 0.1862 ns | 0.1742 ns | 0.0076 |      32 B |
|RedactString_ReadOnlySpan | 5:All            | 16.515 ns | 0.2095 ns | 0.1635 ns | 0.0076 |      32 B |
|RedactString_String       | 5:FirstHalf      | 20.616 ns | 0.3792 ns | 0.3724 ns | 0.0076 |      32 B |
|RedactString_ReadOnlySpan | 5:FirstHalf      | 21.547 ns | 0.3478 ns | 0.3866 ns | 0.0076 |      32 B |
|RedactString_String       | 5:FixedLength    |  9.424 ns | 0.1455 ns | 0.1290 ns |      - |         - |
|RedactString_ReadOnlySpan | 5:FixedLength    | 11.221 ns | 0.0826 ns | 0.0733 ns |      - |         - |
|RedactString_String       | 5:IgnoreSymbols  | 18.795 ns | 0.2382 ns | 0.1860 ns | 0.0076 |      32 B |
|RedactString_ReadOnlySpan | 5:IgnoreSymbols  | 18.918 ns | 0.2925 ns | 0.2442 ns | 0.0076 |      32 B |
|RedactString_String       | 5:SecondHalf     | 19.410 ns | 0.4453 ns | 0.4374 ns | 0.0076 |      32 B |
|RedactString_ReadOnlySpan | 5:SecondHalf     | 22.197 ns | 0.1965 ns | 0.1742 ns | 0.0076 |      32 B |
|RedactString_String       | 8:All            | 17.289 ns | 0.3469 ns | 0.3075 ns | 0.0095 |      40 B |
|RedactString_ReadOnlySpan | 8:All            | 17.554 ns | 0.1788 ns | 0.1585 ns | 0.0095 |      40 B |
|RedactString_String       | 8:FirstHalf      | 23.592 ns | 0.2442 ns | 0.2165 ns | 0.0095 |      40 B |
|RedactString_ReadOnlySpan | 8:FirstHalf      | 21.708 ns | 0.2429 ns | 0.2153 ns | 0.0095 |      40 B |
|RedactString_String       | 8:FixedLength    |  9.526 ns | 0.1484 ns | 0.1388 ns |      - |         - |
|RedactString_ReadOnlySpan | 8:FixedLength    | 10.936 ns | 0.1720 ns | 0.1524 ns |      - |         - |
|RedactString_String       | 8:IgnoreSymbols  | 21.003 ns | 0.2319 ns | 0.1810 ns | 0.0095 |      40 B |
|RedactString_ReadOnlySpan | 8:IgnoreSymbols  | 22.916 ns | 0.2077 ns | 0.1842 ns | 0.0095 |      40 B |
|RedactString_String       | 8:SecondHalf     | 20.759 ns | 0.1686 ns | 0.1577 ns | 0.0095 |      40 B |
|RedactString_ReadOnlySpan | 8:SecondHalf     | 22.278 ns | 0.1733 ns | 0.1447 ns | 0.0095 |      40 B |
