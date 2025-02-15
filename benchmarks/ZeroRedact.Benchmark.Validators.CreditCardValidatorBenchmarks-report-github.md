```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 12.587 ns | 0.0188 ns | 0.0147 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 13.051 ns | 0.0182 ns | 0.0170 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 13.511 ns | 0.0265 ns | 0.0221 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  9.686 ns | 0.0513 ns | 0.0454 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 13.371 ns | 0.0384 ns | 0.0359 ns |         - |
