using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Linq;

namespace ChecksummValidator
{
    public static class InnCheckSumm
    {
        private static readonly ResourceManager _rm = new ResourceManager($"Resources.{nameof(InnCheckSumm)}", Assembly.GetExecutingAssembly());

        private static CultureInfo getCultureInfo(CultureInfo CultureInfo)
            => CultureInfo ?? CultureInfo.CurrentCulture;


        public static bool isValid(object value, ValidationPersonEnum personEnum, CultureInfo cultureInfo = null)
        {
            if(value == null)
                return false;

            string str = value as string;
            if(str == null){
                str = value.ToString();
            }
            return isValid(str,personEnum,cultureInfo);
        }

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
            var numbers = FactorNumbers.InnFactorNumbers
                            .Skip(2).Take(9).ToArray();
            return IsCheckSummValid(value,numbers,9);
        }

        private static bool validate12(string value)
        {
            var numbers = FactorNumbers.InnFactorNumbers
                            .Skip(1).Take(10).ToArray();
            if(!IsCheckSummValid(value,numbers,10))
                return false;

            throw new NotImplementedException();
        }

        private static bool IsCheckSummValid(string value, byte[] factorNumbers, int ChecksummDigitPosition){
            if(string.IsNullOrWhiteSpace(value))
                return false;
            if(!Regex.IsMatch(value,ValueCheckRegExp.innAllRegEx))
                return false;
            if(value.Length < ChecksummDigitPosition)
                return false;
            var expectedCheckSumm = int.Parse(value[ChecksummDigitPosition].ToString());
            int realCheckSumm =0;
            for(var i=0; i<ChecksummDigitPosition; i++){
                var digit = value[i].ToString();
                realCheckSumm += int.Parse(digit)*factorNumbers[i];
            }
            
            return realCheckSumm == expectedCheckSumm;
        }
    }
}
