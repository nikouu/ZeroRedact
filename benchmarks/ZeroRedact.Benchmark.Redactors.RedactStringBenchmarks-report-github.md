```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                    | StringInput         | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
| RedactString_String       | 26:All              |  4.933 ns | 0.0434 ns | 0.0564 ns |  4.914 ns | 0.0051 |      80 B |
| RedactString_ReadOnlySpan | 26:All              |  5.664 ns | 0.1281 ns | 0.2277 ns |  5.790 ns | 0.0051 |      80 B |
| RedactString_String       | 26:FirstHalf        |  7.818 ns | 0.0433 ns | 0.0361 ns |  7.813 ns | 0.0051 |      80 B |
| RedactString_ReadOnlySpan | 26:FirstHalf        |  8.302 ns | 0.0339 ns | 0.0377 ns |  8.306 ns | 0.0051 |      80 B |
| RedactString_String       | 26:FixedLength      |  1.492 ns | 0.0127 ns | 0.0141 ns |  1.488 ns |      - |         - |
| RedactString_ReadOnlySpan | 26:FixedLength      |  1.764 ns | 0.0137 ns | 0.0128 ns |  1.763 ns |      - |         - |
| RedactString_String       | 26:IgnoreSymbols    | 13.781 ns | 0.3057 ns | 0.5107 ns | 13.398 ns | 0.0051 |      80 B |
| RedactString_ReadOnlySpan | 26:IgnoreSymbols    | 13.803 ns | 0.2125 ns | 0.1659 ns | 13.753 ns | 0.0051 |      80 B |
| RedactString_String       | 26:SecondHalf       |  7.733 ns | 0.0193 ns | 0.0190 ns |  7.734 ns | 0.0051 |      80 B |
| RedactString_ReadOnlySpan | 26:SecondHalf       |  8.470 ns | 0.0381 ns | 0.0318 ns |  8.464 ns | 0.0051 |      80 B |
| RedactString_String       | 26:ShowFirstAndLast |  5.827 ns | 0.1459 ns | 0.2555 ns |  5.687 ns | 0.0051 |      80 B |
| RedactString_ReadOnlySpan | 26:ShowFirstAndLast |  6.483 ns | 0.0165 ns | 0.0138 ns |  6.484 ns | 0.0051 |      80 B |
| RedactString_String       | 5:All               |  4.039 ns | 0.1097 ns | 0.1708 ns |  4.143 ns | 0.0020 |      32 B |
| RedactString_ReadOnlySpan | 5:All               |  4.172 ns | 0.0251 ns | 0.0222 ns |  4.173 ns | 0.0020 |      32 B |
| RedactString_String       | 5:FirstHalf         |  5.944 ns | 0.1468 ns | 0.2329 ns |  5.808 ns | 0.0020 |      32 B |
| RedactString_ReadOnlySpan | 5:FirstHalf         |  6.285 ns | 0.0230 ns | 0.0204 ns |  6.285 ns | 0.0020 |      32 B |
| RedactString_String       | 5:FixedLength       |  1.553 ns | 0.0636 ns | 0.0911 ns |  1.496 ns |      - |         - |
| RedactString_ReadOnlySpan | 5:FixedLength       |  1.755 ns | 0.0131 ns | 0.0116 ns |  1.754 ns |      - |         - |
| RedactString_String       | 5:IgnoreSymbols     |  4.844 ns | 0.0180 ns | 0.0168 ns |  4.844 ns | 0.0020 |      32 B |
| RedactString_ReadOnlySpan | 5:IgnoreSymbols     |  5.465 ns | 0.1220 ns | 0.2137 ns |  5.320 ns | 0.0020 |      32 B |
| RedactString_String       | 5:SecondHalf        |  5.464 ns | 0.0373 ns | 0.0291 ns |  5.449 ns | 0.0020 |      32 B |
| RedactString_ReadOnlySpan | 5:SecondHalf        |  6.254 ns | 0.1393 ns | 0.2403 ns |  6.418 ns | 0.0020 |      32 B |
| RedactString_String       | 5:ShowFirstAndLast  |  4.012 ns | 0.1078 ns | 0.1614 ns |  3.911 ns | 0.0020 |      32 B |
| RedactString_ReadOnlySpan | 5:ShowFirstAndLast  |  4.635 ns | 0.0222 ns | 0.0185 ns |  4.631 ns | 0.0020 |      32 B |
| RedactString_String       | 8:All               |  4.172 ns | 0.0167 ns | 0.0156 ns |  4.166 ns | 0.0025 |      40 B |
| RedactString_ReadOnlySpan | 8:All               |  4.500 ns | 0.0181 ns | 0.0222 ns |  4.502 ns | 0.0025 |      40 B |
| RedactString_String       | 8:FirstHalf         |  6.606 ns | 0.1341 ns | 0.1255 ns |  6.643 ns | 0.0025 |      40 B |
| RedactString_ReadOnlySpan | 8:FirstHalf         |  6.549 ns | 0.0157 ns | 0.0132 ns |  6.548 ns | 0.0025 |      40 B |
| RedactString_String       | 8:FixedLength       |  1.613 ns | 0.0271 ns | 0.0240 ns |  1.602 ns |      - |         - |
| RedactString_ReadOnlySpan | 8:FixedLength       |  1.709 ns | 0.0143 ns | 0.0119 ns |  1.709 ns |      - |         - |
| RedactString_String       | 8:IgnoreSymbols     |  5.799 ns | 0.0266 ns | 0.0236 ns |  5.793 ns | 0.0025 |      40 B |
| RedactString_ReadOnlySpan | 8:IgnoreSymbols     |  6.162 ns | 0.0221 ns | 0.0185 ns |  6.159 ns | 0.0025 |      40 B |
| RedactString_String       | 8:SecondHalf        |  5.935 ns | 0.0132 ns | 0.0147 ns |  5.940 ns | 0.0025 |      40 B |
| RedactString_ReadOnlySpan | 8:SecondHalf        |  6.588 ns | 0.1435 ns | 0.2358 ns |  6.444 ns | 0.0025 |      40 B |
| RedactString_String       | 8:ShowFirstAndLast  |  4.349 ns | 0.1163 ns | 0.1878 ns |  4.456 ns | 0.0025 |      40 B |
| RedactString_ReadOnlySpan | 8:ShowFirstAndLast  |  4.844 ns | 0.0130 ns | 0.0109 ns |  4.846 ns | 0.0025 |      40 B |
