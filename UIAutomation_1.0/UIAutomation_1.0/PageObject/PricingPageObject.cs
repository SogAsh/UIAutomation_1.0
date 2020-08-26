using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomation_1._0.PageObject
{
    public class PricingPageObject
    {
        private IWebDriver _driver;

        public static By enterprisePrice = By.XPath("//h4[contains(text(),'$21 per user')]");

        public PricingPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public string GetText_EnterprisePrice()
        {
            string actualPrise = _driver.FindElement(enterprisePrice).Text; //достаем актальную цену для Enterprise
            return actualPrise;
        }
    }
}
