```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method              | macAddress        | Mean     | Error     | StdDev    | Allocated |
|-------------------- |------------------ |---------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 7.956 ns | 0.0364 ns | 0.0340 ns |         - |
| ValidatePhoneNumber | +15551234567      | 5.670 ns | 0.0185 ns | 0.0154 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 7.488 ns | 0.0273 ns | 0.0242 ns |         - |
| ValidatePhoneNumber | 15551234567       | 5.218 ns | 0.0307 ns | 0.0287 ns |         - |
