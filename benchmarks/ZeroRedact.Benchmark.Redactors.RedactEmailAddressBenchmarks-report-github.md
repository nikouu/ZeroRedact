```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  70.52 ns | 0.197 ns | 0.184 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  73.02 ns | 0.206 ns | 0.172 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  87.11 ns | 0.192 ns | 0.179 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  89.72 ns | 0.540 ns | 0.478 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  57.15 ns | 0.091 ns | 0.085 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  57.49 ns | 0.078 ns | 0.073 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  74.60 ns | 0.207 ns | 0.162 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  72.06 ns | 0.126 ns | 0.099 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  86.68 ns | 0.153 ns | 0.136 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  88.93 ns | 0.155 ns | 0.145 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  79.57 ns | 0.140 ns | 0.131 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  82.21 ns | 0.231 ns | 0.193 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  80.05 ns | 0.188 ns | 0.157 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  80.10 ns | 0.170 ns | 0.142 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  81.70 ns | 0.178 ns | 0.167 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  79.33 ns | 0.335 ns | 0.279 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  25.58 ns | 0.074 ns | 0.065 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  25.38 ns | 0.043 ns | 0.038 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  26.15 ns | 0.046 ns | 0.041 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  26.19 ns | 0.047 ns | 0.044 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  39.55 ns | 0.060 ns | 0.056 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  39.56 ns | 0.053 ns | 0.050 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  39.74 ns | 0.119 ns | 0.099 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  42.01 ns | 0.609 ns | 0.540 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  19.35 ns | 0.044 ns | 0.041 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  19.55 ns | 0.039 ns | 0.033 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  20.25 ns | 0.076 ns | 0.067 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  20.88 ns | 0.064 ns | 0.060 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  29.06 ns | 0.119 ns | 0.111 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  28.27 ns | 0.077 ns | 0.072 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  30.66 ns | 0.052 ns | 0.048 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  30.39 ns | 0.080 ns | 0.075 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  42.69 ns | 0.166 ns | 0.138 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  42.01 ns | 0.040 ns | 0.031 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  42.76 ns | 0.036 ns | 0.032 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  45.59 ns | 0.061 ns | 0.051 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  31.49 ns | 0.070 ns | 0.065 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  31.43 ns | 0.089 ns | 0.084 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  32.02 ns | 0.095 ns | 0.079 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  32.85 ns | 0.071 ns | 0.060 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  34.70 ns | 0.069 ns | 0.058 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  34.98 ns | 0.058 ns | 0.048 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  35.25 ns | 0.160 ns | 0.149 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  35.56 ns | 0.060 ns | 0.047 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  31.76 ns | 0.102 ns | 0.095 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  30.82 ns | 0.085 ns | 0.075 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  31.44 ns | 0.053 ns | 0.041 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  31.64 ns | 0.054 ns | 0.051 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              | 214.27 ns | 0.973 ns | 0.910 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              | 215.49 ns | 0.343 ns | 0.286 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 246.11 ns | 1.141 ns | 1.067 ns | 0.1583 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 218.93 ns | 0.653 ns | 0.546 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      | 180.80 ns | 0.606 ns | 0.537 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      | 186.70 ns | 0.280 ns | 0.233 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 228.07 ns | 0.383 ns | 0.299 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 230.57 ns | 1.409 ns | 1.318 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 231.26 ns | 0.682 ns | 0.605 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 223.90 ns | 0.374 ns | 0.350 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 227.71 ns | 0.469 ns | 0.415 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 221.72 ns | 0.545 ns | 0.483 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 224.47 ns | 0.472 ns | 0.418 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 216.70 ns | 0.458 ns | 0.428 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 232.89 ns | 0.345 ns | 0.306 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 228.80 ns | 0.246 ns | 0.230 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 32:All               |  35.63 ns | 0.060 ns | 0.056 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  35.43 ns | 0.121 ns | 0.108 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  54.81 ns | 0.883 ns | 0.783 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  50.25 ns | 0.096 ns | 0.089 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  24.53 ns | 0.042 ns | 0.035 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  28.55 ns | 0.201 ns | 0.178 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  36.82 ns | 0.111 ns | 0.104 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  37.71 ns | 0.096 ns | 0.085 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  51.90 ns | 0.125 ns | 0.117 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  53.08 ns | 0.298 ns | 0.249 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  41.96 ns | 0.115 ns | 0.108 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  42.28 ns | 0.227 ns | 0.201 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  45.26 ns | 0.127 ns | 0.113 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  44.47 ns | 0.112 ns | 0.105 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  40.69 ns | 0.105 ns | 0.098 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  41.31 ns | 0.085 ns | 0.075 ns | 0.0210 |      88 B |
