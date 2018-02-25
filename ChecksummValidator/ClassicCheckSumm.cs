using ChecksummValidator.Constants;
using System;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    internal class ClassicCheckSumm
    {
        public static long Calculate(string value, uint shift = 0U, bool inverse = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                var msg = "Calculation value is empty";
                throw new ArgumentException(msg, nameof(value));
            }
            if (!Regex.IsMatch(value, ValueCheckRegExp.numberRegEx))
            {
                var msg = "Calculation value is not numeric";
                throw new ArgumentException(msg, nameof(value));
            }

            long checksumm = 0;
            long factor = 0;
            string number = string.Empty;
            int digit = 0;
            var len = value.Length;

            for (var i = 0; i < len; i++)
            {
                number = value[i].ToString();
                digit = int.Parse(number);

                factor = ((i + shift) % 10) + 1;
                if (inverse)
                    factor = 10 - factor;

                checksumm += digit * factor;
            }
            return checksumm;
        }
    }
}