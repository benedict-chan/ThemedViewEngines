using System.Configuration;
using System.Web.Mvc;


namespace ThemedViewEngines
{
    public class ThemedRazorViewEngine : RazorViewEngine
    {
        private readonly IThemeSelectorService _themeSelectorService;

        public string DefaultMasterName { get; set; }

        public ThemedRazorViewEngine(IThemeSelectorService themeSelectorService)
            : base()
        {
            DefaultMasterName = "_Layout";
            this._themeSelectorService = themeSelectorService;

            AreaViewLocationFormats = new[]
            {
                "~/#@/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/#@/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.vbhtml",

                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            AreaMasterLocationFormats = new[]
            {
                "~/#@/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/#@/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.vbhtml",

                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            AreaPartialViewLocationFormats = new[]
            {
                "~/#@/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/#@/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/#@/Areas/{2}/Views/Shared/{0}.vbhtml",

                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            ViewLocationFormats = new[]
            {
                "~/#@/Views/{1}/{0}.cshtml",
                "~/#@/Views/{1}/{0}.vbhtml",
                "~/#@/Views/Shared/{0}.cshtml",
                "~/#@/Views/Shared/{0}.vbhtml",

                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
            MasterLocationFormats = new[]
            {
                "~/#@/Views/{1}/{0}.cshtml",
                "~/#@/Views/{1}/{0}.vbhtml",
                "~/#@/Views/Shared/{0}.cshtml",
                "~/#@/Views/Shared/{0}.vbhtml",

                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
            PartialViewLocationFormats = new[]
            {
                "~/#@/Views/{1}/{0}.cshtml",
                "~/#@/Views/{1}/{0}.vbhtml",
                "~/#@/Views/Shared/{0}.cshtml",
                "~/#@/Views/Shared/{0}.vbhtml",

                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };

            FileExtensions = new[]
            {
                "cshtml",
                "vbhtml",
            };

        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            string replacedPartialPath = GetThemedPath(partialPath);

            return base.CreatePartialView(controllerContext, replacedPartialPath);

        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            string replacedViewPath = GetThemedPath(viewPath);
            string replacedMasterPath = GetThemedPath(masterPath);

            return base.CreateView(controllerContext, replacedViewPath, replacedMasterPath);
        }


        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            string replacedVirtualPath = GetThemedPath(virtualPath);

            return base.FileExists(controllerContext, replacedVirtualPath);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var themeName = this._themeSelectorService.GetThemeName();
            if (!string.IsNullOrEmpty(themeName) && string.IsNullOrEmpty(masterName))
            {
                //In case if we have a theme, and the request view is not found in the theme folder (i.e. we will use the default view), 
                // we will not be able to locate the theme's master page via _ViewStart (as the view is now in the default "theme" tree )
                //Therefore we have to manually locate the Master page name here
                masterName = DefaultMasterName;
            }
            return base.FindView(controllerContext, viewName, masterName, false);
        }



        private string GetThemedPath(string originalPath)
        {
            var replacedPath = originalPath;
            var themeName = this._themeSelectorService.GetThemeName();
            if (!string.IsNullOrEmpty(themeName))
            {
                string replaceText = string.Format("Themes/{0}", themeName);
                replacedPath = originalPath.Replace("#@", replaceText);
            }
            return replacedPath;

        }

    }


}