```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 30.40 ns | 0.169 ns | 0.150 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 36.45 ns | 0.089 ns | 0.079 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 22.76 ns | 0.053 ns | 0.047 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 29.33 ns | 0.049 ns | 0.043 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 38.83 ns | 0.162 ns | 0.144 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 44.56 ns | 0.412 ns | 0.365 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 41.04 ns | 0.093 ns | 0.077 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 43.85 ns | 0.142 ns | 0.126 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 34.83 ns | 0.397 ns | 0.371 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 39.67 ns | 0.204 ns | 0.191 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 25.82 ns | 0.056 ns | 0.047 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 32.66 ns | 0.135 ns | 0.112 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 48.30 ns | 0.477 ns | 0.446 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 52.99 ns | 0.136 ns | 0.127 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 52.39 ns | 0.156 ns | 0.130 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 54.81 ns | 0.175 ns | 0.155 ns | 0.0134 |      56 B |
