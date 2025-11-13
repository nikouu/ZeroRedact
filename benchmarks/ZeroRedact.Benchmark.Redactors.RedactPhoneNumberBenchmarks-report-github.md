```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 25.04 ns | 0.070 ns | 0.062 ns | 0.0115 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 26.01 ns | 0.100 ns | 0.094 ns | 0.0115 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 18.53 ns | 0.035 ns | 0.031 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 19.19 ns | 0.028 ns | 0.025 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 33.51 ns | 0.072 ns | 0.064 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 32.88 ns | 0.134 ns | 0.125 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 32.24 ns | 0.067 ns | 0.059 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 30.88 ns | 0.097 ns | 0.086 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 27.45 ns | 0.089 ns | 0.084 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 28.18 ns | 0.142 ns | 0.125 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 20.21 ns | 0.036 ns | 0.034 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 21.47 ns | 0.020 ns | 0.018 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 38.76 ns | 0.096 ns | 0.085 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 39.28 ns | 0.106 ns | 0.094 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 36.07 ns | 0.160 ns | 0.150 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 34.84 ns | 0.079 ns | 0.066 ns | 0.0134 |      56 B |
