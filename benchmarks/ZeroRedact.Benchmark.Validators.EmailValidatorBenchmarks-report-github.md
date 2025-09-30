```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean     | Error    | StdDev   | Allocated |
|----------------------- |--------------------- |---------:|---------:|---------:|----------:|
| ValidateEmailAddresses | _______@example.com  | 18.95 ns | 0.090 ns | 0.080 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 18.87 ns | 0.068 ns | 0.057 ns |         - |
| ValidateEmailAddresses | @example.com         | 12.27 ns | 0.055 ns | 0.052 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 17.60 ns | 0.089 ns | 0.074 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 28.21 ns | 0.234 ns | 0.219 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 18.73 ns | 0.169 ns | 0.150 ns |         - |
| ValidateEmailAddresses | email@example        | 12.40 ns | 0.092 ns | 0.086 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 20.70 ns | 0.017 ns | 0.014 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 19.59 ns | 0.214 ns | 0.190 ns |         - |
| ValidateEmailAddresses | email@example.com    | 17.05 ns | 0.073 ns | 0.065 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 24.63 ns | 0.109 ns | 0.085 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 27.10 ns | 0.147 ns | 0.123 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 28.94 ns | 0.138 ns | 0.116 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 29.95 ns | 0.474 ns | 0.421 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 28.69 ns | 0.217 ns | 0.193 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 28.23 ns | 0.390 ns | 0.325 ns |         - |
| ValidateEmailAddresses | plainaddress         | 11.15 ns | 0.046 ns | 0.039 ns |         - |
