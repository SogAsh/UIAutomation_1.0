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
        private int time = 2000;
        private IWebDriver driver;

        public static By marketTab2 = By.XPath("//li/a[@href='/marketplace']");
        public static By menuTypes = By.XPath("//h4[@class='text-mono mb-3 text-normal']");

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            driver = new ChromeDriver(chromeOptions);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://github.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void WhenIncognito_Close()
        {
            driver.FindElement(PageObject.marketTab2).Click();

            var timeBefore = DateTime.Now;
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(PageObject.menuTypes));
            var timeAfter = DateTime.Now;
            var loadTime = timeAfter - timeBefore;
            Assert.IsTrue(loadTime.Seconds < 2, "Loading is too long");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
