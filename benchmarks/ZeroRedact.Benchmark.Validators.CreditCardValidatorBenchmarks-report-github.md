```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 12.687 ns | 0.1269 ns | 0.1187 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 13.092 ns | 0.0546 ns | 0.0456 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 13.510 ns | 0.0467 ns | 0.0414 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  9.694 ns | 0.0578 ns | 0.0482 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 13.470 ns | 0.0856 ns | 0.0759 ns |         - |
