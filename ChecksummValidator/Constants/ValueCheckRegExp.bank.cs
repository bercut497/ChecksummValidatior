namespace ChecksummValidator.Constants
{
    internal static partial class ValueCheckRegExp
    {
        public const string bankIdentityCode = @"^(\d{9})$";
        public const string paymentAccount = @"^(\d{20})$";
        public const string correspondentAccount = @"^301(\d{17})$";
    }
}