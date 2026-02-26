```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                          | EmailAddressInput    | Mean       | Error     | StdDev    | Median     | Gen0   | Allocated |
|-------------------------------- |--------------------- |-----------:|----------:|----------:|-----------:|-------:|----------:|
| RedactEmailAddress_String       | 101:All              |  36.765 ns | 0.1198 ns | 0.0935 ns |  36.751 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:All              |  36.909 ns | 0.0987 ns | 0.0875 ns |  36.906 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:F(...)rname [21] |  47.658 ns | 0.9738 ns | 1.7560 ns |  46.457 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:F(...)rname [21] |  46.129 ns | 0.0920 ns | 0.0860 ns |  46.100 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:FixedLength      |  26.857 ns | 0.1438 ns | 0.1345 ns |  26.808 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 101:FixedLength      |  28.760 ns | 0.5905 ns | 1.1235 ns |  28.302 ns |      - |         - |
| RedactEmailAddress_String       | 101:Full             |  36.863 ns | 0.4120 ns | 0.3217 ns |  36.757 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Full             |  37.356 ns | 0.0873 ns | 0.0774 ns |  37.345 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:Middle           |  51.054 ns | 0.1072 ns | 0.0895 ns |  51.068 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Middle           |  51.789 ns | 0.0984 ns | 0.0822 ns |  51.806 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:MostUsername     |  40.346 ns | 0.1366 ns | 0.1278 ns |  40.330 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:MostUsername     |  40.829 ns | 0.1404 ns | 0.1314 ns |  40.835 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:S(...)cters [23] |  44.780 ns | 0.9271 ns | 1.2690 ns |  44.117 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:S(...)cters [23] |  40.444 ns | 0.0512 ns | 0.0400 ns |  40.436 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 101:Username         |  41.300 ns | 0.8542 ns | 1.7448 ns |  40.075 ns | 0.0142 |     224 B |
| RedactEmailAddress_ReadOnlySpan | 101:Username         |  41.360 ns | 0.8258 ns | 1.3797 ns |  40.474 ns | 0.0142 |     224 B |
| RedactEmailAddress_String       | 17:All               |  13.382 ns | 0.0479 ns | 0.0425 ns |  13.386 ns | 0.0036 |      56 B |
| RedactEmailAddress_String       | 17:All               |  13.721 ns | 0.3016 ns | 0.4955 ns |  13.455 ns | 0.0036 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  14.387 ns | 0.2955 ns | 0.5403 ns |  14.531 ns | 0.0036 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:All               |  14.152 ns | 0.2924 ns | 0.4885 ns |  14.107 ns | 0.0036 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  17.443 ns | 0.0452 ns | 0.0423 ns |  17.438 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:FirstHalfUsername |  18.761 ns | 0.0799 ns | 0.0748 ns |  18.787 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  17.505 ns | 0.0572 ns | 0.0507 ns |  17.509 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:FirstHalfUsername |  17.399 ns | 0.0313 ns | 0.0292 ns |  17.396 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:FixedLength       |   9.790 ns | 0.2241 ns | 0.4154 ns |   9.531 ns |      - |         - |
| RedactEmailAddress_String       | 17:FixedLength       |   9.280 ns | 0.0588 ns | 0.0550 ns |   9.283 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  11.096 ns | 0.2356 ns | 0.3738 ns |  10.925 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 17:FixedLength       |  10.931 ns | 0.0405 ns | 0.0379 ns |  10.940 ns |      - |         - |
| RedactEmailAddress_String       | 17:Full              |  13.512 ns | 0.0262 ns | 0.0245 ns |  13.520 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Full              |  13.995 ns | 0.0407 ns | 0.0361 ns |  13.990 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  14.228 ns | 0.0404 ns | 0.0316 ns |  14.230 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Full              |  14.264 ns | 0.0346 ns | 0.0289 ns |  14.270 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  18.529 ns | 0.0457 ns | 0.0427 ns |  18.516 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Middle            |  18.518 ns | 0.0231 ns | 0.0193 ns |  18.515 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  18.918 ns | 0.0618 ns | 0.0578 ns |  18.928 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Middle            |  19.226 ns | 0.3959 ns | 0.6394 ns |  18.827 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  13.878 ns | 0.0766 ns | 0.1023 ns |  13.868 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:MostUsername      |  14.100 ns | 0.0878 ns | 0.0821 ns |  14.120 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  14.951 ns | 0.0491 ns | 0.0459 ns |  14.946 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:MostUsername      |  14.625 ns | 0.0743 ns | 0.0695 ns |  14.618 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  16.264 ns | 0.3482 ns | 0.5421 ns |  15.912 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Sh(...)cters [22] |  15.322 ns | 0.0625 ns | 0.0554 ns |  15.335 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  15.811 ns | 0.0601 ns | 0.0470 ns |  15.821 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Sh(...)cters [22] |  15.700 ns | 0.0541 ns | 0.0506 ns |  15.693 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  14.319 ns | 0.0795 ns | 0.0744 ns |  14.345 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 17:Username          |  14.495 ns | 0.3152 ns | 0.5090 ns |  14.828 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  15.448 ns | 0.2720 ns | 0.2412 ns |  15.551 ns | 0.0035 |      56 B |
| RedactEmailAddress_ReadOnlySpan | 17:Username          |  15.476 ns | 0.3178 ns | 0.3532 ns |  15.578 ns | 0.0035 |      56 B |
| RedactEmailAddress_String       | 318:All              | 136.324 ns | 2.7335 ns | 4.8587 ns | 139.736 ns | 0.0422 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:All              | 127.349 ns | 0.3735 ns | 0.3311 ns | 127.294 ns | 0.0422 |     664 B |
| RedactEmailAddress_String       | 318:F(...)rname [21] | 125.957 ns | 0.2896 ns | 0.2567 ns | 126.050 ns | 0.0422 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:F(...)rname [21] | 125.710 ns | 0.7412 ns | 0.6933 ns | 125.477 ns | 0.0422 |     664 B |
| RedactEmailAddress_String       | 318:FixedLength      | 104.148 ns | 2.1116 ns | 3.7534 ns | 102.024 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 318:FixedLength      | 114.331 ns | 0.1909 ns | 0.1786 ns | 114.333 ns |      - |         - |
| RedactEmailAddress_String       | 318:Full             | 102.202 ns | 2.0730 ns | 3.7380 ns |  99.292 ns | 0.0423 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Full             | 102.452 ns | 1.8180 ns | 1.8669 ns | 101.813 ns | 0.0423 |     664 B |
| RedactEmailAddress_String       | 318:Middle           | 112.291 ns | 0.6208 ns | 0.5807 ns | 112.385 ns | 0.0423 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Middle           | 110.763 ns | 0.2160 ns | 0.1686 ns | 110.757 ns | 0.0423 |     664 B |
| RedactEmailAddress_String       | 318:MostUsername     | 125.967 ns | 0.4236 ns | 0.3755 ns | 125.909 ns | 0.0422 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:MostUsername     | 128.568 ns | 2.5917 ns | 5.2354 ns | 124.357 ns | 0.0422 |     664 B |
| RedactEmailAddress_String       | 318:S(...)cters [23] | 127.281 ns | 2.5733 ns | 4.0815 ns | 128.157 ns | 0.0422 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:S(...)cters [23] | 142.044 ns | 0.1785 ns | 0.1582 ns | 141.996 ns | 0.0422 |     664 B |
| RedactEmailAddress_String       | 318:Username         | 125.093 ns | 0.5137 ns | 0.4553 ns | 124.928 ns | 0.0422 |     664 B |
| RedactEmailAddress_ReadOnlySpan | 318:Username         | 123.606 ns | 0.3913 ns | 0.3055 ns | 123.589 ns | 0.0422 |     664 B |
| RedactEmailAddress_String       | 32:All               |  16.392 ns | 0.0865 ns | 0.0809 ns |  16.397 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:All               |  16.621 ns | 0.0896 ns | 0.0748 ns |  16.593 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:FirstHalfUsername |  23.908 ns | 0.5087 ns | 0.8068 ns |  23.396 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:FirstHalfUsername |  24.738 ns | 0.5050 ns | 0.8976 ns |  25.373 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:FixedLength       |  13.207 ns | 0.0738 ns | 0.0690 ns |  13.199 ns |      - |         - |
| RedactEmailAddress_ReadOnlySpan | 32:FixedLength       |  12.851 ns | 0.0808 ns | 0.0793 ns |  12.862 ns |      - |         - |
| RedactEmailAddress_String       | 32:Full              |  16.933 ns | 0.0570 ns | 0.0505 ns |  16.916 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Full              |  17.436 ns | 0.0482 ns | 0.0402 ns |  17.427 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:Middle            |  25.351 ns | 0.5318 ns | 0.8737 ns |  24.733 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Middle            |  25.422 ns | 0.0460 ns | 0.0384 ns |  25.423 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:MostUsername      |  18.671 ns | 0.0417 ns | 0.0390 ns |  18.669 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:MostUsername      |  18.958 ns | 0.0441 ns | 0.0391 ns |  18.951 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:Sh(...)cters [22] |  21.830 ns | 0.4548 ns | 0.7213 ns |  22.249 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Sh(...)cters [22] |  20.778 ns | 0.0381 ns | 0.0318 ns |  20.782 ns | 0.0056 |      88 B |
| RedactEmailAddress_String       | 32:Username          |  18.149 ns | 0.1183 ns | 0.0923 ns |  18.161 ns | 0.0056 |      88 B |
| RedactEmailAddress_ReadOnlySpan | 32:Username          |  18.454 ns | 0.0310 ns | 0.0259 ns |  18.457 ns | 0.0056 |      88 B |
