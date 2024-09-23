```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                      | CreditCardInput      |     Mean |    Error |   StdDev |   Median |   Gen0 | Allocated |
| --------------------------- | -------------------- | -------: | -------: | -------: | -------: | -----: | --------: |
| RedactCreditCard_String       | 16:All               | 38.50 ns | 0.346 ns | 0.307 ns | 38.41 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 35.63 ns | 0.274 ns | 0.256 ns | 35.55 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 27.95 ns | 0.228 ns | 0.202 ns | 27.99 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 28.49 ns | 0.211 ns | 0.187 ns | 28.43 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 48.97 ns | 0.384 ns | 0.340 ns | 48.93 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 49.60 ns | 1.020 ns | 2.687 ns | 48.68 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 49.23 ns | 0.289 ns | 0.241 ns | 49.21 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 50.09 ns | 0.821 ns | 0.685 ns | 50.05 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 50.32 ns | 1.043 ns | 1.593 ns | 50.06 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 49.41 ns | 0.837 ns | 0.742 ns | 49.32 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 39.61 ns | 0.840 ns | 0.745 ns | 39.40 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 38.75 ns | 0.415 ns | 0.368 ns | 38.75 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 30.44 ns | 0.461 ns | 0.409 ns | 30.35 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 31.20 ns | 0.406 ns | 0.379 ns | 31.00 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 52.28 ns | 0.537 ns | 0.476 ns | 52.24 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 53.10 ns | 0.321 ns | 0.250 ns | 53.10 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 55.84 ns | 0.529 ns | 0.441 ns | 55.79 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 63.71 ns | 1.954 ns | 5.730 ns | 62.65 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 53.45 ns | 1.082 ns | 1.012 ns | 53.16 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 53.00 ns | 0.975 ns | 0.912 ns | 52.74 ns | 0.0153 |      64 B |
