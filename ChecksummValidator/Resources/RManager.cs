using System.Globalization;
using System.Resources;

namespace ChecksummValidator.Resources
{
    public class RManager
    {
        private readonly ResourceManager _mainResource;
        private readonly ResourceManager _fallbackResource;

        public string GetString(string key)
            => _mainResource?.GetString(key) ?? _fallbackResource?.GetString(key) ?? key;

        public string this[string key] => GetString(key);

        private ResourceManager GetInnCheckSummManager(CultureInfo culture = null)
        {
            var cultureInfo = culture ?? CultureInfo.CurrentCulture;

            var name = cultureInfo.Name.ToUpperInvariant();
            switch (name)
            {
                case "RU-RU":
                    return InnCheckSumm_ru_RU.ResourceManager;

                default:
                    return InnCheckSumm.ResourceManager;
            }
        }

        private ResourceManager GetBarCodeCheckSummManager(CultureInfo culture = null) {
            var cultureInfo = culture ?? CultureInfo.CurrentCulture;

            var name = cultureInfo.Name.ToUpperInvariant();
            switch (name)
            {
                case "RU-RU":
                    return BarCodeCheckSumm_ru_RU.ResourceManager;

                default:
                    return BarCodeCheckSumm.ResourceManager;
            }
        }

        public RManager(string className, CultureInfo culture = null)
        {
            var cultureInfo = culture ?? CultureInfo.CurrentCulture;

            switch (className)
            {
                case nameof(InnCheckSumm):
                    _mainResource = GetInnCheckSummManager(cultureInfo);
                    _fallbackResource = GetInnCheckSummManager(CultureInfo.InvariantCulture);
                    break;
                case nameof(BarCodeCheckSumm):
                    _mainResource = GetBarCodeCheckSummManager(cultureInfo);
                    _fallbackResource = GetBarCodeCheckSummManager(CultureInfo.InvariantCulture);
                    break;
                default:
                    _mainResource = null;
                    _fallbackResource = null;
                    break;
            }
        }

        public static RManager GetManager(string callerClassName, CultureInfo culture = null)
        {
            return new RManager(callerClassName, culture);
        }
    }
}