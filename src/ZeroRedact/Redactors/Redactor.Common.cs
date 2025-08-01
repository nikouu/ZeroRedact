﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZeroRedact
{
    /// <summary>
    /// Implements redaction capabilities.
    /// </summary>
    [SkipLocalsInit]
    public sealed partial class Redactor : IRedactor
    {
        // Both constructors assign this. If it was defaulted here, it would be assigned twice
        private readonly RedactorOptions _baseRedactorOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Redactor"/> class.
        /// </summary>
        public Redactor()
        {
            _baseRedactorOptions = Constants.DefaultRedactorOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Redactor"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to configure the redactor.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="options"/> has a less than one <see cref="RedactorOptions.FixedLengthSize"/>.</exception>
        public Redactor(RedactorOptions options)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(options.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.CreditCardRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.DateRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.EmailAddressRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.IPv4AddressRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.IPv6AddressRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.MACAddressRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.PhoneNumberRedactorOptions.FixedLengthSize, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(options.StringRedactorOptions.FixedLengthSize, 1);

            _baseRedactorOptions = options;
        }

        private static string CreateAllRedaction(char character, int length)
        {
            return new string(character, length);
        }

        private static string CreateFixedLengthRedaction(char character, int length)
        {
            if (character == Constants.DefaultRedactionCharacter && length == Constants.DefaultFixedLengthSize)
            {
                return Constants.DefaultRedactionString;
            }

            return CreateAllRedaction(character, length);
        }

        private static unsafe string CreateFullRedactionWithSymbols(ReadOnlySpan<char> input, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(input);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(input.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                for (int i = 0; i < input.Length; i++)
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
            });

            return result;
        }

        private static unsafe string CreateShowLastFourDigitRedaction(ReadOnlySpan<char> input, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(input);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(input.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                // Deal with last four
                var lastFourCount = 0;
                var lastFourFinalIndex = 0;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(input[i]))
                    {
                        lastFourCount++;
                        outputBuffer[i] = input[i];
                        if (lastFourCount == 4)
                        {
                            lastFourFinalIndex = i;
                            break;
                        }
                    }
                    else
                    {
                        outputBuffer[i] = input[i];
                    }
                }

                // Deal with remaining 
                for (int i = 0; i < lastFourFinalIndex; i++)
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
            });

            return result;
        }
    }
}
