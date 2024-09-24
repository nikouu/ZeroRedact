using BenchmarkDotNet.Attributes;
using ZeroRedact.Validators;

namespace ZeroRedact.Benchmark.Validators
{
    [MemoryDiagnoser]
    public class CreditCardValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("4111111111111111")]
        [Arguments("4111 1111 1111 1111")]
        [Arguments("5500-0000-0000-0004")]
        [Arguments("3400 0000 0000 009")]
        [Arguments("3000 0000 0000 04")]
        public bool ValidateCreditCardNumbers(string creditCardNumber)
        {
            return CreditCardValidator.IsValidForRedaction(creditCardNumber.AsSpan());
        }
    }
}
