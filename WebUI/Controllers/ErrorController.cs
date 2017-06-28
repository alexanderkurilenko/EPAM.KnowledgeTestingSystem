using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult General()
        {
            return View("Error");
        }

        public ActionResult Http404()
        {
            return View("404");
        }

        public ActionResult Http403()
        {
            return View("403");
        }
    }
}