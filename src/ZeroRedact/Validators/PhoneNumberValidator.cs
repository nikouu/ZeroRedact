using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroRedact.Validators
{
    internal class PhoneNumberValidator
    {
        public static bool IsValidForRedaction(ReadOnlySpan<char> phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (char.IsLetter(phoneNumber[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
