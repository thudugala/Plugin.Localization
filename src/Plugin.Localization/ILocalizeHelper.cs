using System.Globalization;

namespace Plugin.Localization
{
    /// <summary>
    /// Localize Helper for platform.
    /// </summary>
    public interface ILocalizeHelper
    {
        /// <summary>
        /// Get Current CultureInfo from platform.
        /// </summary>
        /// <param name="languageConvertor"></param>
        /// <returns></returns>
        CultureInfo GetCurrentCultureInfo(ILanguageConvertor languageConvertor);
    }
}