using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomation_1._0
{
    public class BasicClass
    {
        protected IWebDriver driver;
        protected static int time = 2000;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(DataBase.tarhetUrl);
            driver.Manage().Window.Maximize();
            //WaitUntil.ShouldLocate(driver, DataBase.tarhetUrl);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
