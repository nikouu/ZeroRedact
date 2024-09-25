```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean      | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |----------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 12.587 ns | 0.0178 ns | 0.0139 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 13.129 ns | 0.0638 ns | 0.0533 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 13.552 ns | 0.0728 ns | 0.0645 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    |  9.726 ns | 0.0912 ns | 0.0853 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 13.459 ns | 0.1117 ns | 0.1045 ns |         - |
