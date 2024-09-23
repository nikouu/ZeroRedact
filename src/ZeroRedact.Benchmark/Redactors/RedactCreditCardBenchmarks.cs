using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactCreditCardBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(CreditCardInputData))]
        public RedactCreditCardInput CreditCardInput;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactCreditCard_String()
        {
            return _redactor.RedactCreditCard(CreditCardInput.Value, new CreditCardRedactorOptions { RedactorType = CreditCardInput.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactCreditCard_ReadOnlySpan()
        {
            return _redactor.RedactCreditCard(CreditCardInput.Value.AsSpan(), new CreditCardRedactorOptions { RedactorType = CreditCardInput.RedactorType });
        }

        public static IEnumerable<RedactCreditCardInput> CreditCardInputData =>
        [
            new RedactCreditCardInput("1234567890123456", CreditCardRedaction.All),
            new RedactCreditCardInput("1234567890123456", CreditCardRedaction.FixedLength),
            new RedactCreditCardInput("1234567890123456", CreditCardRedaction.Full),
            new RedactCreditCardInput("1234567890123456", CreditCardRedaction.ShowLastFour),
            new RedactCreditCardInput("1234567890123456", CreditCardRedaction.ShowFirstSixLastFour),
            new RedactCreditCardInput("1234-5678-9012-3456", CreditCardRedaction.All),
            new RedactCreditCardInput("1234-5678-9012-3456", CreditCardRedaction.Full),
            new RedactCreditCardInput("1234-5678-9012-3456", CreditCardRedaction.FixedLength),
            new RedactCreditCardInput("1234-5678-9012-3456", CreditCardRedaction.ShowLastFour),
            new RedactCreditCardInput("1234-5678-9012-3456", CreditCardRedaction.ShowFirstSixLastFour)
        ];
    }

    public class RedactCreditCardInput
    {
        public string Value { get; }
        public CreditCardRedaction RedactorType { get; }

        public RedactCreditCardInput(string value, CreditCardRedaction redactorType)
        {
            Value = value;
            RedactorType = redactorType;
        }

        public override string ToString()
        {
            return $"{Value.Length}:{RedactorType}";
        }
    }
}
