using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemedViewEngines.SampleMVC4.Areas.TestArea.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /TestArea/Area/

        public ActionResult Index()
        {
            return View();
        }

    }
}
