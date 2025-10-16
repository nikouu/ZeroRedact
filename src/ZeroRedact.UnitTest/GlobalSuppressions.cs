// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0305:Collection initialization can be simplified", Justification = "Test project isn't prod code.")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Most of these are for triggering exceptions during unit testing.")]
