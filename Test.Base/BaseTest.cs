using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.BaseTest
{
    public class BaseTest
    {
        protected IWebDriver driver { get; private set; }

        public BaseTest()
        {
        }

        [OneTimeSetUp]
        public void SetUpClassMaster()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://addressenrichment.azurewebsites.net/Login");
        }

        [OneTimeTearDown]
        public void TearDownClassMaster()
        {
            driver.Quit();
        }
    }
}
