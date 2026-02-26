```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                        | CreditCardInput      | Mean      | Error     | StdDev    | Median   | Gen0   | Allocated |
|------------------------------ |--------------------- |----------:|----------:|----------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 12.727 ns | 0.0404 ns | 0.0359 ns | 12.73 ns | 0.0036 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 13.654 ns | 0.2859 ns | 0.5228 ns | 13.29 ns | 0.0036 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       |  9.996 ns | 0.2292 ns | 0.2980 ns | 10.12 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 10.309 ns | 0.2173 ns | 0.3571 ns | 10.05 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 18.087 ns | 0.3918 ns | 0.7164 ns | 18.62 ns | 0.0035 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 18.336 ns | 0.0580 ns | 0.0543 ns | 18.34 ns | 0.0035 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 18.279 ns | 0.3957 ns | 0.7235 ns | 17.67 ns | 0.0035 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 18.469 ns | 0.0522 ns | 0.0436 ns | 18.46 ns | 0.0035 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 15.420 ns | 0.3308 ns | 0.6294 ns | 15.61 ns | 0.0035 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 15.410 ns | 0.0429 ns | 0.0358 ns | 15.42 ns | 0.0035 |      56 B |
| RedactCreditCard_String       | 19:All               | 14.085 ns | 0.3073 ns | 0.5921 ns | 13.77 ns | 0.0041 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 13.923 ns | 0.0396 ns | 0.0351 ns | 13.92 ns | 0.0041 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 10.561 ns | 0.1153 ns | 0.1022 ns | 10.56 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 10.983 ns | 0.0820 ns | 0.0806 ns | 10.96 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 20.725 ns | 0.3958 ns | 0.3703 ns | 20.84 ns | 0.0041 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 20.361 ns | 0.1341 ns | 0.1047 ns | 20.37 ns | 0.0041 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 20.906 ns | 0.3604 ns | 0.3371 ns | 20.90 ns | 0.0041 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 20.607 ns | 0.3300 ns | 0.2577 ns | 20.74 ns | 0.0041 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 18.544 ns | 0.3741 ns | 0.4003 ns | 18.49 ns | 0.0041 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 18.750 ns | 0.0965 ns | 0.0902 ns | 18.76 ns | 0.0041 |      64 B |
