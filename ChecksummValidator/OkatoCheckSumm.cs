using ChecksummValidator.Enums;

namespace ChecksummValidator
{
    public static class OkatoCheckSumm
    {
        public static bool IsValid(object value)
        {
            return ClassificationCode.IsValid(value, ClassificationCodeType.okato);
        }

        public static bool IsValid(string value)
        {
            return ClassificationCode.IsValid(value, ClassificationCodeType.okato);
        }
    }
}