```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                        | CreditCardInput      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |--------------------- |---------:|---------:|---------:|-------:|----------:|
| RedactCreditCard_String       | 16:All               | 30.56 ns | 0.232 ns | 0.205 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:All               | 34.59 ns | 0.160 ns | 0.125 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:FixedLength       | 23.30 ns | 0.121 ns | 0.094 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 16:FixedLength       | 28.75 ns | 0.030 ns | 0.024 ns |      - |         - |
| RedactCreditCard_String       | 16:Full              | 41.66 ns | 0.179 ns | 0.168 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Full              | 44.91 ns | 0.134 ns | 0.112 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:Sh(...)tFour [23] | 42.56 ns | 0.189 ns | 0.168 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:Sh(...)tFour [23] | 46.92 ns | 0.216 ns | 0.203 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 16:ShowLastFour      | 40.59 ns | 0.123 ns | 0.109 ns | 0.0134 |      56 B |
| RedactCreditCard_ReadOnlySpan | 16:ShowLastFour      | 44.87 ns | 0.301 ns | 0.282 ns | 0.0134 |      56 B |
| RedactCreditCard_String       | 19:All               | 32.20 ns | 0.159 ns | 0.141 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:All               | 38.48 ns | 0.123 ns | 0.109 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:FixedLength       | 24.81 ns | 0.069 ns | 0.054 ns |      - |         - |
| RedactCreditCard_ReadOnlySpan | 19:FixedLength       | 29.73 ns | 0.106 ns | 0.099 ns |      - |         - |
| RedactCreditCard_String       | 19:Full              | 47.88 ns | 0.377 ns | 0.294 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Full              | 50.64 ns | 0.399 ns | 0.374 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:Sh(...)tFour [23] | 48.27 ns | 0.154 ns | 0.137 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:Sh(...)tFour [23] | 54.09 ns | 0.182 ns | 0.161 ns | 0.0153 |      64 B |
| RedactCreditCard_String       | 19:ShowLastFour      | 47.02 ns | 0.221 ns | 0.196 ns | 0.0153 |      64 B |
| RedactCreditCard_ReadOnlySpan | 19:ShowLastFour      | 50.66 ns | 0.218 ns | 0.182 ns | 0.0153 |      64 B |
