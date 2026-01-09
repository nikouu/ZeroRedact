```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  46.89 ns | 0.446 ns | 0.395 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  44.27 ns | 0.458 ns | 0.406 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  57.27 ns | 0.668 ns | 0.592 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  57.73 ns | 0.424 ns | 0.397 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  31.91 ns | 0.255 ns | 0.226 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  34.48 ns | 0.294 ns | 0.275 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  50.69 ns | 0.294 ns | 0.261 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  54.96 ns | 0.497 ns | 0.415 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  60.19 ns | 0.661 ns | 0.618 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  58.44 ns | 0.420 ns | 0.373 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  53.92 ns | 0.559 ns | 0.495 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  58.42 ns | 1.108 ns | 0.982 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  60.79 ns | 1.258 ns | 2.136 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  56.23 ns | 0.728 ns | 0.681 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  55.52 ns | 0.389 ns | 0.345 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  53.23 ns | 0.163 ns | 0.136 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  29.53 ns | 0.177 ns | 0.157 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  33.59 ns | 0.107 ns | 0.084 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  32.53 ns | 0.184 ns | 0.172 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  29.23 ns | 0.236 ns | 0.220 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  38.85 ns | 0.233 ns | 0.218 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  39.03 ns | 0.316 ns | 0.296 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  39.95 ns | 0.207 ns | 0.184 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  46.27 ns | 0.295 ns | 0.246 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  23.33 ns | 0.241 ns | 0.225 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  23.27 ns | 0.056 ns | 0.047 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  26.38 ns | 0.069 ns | 0.061 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  22.86 ns | 0.072 ns | 0.064 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  33.86 ns | 0.241 ns | 0.214 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  35.42 ns | 0.475 ns | 0.445 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  35.57 ns | 0.093 ns | 0.078 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  33.37 ns | 0.113 ns | 0.088 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  42.27 ns | 0.172 ns | 0.144 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  41.14 ns | 0.105 ns | 0.082 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  41.49 ns | 0.469 ns | 0.392 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  44.93 ns | 0.591 ns | 0.553 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  36.61 ns | 0.276 ns | 0.245 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  36.74 ns | 0.539 ns | 0.505 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  37.86 ns | 0.383 ns | 0.359 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  37.37 ns | 0.268 ns | 0.223 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  38.53 ns | 0.209 ns | 0.186 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  38.24 ns | 0.206 ns | 0.183 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  38.66 ns | 0.190 ns | 0.168 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  39.34 ns | 0.195 ns | 0.182 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  36.21 ns | 0.242 ns | 0.226 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  35.90 ns | 0.294 ns | 0.275 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  36.50 ns | 0.169 ns | 0.150 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  38.47 ns | 0.256 ns | 0.240 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              |  96.18 ns | 1.921 ns | 2.934 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              |  89.97 ns | 0.585 ns | 0.518 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 117.20 ns | 0.503 ns | 0.393 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 116.12 ns | 1.077 ns | 1.008 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      |  61.23 ns | 0.278 ns | 0.260 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  57.01 ns | 0.483 ns | 0.428 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 109.32 ns | 1.165 ns | 0.972 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 103.24 ns | 1.153 ns | 1.079 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 110.44 ns | 0.825 ns | 0.731 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 116.48 ns | 0.485 ns | 0.405 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 112.17 ns | 0.752 ns | 0.704 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 111.14 ns | 0.394 ns | 0.308 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 108.55 ns | 0.689 ns | 0.611 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 110.58 ns | 0.825 ns | 0.731 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 111.59 ns | 0.933 ns | 0.873 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 108.84 ns | 1.080 ns | 1.010 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 32:All               |  31.96 ns | 0.213 ns | 0.199 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  34.14 ns | 0.235 ns | 0.220 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  42.30 ns | 0.192 ns | 0.170 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  42.74 ns | 0.340 ns | 0.284 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  24.27 ns | 0.154 ns | 0.144 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  23.96 ns | 0.118 ns | 0.099 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  35.73 ns | 0.133 ns | 0.111 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  35.56 ns | 0.285 ns | 0.253 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  43.86 ns | 0.144 ns | 0.112 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  46.89 ns | 0.275 ns | 0.257 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  39.29 ns | 0.221 ns | 0.196 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  39.58 ns | 0.283 ns | 0.265 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  41.65 ns | 0.136 ns | 0.106 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  41.58 ns | 0.388 ns | 0.363 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  38.63 ns | 0.274 ns | 0.229 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  42.19 ns | 0.222 ns | 0.196 ns | 0.0210 |      88 B |
