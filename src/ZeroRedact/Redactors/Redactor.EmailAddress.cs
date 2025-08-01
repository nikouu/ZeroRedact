﻿using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZeroRedact.Options.Internal;
using ZeroRedact.Validators;

namespace ZeroRedact
{
    public partial class Redactor
    {
        /// <inheritdoc />
        public string RedactEmailAddress(string emailAddress)
            => RedactEmailAddressInternal(emailAddress);

        /// <inheritdoc />
        public string RedactEmailAddress(string emailAddress, EmailAddressRedactorOptions redactorOptions)
            => RedactEmailAddressInternal(emailAddress, redactorOptions, skipValidation: false);

        /// <inheritdoc />
        public ReadOnlySpan<char> RedactEmailAddress(ReadOnlySpan<char> emailAddress)
            => RedactEmailAddressInternal(emailAddress);
        /// <inheritdoc />
        /// 
        public ReadOnlySpan<char> RedactEmailAddress(ReadOnlySpan<char> emailAddress, EmailAddressRedactorOptions redactorOptions)
            => RedactEmailAddressInternal(emailAddress, redactorOptions, skipValidation: false);

        /// <inheritdoc />
        public string RedactEmailAddress(MailAddress emailAddress)
            => RedactEmailAddressInternal(emailAddress.Address);

        /// <inheritdoc />
        public string RedactEmailAddress(MailAddress emailAddress, EmailAddressRedactorOptions redactorOptions)
            => RedactEmailAddressInternal(emailAddress.Address, redactorOptions, skipValidation: true);

        private string RedactEmailAddressInternal(ReadOnlySpan<char> emailAddress, bool skipValidation = false)
        {
            var internalOptions = new InternalEmailAddressRedactorOptions(_baseRedactorOptions);
            return RedactEmailInternal(emailAddress, internalOptions, skipValidation);
        }

        private string RedactEmailAddressInternal(ReadOnlySpan<char> emailAddress, in EmailAddressRedactorOptions options, bool skipValidation = false)
        {
            var internalOptions = new InternalEmailAddressRedactorOptions(_baseRedactorOptions, options);
            return RedactEmailInternal(emailAddress, internalOptions, skipValidation);
        }

        private static string RedactEmailInternal(ReadOnlySpan<char> emailAddress, in InternalEmailAddressRedactorOptions options, bool skipValidation)
        {
            try
            {
                if (!skipValidation)
                {
                    if (emailAddress.IsEmpty)
                    {
                        return string.Empty;
                    }

                    if (!EmailAddressValidator.IsValidForRedaction(emailAddress))
                    {
                        return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
                    }
                }

                return options.RedactorType switch
                {
                    EmailAddressRedaction.All => CreateAllRedaction(options.RedactionCharacter, emailAddress.Length),
                    EmailAddressRedaction.FixedLength => CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize),
                    EmailAddressRedaction.Full => CreateFullEmailRedaction(emailAddress, options.RedactionCharacter),
                    EmailAddressRedaction.Username => CreateUsernameRedaction(emailAddress, options.RedactionCharacter),
                    EmailAddressRedaction.FirstHalfUsername => CreateHalfUsernameRedaction(emailAddress, options.RedactionCharacter),
                    EmailAddressRedaction.Middle => CreateMiddleRedaction(emailAddress, options.RedactionCharacter),
                    EmailAddressRedaction.MostUsername => CreateMostUsernameRedaction(emailAddress, options.RedactionCharacter),
                    EmailAddressRedaction.ShowFirstCharacters => CreateShowFirstCharactersRedaction(emailAddress, options.RedactionCharacter),
                    _ => throw new NotImplementedException()
                };
            }
            catch
            {
                return CreateFixedLengthRedaction(options.RedactionCharacter, options.FixedLengthSize);
            }
        }

        private static unsafe string CreateFullEmailRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var finalDot = input.LastIndexOf('.');
                var finalAtIndex = input.LastIndexOf('@');

                outputBuffer.Fill(state.RedactionCharacter);
                outputBuffer[finalDot] = '.';
                outputBuffer[finalAtIndex] = '@';
            });

            return result;
        }

        private static unsafe string CreateUsernameRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var finalAtIndex = input.LastIndexOf('@');
                var domain = input[finalAtIndex..];

                outputBuffer[..finalAtIndex].Fill(state.RedactionCharacter);
                domain.CopyTo(outputBuffer[finalAtIndex..]);
            });

            return result;
        }

        private static unsafe string CreateHalfUsernameRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var finalAtIndex = input.LastIndexOf('@');
                var username = input[..finalAtIndex];
                var domain = input[finalAtIndex..];

                var halfLength = (int)Math.Ceiling(username.Length / 2d);

                outputBuffer[..halfLength].Fill(state.RedactionCharacter);
                username[halfLength..].CopyTo(outputBuffer[halfLength..]);
                domain.CopyTo(outputBuffer[finalAtIndex..]);
            });

            return result;
        }
        private static unsafe string CreateMiddleRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var finalAtIndex = input.LastIndexOf('@');
                var username = input[..finalAtIndex];
                var domain = input[finalAtIndex..];

                var secondHalfUsernameIndex = username.Length - (int)Math.Ceiling(username.Length / 2d);
                var halfDomain = (int)Math.Ceiling(domain.Length / 2d);
                var secondHalfDomainIndex = finalAtIndex + halfDomain;

                username[..secondHalfUsernameIndex].CopyTo(outputBuffer);
                outputBuffer[secondHalfUsernameIndex..finalAtIndex].Fill(state.RedactionCharacter);
                outputBuffer[finalAtIndex..secondHalfDomainIndex].Fill(state.RedactionCharacter);
                domain[halfDomain..].CopyTo(outputBuffer[secondHalfDomainIndex..]);
            });

            return result;
        }

        private static unsafe string CreateMostUsernameRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                var finalAtIndex = input.LastIndexOf('@');
                var username = input[..finalAtIndex];
                var domain = input[finalAtIndex..];


                outputBuffer[..finalAtIndex].Fill(state.RedactionCharacter);
                outputBuffer[0] = username[0];
                outputBuffer[username.Length - 1] = username[^1];
                domain.CopyTo(outputBuffer[finalAtIndex..]);
            });

            return result;
        }

        private static unsafe string CreateShowFirstCharactersRedaction(ReadOnlySpan<char> emailAddress, char redactionCharacter)
        {
            ref var valueRef = ref MemoryMarshal.GetReference(emailAddress);
            var valuePtr = (IntPtr)Unsafe.AsPointer(ref valueRef);

            var redactorState = new RedactorState
            {
                StartPointer = valuePtr,
                RedactionCharacter = redactionCharacter
            };

            var result = string.Create(emailAddress.Length, redactorState, static (outputBuffer, state) =>
            {
                var input = new ReadOnlySpan<char>(state.StartPointer.ToPointer(), outputBuffer.Length);

                outputBuffer.Fill('*');

                // first characters
                var finalAtIndex = input.LastIndexOf('@');
                outputBuffer[0] = input[0];
                outputBuffer[finalAtIndex] = input[finalAtIndex];
                outputBuffer[finalAtIndex + 1] = input[finalAtIndex + 1];

                // domain
                var finalDot = input.LastIndexOf('.');
                input[finalDot..].CopyTo(outputBuffer[finalDot..]);
            });

            return result;
        }
    }
}
