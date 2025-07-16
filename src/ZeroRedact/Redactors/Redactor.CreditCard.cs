using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactCreditCard(string creditCardNumber)
            => RedactCreditCardInternal(creditCardNumber);

        /// <inheritdoc />
        public string RedactCreditCard(string creditCardNumber, CreditCardRedactorOptions redactorOptions)
            => RedactCreditCardInternal(creditCardNumber, redactorOptions);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactCreditCard(ReadOnlySpan<char> creditCardNumber)
            => RedactCreditCardInternal(creditCardNumber);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactCreditCard(ReadOnlySpan<char> creditCardNumber, CreditCardRedactorOptions redactorOptions)
        => RedactCreditCardInternal(creditCardNumber, redactorOptions);

        private string RedactCreditCardInternal(ReadOnlySpan<char> creditCardNumber)
        {
            var internalOptions = new InternalCreditCardRedactorOptions(_baseRedactorOptions);
            return RedactCreditCardInternal(creditCardNumber, internalOptions);
        }

        private string RedactCreditCardInternal(ReadOnlySpan<char> creditCardNumber, in CreditCardRedactorOptions options)
        {
            var internalOptions = new InternalCreditCardRedactorOptions(_baseRedactorOptions, options);
            return RedactCreditCardInternal(creditCardNumber, internalOptions);
        }

        internal static string RedactCreditCardInternal(ReadOnlySpan<char> creditCardNumber, in InternalCreditCardRedactorOptions options)
        {
            try
            {
                // todo, is this what we want?
                if (creditCardNumber.IsEmpty)
                {
                    return string.Empty;
                }

                if (!CreditCardValidator.IsValidForRedaction(creditCardNumber))
                {
                    return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                }

                return options.RedactorType switch
                {
                    CreditCardRedaction.All => CreateAllRedaction(options.RedactionCharacter, creditCardNumber.Length),
                    CreditCardRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    CreditCardRedaction.Full => CreateFullRedactionWithSymbols(creditCardNumber, options.RedactionCharacter),
                    CreditCardRedaction.ShowLastFour => CreateShowLastFourDigitRedaction(creditCardNumber, options.RedactionCharacter),
                    CreditCardRedaction.ShowFirstSixLastFour => CreateShowLastSixLastFourRedaction(creditCardNumber, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        private static unsafe string CreateShowLastSixLastFourRedaction(ReadOnlySpan<char> creditCardNumber, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(creditCardNumber);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(creditCardNumber.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                // Deal with first six
                var firstSixCount = 0;
                var firstSixFinalIndex = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]))
                    {
                        firstSixCount++;
                        outputBuffer[i] = input[i];
                        if (firstSixCount == 6)
                        {
                            firstSixFinalIndex = i;
                            break;
                        }
                    }
                    else
                    {
                        outputBuffer[i] = input[i];
                    }
                }

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

                // Deal with remaining in the middle
                for (int i = firstSixFinalIndex + 1; i < lastFourFinalIndex; i++)
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
