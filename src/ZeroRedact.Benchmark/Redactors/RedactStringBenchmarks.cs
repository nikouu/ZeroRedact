using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactStringBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(StringInputData))]
        public RedactStringInput StringInput;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor(new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions { RedactorType = StringInput.RedactorType }
            });
        }

        [Benchmark]
        public string RedactString_String()
        {
            return _redactor.RedactString(StringInput.Value);
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactString_ReadOnlySpan()
        {
            return _redactor.RedactString(StringInput.Value.AsSpan());
        }

        public static IEnumerable<RedactStringInput> StringInputData =>
        [
            new RedactStringInput("hello", StringRedaction.All),
            new RedactStringInput("hello", StringRedaction.FixedLength),
            new RedactStringInput("hello", StringRedaction.FirstHalf),
            new RedactStringInput("hello", StringRedaction.SecondHalf),
            new RedactStringInput("hello", StringRedaction.IgnoreSymbols),
            new RedactStringInput("hello", StringRedaction.ShowFirstAndLast),
            new RedactStringInput("abcdefgh", StringRedaction.All),
            new RedactStringInput("abcdefgh", StringRedaction.FixedLength),
            new RedactStringInput("abcdefgh", StringRedaction.FirstHalf),
            new RedactStringInput("abcdefgh", StringRedaction.SecondHalf),
            new RedactStringInput("abcdefgh", StringRedaction.IgnoreSymbols),
            new RedactStringInput("abcdefgh", StringRedaction.ShowFirstAndLast),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.All),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.FixedLength),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.FirstHalf),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.SecondHalf),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.IgnoreSymbols),
            new RedactStringInput("abcdefghijklmnopqrstuvwxyz", StringRedaction.ShowFirstAndLast)
        ];
    }

    // custom class to get the table display to be nicer
    public class RedactStringInput
    {
        public string Value { get; }
        public StringRedaction RedactorType { get; }

        public RedactStringInput(string value, StringRedaction redactorType)
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
