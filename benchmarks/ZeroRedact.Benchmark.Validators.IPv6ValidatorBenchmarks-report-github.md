```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                | ipAddress            | Mean     | Error     | StdDev    | Allocated |
|---------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateIPv6Addresses | ::1                  | 2.070 ns | 0.0190 ns | 0.0178 ns |         - |
| ValidateIPv6Addresses | 2001:(...):7334 [39] | 1.711 ns | 0.0059 ns | 0.0049 ns |         - |
| ValidateIPv6Addresses | 2001:db8::2:1        | 1.236 ns | 0.0393 ns | 0.0368 ns |         - |
| ValidateIPv6Addresses | fe80:(...):890a [24] | 1.319 ns | 0.0035 ns | 0.0031 ns |         - |
