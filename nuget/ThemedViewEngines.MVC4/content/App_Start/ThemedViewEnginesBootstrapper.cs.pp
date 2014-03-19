using System.Linq;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ThemedViewEngines;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.ThemedViewEnginesBootstrapper), "Start")]
namespace $rootnamespace$.App_Start {
    public static class ThemedViewEnginesBootstrapper{
        public static void Start() 
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ThemedRazorViewEngine(new AppConfigurationThemeService()));
        }
    }
}