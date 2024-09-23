using System;
using System.Collections.Generic;
using System.Linq;
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
        public string RedactIPv6Address(string ipAddress)
            => RedactIPv6Internal(ipAddress);

        public string RedactIPv6Address(string ipAddress, IPv6RedactorOptions redactorOptions)
            => RedactIPv6Internal(ipAddress, redactorOptions);

        public ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress)
            => RedactIPv6Internal(ipAddress);

        public ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress, IPv6RedactorOptions redactorOptions)
            => RedactIPv6Internal(ipAddress, redactorOptions);

        private string RedactIPv6Internal(ReadOnlySpan<char> ipAddress)
        {
            var internalOptions = new InternalIPv6RedactorOptions(_baseRedactorOptions);
            return RedactIPv6Internal(ipAddress, internalOptions);
        }

        private string RedactIPv6Internal(ReadOnlySpan<char> ipAddress, IPv6RedactorOptions options)
        {
            var internalOptions = new InternalIPv6RedactorOptions(_baseRedactorOptions, options);
            return RedactIPv6Internal(ipAddress, internalOptions);
        }

        private string RedactIPv6Internal(ReadOnlySpan<char> ipAddress, InternalIPv6RedactorOptions options)
        {
            try
            {
                if (ipAddress.IsEmpty)
                {
                    return string.Empty;
                }

                if (!IPv6Validator.IsValidForRedaction(ipAddress))
                {
                    return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                }

                return options.RedactorType switch
                {
                    IPv6Redaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, ipAddress.Length),
                    IPv6Redaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    IPv6Redaction.Full => CreateFullRedactionWithSymbols(ipAddress, options.RedactionCharacter),
                    IPv6Redaction.ShowLastQuartet => CreateShowLastQuartetRedaction(ipAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        // Technically the same as the MAC address redaction
        private unsafe string CreateShowLastQuartetRedaction(ReadOnlySpan<char> ipv4Address, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(ipv4Address);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(ipv4Address.Length, redactorState, static (outputBuffer, state) =>
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
