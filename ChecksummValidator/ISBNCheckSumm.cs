using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;
    using Resources;

    public static class ISBNCheckSumm
    {
        private static RManager ResManager(CultureInfo cultureInfo) => (cultureInfo == null)
    ? RManager.GetManager(nameof(ISBNCheckSumm), CultureInfo.CurrentCulture)
    : RManager.GetManager(nameof(ISBNCheckSumm), cultureInfo);

        private static Regex getRegex(ISBNTypeEnum typeEnum)
        {
            switch (typeEnum)
            {
                case ISBNTypeEnum.ISSN:
                    return new Regex(ValueCheckRegExp.issnRegEx, RegexOptions.CultureInvariant);

                case ISBNTypeEnum.ISBN10:
                    return new Regex(ValueCheckRegExp.isbn10RegEx, RegexOptions.CultureInvariant);

                case ISBNTypeEnum.ISBN13:
                    return new Regex(ValueCheckRegExp.isbn13RegEx, RegexOptions.CultureInvariant);

                default:
                    return new Regex(ValueCheckRegExp.numberRegEx, RegexOptions.CultureInvariant);
            }
        }

        public static bool IsValid(object value, ISBNTypeEnum typeEnum, CultureInfo cultureInfo = null)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, typeEnum, cultureInfo);
        }

        public static bool IsValid(string value, ISBNTypeEnum typeEnum, CultureInfo cultureInfo = null)
        {
            if (typeEnum == ISBNTypeEnum.Undefined)
            {
                var message = ResManager(cultureInfo).GetString("ISBNTypeEnum");
                throw new ArgumentException(message, nameof(typeEnum));
            }
            if (value == null)
                return false;

            value = value.Trim();

            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = Regex.Replace(value, @"[^\dX]", "");

            var regEx = getRegex(typeEnum);
            if (!regEx.IsMatch(value))
                return false;

            if (typeEnum == ISBNTypeEnum.ISBN13)
                return BarCodeCheckSumm.IsValid(value, BarcodeTypeEnum.EAN13, currentCultureInfo);

            int currentCheckSumm = 0;
            var len = value.Length;
            char c = '\0';
            int digit = 0;
            for (var i = 0; i < len; i++)
            {
                c = value[i];
                digit = (c == 'X') ? 10 : int.Parse(c.ToString());
                currentCheckSumm += digit * (len-i);
            }
            currentCheckSumm = currentCheckSumm % 11;

            return currentCheckSumm == 0;
        }
    }
}