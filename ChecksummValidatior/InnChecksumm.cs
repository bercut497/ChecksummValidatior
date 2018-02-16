using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace ChecksummValidatior
{
    public static class InnCheckSumm
    {
        private static readonly ResourceManager _rm = new ResourceManager($"Resources.{nameof(InnCheckSumm)}", Assembly.GetExecutingAssembly());

        private static CultureInfo getCultureInfo(CultureInfo CultureInfo)
            => CultureInfo ?? CultureInfo.CurrentCulture;

        public static bool isValid(string value, ValidationPersonEnum personEnum, CultureInfo cultureInfo = null)
        {
            var currentCultureInfo = getCultureInfo(cultureInfo);

            value = value.Trim();
            if (personEnum == ValidationPersonEnum.Undefined)
            {
                throw new ArgumentException(_rm.GetString("PersonEnumUndefined", currentCultureInfo), nameof(personEnum));
            }

            if (string.IsNullOrWhiteSpace(value.Trim()))
            {
                return false;
            }

            if ((personEnum == ValidationPersonEnum.LegalEntity) && Regex.IsMatch(value, ValueCheckRegExp.inn10RegEx)) {
                return validate10(value);
            }

            if (Regex.IsMatch(value, ValueCheckRegExp.inn12RegEx))
            {
                return validate12(value);
            }
            return false;
        }

        private static bool validate10(string value)
        {
            throw new NotImplementedException();
        }

        private static bool validate12(string value)
        {
            throw new NotImplementedException();
        }
    }
}
