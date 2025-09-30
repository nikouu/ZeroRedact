```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                         | PhoneNumberInput | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------- |----------------- |---------:|---------:|---------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 25.79 ns | 0.213 ns | 0.189 ns | 0.0115 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 27.19 ns | 0.234 ns | 0.195 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   | 17.91 ns | 0.072 ns | 0.064 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   | 19.97 ns | 0.077 ns | 0.072 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 32.27 ns | 0.102 ns | 0.080 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 34.03 ns | 0.156 ns | 0.146 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 30.07 ns | 0.125 ns | 0.117 ns | 0.0114 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 30.60 ns | 0.115 ns | 0.090 ns | 0.0114 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 27.96 ns | 0.138 ns | 0.129 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 28.43 ns | 0.110 ns | 0.091 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   | 20.54 ns | 0.076 ns | 0.063 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 21.56 ns | 0.029 ns | 0.024 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 39.14 ns | 0.154 ns | 0.128 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 40.55 ns | 0.190 ns | 0.177 ns | 0.0134 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 36.65 ns | 0.230 ns | 0.203 ns | 0.0134 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 35.63 ns | 0.153 ns | 0.128 ns | 0.0134 |      56 B |
