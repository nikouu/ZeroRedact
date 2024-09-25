```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  50.67 ns | 0.612 ns | 0.542 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  50.93 ns | 0.473 ns | 0.442 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  66.32 ns | 0.490 ns | 0.410 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  66.23 ns | 0.485 ns | 0.454 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  35.08 ns | 0.200 ns | 0.167 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  36.42 ns | 0.126 ns | 0.105 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  55.01 ns | 0.523 ns | 0.489 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  56.71 ns | 0.492 ns | 0.436 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  29.43 ns | 0.180 ns | 0.168 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  30.23 ns | 0.204 ns | 0.180 ns |      - |         - |
| RedactEmailAddress_String       | 101:MostUsername     |  63.54 ns | 0.843 ns | 0.704 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  62.77 ns | 0.966 ns | 0.904 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  59.46 ns | 0.612 ns | 0.542 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  59.28 ns | 0.724 ns | 0.641 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  58.26 ns | 0.618 ns | 0.516 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  58.58 ns | 0.414 ns | 0.346 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  37.09 ns | 0.304 ns | 0.254 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  37.90 ns | 0.347 ns | 0.325 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  38.35 ns | 0.301 ns | 0.266 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  38.82 ns | 0.811 ns | 0.833 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  47.17 ns | 0.398 ns | 0.353 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  48.75 ns | 0.660 ns | 0.617 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  46.17 ns | 0.347 ns | 0.307 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  46.63 ns | 0.428 ns | 0.379 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  29.65 ns | 0.203 ns | 0.180 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  30.75 ns | 0.126 ns | 0.111 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  30.62 ns | 0.164 ns | 0.146 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  29.87 ns | 0.149 ns | 0.124 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  42.12 ns | 0.408 ns | 0.382 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  42.05 ns | 0.472 ns | 0.442 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  41.76 ns | 0.314 ns | 0.294 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  40.77 ns | 0.273 ns | 0.242 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  25.41 ns | 0.119 ns | 0.111 ns |      - |         - |
| RedactEmailAddress_String       | 17:Middle            |  25.41 ns | 0.167 ns | 0.148 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  25.55 ns | 0.115 ns | 0.108 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  25.07 ns | 0.078 ns | 0.069 ns |      - |         - |
| RedactEmailAddress_String       | 17:MostUsername      |  47.06 ns | 0.399 ns | 0.373 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  47.43 ns | 0.347 ns | 0.325 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  46.17 ns | 0.319 ns | 0.283 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  47.77 ns | 0.223 ns | 0.174 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  46.33 ns | 0.309 ns | 0.274 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  45.59 ns | 0.427 ns | 0.400 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  46.36 ns | 0.442 ns | 0.414 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  46.65 ns | 0.334 ns | 0.296 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  42.66 ns | 0.356 ns | 0.316 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  41.84 ns | 0.162 ns | 0.127 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  43.29 ns | 0.473 ns | 0.395 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  42.15 ns | 0.508 ns | 0.475 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              |  88.28 ns | 0.920 ns | 0.815 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              |  86.25 ns | 1.024 ns | 0.908 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 107.91 ns | 1.263 ns | 1.181 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 107.18 ns | 1.443 ns | 1.279 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      |  48.88 ns | 0.223 ns | 0.186 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  47.25 ns | 0.116 ns | 0.102 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             |  93.82 ns | 1.873 ns | 1.660 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             |  94.43 ns | 1.097 ns | 0.972 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Middle           |  34.92 ns | 0.217 ns | 0.192 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           |  34.91 ns | 0.217 ns | 0.203 ns |      - |         - |
| RedactEmailAddress_String       | 318:MostUsername     | 103.91 ns | 0.991 ns | 0.927 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 103.56 ns | 1.227 ns | 1.148 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] |  99.32 ns | 1.405 ns | 1.246 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 100.83 ns | 1.338 ns | 1.252 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Username         |  99.77 ns | 1.595 ns | 1.492 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 101.69 ns | 2.036 ns | 2.091 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 32:All               |  40.32 ns | 0.338 ns | 0.299 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  39.19 ns | 0.253 ns | 0.224 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  50.06 ns | 0.399 ns | 0.373 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  50.51 ns | 0.495 ns | 0.463 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  31.18 ns | 0.300 ns | 0.266 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  30.71 ns | 0.224 ns | 0.199 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  43.31 ns | 0.346 ns | 0.324 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  42.78 ns | 0.584 ns | 0.488 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  25.95 ns | 0.131 ns | 0.116 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  25.38 ns | 0.168 ns | 0.158 ns |      - |         - |
| RedactEmailAddress_String       | 32:MostUsername      |  48.62 ns | 0.793 ns | 0.742 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  49.05 ns | 0.493 ns | 0.437 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  47.31 ns | 0.579 ns | 0.513 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  47.73 ns | 0.414 ns | 0.387 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  44.41 ns | 0.403 ns | 0.377 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  44.08 ns | 0.321 ns | 0.284 ns | 0.0210 |      88 B |
