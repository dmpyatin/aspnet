using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfRepPatTest.Data;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Data;
using Web.Implementation.Controllers;
using Web.Implementation.Infrastructure;
using Web.Implementation.Models;

namespace UnitTestProject
{
   
    /*[TestClass]
    public partial class DataServiceTests
    {
        //Юнит тесты
        [TestMethod]
        public void SignInTest()
        {

            var auth = new Mock<IFormsAuthenticationWrapper>();

            //auth.Setup(p => p.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>()));
            //auth.Setup(p => p.SignOut());

            /*ISessionWrapperRepository session = Mock.Of<ISessionWrapperRepository>(
                 p => p.GetSession(It.IsAny<string>()) == null);

            var testSignInController = new SignInController(session, auth.Object);

             var factory = new FakeControllerContextFactory();

             testSignInController.ControllerContext = factory.CreateFakeControllerContext(testSignInController);

             var userStub = Mock.Get(testSignInController.User.Identity);
             userStub.SetupGet(p => p.Name).Returns("admin");

             testSignInController.Index(new SignInModel() { UserName = "admin", Password = "admin", RememberMe = false });

             Mock.Get(session).Verify(p => p.SetSession(It.IsAny<string>(), It.IsAny<object>()), Times.Once());

             auth.Verify(p => p.SetCookie(It.IsAny<string>(), It.IsAny<bool>()), Times.Once());

             testSignInController.SignOut();

             auth.Verify(p => p.SignOut(), Times.Once());

             Assert.AreEqual(true, true);
             
        }


        [TestMethod]
        public void CrudNullEntity()
        {
            var curContext = new Lazy<CurrentContext>();

            var dataService = new DataService(curContext);

            try
            {
                dataService.Add(null);
            }
            catch (ArgumentNullException ex)
            {

                var testEx = new System.ArgumentNullException("entity", "error");

                Assert.AreEqual(testEx.GetType(), ex.GetType());
            }
        }

        [TestMethod]
        public void CrudBehavior()
        {
            var mock = new Mock<ICurrentDatabase>();

            mock.Setup(lw => lw.Add<Product>(It.IsAny<Product>()));
            mock.Setup(lw => lw.Update<Product>(It.IsAny<Product>()));
            mock.Setup(lw => lw.Delete<Product>(It.IsAny<Product>()));
          
            var testDataService = new DataService(mock.Object);

            var myProduct = new Product();
            var myCategory = new Category();

            testDataService.Add(myProduct);
            testDataService.Update(myProduct);
            testDataService.Delete(myProduct);

            testDataService.Add(myCategory);
            testDataService.Update(myCategory);
            testDataService.Delete(myCategory);

            mock.Verify();
        }

        [TestMethod]
        public void GetCategories()
        {
            /*IQueryable<Product> testProducts = new List<Product>() { 
                new Product() { Id = 1, Name = "product1", MinimumStockLevel = 10, CategoryId = 1 },
                new Product() { Id = 2, Name = "product2", MinimumStockLevel = 20, CategoryId = 2 },
                new Product() { Id = 3, Name = "product3", MinimumStockLevel = 30, CategoryId = 3 }
            }.AsQueryable();

            IQueryable<Category> testCategories = new List<Category>() { 
                new Category() { Id = 1, Name = "category1", Products = null },
                new Category() { Id = 2, Name = "category2", Products = null },
                new Category() { Id = 3, Name = "category3", Products = null }
            }.AsQueryable();

            //ICurrentDatabase logger = Mock.Of<ICurrentDatabase>(
               // d => d.Products == testProducts &&
                     //d.Categories == testCategories);

            //var testDataService = new DataService(logger);

            //var resultProducts = testDataService.GetCategories();

            Assert.AreEqual(true, true);
        }


        [TestMethod]
        public void GetAllProductsTest()
        {
            IQueryable<Product> testProducts = new List<Product>() { 
                new Product() { Id = 1, Name = "product1", MinimumStockLevel = 10, CategoryId = 1 },
                new Product() { Id = 2, Name = "product2", MinimumStockLevel = 20, CategoryId = 2 },
                new Product() { Id = 3, Name = "product3", MinimumStockLevel = 30, CategoryId = 3 }
            }.AsQueryable();
           
            ICurrentDatabase logger = Mock.Of<ICurrentDatabase>(
                d => d.Products == testProducts);


            var testDataService = new DataService(logger);

            var resultProducts = testDataService.GetAllProducts;

            Assert.AreEqual(resultProducts.Count(), 3);
        }

        [TestMethod]
        public void GetAllCategoriesTest()
        {
            IQueryable<Category> testCategories = new List<Category>() { 
                new Category() { Id = 1, Name = "category1", Products = null },
                new Category() { Id = 2, Name = "category2", Products = null },
                new Category() { Id = 3, Name = "category3", Products = null }
            }.AsQueryable();

            ICurrentDatabase logger = Mock.Of<ICurrentDatabase>(
                d => d.Categories == testCategories);


            var testDataService = new DataService(logger);

            var resultCategories = testDataService.GetAllCategories;

            Assert.AreEqual(resultCategories.Count(), 3);
        }

        [TestMethod]
        public void GetProductByIdTest()
        {
            IQueryable<Product>  testProducts = new List<Product>() { 
                new Product() { Id = 1, Name = "product1", MinimumStockLevel = 10, CategoryId = 1 },
                new Product() { Id = 2, Name = "product2", MinimumStockLevel = 20, CategoryId = 2 },
                new Product() { Id = 3, Name = "product3", MinimumStockLevel = 30, CategoryId = 3 }
            }.AsQueryable();

            ICurrentDatabase logger = Mock.Of<ICurrentDatabase>(
                d => d.Products == testProducts);


            var testDataService = new DataService(logger);

            var resultProduct = testDataService.GetProductById(1);

            Assert.AreEqual(resultProduct.Id, 1);
        }

        [TestMethod]
        public void GetCategoryByIdTest()
        {
            IQueryable<Category>  testCategories = new List<Category>() { 
                new Category() { Id = 1, Name = "category1", Products = null },
                new Category() { Id = 2, Name = "category2", Products = null },
                new Category() { Id = 3, Name = "category3", Products = null }
            }.AsQueryable();

            ICurrentDatabase logger = Mock.Of<ICurrentDatabase>(
                d => d.Categories == testCategories);


            var testDataService = new DataService(logger);

            var resultCategory = testDataService.GetCategoryById(1);

            //var r = testDataService.GetProductById(1);

            Assert.AreEqual(resultCategory.Id, 1);
        }
    }*/
}
