using BenchmarkDotNet.Attributes;
using System.Text;

namespace ZeroRedact.Benchmark
{
    public class SimpleRedactionBenchmarks
    {
        private Redactor _redactor;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor(new RedactorOptions
            {
                StringRedactorOptions = new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf }
            });
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString0(string value)
        {
            return _redactor.RedactString(value);
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString1(string value)
        {
            int length = value.Length;
            int halfLength = (length + 1) / 2;
            return new string('*', halfLength) + value.Substring(halfLength);
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString2(string value)
        {
            int halfLength = (value.Length + 1) / 2;
            return new string('*', halfLength) + value.Substring(halfLength);
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString3(string value)
        {
            int halfLength = (value.Length + 1) / 2;
            var redacted = new StringBuilder(value);
            for (int i = 0; i < halfLength; i++)
            {
                redacted[i] = '*';
            }
            return redacted.ToString();
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString4(string value)
        {
            int halfLength = (value.Length + 1) / 2;
            string firstHalf = value[..halfLength];
            string redactedFirstHalf = firstHalf.Replace(firstHalf, new string('*', halfLength));
            return redactedFirstHalf + value[halfLength..];
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString5(string value)
        {
            int halfLength = (value.Length + 1) / 2;
            return System.Text.RegularExpressions.Regex.Replace(value, "^.{" + halfLength + "}", new string('*', halfLength));
        }

        [Benchmark]
        [Arguments("abcdefghijklmnopqrstuvwxyz")]
        public string RedactFirstHalfString6(string value)
        {
            int halfLength = (value.Length + 1) / 2;
            return string.Concat(new string('*', halfLength), value.AsSpan(halfLength));
        }
    }
}
