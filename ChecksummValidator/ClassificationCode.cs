using System;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;

    public static class ClassificationCode
    {
        private static Regex GetRegEx(ClassificationCodeType code)
        {
            switch (code)
            {
                case ClassificationCodeType.okato:
                    return new Regex(ValueCheckRegExp.OkatoRegEx);

                case ClassificationCodeType.okpo:
                    return new Regex(ValueCheckRegExp.OkpoRegEx);

                default:
                    return new Regex(ValueCheckRegExp.numberRegEx);
            }
        }

        public static bool IsValid(object value, ClassificationCodeType code)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, code);
        }

        public static bool IsValid(string value, ClassificationCodeType code)
        {
            if (code == ClassificationCodeType.Undefined)
            {
                throw new ArgumentException("ClassificationCodeUdefined", nameof(code));
            }
            if (value == null)
                return false;

            if (string.IsNullOrWhiteSpace(value.Trim()))
                return false;

            var regEx = GetRegEx(code);
            if (!regEx.IsMatch(value))
                return false;

            var calculationStringLength = value.Length - 1;
            var expectedCheckSumm = int.Parse(value[calculationStringLength].ToString());
            var calculationString = value.Substring(0, calculationStringLength);

            var checksumm = CalculateCheckSumm(calculationString, false);

            if (checksumm == 10)
                checksumm = CalculateCheckSumm(calculationString, true);

            if (checksumm == 10)
                checksumm = 0;

            return checksumm == expectedCheckSumm;
        }

        private static int CalculateCheckSumm(string value, bool shifted = false)
        {
            var shift = shifted ? 2u : 0u;
            var checksumm = ClassicCheckSumm.Calculate(value, shift) % 11L;
            return (int)checksumm;
        }
    }
}