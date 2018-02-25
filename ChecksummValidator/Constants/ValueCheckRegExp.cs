namespace ChecksummValidator.Constants
{
    internal static class ValueCheckRegExp
    {
        public const string numberRegEx = @"^\d+$";

        public const string innAllRegEx = @"^\d{10}(\d{2})?$";
        public const string inn10RegEx = @"^\d{10}$";
        public const string inn12RegEx = @"^\d{12}$";

        ////

        public const string ean8RegEx = @"^\d{8}$";
        public const string upc12RegEx = @"^\d{12}$";
        public const string ean13RegEx = @"^\d{13}$";

        ////

        public const string ogrnAllRegEx = @"^(\d{13}(\d{2})?)$";
        public const string ogrn13RegEx = @"^\d{13}$";
        public const string ogrn15RegEx = @"^\d{15}$";

        ////

        public const string isbnAllRegEx = @"^((\d{7}(\d{2})?[0-9X])|(\d{13}))$";
        public const string issnRegEx = @"^\d{7}[0-9X]$";
        public const string isbn10RegEx = @"^\d{9}[0-9X]$";
        public const string isbn13RegEx = @"^97[89]\d{10}$";
    }
}