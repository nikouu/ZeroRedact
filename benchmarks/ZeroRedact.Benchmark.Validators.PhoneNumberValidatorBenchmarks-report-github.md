```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method              | macAddress        | Mean      | Error     | StdDev    | Allocated |
|-------------------- |------------------ |----------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 13.022 ns | 0.0476 ns | 0.0422 ns |         - |
| ValidatePhoneNumber | +15551234567      |  9.745 ns | 0.0357 ns | 0.0334 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 12.458 ns | 0.0662 ns | 0.0553 ns |         - |
| ValidatePhoneNumber | 15551234567       |  8.985 ns | 0.0367 ns | 0.0343 ns |         - |
