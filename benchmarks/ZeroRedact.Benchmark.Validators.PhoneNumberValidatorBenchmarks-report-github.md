```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method              | macAddress        | Mean      | Error     | StdDev    | Allocated |
|-------------------- |------------------ |----------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 13.024 ns | 0.0474 ns | 0.0396 ns |         - |
| ValidatePhoneNumber | +15551234567      |  9.781 ns | 0.0588 ns | 0.0550 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 12.447 ns | 0.0549 ns | 0.0487 ns |         - |
| ValidatePhoneNumber | 15551234567       |  9.039 ns | 0.0829 ns | 0.0775 ns |         - |
