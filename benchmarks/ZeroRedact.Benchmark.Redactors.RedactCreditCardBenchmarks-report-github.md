```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 27.75 ns | 0.225 ns | 0.176 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 31.99 ns | 0.056 ns | 0.049 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 19.83 ns | 0.121 ns | 0.107 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 25.93 ns | 0.085 ns | 0.079 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 40.19 ns | 0.377 ns | 0.334 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 42.36 ns | 0.143 ns | 0.134 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 42.07 ns | 0.131 ns | 0.109 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 46.55 ns | 0.166 ns | 0.155 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 41.28 ns | 0.167 ns | 0.156 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 42.48 ns | 0.196 ns | 0.183 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 29.42 ns | 0.116 ns | 0.103 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 34.21 ns | 0.111 ns | 0.098 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 21.84 ns | 0.111 ns | 0.093 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 27.70 ns | 0.054 ns | 0.051 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 42.89 ns | 0.325 ns | 0.288 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 46.60 ns | 0.214 ns | 0.200 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 46.38 ns | 0.215 ns | 0.191 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 50.80 ns | 0.242 ns | 0.215 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 42.90 ns | 0.170 ns | 0.151 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 47.50 ns | 0.152 ns | 0.142 ns | 0.0153 |      64 B |
