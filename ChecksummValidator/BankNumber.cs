using System;
using System.Collections.Generic;
using System.Text;

namespace ChecksummValidator
{
    using Constants;
    using Enums;
    using System.Text.RegularExpressions;

    public static class BankNumber
    {


        public static bool IsValid(object value, BankNumberTypeEnum bankNumber, object bikNumber)
        {
            if (value == null)
                return false;

            if (bikNumber == null)
                return false;

            string stringValue = value as string;
            if (stringValue == null)
            {
                stringValue = value.ToString();
            }

            string stringBikNumber = value as string;
            if (stringBikNumber == null)
            {
                stringBikNumber = value.ToString();
            }


            return IsValid(stringValue, bankNumber, stringBikNumber);
        }

        private static Regex GetRegex(BankNumberTypeEnum bankNumber)
            => (bankNumber == BankNumberTypeEnum.CorrespondentAccount)
            ? new Regex(ValueCheckRegExp.correspondentAccount, RegexOptions.CultureInvariant)
            : new Regex(ValueCheckRegExp.paymentAccount, RegexOptions.CultureInvariant);


        public static bool IsValid(string value, BankNumberTypeEnum bankNumber, string BikNumber)
        {
            if (string.IsNullOrWhiteSpace(BikNumber))
                throw new ArgumentNullException(nameof(BikNumber), $"{nameof(BikNumber)} not set");

            if (bankNumber == BankNumberTypeEnum.Undefined)
                throw new ArgumentNullException(nameof(bankNumber), $"{nameof(bankNumber)} not set");

            var valueRegex = GetRegex(bankNumber);

            if (!valueRegex.IsMatch(value))
                return false;

            if (!Regex.IsMatch(BikNumber, ValueCheckRegExp.bankIdentityCode))
                return false;

            var zeroCalcString = CalculationString(BikNumber, value, bankNumber);

            var nineExpectedValue = int.Parse(value[9]+"");
            var nineNumberValue = value.Substring(0,8)+"0"+ value.Substring(9,11);
            var nineCalcString = CalculationString(BikNumber, nineNumberValue, bankNumber);

            return IsCheckSummValid(0, zeroCalcString) && IsCheckSummValid(nineExpectedValue, nineCalcString);
        }

        private static string CalculationString(string BikNumber, string value, BankNumberTypeEnum bankNumber)
        {
            var prefix = string.Empty;
            switch (bankNumber)
            {
                case BankNumberTypeEnum.PaymentAccount:
                    prefix = BikNumber.Substring(BikNumber.Length - 3, 3);
                    break;
                case BankNumberTypeEnum.CorrespondentAccount:
                    prefix = 0 + BikNumber.Substring(5, 2);
                    break;
            }

            return prefix + value;
        }

        private static bool IsCheckSummValid(int expected, string value) {
            if (value.Length != 23)
                return false;
            long summ = 0;
            for (var i=0; i < 23; i++) {
                summ += int.Parse(value[i] + "") * FactorNumbers.BankFactorNumbers[i];
            }
            summ = summ % 10;
            return expected == summ;
        }
    }
}
