using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Implementation.Infrastructure;
using System.Web.Http;
using System.Web.Hosting;


namespace Web.Implementation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new HandleErrorAttribute());
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/v1.0/{controller}/{action}/{id}",
               defaults: new { id = System.Web.Http.RouteParameter.Optional }
           );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                defaults:  new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );  
        }

        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            var t = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            AreaRegistration.RegisterAllAreas();
            DependencyConfigure.Initialize();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}