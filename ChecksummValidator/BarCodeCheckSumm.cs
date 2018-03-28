﻿using System;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    using Constants;
    using Enums;

    public static class BarCodeCheckSumm
    {
        private static byte[] GetFactorNumbers(int len)
        {
            if (len < 0)
                return new byte[0];

            var result = new byte[len];
            int faktor = 1;
            if ((len % 2) == 0)
            {
                faktor = 3;
            }
            for (var i = 0; i < len; i++)
            {
                result[i] = (byte)faktor;
                faktor = (faktor == 1) ? 3 : 1;
            }
            return result;
        }

        private static byte[] getFactorNumbers(BarcodeTypeEnum typeEnum)
        {
            switch (typeEnum)
            {
                case BarcodeTypeEnum.EAN13:
                    return GetFactorNumbers(13);

                case BarcodeTypeEnum.EAN8:
                    return GetFactorNumbers(8);

                case BarcodeTypeEnum.UPC12:
                    return GetFactorNumbers(12);

                default:
                    return GetFactorNumbers(0);
            }
        }

        private static Regex getRegex(BarcodeTypeEnum typeEnum)
        {
            switch (typeEnum)
            {
                case BarcodeTypeEnum.EAN13:
                    return new Regex(ValueCheckRegExp.ean13RegEx, RegexOptions.CultureInvariant);

                case BarcodeTypeEnum.EAN8:
                    return new Regex(ValueCheckRegExp.ean8RegEx, RegexOptions.CultureInvariant);

                case BarcodeTypeEnum.UPC12:
                    return new Regex(ValueCheckRegExp.upc12RegEx, RegexOptions.CultureInvariant);

                default:
                    return new Regex(ValueCheckRegExp.numberRegEx, RegexOptions.CultureInvariant);
            }
        }

        public static bool IsValid(object value, BarcodeTypeEnum typeEnum)
        {
            if (value == null)
                return false;

            string str = value as string;
            if (str == null)
            {
                str = value.ToString();
            }
            return IsValid(str, typeEnum);
        }

        public static bool IsValid(string value, BarcodeTypeEnum typeEnum)
        {
            if (typeEnum == BarcodeTypeEnum.Undefined)
            {
                throw new ArgumentException("TypeEnumUndefined", nameof(typeEnum));
            }
            if (value == null)
                return false;

            value = value.Trim();

            if (string.IsNullOrWhiteSpace(value))
                return false;

            var regEx = getRegex(typeEnum);
            if (!regEx.IsMatch(value))
                return false;

            byte[] factorNumbers = getFactorNumbers(typeEnum);

            if (factorNumbers.Length != value.Length)
                return false;

            int currentCheckSumm = 0;
            var len = value.Length;
            for (var i = 0; i < len; i++)
            {
                currentCheckSumm += int.Parse(value[i].ToString()) * factorNumbers[i];
            }
            currentCheckSumm = currentCheckSumm % 10;

            return currentCheckSumm == 0;
        }
    }
}