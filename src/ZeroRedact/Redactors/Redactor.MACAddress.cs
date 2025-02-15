using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactMACAddress(string macAddress)
            => RedactMACAddressInternal(macAddress);

        /// <inheritdoc />
        public string RedactMACAddress(string macAddress, MACAddressRedactorOptions redactorOptions)
            => RedactMACAddressInternal(macAddress, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> macAddress)
            => RedactMACAddressInternal(macAddress);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> macAddress, MACAddressRedactorOptions redactorOptions)
            => RedactMACAddressInternal(macAddress, redactorOptions);

        private string RedactMACAddressInternal(ReadOnlySpan<char> macAddress)
        {
            var internalOptions = new InternalMACAddressRedactorOptions(_baseRedactorOptions);
            return RedactMACAddressInternal(macAddress, internalOptions);
        }

        private string RedactMACAddressInternal(ReadOnlySpan<char> macAddress, MACAddressRedactorOptions options)
        {
            var internalOptions = new InternalMACAddressRedactorOptions(_baseRedactorOptions, options);
            return RedactMACAddressInternal(macAddress, internalOptions);
        }

        private static string RedactMACAddressInternal(ReadOnlySpan<char> macAddress, InternalMACAddressRedactorOptions options)
        {
            try
            {
                if (macAddress.IsEmpty)
                {
                    return string.Empty;
                }

                if (!MACAddressValidator.IsValidForRedaction(macAddress))
                {
                    return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                }

                return options.RedactorType switch
                {
                    MACAddressRedaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, macAddress.Length),
                    MACAddressRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    MACAddressRedaction.Full => CreateFullRedactionWithSymbols(macAddress, options.RedactionCharacter),
                    MACAddressRedaction.ShowLastByte => CreateShowLastByteRedaction(macAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        // Technically the same as the IPv6 redaction
        private static unsafe string CreateShowLastByteRedaction(ReadOnlySpan<char> macAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(macAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(macAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new Span<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var lastColon = input.LastIndexOf(':');

                for (int i = 0; i < lastColon; i++)
                {
                    if (char.IsLetterOrDigit(input[i]))
                    {
                        outputBuffer[i] = state.RedactionCharacter;
                    }
                    else
                    {
                        outputBuffer[i] = input[i];
                    }
                }

                input[lastColon..].CopyTo(outputBuffer[lastColon..]);
            });

            return result;
        }
    }
}
