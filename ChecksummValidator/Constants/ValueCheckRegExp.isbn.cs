namespace ChecksummValidator.Constants
{
    internal static partial class ValueCheckRegExp
    {
        public const string isbnAllRegEx = @"^((\d{7}(\d{2})?[0-9X])|(\d{13}))$";
        public const string issnRegEx = @"^\d{7}[0-9X]$";
        public const string isbn10RegEx = @"^\d{9}[0-9X]$";
        public const string isbn13RegEx = @"^97[89]\d{10}$";
    }
}