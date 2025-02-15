```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 35.98 ns | 0.487 ns | 0.455 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 35.75 ns | 0.135 ns | 0.119 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 28.18 ns | 0.136 ns | 0.127 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 30.70 ns | 0.111 ns | 0.093 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 47.22 ns | 0.166 ns | 0.155 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 46.48 ns | 0.456 ns | 0.426 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 47.19 ns | 0.209 ns | 0.196 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 47.49 ns | 0.159 ns | 0.149 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 45.02 ns | 0.245 ns | 0.191 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 44.72 ns | 0.136 ns | 0.114 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 37.38 ns | 0.173 ns | 0.144 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 37.09 ns | 0.174 ns | 0.154 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 30.30 ns | 0.096 ns | 0.085 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 29.76 ns | 0.039 ns | 0.033 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 50.63 ns | 0.332 ns | 0.295 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 50.46 ns | 0.392 ns | 0.367 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 54.92 ns | 0.179 ns | 0.168 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 53.66 ns | 0.337 ns | 0.282 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 50.14 ns | 0.169 ns | 0.141 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 50.17 ns | 0.766 ns | 0.717 ns | 0.0153 |      64 B |
