```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.52411), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  | 10.005 ns | 0.0984 ns | 0.0921 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 11.457 ns | 0.0216 ns | 0.0202 ns |         - |
| ValidateEmailAddresses | @example.com         |  7.275 ns | 0.0122 ns | 0.0114 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 11.161 ns | 0.0201 ns | 0.0167 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] |  3.516 ns | 0.0056 ns | 0.0050 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 10.752 ns | 0.0161 ns | 0.0151 ns |         - |
| ValidateEmailAddresses | email@example        |  6.524 ns | 0.0108 ns | 0.0084 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 10.822 ns | 0.0353 ns | 0.0313 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 11.117 ns | 0.0122 ns | 0.0109 ns |         - |
| ValidateEmailAddresses | email@example.com    |  9.149 ns | 0.0141 ns | 0.0125 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 12.768 ns | 0.0283 ns | 0.0251 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 13.701 ns | 0.0392 ns | 0.0367 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.735 ns | 0.0255 ns | 0.0213 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.881 ns | 0.0290 ns | 0.0271 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.762 ns | 0.0379 ns | 0.0354 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 14.327 ns | 0.0385 ns | 0.0360 ns |         - |
| ValidateEmailAddresses | plainaddress         |  5.822 ns | 0.0187 ns | 0.0166 ns |         - |
