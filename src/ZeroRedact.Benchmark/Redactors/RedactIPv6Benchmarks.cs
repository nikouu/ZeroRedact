using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactIPv6Benchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(IPv6InputData))]
        public RedactIPv6Input IPv6Input;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactIPv6_String()
        {
            return _redactor.RedactIPv6Address(IPv6Input.Value, new IPv6AddressRedactorOptions { RedactorType = IPv6Input.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactIPv6_ReadOnlySpan()
        {
            return _redactor.RedactIPv6Address(IPv6Input.Value.AsSpan(), new IPv6AddressRedactorOptions { RedactorType = IPv6Input.RedactorType });
        }

        public static IEnumerable<RedactIPv6Input> IPv6InputData =>
        [
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6AddressRedaction.All),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6AddressRedaction.FixedLength),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6AddressRedaction.Full),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6AddressRedaction.ShowLastQuartet),
        ];
    }

    public class RedactIPv6Input
    {
        public string Value { get; }
        public IPv6AddressRedaction RedactorType { get; }

        public RedactIPv6Input(string value, IPv6AddressRedaction redactorType)
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
