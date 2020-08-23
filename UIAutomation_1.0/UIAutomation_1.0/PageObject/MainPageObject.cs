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
        private IWebDriver driver;

        #region Locators
        //for WhenIsCount_True()
        public static By enterpriseTab = By.XPath("//a[@class='HeaderMenu-link no-underline py-3 d-block d-lg-inline-block'][contains(text(),'Enterprise')]");
        //public static By pricingTab = By.XPath("//summary[contains(text(),'Pricing')]");
        public static By mainIcon = By.CssSelector(".mr-4[href*='https://github.com/']");
        public static By insertValue = By.XPath("//input[@placeholder='Search GitHub']");
        public static By searchClick = By.XPath("//span[@class='js-jump-to-badge-search-text-global']");
        #endregion

        public MainPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public EnterprisePageObject GoToEnterprisePage() //переходим на страницу Enterprise
        {
            driver.FindElement(enterpriseTab).Click();
            return new EnterprisePageObject(driver);
        }

        public MainPageObject GoToMainPage() //переходим на главную страницу 
        {
            driver.FindElement(mainIcon).Click();
            return new MainPageObject(driver);
        }

        public SearchResultPageObject InsertValue_RestSharp() //вводим текст в поле Search
        {
            driver.FindElement(insertValue).SendKeys("RestSharp");
            driver.FindElement(searchClick).Click();
            return new SearchResultPageObject(driver);
        }
    }
}
