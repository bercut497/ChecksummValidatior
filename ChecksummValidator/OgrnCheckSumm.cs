using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using ChecksummValidator.Constants;
    using ChecksummValidator.Enums;
    using ChecksummValidator.Resources;

    public static class OgrnCheckSumm
    {
        private static RManager ResManager(CultureInfo cultureInfo) => (cultureInfo == null)
? RManager.GetManager(nameof(OgrnCheckSumm), CultureInfo.CurrentCulture)
: RManager.GetManager(nameof(OgrnCheckSumm), cultureInfo);

        public static bool IsValid(object value, ValidationPersonEnum personEnum, CultureInfo cultureInfo = null)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, personEnum, cultureInfo);
        }

        public static bool IsValid(string value, ValidationPersonEnum personEnum, CultureInfo cultureInfo = null)
        {
            if (personEnum == ValidationPersonEnum.Undefined)
            {
                var message = ResManager(cultureInfo).GetString("PersonEnumUndefined");
                throw new ArgumentException(message, nameof(personEnum));
            }

            if (personEnum == ValidationPersonEnum.NaturalPerson)
            {
                var message = ResManager(cultureInfo).GetString("PersonEnumIsNaturalPerson");
                throw new ArgumentException(message, nameof(personEnum));
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