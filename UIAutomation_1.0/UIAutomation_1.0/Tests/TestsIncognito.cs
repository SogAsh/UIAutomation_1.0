using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using UIAutomation_1._0;

namespace UIAutomation_1._1
{
    public class TestsIncognito
    {
        private IWebDriver _driver;
        private static int time = 2000;

        public static By marketTab = By.XPath("//li/a[@href='/marketplace']");
        public static By menuTypes = By.XPath("//h4[@class='text-mono mb-3 text-normal']");


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            _driver = new ChromeDriver(chromeOptions);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl("https://github.com/");
            _driver.Manage().Window.Maximize();
            BasicClass.ShouldLocate(_driver, DataBase.targetUrl); //ожидание 
        }

        [Test]
        public void WhenIncognito_Close()
        {
            _driver.FindElement(marketTab).Click();

            var timeBefore = DateTime.Now;
            BasicClass.WaitElement(_driver, menuTypes);

            var timeAfter = DateTime.Now;
            var loadTime = timeAfter - timeBefore;
            Assert.IsTrue(loadTime.Seconds < 2, "Loading is too long");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
