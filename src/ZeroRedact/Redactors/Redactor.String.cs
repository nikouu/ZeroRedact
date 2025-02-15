using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactString(string value)
            => RedactStringInternal(value);

        /// <inheritdoc />
        public string RedactString(string value, StringRedactorOptions redactorOptions)
            => RedactStringInternal(value, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactString(ReadOnlySpan<char> value)
            => RedactStringInternal(value);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactString(ReadOnlySpan<char> value, StringRedactorOptions redactorOptions)
            => RedactStringInternal(value, redactorOptions);

        private string RedactStringInternal(ReadOnlySpan<char> value)
        {
            var internalOptions = new InternalStringRedactorOptions(_baseRedactorOptions);
            return RedactStringInternal(value, internalOptions);
        }

        private string RedactStringInternal(ReadOnlySpan<char> value, StringRedactorOptions options)
        {
            var internalOptions = new InternalStringRedactorOptions(_baseRedactorOptions, options);
            return RedactStringInternal(value, internalOptions);
        }

        private string RedactStringInternal(ReadOnlySpan<char> value, InternalStringRedactorOptions options)
        {
            try
            {
                if (value.IsEmpty)
                {
                    return string.Empty;
                }

                return options.RedactorType switch
                {
                    StringRedaction.All => CreateAllRedaction(options.RedactionCharacter, value.Length),
                    StringRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    StringRedaction.FirstHalf => CreateFirstHalfStringRedaction(value, options.RedactionCharacter),
                    StringRedaction.SecondHalf => CreateSecondHalfStringRedaction(value, options.RedactionCharacter),
                    StringRedaction.IgnoreSymbols => CreateFullRedactionWithSymbols(value, options.RedactionCharacter),
                    StringRedaction.ShowFirstAndLast => CreateShowFirstAndLastRedaction(value, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        // todo: look at possible improvements via https://source.dot.net/#Microsoft.Extensions.Compliance.Abstractions/Redaction/Redactor.cs,41
        private static unsafe string CreateFirstHalfStringRedaction(ReadOnlySpan<char> value, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(value);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(value.Length, redactorState, static (outputBuffer, state) =>
            {
                var inputSpan = new Span<char>(state.StartPointer.ToPointer(), outputBuffer.Length);
                var halfLength = (int)Math.Ceiling(inputSpan.Length / 2d);

                outputBuffer[..halfLength].Fill(state.RedactionCharacter);
                inputSpan[halfLength..].CopyTo(outputBuffer[halfLength..]);
            });

            return result;
        }

        private static unsafe string CreateSecondHalfStringRedaction(ReadOnlySpan<char> value, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(value);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(value.Length, redactorState, static (outputBuffer, state) =>
            {
                var inputSpan = new Span<char>(state.StartPointer.ToPointer(), outputBuffer.Length);
                var halfLength = (int)Math.Ceiling(inputSpan.Length / 2d);

                var secondHalfLength = outputBuffer.Length - halfLength;

                outputBuffer[secondHalfLength..].Fill(state.RedactionCharacter);
                inputSpan[..secondHalfLength].CopyTo(outputBuffer[..secondHalfLength]);
            });

            return result;
        }

        private static unsafe string CreateShowFirstAndLastRedaction(ReadOnlySpan<char> value, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(value);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(value.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new Span<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                outputBuffer.Fill(state.RedactionCharacter);
                outputBuffer[0] = input[0];
                outputBuffer[^1] = input[^1];
            });

            return result;
        }
    }
}
