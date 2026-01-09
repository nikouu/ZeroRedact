```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  67.80 ns | 0.295 ns | 0.261 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  67.76 ns | 0.390 ns | 0.346 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  87.83 ns | 0.327 ns | 0.273 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  93.27 ns | 0.460 ns | 0.408 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  55.97 ns | 0.304 ns | 0.270 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  54.93 ns | 0.273 ns | 0.255 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  74.86 ns | 0.333 ns | 0.295 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  82.44 ns | 1.658 ns | 1.470 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  88.59 ns | 0.360 ns | 0.319 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  93.34 ns | 0.807 ns | 0.755 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  81.22 ns | 0.449 ns | 0.398 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  78.52 ns | 0.668 ns | 0.625 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  84.81 ns | 0.463 ns | 0.410 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  91.28 ns | 1.513 ns | 1.415 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  80.51 ns | 0.453 ns | 0.378 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  80.39 ns | 1.504 ns | 1.333 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  24.35 ns | 0.200 ns | 0.187 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  23.71 ns | 0.125 ns | 0.117 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  24.76 ns | 0.112 ns | 0.105 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  24.73 ns | 0.146 ns | 0.136 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  40.62 ns | 0.612 ns | 0.542 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  41.78 ns | 0.182 ns | 0.170 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  42.66 ns | 0.178 ns | 0.167 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  42.20 ns | 0.105 ns | 0.082 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  17.03 ns | 0.217 ns | 0.181 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  16.67 ns | 0.070 ns | 0.066 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  17.87 ns | 0.090 ns | 0.075 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  18.25 ns | 0.286 ns | 0.268 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  30.46 ns | 0.124 ns | 0.104 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  31.10 ns | 0.219 ns | 0.194 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  27.92 ns | 0.188 ns | 0.176 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  27.91 ns | 0.196 ns | 0.184 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.15 ns | 0.175 ns | 0.155 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.34 ns | 0.258 ns | 0.228 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  41.82 ns | 0.273 ns | 0.242 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  42.44 ns | 0.641 ns | 0.763 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  33.11 ns | 0.263 ns | 0.233 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  33.03 ns | 0.137 ns | 0.107 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  31.01 ns | 0.158 ns | 0.140 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  32.08 ns | 0.249 ns | 0.221 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  37.71 ns | 0.375 ns | 0.351 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  38.01 ns | 0.292 ns | 0.244 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  39.66 ns | 0.165 ns | 0.138 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  38.30 ns | 0.191 ns | 0.169 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  30.86 ns | 0.174 ns | 0.163 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  30.63 ns | 0.150 ns | 0.133 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  30.91 ns | 0.218 ns | 0.193 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  31.00 ns | 0.162 ns | 0.151 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              | 199.96 ns | 0.858 ns | 0.761 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              | 208.11 ns | 1.076 ns | 1.006 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 238.15 ns | 0.922 ns | 0.770 ns | 0.1583 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 243.93 ns | 1.685 ns | 1.577 ns | 0.1583 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      | 172.44 ns | 1.046 ns | 0.928 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      | 172.14 ns | 0.694 ns | 0.649 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 220.38 ns | 1.329 ns | 1.243 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 217.65 ns | 1.266 ns | 1.184 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 235.07 ns | 4.490 ns | 3.980 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 228.80 ns | 2.758 ns | 2.445 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 225.65 ns | 1.282 ns | 1.136 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 224.51 ns | 1.038 ns | 0.971 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 222.76 ns | 1.230 ns | 1.090 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 249.75 ns | 1.865 ns | 1.653 ns | 0.1583 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 208.45 ns | 1.153 ns | 0.963 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 227.82 ns | 1.885 ns | 1.671 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 32:All               |  31.43 ns | 0.446 ns | 0.372 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  32.49 ns | 0.255 ns | 0.238 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  49.23 ns | 0.216 ns | 0.191 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  51.03 ns | 0.231 ns | 0.204 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  22.75 ns | 0.133 ns | 0.124 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  23.16 ns | 0.133 ns | 0.118 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  37.95 ns | 0.251 ns | 0.235 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  37.06 ns | 0.329 ns | 0.307 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  50.98 ns | 0.139 ns | 0.116 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  50.47 ns | 0.300 ns | 0.266 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  41.95 ns | 0.319 ns | 0.298 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  40.82 ns | 0.289 ns | 0.270 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  45.71 ns | 0.210 ns | 0.175 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  46.14 ns | 0.310 ns | 0.275 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  40.23 ns | 0.247 ns | 0.219 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  40.68 ns | 0.211 ns | 0.187 ns | 0.0210 |      88 B |
