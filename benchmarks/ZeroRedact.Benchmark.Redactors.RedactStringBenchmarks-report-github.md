```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 17.163 ns | 0.1613 ns | 0.1509 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 17.737 ns | 0.0806 ns | 0.0754 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 23.592 ns | 0.1379 ns | 0.1151 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 25.904 ns | 0.1114 ns | 0.0930 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  9.515 ns | 0.0875 ns | 0.0776 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      | 10.990 ns | 0.0277 ns | 0.0246 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 38.307 ns | 0.1958 ns | 0.1832 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 37.701 ns | 0.2082 ns | 0.1845 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 25.841 ns | 0.1935 ns | 0.1616 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 26.477 ns | 0.0752 ns | 0.0667 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 17.004 ns | 0.0889 ns | 0.0831 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 18.457 ns | 0.1256 ns | 0.1114 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               | 15.325 ns | 0.0667 ns | 0.0624 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 18.038 ns | 0.0893 ns | 0.0792 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 21.125 ns | 0.1353 ns | 0.1265 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 21.429 ns | 0.0957 ns | 0.0848 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  8.805 ns | 0.0730 ns | 0.0647 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       | 11.177 ns | 0.0272 ns | 0.0241 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 17.954 ns | 0.1463 ns | 0.1221 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 18.902 ns | 0.2094 ns | 0.1959 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 18.396 ns | 0.0554 ns | 0.0432 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 20.250 ns | 0.0799 ns | 0.0747 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  | 15.418 ns | 0.0850 ns | 0.0753 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 15.882 ns | 0.0852 ns | 0.0797 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               | 16.958 ns | 0.1044 ns | 0.0977 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 17.831 ns | 0.0877 ns | 0.0777 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf         | 23.458 ns | 0.1092 ns | 0.1022 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 21.534 ns | 0.1962 ns | 0.1739 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  9.726 ns | 0.0398 ns | 0.0310 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       | 10.439 ns | 0.0231 ns | 0.0180 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 21.184 ns | 0.1333 ns | 0.1181 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 19.893 ns | 0.1134 ns | 0.1005 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 22.035 ns | 0.0789 ns | 0.0616 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 24.750 ns | 0.4159 ns | 0.3891 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  | 19.382 ns | 0.0812 ns | 0.0759 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 18.481 ns | 0.1021 ns | 0.0905 ns | 0.0095 |      40 B |
