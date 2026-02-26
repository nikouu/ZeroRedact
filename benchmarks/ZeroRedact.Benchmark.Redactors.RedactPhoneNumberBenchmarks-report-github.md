```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                         | PhoneNumberInput | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|------------------------------- |----------------- |----------:|----------:|----------:|----------:|-------:|----------:|
| RedactPhoneNumber_String       | 12:All           | 12.160 ns | 0.0236 ns | 0.0221 ns | 12.156 ns | 0.0031 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:All           | 13.119 ns | 0.0441 ns | 0.0391 ns | 13.122 ns | 0.0031 |      48 B |
| RedactPhoneNumber_String       | 12:FixedLength   |  9.435 ns | 0.2174 ns | 0.3254 ns |  9.677 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 12:FixedLength   |  9.821 ns | 0.0396 ns | 0.0389 ns |  9.833 ns |      - |         - |
| RedactPhoneNumber_String       | 12:Full          | 14.527 ns | 0.1502 ns | 0.1405 ns | 14.577 ns | 0.0030 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:Full          | 14.887 ns | 0.3091 ns | 0.5078 ns | 14.591 ns | 0.0030 |      48 B |
| RedactPhoneNumber_String       | 12:ShowLastFour  | 14.400 ns | 0.0744 ns | 0.0621 ns | 14.396 ns | 0.0030 |      48 B |
| RedactPhoneNumber_ReadOnlySpan | 12:ShowLastFour  | 14.942 ns | 0.3101 ns | 0.5008 ns | 14.734 ns | 0.0030 |      48 B |
| RedactPhoneNumber_String       | 17:All           | 12.848 ns | 0.0319 ns | 0.0298 ns | 12.849 ns | 0.0036 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:All           | 13.971 ns | 0.2916 ns | 0.4709 ns | 13.697 ns | 0.0036 |      56 B |
| RedactPhoneNumber_String       | 17:FixedLength   |  9.396 ns | 0.0184 ns | 0.0163 ns |  9.391 ns |      - |         - |
| RedactPhoneNumber_ReadOnlySpan | 17:FixedLength   | 10.389 ns | 0.0201 ns | 0.0168 ns | 10.391 ns |      - |         - |
| RedactPhoneNumber_String       | 17:Full          | 17.945 ns | 0.0579 ns | 0.0452 ns | 17.957 ns | 0.0035 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:Full          | 19.699 ns | 0.4058 ns | 0.6891 ns | 20.120 ns | 0.0035 |      56 B |
| RedactPhoneNumber_String       | 17:ShowLastFour  | 15.581 ns | 0.1044 ns | 0.0872 ns | 15.566 ns | 0.0035 |      56 B |
| RedactPhoneNumber_ReadOnlySpan | 17:ShowLastFour  | 16.030 ns | 0.0484 ns | 0.0429 ns | 16.032 ns | 0.0035 |      56 B |
