```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   |  9.651 ns | 0.0471 ns | 0.0441 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 11.585 ns | 0.0288 ns | 0.0255 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 10.706 ns | 0.0391 ns | 0.0366 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  5.530 ns | 0.0221 ns | 0.0196 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 |  8.630 ns | 0.0511 ns | 0.0453 ns |         - |
