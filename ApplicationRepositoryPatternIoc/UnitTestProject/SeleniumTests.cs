using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject
{
    [TestClass]
    public partial class ControllerTests
    {

        private static string BaseUrl = "http://localhost:3189/";
        private static string login = "login";
        private static string admin = "admin";
        private static string password = "password";
        private static string signIn = "signin";
        private static string userName = "username";


        [TestMethod]
        public void CanFillAndSubmitFormAfterLogOn()
        {
            var driver = new ChromeDriver(@"C:\");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            
            driver.Navigate().GoToUrl(BaseUrl + "SignIn");

            driver.FindElement(By.Id(login)).SendKeys(admin);
            driver.FindElement(By.Id(password)).SendKeys(admin);

            driver.FindElement(By.Id(signIn)).Click();

            var t = driver.FindElement(By.Id(userName));

            Assert.AreNotEqual(t, null);
           
        }
    } 
}
