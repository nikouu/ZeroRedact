```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                        | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_ReadOnlySpan | 101:All              |  54.74 ns | 1.120 ns | 1.871 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  71.53 ns | 1.379 ns | 1.475 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  37.05 ns | 0.372 ns | 0.330 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  59.98 ns | 0.656 ns | 0.547 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  30.47 ns | 0.249 ns | 0.208 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  65.73 ns | 0.854 ns | 0.713 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  62.77 ns | 1.212 ns | 1.190 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  62.67 ns | 1.165 ns | 0.973 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  38.73 ns | 0.483 ns | 0.452 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  38.01 ns | 0.540 ns | 0.451 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  48.34 ns | 0.793 ns | 0.742 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  48.28 ns | 0.683 ns | 0.639 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  31.24 ns | 0.114 ns | 0.101 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  31.72 ns | 0.339 ns | 0.283 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  42.15 ns | 0.416 ns | 0.389 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  42.25 ns | 0.524 ns | 0.491 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  25.35 ns | 0.197 ns | 0.185 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  25.73 ns | 0.151 ns | 0.126 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  47.32 ns | 0.368 ns | 0.307 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  47.30 ns | 0.460 ns | 0.408 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  46.42 ns | 0.491 ns | 0.459 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  46.38 ns | 0.323 ns | 0.287 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  43.20 ns | 0.250 ns | 0.234 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  43.02 ns | 0.512 ns | 0.428 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              |  88.45 ns | 1.419 ns | 1.258 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 113.97 ns | 1.867 ns | 1.655 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  47.82 ns | 0.369 ns | 0.327 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:Full             |  99.97 ns | 1.410 ns | 1.178 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           |  37.35 ns | 0.315 ns | 0.263 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 114.65 ns | 1.915 ns | 1.599 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 104.69 ns | 1.537 ns | 1.438 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 105.90 ns | 2.093 ns | 1.958 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  40.50 ns | 0.405 ns | 0.359 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  52.43 ns | 0.684 ns | 0.640 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  30.22 ns | 0.188 ns | 0.176 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  44.48 ns | 0.269 ns | 0.225 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  26.04 ns | 0.239 ns | 0.223 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  50.80 ns | 0.825 ns | 0.689 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  49.80 ns | 0.604 ns | 0.472 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  46.98 ns | 0.483 ns | 0.428 ns | 0.0210 |      88 B |
