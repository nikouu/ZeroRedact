```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method              | phoneNumber       | Mean     | Error     | StdDev    | Allocated |
|-------------------- |------------------ |---------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 7.947 ns | 0.0687 ns | 0.0574 ns |         - |
| ValidatePhoneNumber | +15551234567      | 5.674 ns | 0.0358 ns | 0.0318 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 7.482 ns | 0.0541 ns | 0.0506 ns |         - |
| ValidatePhoneNumber | 15551234567       | 5.183 ns | 0.0182 ns | 0.0152 ns |         - |
