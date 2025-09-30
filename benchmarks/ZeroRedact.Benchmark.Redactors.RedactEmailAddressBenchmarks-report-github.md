```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  71.39 ns | 0.351 ns | 0.311 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  73.25 ns | 0.350 ns | 0.327 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  90.58 ns | 0.633 ns | 0.561 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  88.27 ns | 0.186 ns | 0.145 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  57.32 ns | 0.339 ns | 0.301 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  60.56 ns | 0.136 ns | 0.121 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  75.94 ns | 0.295 ns | 0.246 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  77.82 ns | 0.448 ns | 0.419 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  92.94 ns | 0.568 ns | 0.531 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  92.36 ns | 0.405 ns | 0.378 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  81.57 ns | 0.312 ns | 0.260 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  80.83 ns | 0.373 ns | 0.331 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  84.09 ns | 0.473 ns | 0.442 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  83.76 ns | 0.527 ns | 0.493 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  79.97 ns | 0.446 ns | 0.417 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  80.26 ns | 0.228 ns | 0.190 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  26.51 ns | 0.153 ns | 0.136 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  26.28 ns | 0.139 ns | 0.123 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  26.91 ns | 0.146 ns | 0.122 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  27.81 ns | 0.079 ns | 0.070 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  40.31 ns | 0.221 ns | 0.207 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  40.15 ns | 0.245 ns | 0.229 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  41.41 ns | 0.804 ns | 0.825 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  41.22 ns | 0.598 ns | 0.559 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  18.82 ns | 0.094 ns | 0.088 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  18.84 ns | 0.060 ns | 0.053 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  20.20 ns | 0.093 ns | 0.087 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  20.53 ns | 0.044 ns | 0.039 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  29.04 ns | 0.124 ns | 0.110 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  29.91 ns | 0.118 ns | 0.110 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  29.83 ns | 0.252 ns | 0.211 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  29.84 ns | 0.123 ns | 0.115 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.15 ns | 0.220 ns | 0.206 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  43.01 ns | 0.322 ns | 0.286 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  43.57 ns | 0.177 ns | 0.166 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  43.75 ns | 0.195 ns | 0.173 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  32.23 ns | 0.176 ns | 0.156 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  32.31 ns | 0.120 ns | 0.100 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  32.55 ns | 0.149 ns | 0.132 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  33.14 ns | 0.197 ns | 0.175 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  35.50 ns | 0.179 ns | 0.167 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  37.13 ns | 0.193 ns | 0.181 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  36.03 ns | 0.130 ns | 0.122 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  36.05 ns | 0.127 ns | 0.119 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  31.80 ns | 0.183 ns | 0.171 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  32.61 ns | 0.151 ns | 0.134 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  34.19 ns | 0.133 ns | 0.124 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  32.21 ns | 0.382 ns | 0.319 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              | 216.15 ns | 1.426 ns | 1.334 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              | 215.75 ns | 0.824 ns | 0.688 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 234.05 ns | 0.904 ns | 0.755 ns | 0.1583 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 250.25 ns | 1.671 ns | 1.481 ns | 0.1583 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      | 182.23 ns | 0.337 ns | 0.263 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      | 188.01 ns | 0.735 ns | 0.651 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 233.89 ns | 1.624 ns | 1.519 ns | 0.1583 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 233.10 ns | 0.625 ns | 0.554 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 228.07 ns | 1.077 ns | 1.007 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 228.34 ns | 1.476 ns | 1.381 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 230.56 ns | 1.592 ns | 1.489 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 227.30 ns | 1.203 ns | 1.067 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 241.91 ns | 1.871 ns | 1.750 ns | 0.1583 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 231.46 ns | 1.705 ns | 1.595 ns | 0.1583 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 229.12 ns | 0.821 ns | 0.728 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 227.29 ns | 1.079 ns | 1.009 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 32:All               |  34.36 ns | 0.258 ns | 0.229 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  35.65 ns | 0.200 ns | 0.178 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  50.46 ns | 0.203 ns | 0.180 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  51.56 ns | 0.272 ns | 0.255 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  25.49 ns | 0.050 ns | 0.045 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  25.80 ns | 0.107 ns | 0.100 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  37.67 ns | 0.143 ns | 0.127 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  38.38 ns | 0.189 ns | 0.168 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  53.11 ns | 0.251 ns | 0.235 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  54.45 ns | 0.201 ns | 0.188 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  42.51 ns | 0.176 ns | 0.165 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  43.12 ns | 0.235 ns | 0.220 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  44.43 ns | 0.234 ns | 0.208 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  47.11 ns | 0.947 ns | 1.013 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  42.20 ns | 0.195 ns | 0.173 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  43.23 ns | 0.175 ns | 0.155 ns | 0.0210 |      88 B |
