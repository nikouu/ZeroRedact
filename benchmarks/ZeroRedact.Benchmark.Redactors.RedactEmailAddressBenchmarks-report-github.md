```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4894/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                          | EmailAddressInput    | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|-------------------------------- |--------------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  58.41 ns | 1.231 ns | 1.418 ns |  58.42 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  55.09 ns | 1.121 ns | 2.050 ns |  55.42 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  79.18 ns | 2.095 ns | 5.805 ns |  77.49 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  75.21 ns | 1.399 ns | 2.593 ns |  75.31 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  38.59 ns | 0.823 ns | 2.167 ns |  38.09 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  37.75 ns | 0.775 ns | 1.295 ns |  37.27 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  67.00 ns | 1.398 ns | 3.707 ns |  66.65 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  61.88 ns | 1.137 ns | 1.117 ns |  61.59 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  71.93 ns | 1.484 ns | 2.787 ns |  72.05 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  73.19 ns | 1.100 ns | 1.029 ns |  73.05 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  65.33 ns | 1.215 ns | 1.077 ns |  65.30 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  66.15 ns | 1.347 ns | 1.932 ns |  66.01 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  69.57 ns | 1.074 ns | 0.897 ns |  69.48 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  67.64 ns | 1.302 ns | 1.279 ns |  67.12 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  65.59 ns | 1.348 ns | 1.890 ns |  65.33 ns | 0.0535 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  63.45 ns | 1.000 ns | 0.936 ns |  63.46 ns | 0.0535 |     224 B |
| RedactEmailAddress_String       | 17:All               |  39.83 ns | 0.855 ns | 0.950 ns |  39.58 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:All               |  39.90 ns | 0.779 ns | 0.800 ns |  39.70 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  40.24 ns | 0.622 ns | 0.551 ns |  40.15 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  39.44 ns | 0.651 ns | 0.609 ns |  39.31 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  48.35 ns | 0.765 ns | 0.678 ns |  48.18 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  48.58 ns | 0.641 ns | 0.535 ns |  48.61 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  48.31 ns | 0.459 ns | 0.429 ns |  48.20 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  47.83 ns | 0.309 ns | 0.274 ns |  47.74 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |  29.91 ns | 0.254 ns | 0.237 ns |  29.86 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |  30.93 ns | 0.308 ns | 0.273 ns |  30.80 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  30.75 ns | 0.150 ns | 0.125 ns |  30.72 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  31.40 ns | 0.174 ns | 0.145 ns |  31.35 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  42.66 ns | 0.324 ns | 0.287 ns |  42.66 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  42.98 ns | 0.232 ns | 0.206 ns |  42.93 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  43.06 ns | 0.872 ns | 0.815 ns |  42.93 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  42.67 ns | 0.424 ns | 0.376 ns |  42.49 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  51.68 ns | 0.583 ns | 0.487 ns |  51.81 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  51.12 ns | 0.954 ns | 1.099 ns |  50.89 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  52.10 ns | 0.830 ns | 0.776 ns |  51.92 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  51.17 ns | 0.863 ns | 0.807 ns |  51.00 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  45.04 ns | 0.764 ns | 0.677 ns |  44.88 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  45.46 ns | 0.957 ns | 0.940 ns |  45.34 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  45.78 ns | 0.574 ns | 0.479 ns |  45.81 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  45.73 ns | 0.922 ns | 1.025 ns |  45.83 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  47.90 ns | 0.999 ns | 1.189 ns |  47.76 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  47.25 ns | 0.805 ns | 0.753 ns |  47.01 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  46.35 ns | 0.851 ns | 0.711 ns |  46.60 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  47.24 ns | 0.881 ns | 0.825 ns |  47.01 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  45.60 ns | 0.787 ns | 0.966 ns |  45.48 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  45.35 ns | 0.963 ns | 1.711 ns |  44.82 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  43.71 ns | 0.724 ns | 0.804 ns |  43.70 ns | 0.0134 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  44.19 ns | 0.861 ns | 0.805 ns |  44.09 ns | 0.0134 |      56 B |
| RedactEmailAddress_String       | 318:All              |  99.61 ns | 1.806 ns | 1.601 ns |  99.06 ns | 0.1587 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              | 106.35 ns | 2.050 ns | 1.918 ns | 105.94 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 124.70 ns | 2.530 ns | 2.598 ns | 124.15 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 124.63 ns | 1.569 ns | 1.310 ns | 124.97 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      |  46.53 ns | 0.473 ns | 0.420 ns |  46.49 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      |  47.12 ns | 0.729 ns | 0.682 ns |  46.95 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 111.06 ns | 1.696 ns | 1.503 ns | 111.36 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 113.79 ns | 1.869 ns | 1.657 ns | 114.19 ns | 0.1587 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 124.36 ns | 2.511 ns | 2.226 ns | 124.65 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 123.09 ns | 2.079 ns | 2.311 ns | 122.73 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 117.41 ns | 2.359 ns | 3.531 ns | 117.42 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 118.32 ns | 2.336 ns | 3.350 ns | 117.26 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 121.93 ns | 2.436 ns | 2.900 ns | 121.95 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 120.74 ns | 2.451 ns | 2.724 ns | 121.09 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 115.90 ns | 1.763 ns | 1.649 ns | 116.33 ns | 0.1585 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 117.82 ns | 2.085 ns | 1.741 ns | 118.27 ns | 0.1585 |     664 B |
| RedactEmailAddress_String       | 32:All               |  42.39 ns | 0.557 ns | 0.521 ns |  42.25 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  41.64 ns | 0.856 ns | 1.113 ns |  41.93 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  52.88 ns | 0.900 ns | 0.798 ns |  52.80 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  53.44 ns | 1.094 ns | 1.260 ns |  53.78 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  31.61 ns | 0.652 ns | 0.610 ns |  31.60 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  31.04 ns | 0.647 ns | 0.693 ns |  30.86 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  46.24 ns | 0.795 ns | 0.851 ns |  46.19 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  46.26 ns | 0.932 ns | 0.872 ns |  46.06 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  56.70 ns | 0.822 ns | 0.642 ns |  56.70 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  56.11 ns | 1.101 ns | 1.030 ns |  55.93 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  47.34 ns | 0.297 ns | 0.278 ns |  47.26 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  47.36 ns | 0.304 ns | 0.285 ns |  47.34 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  49.45 ns | 1.018 ns | 0.952 ns |  49.64 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  51.16 ns | 0.201 ns | 0.168 ns |  51.11 ns | 0.0210 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  46.21 ns | 0.323 ns | 0.286 ns |  46.15 ns | 0.0210 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  46.93 ns | 0.195 ns | 0.163 ns |  46.92 ns | 0.0210 |      88 B |
