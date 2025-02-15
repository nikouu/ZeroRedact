using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactPhoneNumberBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(PhoneNumberInputData))]
        public RedactPhoneNumberInput PhoneNumberInput;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactPhoneNumber_String()
        {
            return _redactor.RedactPhoneNumber(PhoneNumberInput.Value, new PhoneNumberRedactorOptions { RedactorType = PhoneNumberInput.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactPhoneNumber_ReadOnlySpan()
        {
            return _redactor.RedactPhoneNumber(PhoneNumberInput.Value.AsSpan(), new PhoneNumberRedactorOptions { RedactorType = PhoneNumberInput.RedactorType });
        }

        public static IEnumerable<RedactPhoneNumberInput> PhoneNumberInputData =>
        [
            new RedactPhoneNumberInput("123-456-7890", PhoneNumberRedaction.All),
            new RedactPhoneNumberInput("123-456-7890", PhoneNumberRedaction.FixedLength),
            new RedactPhoneNumberInput("123-456-7890", PhoneNumberRedaction.Full),
            new RedactPhoneNumberInput("123-456-7890", PhoneNumberRedaction.ShowLastFour),
            new RedactPhoneNumberInput("+1 (555) 123-4567", PhoneNumberRedaction.All),
            new RedactPhoneNumberInput("+1 (555) 123-4567", PhoneNumberRedaction.FixedLength),
            new RedactPhoneNumberInput("+1 (555) 123-4567", PhoneNumberRedaction.Full),
            new RedactPhoneNumberInput("+1 (555) 123-4567", PhoneNumberRedaction.ShowLastFour)
        ];
    }

    public class RedactPhoneNumberInput
    {
        public string Value { get; }
        public PhoneNumberRedaction RedactorType { get; }

        public RedactPhoneNumberInput(string value, PhoneNumberRedaction redactorType)
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
