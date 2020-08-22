using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace UIAutomation_1._0
{
    [TestFixture]
    public class Tests : PageObject
    {
        [Test]
        public void WhenIsCount_True()
        {
            driver.FindElement(PageObject.enterpriseTab).Click();
            Thread.Sleep(time);
            /*
            driver.FindElement(PageObject.pricingTab).Click();
            Thread.Sleep(time);

            SelectElement pricingElement = new SelectElement(driver.FindElement(By.XPath("//summary[contains(text(),'Pricing')]")));
            pricingElement.SelectByText("Compare plans");
            Thread.Sleep(time);
            */

            driver.FindElement(PageObject.mainIcon).Click();
            Thread.Sleep(time);
            driver.FindElement(PageObject.insertValue).SendKeys("RestSharp");
            Thread.Sleep(time);
            driver.FindElement(PageObject.searchClick).Click();
            Thread.Sleep(time);
            //IJavaScriptExecutor scroll = (IJavaScriptExecutor)driver;
            //scroll.ExecuteScript("window.scrollby(0,300)");

            //Count of results
            IWebElement countElement = driver.FindElement(PageObject.countRepozitory);

            var actualCount = countElement.Text;
            var expectedCount = PageObject.countResults;
            Assert.AreEqual(expectedCount, actualCount, "Expected count of job is not equal the actual count");

            driver.FindElement(PageObject.restSharpLink).Click();
        }
    }
}