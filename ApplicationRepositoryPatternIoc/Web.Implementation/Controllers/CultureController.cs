using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Models;
using Timetable.Site.Controllers.Api;
using EfRepPatTest.Data;

namespace Web.Implementation.Controllers
{
    public class CultureApiController : BaseApiController<Culture>
    {
        private IDataService DataService;

        public CultureApiController(IDataService dataService)
        {
            DataService = dataService;
        }

        public HttpResponseMessage GetAll()
        {
            return CreateResponse<IEnumerable<Culture>>(privateGetAll);
        }

        private IEnumerable<Culture> privateGetAll()
        {
            var t = DataService.GetAllCultures.ToList();

            //DataService.GetTranslation();

            return DataService.GetAllCultures.AsEnumerable();
        }
    }


    public class CultureController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
