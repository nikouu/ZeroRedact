using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    public class RedactMACAddressBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(MACAddressInputData))]
        public RedactMACAddressInput MACAddressInput;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactMACAddress_String()
        {
            return _redactor.RedactMACAddress(MACAddressInput.Value, new MACAddressRedactorOptions { RedactorType = MACAddressInput.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactMACAddress_ReadOnlySpan()
        {
            return _redactor.RedactMACAddress(MACAddressInput.Value.AsSpan(), new MACAddressRedactorOptions { RedactorType = MACAddressInput.RedactorType });
        }

        public static IEnumerable<RedactMACAddressInput> MACAddressInputData =>
        [
            new RedactMACAddressInput("00:1A:2B:3C:4D:5E", MACAddressRedaction.All),
            new RedactMACAddressInput("00:1A:2B:3C:4D:5E", MACAddressRedaction.FixedLength),
            new RedactMACAddressInput("00:1A:2B:3C:4D:5E", MACAddressRedaction.Full),
            new RedactMACAddressInput("00:1A:2B:3C:4D:5E", MACAddressRedaction.ShowLastByte),
        ];
    }

    public class RedactMACAddressInput
    {
        public string Value { get; }
        public MACAddressRedaction RedactorType { get; }

        public RedactMACAddressInput(string value, MACAddressRedaction redactorType)
        {
            Value = value;
            RedactorType = redactorType;
        }

        public override string ToString()
        {
            return $"{Value}:{RedactorType}";
        }
    }
}
