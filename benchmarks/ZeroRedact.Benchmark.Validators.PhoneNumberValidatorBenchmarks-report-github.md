```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method              | phoneNumber       | Mean     | Error     | StdDev    | Allocated |
|-------------------- |------------------ |---------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 4.085 ns | 0.0803 ns | 0.0751 ns |         - |
| ValidatePhoneNumber | +15551234567      | 3.471 ns | 0.0362 ns | 0.0339 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 3.867 ns | 0.0771 ns | 0.0721 ns |         - |
| ValidatePhoneNumber | 15551234567       | 3.428 ns | 0.0668 ns | 0.0625 ns |         - |
