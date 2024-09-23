using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZeroRedact.Options;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactMACAddress(string MACAddress)
            => RedactMACAddressInternal(MACAddress);

        /// <inheritdoc />
        public string RedactMACAddress(string MACAddress, MACAddressRedactorOptions redactorOptions)
            => RedactMACAddressInternal(MACAddress, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> MACAddress)
            => RedactMACAddressInternal(MACAddress);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactMACAddress(ReadOnlySpan<char> MACAddress, MACAddressRedactorOptions redactorOptions)
            => RedactMACAddressInternal(MACAddress, redactorOptions);

        private string RedactMACAddressInternal(ReadOnlySpan<char> MACAddress)
        {
            var internalOptions = new InternalMACAddressRedactorOptions(_baseRedactorOptions);
            return RedactMACAddressInternal(MACAddress, internalOptions);
        }

        private string RedactMACAddressInternal(ReadOnlySpan<char> MACAddress, MACAddressRedactorOptions options)
        {
            var internalOptions = new InternalMACAddressRedactorOptions(_baseRedactorOptions, options);
            return RedactMACAddressInternal(MACAddress, internalOptions);
        }

        private string RedactMACAddressInternal(ReadOnlySpan<char> MACAddress, InternalMACAddressRedactorOptions options)
        {
            try
            {
                if (MACAddress.IsEmpty)
                {
                    return string.Empty;
                }

                if (!MACAddressValidator.IsValidForRedaction(MACAddress))
                {
                    return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                }

                return options.RedactorType switch
                {
                    MACAddressRedaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, MACAddress.Length),
                    MACAddressRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    MACAddressRedaction.Full => CreateFullRedactionWithSymbols(MACAddress, options.RedactionCharacter),
                    MACAddressRedaction.ShowLastByte => CreateShowLastByteRedaction(MACAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        // Technically the same as the IPv6 redaction
        private unsafe string CreateShowLastByteRedaction(ReadOnlySpan<char> macAddress, char redactionCharacter)
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
