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

    }
}
