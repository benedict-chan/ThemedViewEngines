using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemedViewEngines.SampleMVC4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SwitchTheme(string themeName, string redirectTo)
        {
            string controllerName = ControllerContext.RouteData.Values["Controller"].ToString();
            string actionName = ControllerContext.RouteData.Values["Action"].ToString();

            var themedCookie = new HttpCookie("ThemeName", themeName);
            HttpContext.Response.Cookies.Add(themedCookie);

            return Redirect(redirectTo);

            //return RedirectToAction(actionName, controllerName, ControllerContext.RouteData.Values);
        }

    }
}
