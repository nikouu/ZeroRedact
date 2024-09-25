```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                    | StringInput      | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |----------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All           | 19.682 ns | 0.1941 ns | 0.1815 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All           | 17.568 ns | 0.1533 ns | 0.1359 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf     | 24.259 ns | 0.4539 ns | 0.4024 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf     | 24.509 ns | 0.1520 ns | 0.1269 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength   |  8.791 ns | 0.1395 ns | 0.1305 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength   | 10.428 ns | 0.0836 ns | 0.0782 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols | 37.292 ns | 0.3619 ns | 0.3385 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols | 37.487 ns | 0.3361 ns | 0.3144 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf    | 24.105 ns | 0.2343 ns | 0.2077 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf    | 24.947 ns | 0.2483 ns | 0.2323 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All            | 15.582 ns | 0.2023 ns | 0.1893 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All            | 16.176 ns | 0.1426 ns | 0.1264 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf      | 19.944 ns | 0.1660 ns | 0.1552 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf      | 22.361 ns | 0.1617 ns | 0.1433 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength    | 10.290 ns | 0.0736 ns | 0.0688 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength    | 10.789 ns | 0.0941 ns | 0.0880 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols  | 24.518 ns | 0.2130 ns | 0.1888 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols  | 18.347 ns | 0.2076 ns | 0.1733 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf     | 18.628 ns | 0.1718 ns | 0.1523 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf     | 20.098 ns | 0.2107 ns | 0.1867 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All            | 16.444 ns | 0.3207 ns | 0.3149 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All            | 18.344 ns | 0.1352 ns | 0.1129 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf      | 22.005 ns | 0.2051 ns | 0.1818 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf      | 22.009 ns | 0.0925 ns | 0.0773 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength    |  9.388 ns | 0.0807 ns | 0.0754 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength    | 10.966 ns | 0.0925 ns | 0.0820 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols  | 19.858 ns | 0.1721 ns | 0.1610 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols  | 19.923 ns | 0.1801 ns | 0.1596 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf     | 19.348 ns | 0.3147 ns | 0.2457 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf     | 20.297 ns | 0.2317 ns | 0.2167 ns | 0.0095 |      40 B |
