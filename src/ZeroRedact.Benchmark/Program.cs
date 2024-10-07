using BenchmarkDotNet.Running;
using ZeroRedact;
using ZeroRedact.Benchmark;

Console.WriteLine("Hello, World!");

var redactor = new Redactor();

var result = redactor.RedactString("葛󠄀");

var g = new SimpleRedactionBenchmarks();

var t = g.RedactFirstHalfString1("abcdefghijklmnopqrstuvwxyz");
var q = g.RedactFirstHalfString2("abcdefghijklmnopqrstuvwxyz");
var w = g.RedactFirstHalfString3("abcdefghijklmnopqrstuvwxyz");
var e = g.RedactFirstHalfString4("abcdefghijklmnopqrstuvwxyz");
var r = g.RedactFirstHalfString5("abcdefghijklmnopqrstuvwxyz");

var u = redactor.RedactString("abcdefghijklmnopqrstuvwxyz", new StringRedactorOptions { RedactorType = StringRedaction.FirstHalf });

Console.WriteLine(result);

#if !DEBUG
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
#endif

