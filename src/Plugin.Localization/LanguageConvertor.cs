namespace Plugin.Localization
{
    /// <inheritdoc />
    public class LanguageConvertor : ILanguageConvertor
    {
        /// <inheritdoc />
        public virtual string AndroidToDotnetLanguage(string androidLanguage)
        {
            var netLanguage = androidLanguage;
            //certain languages need to be converted to CultureInfo equivalent
            switch (androidLanguage)
            {
                case "ms-BN":   // "Malaysian (Brunei)" not supported .NET culture
                case "ms-MY":   // "Malaysian (Malaysia)" not supported .NET culture
                case "ms-SG":   // "Malaysian (Singapore)" not supported .NET culture
                    netLanguage = "ms"; // closest supported
                    break;

                case "in-ID":  // "Indonesian (Indonesia)" has different code in  .NET
                    netLanguage = "id-ID"; // correct code for .NET
                    break;

                case "gsw-CH":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "de-CH"; // closest supported
                    break;

                case "zh-CN-#Hans":
                    netLanguage = "zh-Hans";
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }

        /// <inheritdoc />
        public virtual string AndroidToDotnetFallbackLanguage(string netLanguage)
        {
            var platCulture = new PlatformCulture(netLanguage);
            var languageCode = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

            switch (languageCode)
            {
                case "gsw":
                    languageCode = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return languageCode;
        }

        /// <inheritdoc />
        public virtual string IOsToDotnetLanguage(string iOsLanguage)
        {
            var netLanguage = iOsLanguage;
            //certain languages need to be converted to CultureInfo equivalent
            switch (iOsLanguage)
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

        /// <inheritdoc />
        public virtual string IOsToDotnetFallbackLanguage(string netLanguage)
        {
            var platCulture = new PlatformCulture(netLanguage);
            var languageCode = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

            switch (languageCode)
            {
                case "pt":
                    languageCode = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;

                case "gsw":
                    languageCode = "de-CH"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return languageCode;
        }
    }
}