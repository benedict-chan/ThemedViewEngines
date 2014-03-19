using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ThemedViewEngines
{


    public class AppConfigurationThemeService : IThemeSelectorService
    {
        public string GetThemeName()
        {
            return ConfigurationManager.AppSettings["ThemeName"] ?? string.Empty;
        }
        public void SetThemeName(string themeName)
        {
            throw new NotSupportedException();
        }
    }




}