using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Plugin.Localization
{
    /// <inheritdoc />
    public class TranslateManager : ITranslateManager
    {
        private readonly ILocalizeHelper _localizeHelper;
        private readonly ILanguageConvertor _languageConvertor;

        /// <inheritdoc />
        public TranslateManager(ILocalizeHelper localizeHelper, ILanguageConvertor languageConvertor)
        {
            _localizeHelper = localizeHelper;
            _languageConvertor = languageConvertor;
        }

        /// <inheritdoc />
        public virtual IList<Assembly> GetLoadedAssemblyList()
        {
            return AppDomain.CurrentDomain
                       .GetAssemblies()
                       .Where(a => Attribute.GetCustomAttribute(a, typeof(ResxLocalizeAttribute)) != null &&
                                   a.IsDynamic == false)
                       .ToList();
        }

        /// <inheritdoc />
        public virtual void SetCulture()
        {
            var currentCultureInfo = _localizeHelper?.GetCurrentCultureInfo(_languageConvertor);
            if (currentCultureInfo is null)
            {
                return;
            }

            var assemblyList = GetLoadedAssemblyList();

            foreach (var assembly in assemblyList)
            {
                var resourceNames = assembly.GetManifestResourceNames()
                    .Where(r => r.EndsWith(".resources"))
                    .Select(r => r.Replace(".resources", string.Empty));

                foreach (var resourceName in resourceNames)
                {
                    var resType = assembly.GetType(resourceName, false, true);
                    var culture = resType.GetProperty("Culture",
                        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    culture?.SetValue(null, currentCultureInfo); // set the RESX for resource localization
                }
            }

            SetLocale(currentCultureInfo);
        }

        /// <inheritdoc />
        public virtual void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}