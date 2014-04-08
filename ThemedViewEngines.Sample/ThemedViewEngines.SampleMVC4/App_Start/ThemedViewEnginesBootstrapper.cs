using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ThemedViewEngines;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ThemedViewEngines.SampleMVC4.App_Start.ThemedViewEnginesBootstrapper), "Start")]
namespace ThemedViewEngines.SampleMVC4.App_Start {
    public static class ThemedViewEnginesBootstrapper{
        public static void Start() 
        {
            ViewEngines.Engines.Clear();

            // Uncomment this when using Web.config for theme
            //ViewEngines.Engines.Add(new ThemedRazorViewEngine(new AppConfigurationThemeService()));

            ViewEngines.Engines.Add(new ThemedRazorViewEngine(new CookieThemeService()));

        }
    }

    public class CookieThemeService : IThemeSelectorService
    {

        public string GetThemeName()
        {
            var cookie = HttpContext.Current.Request.Cookies["ThemeName"];
            if (cookie != null)
                return cookie.Value;
            return string.Empty;
        }

        public void SetThemeName(string themeName)
        {
            throw new System.NotImplementedException();
        }
    }

}