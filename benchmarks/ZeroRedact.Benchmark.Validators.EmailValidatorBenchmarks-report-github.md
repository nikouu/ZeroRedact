```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6332/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-rc.1.25451.107
  [Host]     : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.0 (10.0.25.45207), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  |  9.982 ns | 0.0536 ns | 0.0448 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 11.535 ns | 0.0583 ns | 0.0545 ns |         - |
| ValidateEmailAddresses | @example.com         |  7.335 ns | 0.0295 ns | 0.0261 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 11.245 ns | 0.0485 ns | 0.0430 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] |  3.528 ns | 0.0190 ns | 0.0158 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 10.807 ns | 0.0330 ns | 0.0292 ns |         - |
| ValidateEmailAddresses | email@example        |  6.556 ns | 0.0305 ns | 0.0270 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 10.900 ns | 0.0479 ns | 0.0400 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 11.171 ns | 0.0361 ns | 0.0338 ns |         - |
| ValidateEmailAddresses | email@example.com    |  9.189 ns | 0.0298 ns | 0.0264 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 14.602 ns | 0.0764 ns | 0.0677 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 13.783 ns | 0.0403 ns | 0.0337 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.821 ns | 0.0492 ns | 0.0436 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 15.085 ns | 0.0400 ns | 0.0334 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.862 ns | 0.0944 ns | 0.0837 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 14.405 ns | 0.0572 ns | 0.0507 ns |         - |
| ValidateEmailAddresses | plainaddress         |  5.869 ns | 0.0255 ns | 0.0239 ns |         - |
