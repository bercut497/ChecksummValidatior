using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;
    using Resources;

    public static class SnilsCheckSumm
    {
        private static RManager ResManager(CultureInfo cultureInfo) => (cultureInfo == null)
    ? RManager.GetManager(nameof(ClassificationCode), CultureInfo.CurrentCulture)
    : RManager.GetManager(nameof(ClassificationCode), cultureInfo);

        public static bool IsValid(object value, CultureInfo cultureInfo = null)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, cultureInfo);
        }

        public static bool IsValid(string value, CultureInfo cultureInfo = null)
        {
            if (value == null)
                return false;

            if (string.IsNullOrWhiteSpace(value.Trim()))
                return false;

            value = Regex.Replace(value, @"[^\d]", "");

            var match = Regex.Match(value, ValueCheckRegExp.snils);
            if (!match.Success)
                return false;

            if (match.Groups.Count != 3)
                return false;

            var expectedCheckSumm = int.Parse(match.Groups[2].Value);
            var calculationString = match.Groups[1].Value;

            var checksumm = ClassicCheckSumm.Calculate(calculationString, 0, true);
            if (checksumm > 101)
                checksumm = checksumm % 101;
            if ((checksumm == 100) || (checksumm == 101))
                checksumm = 0;

            return checksumm == expectedCheckSumm;
        }

    }
}
