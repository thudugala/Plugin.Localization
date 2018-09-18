using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Plugin.Localization
{
    /// <summary>
    /// Set the correct resource files for the application
    /// </summary>
    public interface ITranslateManager
    {
        /// <summary>
        /// Get Loaded Assembly with Assembly Attribute ResxLocalize to set Culture.
        /// </summary>
        /// <returns></returns>
        IList<Assembly> GetLoadedAssemblyList();

        /// <summary>
        /// Find the current culture on the device and set the resource file.
        /// </summary>
        void SetCulture();

        /// <summary>
        /// Set the Thread for locale-aware methods
        /// </summary>
        /// <param name="cultureInfo"></param>
        void SetLocale(CultureInfo cultureInfo);
    }
}