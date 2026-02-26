```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                | ipAddress   | Mean     | Error     | StdDev    | Allocated |
|---------------------- |------------ |---------:|----------:|----------:|----------:|
| ValidateIPv4Addresses | 10.0.0.1    | 1.125 ns | 0.0034 ns | 0.0027 ns |         - |
| ValidateIPv4Addresses | 192.168.1.1 | 1.122 ns | 0.0048 ns | 0.0053 ns |         - |
| ValidateIPv4Addresses | 8.8.8.8     | 4.520 ns | 0.1069 ns | 0.3151 ns |         - |
