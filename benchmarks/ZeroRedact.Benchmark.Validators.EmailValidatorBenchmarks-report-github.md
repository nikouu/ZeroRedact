```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.6691/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.1 (10.0.125.57005), X64 RyuJIT AVX2


```
| Method                 | emailAddress         | Mean      | Error     | StdDev    | Allocated |
|----------------------- |--------------------- |----------:|----------:|----------:|----------:|
| ValidateEmailAddresses | _______@example.com  | 12.547 ns | 0.1858 ns | 0.1552 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 12.522 ns | 0.1943 ns | 0.1817 ns |         - |
| ValidateEmailAddresses | @example.com         |  6.468 ns | 0.1048 ns | 0.0980 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 12.010 ns | 0.0688 ns | 0.0574 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 11.757 ns | 0.1034 ns | 0.0967 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 12.392 ns | 0.0715 ns | 0.0669 ns |         - |
| ValidateEmailAddresses | email@example        |  5.798 ns | 0.0344 ns | 0.0322 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 13.437 ns | 0.0752 ns | 0.0667 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 12.422 ns | 0.0679 ns | 0.0635 ns |         - |
| ValidateEmailAddresses | email@example.com    | 11.523 ns | 0.0518 ns | 0.0484 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 12.430 ns | 0.0646 ns | 0.0605 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 12.917 ns | 0.0777 ns | 0.0688 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 12.412 ns | 0.0554 ns | 0.0433 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 12.476 ns | 0.1126 ns | 0.0941 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 12.356 ns | 0.0495 ns | 0.0439 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 12.484 ns | 0.0575 ns | 0.0538 ns |         - |
| ValidateEmailAddresses | plainaddress         |  1.914 ns | 0.0180 ns | 0.0168 ns |         - |
