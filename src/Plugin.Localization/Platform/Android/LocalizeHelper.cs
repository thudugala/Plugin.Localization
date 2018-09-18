﻿using Plugin.Localization.Platform.Android;
using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(LocalizeHelper))]
namespace Plugin.Localization.Platform.Android
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

            var androidLocale = Java.Util.Locale.Default;
            netLanguage = languageConvertor.AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));
            try
            {
                _cultureInfo = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                // android locale not valid .NET culture (e.g. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                try
                {
                    var fallback = languageConvertor.AndroidToDotnetFallbackLanguage(netLanguage);
                    _cultureInfo = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    // android language not valid .NET culture, falling back to English
                    _cultureInfo = new CultureInfo(netLanguage);
                }
            }

            return _cultureInfo;
        }
    }
}