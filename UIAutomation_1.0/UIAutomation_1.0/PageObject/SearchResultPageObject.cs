using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIAutomation_1._0.PageObject
{
    public class SearchResultPageObject
    {
        private IWebDriver _driver;

        public static By restSharpLink = By.LinkText("restsharp/RestSharp");
        public static By countRepozitory = By.XPath("//h3[contains(text(),' repository results')]");
        public static string countResults = 501 + " repository results";

        public SearchResultPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public string GetText_ResualCount()
        {
            string actualCount = _driver.FindElement(countRepozitory).Text; //достаем актальное количество результатов
            return actualCount;
        }

        public SearchResultPageObject GoToRestSharpLink()
        {
            _driver.FindElement(restSharpLink).Click(); //клик по ссылке restsharp/RestSharp
            return new SearchResultPageObject(_driver);
        }
    }
}
