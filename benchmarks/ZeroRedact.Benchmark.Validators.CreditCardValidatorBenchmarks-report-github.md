```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                    | creditCardNumber    | Mean     | Error     | StdDev    | Allocated |
|-------------------------- |-------------------- |---------:|----------:|----------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 8.180 ns | 0.0221 ns | 0.0196 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 8.342 ns | 0.0969 ns | 0.0906 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 8.744 ns | 0.0698 ns | 0.0653 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    | 7.472 ns | 0.0583 ns | 0.0517 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 9.304 ns | 0.0396 ns | 0.0351 ns |         - |
