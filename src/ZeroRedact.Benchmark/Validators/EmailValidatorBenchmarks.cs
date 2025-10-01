using BenchmarkDotNet.Attributes;
using ZeroRedact.Validators;

namespace ZeroRedact.Benchmark.Validators
{
    public class EmailValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("email@example.com")]
        [Arguments("firstname.lastname@example.com")]
        [Arguments("email@subdomain.example.com")]
        [Arguments("email@example-one.com")]
        [Arguments("firstname+lastname@example.com")]
        [Arguments("_______@example.com")]
        [Arguments("email@example.co.jp")]
        [Arguments("firstname-lastname@example.com")]
        [Arguments("plainaddress")]
        [Arguments("#@%^%#$@#$@#.com")]
        [Arguments("@example.com")]
        [Arguments("Joe Smith <email@example.com>")]
        [Arguments("email@example@example.com")]
        [Arguments("email..email@example.com")]
        [Arguments(".email@example.com")]
        [Arguments("email@example")]
        [Arguments("email.@example.com")]
        public bool ValidateEmailAddresses(string emailAddress)
        {
            return EmailAddressValidator.IsValidForRedaction(emailAddress.AsSpan());
        }
    }
}
