using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EfRepPatTest.Data;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Controllers;
using Autofac.Core;
using Autofac.Integration.WebApi;
using System.Web.Http;
using Autofac.Integration;

namespace Web.Implementation.Infrastructure
{
    public static class DependencyConfigure
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            var container = RegisterServices(builder);
            DependencyResolver.SetResolver(
                new AutofacDependencyResolver(container)
                //new Dependency(RegisterServices(builder))
                );
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(
                typeof(MvcApplication).Assembly
                ).PropertiesAutowired();

            builder.RegisterType<DataService>().As <IDataService>();
            builder.RegisterType<SessionWrapperRepository>().As<ISessionWrapperRepository>();
            builder.RegisterType<FormsAuthenticationWrapper>().As<IFormsAuthenticationWrapper>();
            builder.RegisterType<CurrentContext>().As<ICurrentDatabase>().InstancePerDependency();

            return builder.Build();
        }


    }
}