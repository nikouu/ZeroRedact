using BenchmarkDotNet.Attributes;

namespace ZeroRedact.Benchmark.Redactors
{
    public class RedactEmailAddressBenchmarks
    {
        private Redactor _redactor;

        [ParamsSource(nameof(EmailAddressInputData))]
        public RedactEmailAddressInput EmailAddressInput;

        public static IEnumerable<RedactEmailAddressInput> EmailAddressInputData =>
        [
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.All),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.FixedLength),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Full),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Username),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.FirstHalfUsername),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Middle),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.MostUsername),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.ShowFirstCharacters),

            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.All),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.FixedLength),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Full),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Username),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.FirstHalfUsername),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.Middle),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.MostUsername),
            new RedactEmailAddressInput("email@example.com", EmailAddressRedaction.ShowFirstCharacters),

            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.All),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.FixedLength),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.Full),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.Username),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.FirstHalfUsername),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.Middle),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.MostUsername),
            new RedactEmailAddressInput("emailemailemailemail@example.com", EmailAddressRedaction.ShowFirstCharacters),

            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.All),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.FixedLength),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.Full),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.Username),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.FirstHalfUsername),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.Middle),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.MostUsername),
            new RedactEmailAddressInput("emailemailemailemailemailemailemailemail@exampleexampleexampleexampleexampleexampleexampleexample.com", EmailAddressRedaction.ShowFirstCharacters),

            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.All),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.FixedLength),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.Full),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.Username),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.FirstHalfUsername),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.Middle),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.MostUsername),
            new RedactEmailAddressInput("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm@abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghik.mabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghi.lmabcdefghnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghiklm.bcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzab.defghim.org", EmailAddressRedaction.ShowFirstCharacters),
        ];

        [GlobalSetup]
        public void Setup()
        {
            _redactor = new Redactor();
        }

        [Benchmark]
        public string RedactEmailAddress_String()
        {
            return _redactor.RedactEmailAddress(EmailAddressInput.Value, new EmailAddressRedactorOptions { RedactorType = EmailAddressInput.RedactorType });
        }

        [Benchmark]
        public ReadOnlySpan<char> RedactEmailAddress_ReadOnlySpan()
        {
            return _redactor.RedactEmailAddress(EmailAddressInput.Value.AsSpan(), new EmailAddressRedactorOptions { RedactorType = EmailAddressInput.RedactorType });
        }

        public class RedactEmailAddressInput
        {
            public string Value { get; }
            public EmailAddressRedaction RedactorType { get; }

            public RedactEmailAddressInput(string value, EmailAddressRedaction redactorType)
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
}
