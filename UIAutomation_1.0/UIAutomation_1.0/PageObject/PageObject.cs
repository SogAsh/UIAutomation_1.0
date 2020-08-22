using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace UIAutomation_1._0
{
    public class PageObject
    {
        protected int time = 2000;
        protected IWebDriver driver;

        #region Locators
        //for WhenIsCount_True()
        public static By enterpriseTab = By.XPath("//a[@class='HeaderMenu-link no-underline py-3 d-block d-lg-inline-block'][contains(text(),'Enterprise')]");
        public static By pricingTab = By.XPath("//summary[contains(text(),'Pricing')]");
        public static By mainIcon = By.CssSelector(".mr-4[href*='https://github.com/']");
        public static By insertValue = By.XPath("//input[@placeholder='Search GitHub']");
        public static By searchClick = By.XPath("//span[@class='js-jump-to-badge-search-text-global']");
        public static By countRepozitory = By.XPath("//h3[contains(text(),' repository results')]");
        public static int _countResults = 501;
        public static string countResults = _countResults + " repository results";
        public static By restSharpLink = By.LinkText("restsharp/RestSharp");

        //for WhenIncognito_Close()
        public static By marketTab2 = By.XPath("//li/a[@href='/marketplace']");
        public static By menuTypes = By.XPath("//h4[@class='text-mono mb-3 text-normal']");

        //for WhenIsNotPresent_ThrowException()
        public static By singIn = By.XPath("//div/a[@href='/login']");
        public static string usernameForm = "Username";
        #endregion

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        protected void SetUp()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://github.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
    }
}
