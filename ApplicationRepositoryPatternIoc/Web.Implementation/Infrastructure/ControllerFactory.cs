using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using Web.Implementation.Models;
using Moq;
using Web.Implementation.Controllers;
using System.Web.Routing;

namespace Web.Implementation.Infrastructure
{
    public class FakeControllerContextFactory
    {
        public ControllerContext CreateFakeControllerContext(ControllerBase controller)
        {
            var httpContextStub = new Mock<HttpContextBase>{
                DefaultValue = DefaultValue.Mock
            };
            return new ControllerContext(httpContextStub.Object, new RouteData(), controller);
        }
    }
}