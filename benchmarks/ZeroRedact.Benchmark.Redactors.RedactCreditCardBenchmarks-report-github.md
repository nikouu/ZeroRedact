```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 36.16 ns | 0.322 ns | 0.286 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 35.07 ns | 0.244 ns | 0.216 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 28.95 ns | 0.175 ns | 0.155 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 28.53 ns | 0.197 ns | 0.175 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 46.65 ns | 0.518 ns | 0.460 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 45.31 ns | 0.336 ns | 0.298 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 48.33 ns | 0.312 ns | 0.277 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 47.83 ns | 0.600 ns | 0.561 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 45.94 ns | 0.338 ns | 0.316 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 46.20 ns | 0.502 ns | 0.470 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 37.66 ns | 0.288 ns | 0.256 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 41.47 ns | 0.850 ns | 0.835 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 29.49 ns | 0.226 ns | 0.200 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 30.36 ns | 0.191 ns | 0.169 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 51.31 ns | 0.396 ns | 0.331 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 50.73 ns | 0.726 ns | 0.643 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 55.32 ns | 0.487 ns | 0.456 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 55.22 ns | 0.316 ns | 0.280 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 50.72 ns | 0.362 ns | 0.321 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 51.47 ns | 0.432 ns | 0.404 ns | 0.0153 |      64 B |
