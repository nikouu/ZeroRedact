```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6093/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.301
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  8.623 ns | 0.0394 ns | 0.0329 ns |         - |
| ValidateEmailAddresses | .email@example.com   |  8.395 ns | 0.1249 ns | 0.1107 ns |         - |
| ValidateEmailAddresses | @example.com         |  9.464 ns | 0.0270 ns | 0.0239 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     |  7.614 ns | 0.0252 ns | 0.0223 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 10.579 ns | 0.0474 ns | 0.0443 ns |         - |
| ValidateEmailAddresses | email.@example.com   |  8.291 ns | 0.0154 ns | 0.0129 ns |         - |
| ValidateEmailAddresses | email@example        |  7.383 ns | 0.0254 ns | 0.0212 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] |  9.494 ns | 0.0124 ns | 0.0103 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  |  8.755 ns | 0.0282 ns | 0.0235 ns |         - |
| ValidateEmailAddresses | email@example.com    |  7.872 ns | 0.0250 ns | 0.0233 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] |  8.022 ns | 0.0373 ns | 0.0330 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] |  8.498 ns | 0.0460 ns | 0.0431 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.120 ns | 0.0231 ns | 0.0193 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.160 ns | 0.0462 ns | 0.0433 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] |  8.123 ns | 0.0188 ns | 0.0166 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] |  8.115 ns | 0.0123 ns | 0.0096 ns |         - |
| ValidateEmailAddresses | plainaddress         |  4.228 ns | 0.0211 ns | 0.0198 ns |         - |
