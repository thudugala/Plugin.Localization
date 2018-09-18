using Foundation;
using Plugin.Localization.Platform.iOS;
using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizeHelper))]
namespace Plugin.Localization.Platform.iOS
{
    public class LocalizeHelper : ILocalizeHelper
    {
        private CultureInfo _cultureInfo;

        public CultureInfo GetCurrentCultureInfo()
        {
            if (_cultureInfo != null)
            {
                return _cultureInfo;
            }

            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = iOSToDotnetLanguage(pref);
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
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    _cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    // iOS language not valid .NET culture, falling back to English
                    _cultureInfo = new CultureInfo("en");
                }
            }

            return _cultureInfo;
        }

        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;
            //certain languages need to be converted to CultureInfo equivalent
            switch (iOSLanguage)
            {
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;

                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;

                case "zh-Hans-CN":
                    netLanguage = "zh-Hans";
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);
            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;

                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }
    }
}