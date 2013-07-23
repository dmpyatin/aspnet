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

namespace Web.Implementation.Infrastructure
{
    internal class DependencyConfigure
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            DependencyResolver.SetResolver(
                new Dependency(RegisterServices(builder))
                );
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(
                typeof(MvcApplication).Assembly
                ).PropertiesAutowired();

            //deal with your dependencies here
            builder.RegisterType<DataContext>().As<IDbContext>().InstancePerDependency();

            builder.RegisterGeneric(typeof(RepositoryService<>)).As(typeof(IRepository<>));

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();


            return
                builder.Build();
        }


    }
}