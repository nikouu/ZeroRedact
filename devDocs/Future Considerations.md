# Future Considerations

Possible ideas and todos to come back to.

1. Copy the problem fix pattern in [Compiler Error CS8352](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs8352?f1url=%3FappId%3Droslyn%26k%3Dk(CS8352)) where both paremters are ref structs. This would prevent further copying of option structs. Also see [Redactor in Compliance.RedactionWithZeroRedact/Redactors/CreditCardRedactor.cs](https://github.com/nikouu/Compliance.Redaction-with-ZeroRedact/blob/main/Compliance.RedactionWithZeroRedact/Redactors/CreditCardRedactor.cs) where the overridden methods only take in ref structs. 
	1. This would allow the public options to be `in` parameters.
	1. Though this would change the API. It could be offered alongside existing API too, though would that be too many overloads?
1. Dig further into data locality, especially in the `Constants` class.
1. Investigate whether zeroing can be dodged where `Constants.StackAllocThreshold` is used as the final size is known
1. Improve `CreateDateRedaction(DateOnly date, ReadOnlySpan<char> formatCharacters, char redactionCharacter)` to be less "magic number"y with formatCharacters
1. Investigate each `.Fill('*')` call to see if overwriting redaction characters in the buffer can be removed.
1. In `CreateFirstHalfStringRedaction` look at possible improvements via https://source.dot.net/#Microsoft.Extensions.Compliance.Abstractions/Redaction/Redactor.cs,41