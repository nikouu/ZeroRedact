using BenchmarkDotNet.Attributes;
using ZeroRedact.Validators;

namespace ZeroRedact.Benchmark.Validators
{
    [MemoryDiagnoser]
    public class PhoneNumberValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("15551234567")]
        [Arguments("+15551234567")]
        [Arguments("+1 (555) 123-4567")]
        [Arguments("+81-90-1234-5678")]
        public static bool ValidateMacAddresses(string macAddress)
        {
            return PhoneNumberValidator.IsValidForRedaction(macAddress.AsSpan());
        }
    }
}
