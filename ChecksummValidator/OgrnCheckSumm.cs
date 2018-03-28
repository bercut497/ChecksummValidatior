using System;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;

    public static class OgrnCheckSumm
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

            if (personEnum == ValidationPersonEnum.NaturalPerson)
            {
                throw new ArgumentException("PersonEnumIsNaturalPerson", nameof(personEnum));
            }

            if (value == null)
                return false;

            if (string.IsNullOrWhiteSpace(value.Trim()))
                return false;

            switch (personEnum)
            {
                case ValidationPersonEnum.LegalEntity:
                    return Validate13(value);

                case ValidationPersonEnum.SelfEmployed:
                    return Validate15(value);

                default:
                    return false;
            }
        }

        private static bool Validate15(string value)
        {
            if (!Regex.IsMatch(value, ValueCheckRegExp.ogrn15RegEx))
                return false;
            return IsCheckSummValid(value, 13, 14);
        }

        private static bool Validate13(string value)
        {
            if (!Regex.IsMatch(value, ValueCheckRegExp.ogrn13RegEx))
                return false;
            return IsCheckSummValid(value, 11, 12);
        }

        private static bool IsCheckSummValid(string value, uint divider, uint ChecksummDigitPosition)
        {
            if (value == null)
                return false;
            value = value.Trim();
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (!Regex.IsMatch(value, ValueCheckRegExp.numberRegEx))
                return false;
            if (value.Length < ChecksummDigitPosition)
                return false;

            var expectedCheckSummValue = uint.Parse(value[(int)ChecksummDigitPosition].ToString());

            var currentCheckSumm = ulong.Parse(value.Substring(0, (int)ChecksummDigitPosition));
            currentCheckSumm = currentCheckSumm % divider;

            return currentCheckSumm == expectedCheckSummValue;
        }
    }
}