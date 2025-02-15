```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  45.42 ns | 0.244 ns | 0.228 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  48.98 ns | 0.247 ns | 0.231 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  60.90 ns | 0.172 ns | 0.153 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  65.93 ns | 0.344 ns | 0.322 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  31.01 ns | 0.111 ns | 0.098 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  35.95 ns | 0.102 ns | 0.096 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  51.50 ns | 0.248 ns | 0.232 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  54.18 ns | 0.344 ns | 0.305 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  62.34 ns | 0.371 ns | 0.329 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  67.67 ns | 0.467 ns | 0.437 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  58.35 ns | 0.285 ns | 0.253 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  57.97 ns | 0.294 ns | 0.261 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  55.64 ns | 0.273 ns | 0.228 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  59.93 ns | 0.369 ns | 0.327 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  52.42 ns | 0.266 ns | 0.222 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  56.90 ns | 0.287 ns | 0.269 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  32.04 ns | 0.138 ns | 0.129 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  32.54 ns | 0.274 ns | 0.257 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  37.13 ns | 0.096 ns | 0.085 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  36.63 ns | 0.114 ns | 0.095 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  42.68 ns | 0.228 ns | 0.202 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  42.58 ns | 0.175 ns | 0.164 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  46.02 ns | 0.233 ns | 0.195 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  46.03 ns | 0.259 ns | 0.243 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  25.19 ns | 0.055 ns | 0.049 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  24.63 ns | 0.051 ns | 0.040 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  29.88 ns | 0.054 ns | 0.048 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  30.76 ns | 0.074 ns | 0.066 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  35.82 ns | 0.179 ns | 0.167 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  36.12 ns | 0.154 ns | 0.137 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  40.72 ns | 0.133 ns | 0.124 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  41.66 ns | 0.193 ns | 0.180 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  45.92 ns | 0.455 ns | 0.426 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  45.27 ns | 0.168 ns | 0.157 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  50.28 ns | 0.163 ns | 0.152 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  49.19 ns | 0.164 ns | 0.153 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  37.71 ns | 0.161 ns | 0.151 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  38.52 ns | 0.188 ns | 0.166 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  42.28 ns | 0.120 ns | 0.112 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  43.53 ns | 0.189 ns | 0.177 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  40.05 ns | 0.194 ns | 0.162 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  40.90 ns | 0.181 ns | 0.161 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  45.52 ns | 0.186 ns | 0.165 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  45.50 ns | 0.238 ns | 0.211 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  36.67 ns | 0.172 ns | 0.153 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  37.55 ns | 0.154 ns | 0.144 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  42.32 ns | 0.282 ns | 0.250 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  41.82 ns | 0.138 ns | 0.129 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              |  78.49 ns | 0.522 ns | 0.489 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              |  96.30 ns | 0.557 ns | 0.521 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 101.22 ns | 0.536 ns | 0.501 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 104.82 ns | 0.734 ns | 0.687 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      |  45.63 ns | 0.211 ns | 0.187 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  47.62 ns | 0.123 ns | 0.115 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             |  88.38 ns | 0.519 ns | 0.460 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             |  92.49 ns | 0.598 ns | 0.530 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 102.60 ns | 0.647 ns | 0.573 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 104.39 ns | 0.345 ns | 0.323 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     |  96.18 ns | 0.518 ns | 0.459 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 101.71 ns | 0.755 ns | 0.706 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] |  98.34 ns | 1.067 ns | 0.998 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] |  96.51 ns | 0.731 ns | 0.683 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 100.30 ns | 0.902 ns | 0.844 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         |  99.42 ns | 0.219 ns | 0.171 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 32:All               |  33.27 ns | 0.067 ns | 0.053 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  39.82 ns | 0.246 ns | 0.230 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  45.71 ns | 0.145 ns | 0.136 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  51.41 ns | 0.289 ns | 0.271 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  24.78 ns | 0.050 ns | 0.046 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  30.67 ns | 0.070 ns | 0.062 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  37.34 ns | 0.262 ns | 0.219 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  42.35 ns | 0.206 ns | 0.183 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  49.26 ns | 0.229 ns | 0.214 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  53.39 ns | 0.281 ns | 0.250 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  39.75 ns | 0.781 ns | 0.868 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  43.86 ns | 0.164 ns | 0.146 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  42.60 ns | 0.124 ns | 0.103 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  47.79 ns | 0.232 ns | 0.206 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  39.37 ns | 0.197 ns | 0.185 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  42.95 ns | 0.164 ns | 0.137 ns | 0.0210 |      88 B |
