```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  8.907 ns | 0.0694 ns | 0.0542 ns |         - |
| ValidateEmailAddresses | .email@example.com   |  8.451 ns | 0.0239 ns | 0.0199 ns |         - |
| ValidateEmailAddresses | @example.com         |  9.396 ns | 0.0218 ns | 0.0182 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     |  7.796 ns | 0.0271 ns | 0.0227 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 10.714 ns | 0.0747 ns | 0.0624 ns |         - |
| ValidateEmailAddresses | email.@example.com   |  8.460 ns | 0.0216 ns | 0.0202 ns |         - |
| ValidateEmailAddresses | email@example        |  7.408 ns | 0.0294 ns | 0.0245 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] |  9.353 ns | 0.0357 ns | 0.0334 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  |  8.877 ns | 0.0174 ns | 0.0154 ns |         - |
| ValidateEmailAddresses | email@example.com    |  7.906 ns | 0.0762 ns | 0.0676 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] |  8.046 ns | 0.0442 ns | 0.0369 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] |  8.524 ns | 0.0530 ns | 0.0442 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.173 ns | 0.0237 ns | 0.0185 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.160 ns | 0.0121 ns | 0.0108 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.170 ns | 0.0284 ns | 0.0237 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] |  8.170 ns | 0.0261 ns | 0.0232 ns |         - |
| ValidateEmailAddresses | plainaddress         |  4.254 ns | 0.0166 ns | 0.0147 ns |         - |
