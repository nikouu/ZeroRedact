```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5371/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  8.780 ns | 0.0324 ns | 0.0303 ns |         - |
| ValidateEmailAddresses | .email@example.com   |  8.462 ns | 0.1969 ns | 0.1841 ns |         - |
| ValidateEmailAddresses | @example.com         |  9.388 ns | 0.0232 ns | 0.0206 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     |  7.630 ns | 0.0216 ns | 0.0202 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 10.591 ns | 0.0277 ns | 0.0246 ns |         - |
| ValidateEmailAddresses | email.@example.com   |  8.325 ns | 0.0242 ns | 0.0215 ns |         - |
| ValidateEmailAddresses | email@example        |  7.392 ns | 0.0208 ns | 0.0162 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] |  9.554 ns | 0.0445 ns | 0.0395 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  |  8.618 ns | 0.0270 ns | 0.0225 ns |         - |
| ValidateEmailAddresses | email@example.com    |  7.834 ns | 0.0212 ns | 0.0188 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] |  8.016 ns | 0.0179 ns | 0.0159 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] |  8.491 ns | 0.0363 ns | 0.0303 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.181 ns | 0.0436 ns | 0.0387 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.159 ns | 0.0184 ns | 0.0163 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.167 ns | 0.0369 ns | 0.0327 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] |  8.164 ns | 0.0288 ns | 0.0255 ns |         - |
| ValidateEmailAddresses | plainaddress         |  4.247 ns | 0.0125 ns | 0.0104 ns |         - |
