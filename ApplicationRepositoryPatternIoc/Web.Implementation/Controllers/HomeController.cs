using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Models;
using Web.Implementation.Infrastructure;

namespace Web.Implementation.Controllers
{
    public class HomeController : Controller
    {
        private IDataService DataService;
        private TranslationController Translation; 

        public HomeController(IDataService dataService)
        {
            this.DataService = dataService;
            Translation = new TranslationController(this.DataService);
        }


        public ActionResult Index(int? cultureId)
        {
            ViewBag.Message = "<tag>Welcome</tag>";

            var cultureModel = new CultureModel();

            cultureModel.cultureId = 1;
            cultureModel.Cultures = DataService.GetAllCultures.ToList();

            

            return Translation.TranslateView(View(cultureModel), ControllerContext, cultureId);
        }
   
        public ActionResult About()
        {
            return Translation.TranslateView(View(), ControllerContext, 1);
        }
    }
}
