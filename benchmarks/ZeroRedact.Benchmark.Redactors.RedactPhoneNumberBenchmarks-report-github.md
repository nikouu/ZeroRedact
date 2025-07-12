```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 27.37 ns | 0.064 ns | 0.050 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 34.01 ns | 0.096 ns | 0.085 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 21.72 ns | 0.067 ns | 0.059 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 24.48 ns | 0.064 ns | 0.060 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 34.83 ns | 0.118 ns | 0.110 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 39.72 ns | 0.199 ns | 0.187 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 40.10 ns | 0.094 ns | 0.078 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 40.54 ns | 0.601 ns | 0.502 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 31.82 ns | 0.694 ns | 0.799 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 35.33 ns | 0.461 ns | 0.431 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 25.44 ns | 0.189 ns | 0.168 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 27.79 ns | 0.249 ns | 0.221 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 45.65 ns | 0.359 ns | 0.318 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 49.40 ns | 0.522 ns | 0.488 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 46.95 ns | 0.183 ns | 0.162 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 48.99 ns | 0.335 ns | 0.297 ns | 0.0134 |      56 B |
