```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  | 10.018 ns | 0.0580 ns | 0.0514 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 11.504 ns | 0.0588 ns | 0.0522 ns |         - |
| ValidateEmailAddresses | @example.com         |  7.289 ns | 0.0161 ns | 0.0135 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 11.172 ns | 0.0205 ns | 0.0171 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] |  3.529 ns | 0.0157 ns | 0.0147 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 10.782 ns | 0.0270 ns | 0.0226 ns |         - |
| ValidateEmailAddresses | email@example        |  6.535 ns | 0.0336 ns | 0.0314 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 10.847 ns | 0.0530 ns | 0.0470 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 11.190 ns | 0.0999 ns | 0.0834 ns |         - |
| ValidateEmailAddresses | email@example.com    |  9.207 ns | 0.0804 ns | 0.0713 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 14.565 ns | 0.0883 ns | 0.0783 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 13.791 ns | 0.0893 ns | 0.0835 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.783 ns | 0.0497 ns | 0.0415 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.920 ns | 0.0416 ns | 0.0348 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 14.833 ns | 0.0940 ns | 0.0880 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 14.415 ns | 0.0868 ns | 0.0812 ns |         - |
| ValidateEmailAddresses | plainaddress         |  5.834 ns | 0.0251 ns | 0.0223 ns |         - |
