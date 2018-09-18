using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Plugin.Localization
{
    public interface ILocalizeHelper
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
