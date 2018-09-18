namespace Plugin.Localization
{
    /// <summary>
    /// Convert LanguageCode to Dotnet Language Code.
    /// </summary>
    public interface ILanguageConvertor
    {
        /// <summary>
        /// Convert Android Language to Dotnet Language.
        /// </summary>
        /// <param name="androidLanguage"></param>
        /// <returns></returns>
        string AndroidToDotnetLanguage(string androidLanguage);

        /// <summary>
        /// Convert Android Language to Dotnet Language.
        /// </summary>
        /// <param name="netLanguage"></param>
        /// <returns></returns>
        string AndroidToDotnetFallbackLanguage(string netLanguage);

        /// <summary>
        /// Convert iOS Language to Dotnet Language.
        /// </summary>
        /// <param name="iOsLanguage"></param>
        /// <returns></returns>
        string IOsToDotnetLanguage(string iOsLanguage);

        /// <summary>
        /// Convert iOS Language to Dotnet Language.
        /// </summary>
        /// <param name="netLanguage"></param>
        /// <returns></returns>
        string IOsToDotnetFallbackLanguage(string netLanguage);
    }
}