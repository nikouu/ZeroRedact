```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 10.820 ns | 0.0301 ns | 0.0282 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 10.358 ns | 0.0139 ns | 0.0130 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 10.682 ns | 0.0261 ns | 0.0245 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  5.492 ns | 0.0196 ns | 0.0164 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 |  8.539 ns | 0.0250 ns | 0.0208 ns |         - |
