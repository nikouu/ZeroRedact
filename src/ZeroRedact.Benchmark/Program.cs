using BenchmarkDotNet.Running;
using ZeroRedact;

Console.WriteLine("Hello, World!");

var redactor = new Redactor();

var result = redactor.RedactString("葛󠄀");

Console.WriteLine(result);

#if !DEBUG
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
#endif

