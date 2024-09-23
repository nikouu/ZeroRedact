using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    [MemoryDiagnoser]
    public class RedactDateBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(DateInputData))]
        public RedactDateInput DateInput;

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactkDate_DateTime()
        {
            return _redactor.RedactDate(DateInput.Value, new DateRedactorOptions { RedactorType = DateInput.RedactorType });
        }

        [Benchmark]
        public string RedactDate_DateOnly()
        {
            return _redactor.RedactDate(DateInput.DateOnlyValue, new DateRedactorOptions { RedactorType = DateInput.RedactorType });
        }

        public static IEnumerable<RedactDateInput> DateInputData => new[]
        {
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.All),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.FixedLength),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.Full),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.Day),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.Month),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.Year),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.DayAndMonth),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.MonthAndYear),
            new RedactDateInput(new DateTime(2023, 1, 1),DateRedaction.DayAndYear)
        };
    }

    public class RedactDateInput
    {
        public DateTime Value { get; }
        public DateOnly DateOnlyValue { get; }
        public DateRedaction RedactorType { get; }

        public RedactDateInput(DateTime value, DateRedaction redactorType)
        {
            Value = value;
            DateOnlyValue = DateOnly.FromDateTime(value);
            RedactorType = redactorType;
        }

        public override string ToString()
        {
            return $"{RedactorType}";
        }
    }
}
