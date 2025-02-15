using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactIPv6Address(string ipAddress)
            => RedactIPv6Internal(ipAddress);

        /// <inheritdoc />
        public string RedactIPv6Address(string ipAddress, IPv6AddressRedactorOptions redactorOptions)
            => RedactIPv6Internal(ipAddress, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress)
            => RedactIPv6Internal(ipAddress);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactIPv6Address(ReadOnlySpan<char> ipAddress, IPv6AddressRedactorOptions redactorOptions)
            => RedactIPv6Internal(ipAddress, redactorOptions);

        private string RedactIPv6Internal(ReadOnlySpan<char> ipAddress)
        {
            var internalOptions = new InternalIPv6AddressRedactorOptions(_baseRedactorOptions);
            return RedactIPv6Internal(ipAddress, internalOptions);
        }

        private string RedactIPv6Internal(ReadOnlySpan<char> ipAddress, IPv6AddressRedactorOptions options)
        {
            var internalOptions = new InternalIPv6AddressRedactorOptions(_baseRedactorOptions, options);
            return RedactIPv6Internal(ipAddress, internalOptions);
        }

        private static string RedactIPv6Internal(ReadOnlySpan<char> ipAddress, InternalIPv6AddressRedactorOptions options)
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
                    IPv6AddressRedaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, ipAddress.Length),
                    IPv6AddressRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    IPv6AddressRedaction.Full => CreateFullRedactionWithSymbols(ipAddress, options.RedactionCharacter),
                    IPv6AddressRedaction.ShowLastQuartet => CreateShowLastQuartetRedaction(ipAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        // Technically the same as the MAC address redaction
        private static unsafe string CreateShowLastQuartetRedaction(ReadOnlySpan<char> ipv6Address, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(ipv6Address);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(ipv6Address.Length, redactorState, static (outputBuffer, state) =>
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
