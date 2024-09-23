```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Median    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  8.818 ns | 0.0793 ns | 0.0703 ns |  8.823 ns |         - |
| ValidateEmailAddresses | .email@example.com   |  8.575 ns | 0.1554 ns | 0.1596 ns |  8.528 ns |         - |
| ValidateEmailAddresses | @example.com         |  9.588 ns | 0.1283 ns | 0.1138 ns |  9.535 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     |  7.798 ns | 0.0874 ns | 0.0774 ns |  7.803 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 10.892 ns | 0.2121 ns | 0.1771 ns | 10.836 ns |         - |
| ValidateEmailAddresses | email.@example.com   |  8.522 ns | 0.1101 ns | 0.0920 ns |  8.476 ns |         - |
| ValidateEmailAddresses | email@example        |  7.609 ns | 0.1058 ns | 0.0990 ns |  7.552 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] |  9.782 ns | 0.1653 ns | 0.1380 ns |  9.741 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  |  8.958 ns | 0.0716 ns | 0.0598 ns |  8.931 ns |         - |
| ValidateEmailAddresses | email@example.com    |  8.069 ns | 0.1018 ns | 0.0952 ns |  8.055 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] |  8.296 ns | 0.1398 ns | 0.1239 ns |  8.231 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] |  9.010 ns | 0.2076 ns | 0.4099 ns |  8.822 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.403 ns | 0.0928 ns | 0.0823 ns |  8.410 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.401 ns | 0.1052 ns | 0.0932 ns |  8.368 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.372 ns | 0.0835 ns | 0.0697 ns |  8.371 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] |  8.398 ns | 0.1452 ns | 0.1212 ns |  8.353 ns |         - |
| ValidateEmailAddresses | plainaddress         |  4.369 ns | 0.0796 ns | 0.0744 ns |  4.356 ns |         - |
