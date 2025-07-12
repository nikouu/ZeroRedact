```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  42.04 ns | 0.165 ns | 0.154 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  47.71 ns | 0.119 ns | 0.093 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  58.76 ns | 0.267 ns | 0.250 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  61.60 ns | 0.269 ns | 0.239 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  27.39 ns | 0.037 ns | 0.033 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  32.21 ns | 0.048 ns | 0.038 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  48.88 ns | 0.535 ns | 0.446 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  50.86 ns | 0.238 ns | 0.211 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  58.96 ns | 0.267 ns | 0.250 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  62.19 ns | 0.135 ns | 0.106 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  53.01 ns | 0.449 ns | 0.398 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  53.82 ns | 0.165 ns | 0.155 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  52.86 ns | 0.370 ns | 0.346 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  55.37 ns | 0.252 ns | 0.236 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  50.51 ns | 0.332 ns | 0.311 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  54.10 ns | 0.304 ns | 0.269 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  29.80 ns | 0.091 ns | 0.081 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  28.99 ns | 0.126 ns | 0.118 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  34.91 ns | 0.084 ns | 0.078 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  34.98 ns | 0.347 ns | 0.308 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  41.22 ns | 0.146 ns | 0.122 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  41.48 ns | 0.308 ns | 0.288 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  44.21 ns | 0.161 ns | 0.151 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  43.81 ns | 0.256 ns | 0.227 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  21.59 ns | 0.077 ns | 0.068 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  22.67 ns | 0.032 ns | 0.025 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  28.37 ns | 0.092 ns | 0.086 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  27.07 ns | 0.102 ns | 0.095 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  35.47 ns | 0.199 ns | 0.166 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  35.19 ns | 0.062 ns | 0.048 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  37.48 ns | 0.115 ns | 0.102 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  38.80 ns | 0.142 ns | 0.133 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.73 ns | 0.260 ns | 0.243 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.58 ns | 0.185 ns | 0.173 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  47.23 ns | 0.226 ns | 0.188 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  46.92 ns | 0.145 ns | 0.121 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  37.32 ns | 0.163 ns | 0.152 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  36.43 ns | 0.165 ns | 0.138 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  41.00 ns | 0.250 ns | 0.221 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  39.14 ns | 0.128 ns | 0.107 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  37.95 ns | 0.067 ns | 0.052 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  37.36 ns | 0.254 ns | 0.212 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  42.28 ns | 0.213 ns | 0.189 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  43.22 ns | 0.115 ns | 0.102 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  34.05 ns | 0.155 ns | 0.129 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  34.07 ns | 0.387 ns | 0.362 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  40.03 ns | 0.195 ns | 0.173 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  38.85 ns | 0.165 ns | 0.154 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              |  75.18 ns | 1.006 ns | 0.892 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              |  77.31 ns | 0.266 ns | 0.236 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] |  99.82 ns | 0.213 ns | 0.200 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] |  99.86 ns | 0.477 ns | 0.423 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      |  43.68 ns | 0.151 ns | 0.134 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  43.39 ns | 0.097 ns | 0.091 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             |  86.00 ns | 0.856 ns | 0.759 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             |  87.99 ns | 0.639 ns | 0.566 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Middle           |  97.93 ns | 1.168 ns | 1.093 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 100.59 ns | 0.526 ns | 0.492 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     |  91.72 ns | 0.535 ns | 0.474 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     |  96.28 ns | 1.578 ns | 1.688 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] |  92.75 ns | 0.415 ns | 0.388 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] |  96.95 ns | 0.542 ns | 0.480 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Username         |  92.58 ns | 0.494 ns | 0.412 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         |  93.49 ns | 0.625 ns | 0.554 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 32:All               |  31.39 ns | 0.112 ns | 0.105 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  35.32 ns | 0.164 ns | 0.137 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  44.35 ns | 0.192 ns | 0.180 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  48.37 ns | 0.975 ns | 1.197 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  22.56 ns | 0.050 ns | 0.042 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  27.41 ns | 0.077 ns | 0.068 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  34.55 ns | 0.133 ns | 0.118 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  39.69 ns | 0.156 ns | 0.146 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  47.79 ns | 0.244 ns | 0.228 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  50.38 ns | 0.169 ns | 0.158 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  37.75 ns | 0.179 ns | 0.150 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  41.52 ns | 0.341 ns | 0.285 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  40.56 ns | 0.158 ns | 0.140 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  44.92 ns | 0.243 ns | 0.203 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  36.82 ns | 0.147 ns | 0.130 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  40.42 ns | 0.167 ns | 0.148 ns | 0.0210 |      88 B |
