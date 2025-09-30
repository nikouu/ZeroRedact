```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              | 10.385 ns | 0.1117 ns | 0.0932 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:All              | 10.883 ns | 0.1145 ns | 0.1015 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FirstHalf        | 17.776 ns | 0.1352 ns | 0.1265 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        | 18.843 ns | 0.3288 ns | 0.2745 ns | 0.0191 |      80 B |
| RedactString_String       | 26:FixedLength      |  3.544 ns | 0.1068 ns | 0.0999 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      |  4.684 ns | 0.0425 ns | 0.0377 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 33.573 ns | 0.1415 ns | 0.1255 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 32.391 ns | 0.1229 ns | 0.0960 ns | 0.0191 |      80 B |
| RedactString_String       | 26:SecondHalf       | 19.635 ns | 0.1091 ns | 0.0967 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       | 18.498 ns | 0.0863 ns | 0.0765 ns | 0.0191 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast | 10.701 ns | 0.0701 ns | 0.0656 ns | 0.0191 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast | 12.689 ns | 0.0733 ns | 0.0685 ns | 0.0191 |      80 B |
| RedactString_String       | 5:All               |  8.714 ns | 0.0691 ns | 0.0613 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:All               | 10.853 ns | 0.0585 ns | 0.0489 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FirstHalf         | 14.253 ns | 0.1114 ns | 0.0987 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         | 15.542 ns | 0.0623 ns | 0.0552 ns | 0.0076 |      32 B |
| RedactString_String       | 5:FixedLength       |  3.432 ns | 0.0192 ns | 0.0170 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       |  5.577 ns | 0.0223 ns | 0.0198 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     | 12.299 ns | 0.0818 ns | 0.0725 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     | 12.112 ns | 0.0497 ns | 0.0415 ns | 0.0076 |      32 B |
| RedactString_String       | 5:SecondHalf        | 13.161 ns | 0.1701 ns | 0.1507 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        | 14.082 ns | 0.0864 ns | 0.0766 ns | 0.0076 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  |  9.368 ns | 0.0600 ns | 0.0532 ns | 0.0076 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  |  9.967 ns | 0.0372 ns | 0.0330 ns | 0.0076 |      32 B |
| RedactString_String       | 8:All               |  9.431 ns | 0.0694 ns | 0.0649 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:All               | 10.334 ns | 0.0574 ns | 0.0537 ns | 0.0096 |      40 B |
| RedactString_String       | 8:FirstHalf         | 14.304 ns | 0.0917 ns | 0.0857 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         | 14.698 ns | 0.0966 ns | 0.0903 ns | 0.0095 |      40 B |
| RedactString_String       | 8:FixedLength       |  3.659 ns | 0.0186 ns | 0.0174 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       |  4.680 ns | 0.0312 ns | 0.0260 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     | 15.180 ns | 0.1071 ns | 0.0895 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     | 14.804 ns | 0.0572 ns | 0.0478 ns | 0.0095 |      40 B |
| RedactString_String       | 8:SecondHalf        | 14.000 ns | 0.0534 ns | 0.0417 ns | 0.0095 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        | 13.971 ns | 0.0743 ns | 0.0620 ns | 0.0095 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  |  9.897 ns | 0.0650 ns | 0.0542 ns | 0.0096 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  | 11.116 ns | 0.0676 ns | 0.0599 ns | 0.0096 |      40 B |
