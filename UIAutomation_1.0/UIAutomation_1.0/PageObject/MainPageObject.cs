using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using UIAutomation_1._0.PageObject;

namespace UIAutomation_1._0
{
    public class MainPageObject
    {
        private IWebDriver _driver;
        protected static int time = 2000;

        #region Locators
        private readonly By enterpriseTab = By.XPath("//a[@class='HeaderMenu-link no-underline py-3 d-block d-lg-inline-block'][contains(text(),'Enterprise')]");
        private readonly By mainIcon = By.CssSelector(".mr-4[href*='https://github.com/']");
        private readonly By insertValue = By.XPath("//input[@placeholder='Search GitHub']");
        private readonly By searchClick = By.XPath("//span[@class='js-jump-to-badge-search-text-global']");

        public static By pricingTab = By.XPath("//summary[contains(text(),'Pricing')]");
        public static By comparePlans = By.XPath("//a[text()='Compare plans']");
        #endregion

        public MainPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public EnterprisePageObject GoToEnterprisePage() //переходим на страницу Enterprise
        {
            _driver.FindElement(enterpriseTab).Click();
            return new EnterprisePageObject(_driver);
        }

        public MainPageObject GoToMainPage() //переходим на главную страницу 
        {
            _driver.FindElement(mainIcon).Click();
            return new MainPageObject(_driver);
        }

        public void InsertValue_RestSharp() //вводим текст в поле Search
        {
            _driver.FindElement(insertValue).SendKeys("RestSharp");
            BasicClass.WaitElement(_driver, searchClick);

            _driver.FindElement(searchClick).Click();
        }

        public PricingPageObject GoToPricingPage() //переходим на страницу Pricing
        {
            _driver.FindElement(MainPageObject.pricingTab).Click(); //клик по вкладке Pricing
            BasicClass.WaitElement(_driver, MainPageObject.pricingTab);

            _driver.FindElement(MainPageObject.pricingTab).Click();
            
            BasicClass.WaitElement(_driver, MainPageObject.comparePlans);
            _driver.FindElement(MainPageObject.comparePlans).Click(); //выбор Сompare plans

            return new PricingPageObject(_driver);
        }
    }
}
