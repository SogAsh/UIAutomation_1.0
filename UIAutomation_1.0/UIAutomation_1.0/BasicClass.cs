using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UIAutomation_1._0
{
    public class BasicClass
    {
        protected IWebDriver _driver;
        protected static int time = 2000;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(DataBase.targetUrl);
            _driver.Manage().Window.Maximize();
            ShouldLocate(_driver, DataBase.targetUrl); //ожидание 
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        public static void ShouldLocate(IWebDriver driver, string location)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }

            catch (WebDriverTimeoutException ex)
            {
                throw new WebDriverTimeoutException($"Cant find {location}", ex);
            }

        } //метод ожидания страницы

        public static void WaitElement(IWebDriver driver, By locator, int seconds = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        } //метод ожидания элемента
    }
}
