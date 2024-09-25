```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  8.837 ns | 0.0752 ns | 0.0666 ns |         - |
| ValidateEmailAddresses | .email@example.com   |  8.333 ns | 0.0376 ns | 0.0293 ns |         - |
| ValidateEmailAddresses | @example.com         |  9.460 ns | 0.0905 ns | 0.0847 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     |  7.664 ns | 0.0543 ns | 0.0453 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 10.687 ns | 0.1115 ns | 0.1043 ns |         - |
| ValidateEmailAddresses | email.@example.com   |  8.366 ns | 0.0576 ns | 0.0481 ns |         - |
| ValidateEmailAddresses | email@example        |  7.472 ns | 0.1062 ns | 0.0941 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] |  9.623 ns | 0.1194 ns | 0.1117 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  |  8.885 ns | 0.1406 ns | 0.1315 ns |         - |
| ValidateEmailAddresses | email@example.com    |  7.875 ns | 0.0407 ns | 0.0361 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] |  8.058 ns | 0.0553 ns | 0.0490 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] |  8.517 ns | 0.0669 ns | 0.0558 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.232 ns | 0.0911 ns | 0.0852 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.224 ns | 0.0713 ns | 0.0667 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.254 ns | 0.1275 ns | 0.1192 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] |  8.217 ns | 0.0525 ns | 0.0438 ns |         - |
| ValidateEmailAddresses | plainaddress         |  4.261 ns | 0.0432 ns | 0.0405 ns |         - |
