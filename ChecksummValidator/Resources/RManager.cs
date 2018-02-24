using System.Globalization;
using System.Resources;

namespace ChecksummValidator.Resources
{
    public static class RManager
    {
        public static ResourceManager GetInnCheckSummManager(CultureInfo culture = null)
        {
            var cultureInfo = culture ?? CultureInfo.CurrentCulture;

            var name = cultureInfo.Name.ToUpperInvariant();
            switch (name)
            {
                case "RU-RU":
                    return InnCheckSumm_ru_RU_resources.ResourceManager;

                default:
                    return InnCheckSumm_resources.ResourceManager;
            }
        }

        public static ResourceManager GetBarCodeCheckSummManager(CultureInfo culture = null)
        {
            var cultureInfo = culture ?? CultureInfo.CurrentCulture;

            var name = cultureInfo.Name.ToUpperInvariant();
            switch (name)
            {
                case "RU-RU":
                    return BarCodeCheckSumm_ru_RU_Resources.ResourceManager;

                default:
                    return BarCodeCheckSumm_Resources.ResourceManager;
            }
        }
    }
}