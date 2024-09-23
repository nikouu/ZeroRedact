using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactIPv4Benchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(IPv4InputData))]
        public RedactIPv4Input IPv4Input;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactIPv4_String()
        {
            return _redactor.RedactIPv4Address(IPv4Input.Value, new IPv4RedactorOptions { RedactorType = IPv4Input.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactIPv4_ReadOnlySpan()
        {
            return _redactor.RedactIPv4Address(IPv4Input.Value.AsSpan(), new IPv4RedactorOptions { RedactorType = IPv4Input.RedactorType });
        }

        public static IEnumerable<RedactIPv4Input> IPv4InputData => new[]
        {
            new RedactIPv4Input("192.168.0.1", IPv4Redaction.All),
            new RedactIPv4Input("192.168.0.1", IPv4Redaction.FixedLength),
            new RedactIPv4Input("192.168.0.1", IPv4Redaction.Full),
            new RedactIPv4Input("192.168.0.1", IPv4Redaction.ShowLastOctet),
        };
    }

    public class RedactIPv4Input
    {
        public string Value { get; }
        public IPv4Redaction RedactorType { get; }

        public RedactIPv4Input(string value, IPv4Redaction redactorType)
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
