using BenchmarkDotNet.Attributes;
using ZeroRedact.Validators;

namespace ZeroRedact.Benchmark.Validators
{
    [MemoryDiagnoser]
    public class IPv6ValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("2001:0db8:85a3:0000:0000:8a2e:0370:7334")]
        [Arguments("fe80::1ff:fe23:4567:890a")]
        [Arguments("::1")]
        [Arguments("2001:db8::2:1")]
        public static bool ValidateIPv6Addresses(string ipAddress)
        {
            return IPv6Validator.IsValidForRedaction(ipAddress.AsSpan());
        }
    }
}

