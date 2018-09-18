using System;

namespace Plugin.Localization
{
    /// <summary>
    /// Only load Assemblies with this Attribute to Translate.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ResxLocalizeAttribute : Attribute
    {
    }
}