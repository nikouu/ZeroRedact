```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 24.86 ns | 0.052 ns | 0.048 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 27.78 ns | 0.078 ns | 0.073 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 18.70 ns | 0.027 ns | 0.021 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 19.61 ns | 0.048 ns | 0.042 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 34.18 ns | 0.087 ns | 0.072 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 35.23 ns | 0.446 ns | 0.417 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 36.59 ns | 0.131 ns | 0.116 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 36.41 ns | 0.053 ns | 0.045 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 33.69 ns | 0.051 ns | 0.046 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 32.32 ns | 0.178 ns | 0.149 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 27.76 ns | 0.072 ns | 0.064 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 26.97 ns | 0.354 ns | 0.314 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 20.20 ns | 0.033 ns | 0.029 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 20.91 ns | 0.005 ns | 0.004 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 38.53 ns | 0.081 ns | 0.072 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 39.48 ns | 0.077 ns | 0.068 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 40.30 ns | 0.044 ns | 0.039 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 41.15 ns | 0.081 ns | 0.072 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 35.93 ns | 0.267 ns | 0.250 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 36.66 ns | 0.081 ns | 0.076 ns | 0.0153 |      64 B |
