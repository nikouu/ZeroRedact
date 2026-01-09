```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 21.34 ns | 0.166 ns | 0.155 ns | 0.0115 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 23.54 ns | 0.212 ns | 0.198 ns | 0.0115 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 12.77 ns | 0.018 ns | 0.015 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 17.48 ns | 0.064 ns | 0.057 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 29.89 ns | 0.111 ns | 0.093 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 30.27 ns | 0.105 ns | 0.082 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 26.51 ns | 0.443 ns | 0.606 ns | 0.0115 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 29.16 ns | 0.608 ns | 0.650 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 21.93 ns | 0.164 ns | 0.153 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 25.41 ns | 0.143 ns | 0.127 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 16.95 ns | 0.364 ns | 0.341 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 19.31 ns | 0.150 ns | 0.133 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 36.57 ns | 0.191 ns | 0.149 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 37.48 ns | 0.174 ns | 0.146 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 32.85 ns | 0.168 ns | 0.158 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 34.00 ns | 0.196 ns | 0.174 ns | 0.0134 |      56 B |
