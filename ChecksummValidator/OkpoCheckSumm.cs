using ChecksummValidator.Enums;

namespace ChecksummValidator
{
    public static class OkpoCheckSumm
    {
        public static bool IsValid(object value)
        {
            return ClassificationCode.IsValid(value, ClassificationCodeType.okpo);
        }

        public static bool IsValid(string value)
        {
            return ClassificationCode.IsValid(value, ClassificationCodeType.okpo);
        }
    }
}