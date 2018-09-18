using System;

namespace Plugin.Localization
{
    /// <summary>
    /// Get the language code and locale code
    /// </summary>
    public class PlatformCulture
    {
        /// <summary>
        /// Set language code and locale code from input string.
        /// </summary>
        /// <param name="platformCultureString"></param>
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException(@"Expected culture identifier", nameof(platformCultureString));
            }
            PlatformString = platformCultureString.Replace("_", "-"); // .NET expects dash, not underscore
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }

        /// <summary>
        /// Get the language code
        /// </summary>
        public string LanguageCode { get; }

        /// <summary>
        /// Get the locale code
        /// </summary>
        public string LocaleCode { get; }

        /// <summary>
        /// Get the platform string
        /// </summary>
        public string PlatformString { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return PlatformString;
        }
    }
}
