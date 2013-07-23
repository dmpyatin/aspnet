using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfRepPatTest.Service;
using Web.Implementation.Models;

namespace Web.Implementation.Controllers
{
    public class ProductController : Controller
    {
        /*private IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }*/

        public ActionResult Index()
        {
            /*ViewBag.Message = "Welcome to ASP.NET MVC!";
            var products = productService.GetAll().ToList();

            var producModelList =
                products.Select(p =>
                    {
                        var productModel = new ProductModel();
                        productModel.Id = p.Id;
                        productModel.Name = p.Name;
                        productModel.MinimumStockLevel = p.MinimumStockLevel;
                        return productModel;
                    }
                    );*/
            return View();
        }

    }
}