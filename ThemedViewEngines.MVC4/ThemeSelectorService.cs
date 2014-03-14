using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ThemedViewEngines
{
    public interface IThemeSelectorService
    {
        string GetThemeName();
        void SetThemeName(string themeName);
    }

    public class AppConfigurationThemeService : IThemeSelectorService
    {
        public string GetThemeName()
        {
            return ConfigurationManager.AppSettings["ThemedViewName"] ?? string.Empty;
        }
        public void SetThemeName(string themeName)
        {
            throw new NotSupportedException();
        }
    }




}