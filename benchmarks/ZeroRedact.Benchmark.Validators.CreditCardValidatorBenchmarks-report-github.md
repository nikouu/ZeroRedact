```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                    | creditCardNumber    | Mean     | Error     | StdDev    | Median   | Allocated |
|-------------------------- |-------------------- |---------:|----------:|----------:|---------:|----------:|
| ValidateCreditCardNumbers | 3000 0000 0000 04   | 6.178 ns | 0.1347 ns | 0.1603 ns | 6.107 ns |         - |
| ValidateCreditCardNumbers | 3400 0000 0000 009  | 6.776 ns | 0.0108 ns | 0.0091 ns | 6.774 ns |         - |
| ValidateCreditCardNumbers | 4111 1111 1111 1111 | 7.472 ns | 0.1626 ns | 0.2847 ns | 7.670 ns |         - |
| ValidateCreditCardNumbers | 4111111111111111    | 3.688 ns | 0.0061 ns | 0.0047 ns | 3.688 ns |         - |
| ValidateCreditCardNumbers | 5500-0000-0000-0004 | 7.140 ns | 0.1577 ns | 0.2883 ns | 7.058 ns |         - |
