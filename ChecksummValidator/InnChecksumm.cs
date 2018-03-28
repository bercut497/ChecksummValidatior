using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;

    public static class InnCheckSumm
    {
        public static bool IsValid(object value, ValidationPersonEnum personEnum)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, personEnum);
        }

        public static bool IsValid(string value, ValidationPersonEnum personEnum)
        {
            if (personEnum == ValidationPersonEnum.Undefined)
            {
                throw new ArgumentException("PersonEnumUndefined", nameof(personEnum));
            }
            if (value == null)
                return false;

            if (string.IsNullOrWhiteSpace(value.Trim()))
                return false;

            switch (personEnum)
            {
                case ValidationPersonEnum.LegalEntity:
                    return Validate10(value);

                case ValidationPersonEnum.NaturalPerson:
                case ValidationPersonEnum.SelfEmployed:
                    return Validate12(value);

                default:
                    return false;
            }
        }

        private static bool Validate10(string value)
        {
            if (!Regex.IsMatch(value, ValueCheckRegExp.inn10RegEx))
                return false;

            var numbers = FactorNumbers.InnFactorNumbers
                            .Skip(2).Take(9).ToArray();
            return IsCheckSummValid(value, numbers, 9);
        }

        private static bool Validate12(string value)
        {
            if (!Regex.IsMatch(value, ValueCheckRegExp.inn12RegEx))
                return false;

            //step 1
            var numbers = FactorNumbers.InnFactorNumbers
                            .Skip(1).Take(10).ToArray();
            if (!IsCheckSummValid(value, numbers, 10))
                return false;

            //step 2
            numbers = FactorNumbers.InnFactorNumbers;
            return IsCheckSummValid(value, numbers, 11);
        }

        private static bool IsCheckSummValid(string value, byte[] factorNumbers, int ChecksummDigitPosition)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (!Regex.IsMatch(value, ValueCheckRegExp.numberRegEx))
                return false;
            if (value.Length < ChecksummDigitPosition)
                return false;
            if (factorNumbers.Length < ChecksummDigitPosition - 1)
                return false;

            var expectedCheckSumm = int.Parse(value[ChecksummDigitPosition].ToString());
            int realCheckSumm = 0;
            for (var i = 0; i < ChecksummDigitPosition; i++)
            {
                var digit = value[i].ToString();
                realCheckSumm += int.Parse(digit) * factorNumbers[i];
            }
            realCheckSumm = realCheckSumm % 11;
            return realCheckSumm == expectedCheckSumm;
        }
    }
}