```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4894/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method               | macAddress        | Mean      | Error     | StdDev    | Allocated |
|--------------------- |------------------ |----------:|----------:|----------:|----------:|
| ValidateMacAddresses | +1 (555) 123-4567 | 13.919 ns | 0.3050 ns | 0.4566 ns |         - |
| ValidateMacAddresses | +15551234567      | 10.466 ns | 0.2375 ns | 0.3554 ns |         - |
| ValidateMacAddresses | +81-90-1234-5678  | 13.149 ns | 0.2685 ns | 0.2380 ns |         - |
| ValidateMacAddresses | 15551234567       |  9.507 ns | 0.1879 ns | 0.2088 ns |         - |
