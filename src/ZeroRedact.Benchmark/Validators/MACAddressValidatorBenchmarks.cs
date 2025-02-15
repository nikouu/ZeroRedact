using BenchmarkDotNet.Attributes;
using ZeroRedact.Validators;


namespace ZeroRedact.Benchmark.Validators
{
    [MemoryDiagnoser]
    public class MACAddressValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("00:1A:2B:3C:4D:5E")]
        [Arguments("00-1A-2B-3C-4D-5E")]
        [Arguments("00:1A:2B:3C:4D:5E:6F:70")]
        [Arguments("00-1A-2B-3C-4D-5E-6F-70")]
        public static bool ValidateMacAddresses(string macAddress)
        {
            return MACAddressValidator.IsValidForRedaction(macAddress.AsSpan());
        }
    }
}