```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method              | phoneNumber       | Mean     | Error     | StdDev    | Allocated |
|-------------------- |------------------ |---------:|----------:|----------:|----------:|
| ValidatePhoneNumber | +1 (555) 123-4567 | 7.874 ns | 0.0101 ns | 0.0095 ns |         - |
| ValidatePhoneNumber | +15551234567      | 5.644 ns | 0.0177 ns | 0.0148 ns |         - |
| ValidatePhoneNumber | +81-90-1234-5678  | 7.424 ns | 0.0104 ns | 0.0087 ns |         - |
| ValidatePhoneNumber | 15551234567       | 5.191 ns | 0.0430 ns | 0.0359 ns |         - |
