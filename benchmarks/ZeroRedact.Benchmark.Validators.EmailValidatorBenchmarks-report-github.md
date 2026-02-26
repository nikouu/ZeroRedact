```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
Intel Core Ultra 7 265KF 3.90GHz, 1 CPU, 20 logical and 20 physical cores
.NET SDK 10.0.200-preview.0.26103.119
  [Host]     : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3


```
| Method                 | emailAddress         | Mean     | Error     | StdDev    | Median   | Allocated |
|----------------------- |--------------------- |---------:|----------:|----------:|---------:|----------:|
| ValidateEmailAddresses | _______@example.com  | 6.156 ns | 0.1380 ns | 0.2659 ns | 5.992 ns |         - |
| ValidateEmailAddresses | .email@example.com   | 6.805 ns | 0.1523 ns | 0.4492 ns | 6.880 ns |         - |
| ValidateEmailAddresses | @example.com         | 4.607 ns | 0.1065 ns | 0.1268 ns | 4.637 ns |         - |
| ValidateEmailAddresses | #@%^%#$@#$@#.com     | 7.123 ns | 0.1561 ns | 0.3556 ns | 7.131 ns |         - |
| ValidateEmailAddresses | email(...)e.com [24] | 2.887 ns | 0.0726 ns | 0.1609 ns | 2.969 ns |         - |
| ValidateEmailAddresses | email.@example.com   | 7.575 ns | 0.1083 ns | 0.1013 ns | 7.600 ns |         - |
| ValidateEmailAddresses | email@example        | 4.182 ns | 0.0987 ns | 0.2167 ns | 4.304 ns |         - |
| ValidateEmailAddresses | email(...)e.com [21] | 7.808 ns | 0.0600 ns | 0.0561 ns | 7.808 ns |         - |
| ValidateEmailAddresses | email@example.co.jp  | 7.791 ns | 0.1684 ns | 0.2469 ns | 7.805 ns |         - |
| ValidateEmailAddresses | email@example.com    | 6.226 ns | 0.1393 ns | 0.3255 ns | 6.025 ns |         - |
| ValidateEmailAddresses | email(...)e.com [25] | 9.120 ns | 0.0145 ns | 0.0121 ns | 9.119 ns |         - |
| ValidateEmailAddresses | email(...)e.com [27] | 8.741 ns | 0.1883 ns | 0.2819 ns | 8.751 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 8.501 ns | 0.1834 ns | 0.2856 ns | 8.330 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 9.286 ns | 0.1171 ns | 0.1038 ns | 9.300 ns |         - |
| ValidateEmailAddresses | first(...)e.com [30] | 8.325 ns | 0.0245 ns | 0.0229 ns | 8.336 ns |         - |
| ValidateEmailAddresses | Joe S(...).com&gt; [29] | 8.782 ns | 0.1871 ns | 0.2498 ns | 8.633 ns |         - |
| ValidateEmailAddresses | plainaddress         | 3.725 ns | 0.0061 ns | 0.0054 ns | 3.726 ns |         - |
