```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method               | macAddress           | Mean     | Error     | StdDev    | Allocated |
|--------------------- |--------------------- |---------:|----------:|----------:|----------:|
| ValidateMacAddresses | 00-1A-2B-3C-4D-5E    | 1.211 ns | 0.0393 ns | 0.0452 ns |         - |
| ValidateMacAddresses | 00-1A(...)6F-70 [23] | 1.394 ns | 0.0399 ns | 0.0374 ns |         - |
| ValidateMacAddresses | 00:1A:2B:3C:4D:5E    | 1.226 ns | 0.0354 ns | 0.0332 ns |         - |
| ValidateMacAddresses | 00:1A(...)6F:70 [23] | 1.154 ns | 0.0035 ns | 0.0031 ns |         - |
