using Foundation;
using Plugin.Localization.Platform.iOS;
using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizeHelper))]
namespace Plugin.Localization.Platform.iOS
{
    public class LocalizeHelper : ILocalizeHelper
    {
        private CultureInfo _cultureInfo;

        public CultureInfo GetCurrentCultureInfo(ILanguageConvertor languageConvertor)
        {
            if (_cultureInfo != null)
            {
                return _cultureInfo;
            }

            var netLanguage = "en";
            if (languageConvertor is null)
            {
                return new CultureInfo(netLanguage);
            }

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = languageConvertor.IOsToDotnetLanguage(pref);
            }

            try
            {
                _cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                // iOS locale not valid .NET culture (e.g. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = languageConvertor.IOsToDotnetFallbackLanguage(netLanguage);
                    _cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    // iOS language not valid .NET culture, falling back to English
                    _cultureInfo = new CultureInfo(netLanguage);
                }
            }

            return _cultureInfo;
        }
    }
}