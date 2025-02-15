// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Primary constructors add extra allocations.")]
[assembly: SuppressMessage("Performance", "HAA0502:Explicit new reference type allocation", Justification = "Mostly seen in benchmark setup.")]
[assembly: SuppressMessage("Performance", "CA1845:Use span-based 'string.Concat'", Justification = "Comparing different methods.", Scope = "namespaceanddescendants", Target = "~T:ZeroRedact.Benchmark.SimpleRedactionBenchmarks")]
[assembly: SuppressMessage("Style", "IDE0057:Use range operator", Justification = "Comparing different methods.", Scope = "namespaceanddescendants", Target = "~T:ZeroRedact.Benchmark.SimpleRedactionBenchmarks")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Keeping non-static as it compare to a non-static method elsewhere.", Scope = "namespaceanddescendants", Target = "~T:ZeroRedact.Benchmark.SimpleRedactionBenchmarks")]
[assembly: SuppressMessage("Performance", "HAA0502:Explicit new reference type allocation", Justification = "Benchmark setup.")]
