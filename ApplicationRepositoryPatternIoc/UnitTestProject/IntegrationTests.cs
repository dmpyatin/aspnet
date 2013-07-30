using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfRepPatTest.Data;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using System.Linq;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Data;
using Web.Implementation.Controllers;
using System.Web.Mvc;

namespace UnitTestProject
{
    public partial class DataServiceTests
    {
        //Интеграционные тесты
        [TestMethod]
        public void AddCategoryTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var myCategory = new Category();
            myCategory.Name = "newcategory";

            var countCategoriesPre = dataService.Database.Value.Categories.Where(x => x.Name == "newcategory").Count();

            dataService.Database.Value.Add<Category>(myCategory);

            var countCategoriesPost = dataService.Database.Value.Categories.Where(x => x.Name == "newcategory").Count();

          

            Assert.AreEqual(countCategoriesPre + 1, countCategoriesPost);
        }


        
        [TestMethod]
        public void AddProductTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var myProduct = new Product();
            myProduct.CategoryId = 1;
            myProduct.MinimumStockLevel = 10;
            myProduct.Name = "newproduct";

            var countProductsPre = dataService.Database.Value.Products.Where(x => x.Name == "newproduct" &&
                                                                         x.MinimumStockLevel == 10).Count();

            dataService.Database.Value.Add<Product>(myProduct);

            var countProductsPost = dataService.Database.Value.Products.Where(x => x.Name == "newproduct" &&
                                                                         x.MinimumStockLevel == 10).Count();

            
            Assert.AreEqual(countProductsPre + 1, countProductsPost);

        }


  
        [TestMethod]
        public void UpdateProductTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var myProductPre = dataService.Database.Value.Products.Where(x => x.Id == 1).Single();

            Random rand = new Random(System.DateTime.Now.Second);

            myProductPre.Name = "newproduct" + rand.ToString();
            dataService.Database.Value.Update<Product>(myProductPre);

            var myProductPost = dataService.Database.Value.Products.Where(x => x.Id == 1).Single();

          

            Assert.AreEqual(myProductPost.Name, myProductPre.Name);
        }

        
        [TestMethod]
        public void UpdateCategoryTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var myCategoryPre = dataService.Database.Value.Categories.Where(x => x.Id == 1).Single();

            Random rand = new Random(System.DateTime.Now.Second);

            myCategoryPre.Name = "newcategory" + rand.ToString();

            dataService.Database.Value.Update<Category>(myCategoryPre);

            var myCategoryPost = dataService.Database.Value.Categories.Where(x => x.Id == 1).Single();

            Assert.AreEqual(myCategoryPost.Name, myCategoryPre.Name);
        }

        
        [TestMethod]
        public void DeleteProductTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var myProduct = new Product();
            myProduct.Name = "newproduct";
            myProduct.MinimumStockLevel = 10;
            myProduct.CategoryId = 1;

            var countProductsPre = dataService.Database.Value.Products.Where(x => x.Name == "newproduct").Count();

            dataService.Database.Value.Add<Product>(myProduct);

            dataService.Database.Value.Delete<Product>(myProduct);

            var countProductsPost = dataService.Database.Value.Products.Where(x => x.Name == "newproduct").Count();

            Assert.AreEqual(countProductsPre, countProductsPost);
        }

        
        [TestMethod]
        public void DeleteCategoryTest()
        {
            Lazy<ICurrentDatabase> curContext = new Lazy<ICurrentDatabase>(() => new CurrentContext());

            var dataService = new DataService(curContext);

            var countCategoriesPre = dataService.Database.Value.Categories.Where(x => x.Name == "newcategory").Count();

            var myCategory = new Category();
            myCategory.Name = "newcategory";

            dataService.Database.Value.Add<Category>(myCategory);

            dataService.Database.Value.Delete<Category>(myCategory);

            var countCategoriesPost = dataService.Database.Value.Categories.Where(x => x.Name == "newcategory").Count();

            Assert.AreEqual(countCategoriesPre, countCategoriesPost);
        }
    }
}
