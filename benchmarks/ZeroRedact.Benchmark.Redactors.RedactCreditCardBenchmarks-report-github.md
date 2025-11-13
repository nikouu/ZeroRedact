```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 25.20 ns | 0.206 ns | 0.192 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 25.68 ns | 0.105 ns | 0.098 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 18.81 ns | 0.093 ns | 0.087 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 19.75 ns | 0.217 ns | 0.203 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 36.67 ns | 0.354 ns | 0.332 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 35.37 ns | 0.114 ns | 0.095 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 37.22 ns | 0.287 ns | 0.255 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 37.85 ns | 0.134 ns | 0.112 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 33.41 ns | 0.107 ns | 0.100 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 34.37 ns | 0.196 ns | 0.174 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 26.86 ns | 0.190 ns | 0.169 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 27.51 ns | 0.105 ns | 0.093 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 20.18 ns | 0.094 ns | 0.088 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 21.56 ns | 0.118 ns | 0.098 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 39.53 ns | 0.249 ns | 0.233 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 41.70 ns | 0.185 ns | 0.173 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 41.81 ns | 0.315 ns | 0.263 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 42.51 ns | 0.254 ns | 0.238 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 36.46 ns | 0.141 ns | 0.110 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 37.16 ns | 0.140 ns | 0.124 ns | 0.0153 |      64 B |
