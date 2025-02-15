```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 17.176 ns | 0.1024 ns | 0.0958 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 17.137 ns | 0.0967 ns | 0.0857 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 23.374 ns | 0.0440 ns | 0.0343 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 23.000 ns | 0.1028 ns | 0.0962 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  9.341 ns | 0.0314 ns | 0.0279 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      | 10.032 ns | 0.0373 ns | 0.0331 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 37.457 ns | 0.0709 ns | 0.0629 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 36.788 ns | 0.1376 ns | 0.1287 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 23.505 ns | 0.1086 ns | 0.0963 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 24.016 ns | 0.4988 ns | 0.4165 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 16.992 ns | 0.1190 ns | 0.1113 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 17.691 ns | 0.0967 ns | 0.0808 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               | 16.093 ns | 0.0553 ns | 0.0491 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 15.526 ns | 0.0475 ns | 0.0397 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 19.627 ns | 0.1844 ns | 0.1725 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 20.096 ns | 0.0867 ns | 0.0811 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  9.210 ns | 0.0399 ns | 0.0354 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       | 10.217 ns | 0.0241 ns | 0.0226 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 16.427 ns | 0.0640 ns | 0.0598 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 17.400 ns | 0.0918 ns | 0.0767 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 18.709 ns | 0.0877 ns | 0.0821 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 18.830 ns | 0.1013 ns | 0.0948 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  | 15.879 ns | 0.1165 ns | 0.1089 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  | 15.899 ns | 0.0776 ns | 0.0688 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               | 15.935 ns | 0.1866 ns | 0.1654 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 16.628 ns | 0.1257 ns | 0.1050 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FirstHalf         | 21.104 ns | 0.1047 ns | 0.0874 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 20.081 ns | 0.1286 ns | 0.1140 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  8.524 ns | 0.0403 ns | 0.0336 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       |  9.950 ns | 0.0655 ns | 0.0581 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 19.676 ns | 0.0896 ns | 0.0838 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 19.429 ns | 0.0722 ns | 0.0640 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 21.129 ns | 0.1239 ns | 0.1159 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 19.671 ns | 0.2479 ns | 0.2198 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  | 16.453 ns | 0.0981 ns | 0.0918 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 17.031 ns | 0.0732 ns | 0.0684 ns | 0.0095 |      40 B |
