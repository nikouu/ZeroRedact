```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 12.845 ns | 0.0677 ns | 0.0528 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 13.468 ns | 0.2395 ns | 0.2123 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 13.779 ns | 0.1346 ns | 0.1193 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  9.934 ns | 0.1606 ns | 0.1424 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 13.652 ns | 0.1371 ns | 0.1145 ns |         - |
