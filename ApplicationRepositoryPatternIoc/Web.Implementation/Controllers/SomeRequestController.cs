using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Implementation.Controllers
{
    public class SomeRequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(string someText)
        {
            var translate = "Translate";
            return translate;
        }
    }
}
