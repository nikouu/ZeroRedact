using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactIPv4Address(string ipAddress)
            => RedactIPv4Internal(ipAddress);

        /// <inheritdoc />
        public string RedactIPv4Address(string ipAddress, IPv4AddressRedactorOptions redactorOptions)
            => RedactIPv4Internal(ipAddress, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactIPv4Address(ReadOnlySpan<char> ipAddress)
            => RedactIPv4Internal(ipAddress);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactIPv4Address(ReadOnlySpan<char> ipAddress, IPv4AddressRedactorOptions redactorOptions)
            => RedactIPv4Internal(ipAddress, redactorOptions);

        private string RedactIPv4Internal(ReadOnlySpan<char> ipAddress)
        {
            var internalOptions = new InternalIPv4AddressRedactorOptions(_baseRedactorOptions);
            return RedactIPv4Internal(ipAddress, internalOptions);
        }

        private string RedactIPv4Internal(ReadOnlySpan<char> ipAddress, in IPv4AddressRedactorOptions redactorOptions)
        {
            var internalOptions = new InternalIPv4AddressRedactorOptions(_baseRedactorOptions, redactorOptions);
            return RedactIPv4Internal(ipAddress, internalOptions);
        }

        private static string RedactIPv4Internal(ReadOnlySpan<char> ipAddress, in InternalIPv4AddressRedactorOptions options)
        {
            try
            {
                if (ipAddress.IsEmpty)
                {
                    return string.Empty;
                }

                if (!IPv4Validator.IsValidForRedaction(ipAddress))
                {
                    return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                }

                return options.RedactorType switch
                {
                    IPv4AddressRedaction.All => CreateFixedLengthRedaction(options.RedactionCharacter, ipAddress.Length),
                    IPv4AddressRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    IPv4AddressRedaction.Full => CreateFullRedactionWithSymbols(ipAddress, options.RedactionCharacter),
                    IPv4AddressRedaction.ShowLastOctet => CreateShowLastOctetRedaction(ipAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        private static unsafe string CreateShowLastOctetRedaction(ReadOnlySpan<char> ipv4Address, char redactionCharacter)
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
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var lastDot = input.LastIndexOf('.');

                for (int i = 0; i < lastDot; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        outputBuffer[i] = state.RedactionCharacter;
                    }
                    else
                    {
                        outputBuffer[i] = input[i];
                    }
                }

                input[lastDot..].CopyTo(outputBuffer[lastDot..]);
            });

            return result;
        }
    }
}
