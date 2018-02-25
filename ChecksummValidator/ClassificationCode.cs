using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;
    using Resources;

    public static class ClassificationCode
    {
        private static RManager ResManager(CultureInfo cultureInfo) => (cultureInfo == null)
            ?RManager.GetManager(nameof(ClassificationCode), CultureInfo.CurrentCulture)
            :RManager.GetManager(nameof(ClassificationCode), cultureInfo);

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

        public static bool IsValid(object value, ClassificationCodeType code, CultureInfo cultureInfo = null)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, code, cultureInfo);
        }

        public static bool IsValid(string value, ClassificationCodeType code, CultureInfo cultureInfo = null)
        {
            if (code == ClassificationCodeType.Undefined)
            {
                var message = ResManager(cultureInfo).GetString("ClassificationCodeUdefined");
                throw new ArgumentException(message, nameof(code));
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

            var checksumm = CalculateCheckSumm(calculationString, false, cultureInfo);

            if (checksumm == 10)
                checksumm = CalculateCheckSumm(calculationString, true, cultureInfo);

            if (checksumm == 10)
                checksumm = 0;

            return checksumm == expectedCheckSumm;
        }

        private static int CalculateCheckSumm(string value,bool shifted = false, CultureInfo cultureInfo = null) {
            var shift = shifted ? 2u : 0u;
            var checksumm = ClassicCheckSumm.Calculate(value, shift) % 11L;
            return (int)checksumm;
        }
    }
}
