using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Validators;

namespace ZeroRedact.Benchmark.Validators
{
    [MemoryDiagnoser]
    public class IPv4ValidatorBenchmarks
    {
        [Benchmark]
        [Arguments("192.168.1.1")]
        [Arguments("10.0.0.1")]
        [Arguments("8.8.8.8")]
        public bool ValidateIPv4Addresses(string ipAddress)
        {
            return IPv4Validator.IsValidForRedaction(ipAddress.AsSpan());
        }
    }
}
