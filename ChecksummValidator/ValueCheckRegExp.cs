using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ChecksummValidator
{
    internal static class ValueCheckRegExp
    {
        public const string innAllRegEx = @"^\d{10}(\d{2})?$";
        public const string inn10RegEx = @"^\d{10}$";
        public const string inn12RegEx = @"^\d{12}$";
        //
        public const string ean8RegEx = @"^\d{8}$";
        public const string ean13RegEx = @"^\d{13}$";
        public const string upc12RegEx = @"^\d{12}$";


    }
}
