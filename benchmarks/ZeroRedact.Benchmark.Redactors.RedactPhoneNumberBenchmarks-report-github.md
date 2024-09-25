```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 28.01 ns | 0.162 ns | 0.143 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 28.83 ns | 0.190 ns | 0.168 ns | 0.0115 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 20.26 ns | 0.163 ns | 0.152 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 20.11 ns | 0.078 ns | 0.070 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 34.02 ns | 0.222 ns | 0.197 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 33.76 ns | 0.292 ns | 0.273 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 35.18 ns | 0.311 ns | 0.275 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 34.82 ns | 0.184 ns | 0.153 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 27.73 ns | 0.157 ns | 0.131 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 26.79 ns | 0.161 ns | 0.143 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 19.35 ns | 0.109 ns | 0.102 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 19.68 ns | 0.115 ns | 0.102 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 40.46 ns | 0.335 ns | 0.261 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 39.30 ns | 0.358 ns | 0.335 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 40.00 ns | 0.369 ns | 0.327 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 38.68 ns | 0.414 ns | 0.387 ns | 0.0134 |      56 B |
