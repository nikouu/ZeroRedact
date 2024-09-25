namespace ZeroRedact
{
    internal readonly struct RedactorState
    {
        public readonly IntPtr StartPointer { get; init; }
        public readonly char RedactionCharacter { get; init; }
    }
}
