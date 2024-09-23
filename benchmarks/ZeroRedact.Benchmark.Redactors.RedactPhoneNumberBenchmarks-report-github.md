```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                       | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|----------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| MaskPhoneNumber_String       | 12:All           | 30.09 ns | 0.307 ns | 0.257 ns | 0.0114 |      48 B |
| MaskPhoneNumber_ReadOnlySpan | 12:All           | 28.47 ns | 0.328 ns | 0.291 ns | 0.0115 |      48 B |
| MaskPhoneNumber_String       | 12:FixedLength   | 19.60 ns | 0.227 ns | 0.202 ns |      - |         - |
| MaskPhoneNumber_ReadOnlySpan | 12:FixedLength   | 20.55 ns | 0.397 ns | 0.408 ns |      - |         - |
| MaskPhoneNumber_String       | 12:Full          | 35.21 ns | 0.653 ns | 0.611 ns | 0.0114 |      48 B |
| MaskPhoneNumber_ReadOnlySpan | 12:Full          | 35.09 ns | 0.312 ns | 0.244 ns | 0.0114 |      48 B |
| MaskPhoneNumber_String       | 12:ShowLastFour  | 37.24 ns | 0.498 ns | 0.466 ns | 0.0114 |      48 B |
| MaskPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 35.94 ns | 0.386 ns | 0.361 ns | 0.0114 |      48 B |
| MaskPhoneNumber_String       | 17:All           | 27.69 ns | 0.207 ns | 0.173 ns | 0.0134 |      56 B |
| MaskPhoneNumber_ReadOnlySpan | 17:All           | 28.91 ns | 0.519 ns | 0.460 ns | 0.0134 |      56 B |
| MaskPhoneNumber_String       | 17:FixedLength   | 19.52 ns | 0.117 ns | 0.109 ns |      - |         - |
| MaskPhoneNumber_ReadOnlySpan | 17:FixedLength   | 19.94 ns | 0.159 ns | 0.148 ns |      - |         - |
| MaskPhoneNumber_String       | 17:Full          | 41.30 ns | 0.518 ns | 0.485 ns | 0.0134 |      56 B |
| MaskPhoneNumber_ReadOnlySpan | 17:Full          | 40.98 ns | 0.823 ns | 0.809 ns | 0.0134 |      56 B |
| MaskPhoneNumber_String       | 17:ShowLastFour  | 46.07 ns | 0.571 ns | 0.506 ns | 0.0134 |      56 B |
| MaskPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 42.22 ns | 0.854 ns | 2.220 ns | 0.0134 |      56 B |
