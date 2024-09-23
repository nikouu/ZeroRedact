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
            return _redactor.RedactIPv6(IPv6Input.Value, new IPv6RedactorOptions { RedactorType = IPv6Input.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactIPv6_ReadOnlySpan()
        {
            return _redactor.RedactIPv6(IPv6Input.Value.AsSpan(), new IPv6RedactorOptions { RedactorType = IPv6Input.RedactorType });
        }

        public static IEnumerable<RedactIPv6Input> IPv6InputData => new[]
        {
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6Redaction.All),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6Redaction.FixedLength),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6Redaction.Full),
            new RedactIPv6Input("2001:0db8:85a3:0000:0000:8a2e:0370:7334", IPv6Redaction.ShowLastQuartet),
        };
    }

    public class RedactIPv6Input
    {
        public string Value { get; }
        public IPv6Redaction RedactorType { get; }

        public RedactIPv6Input(string value, IPv6Redaction redactorType)
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
