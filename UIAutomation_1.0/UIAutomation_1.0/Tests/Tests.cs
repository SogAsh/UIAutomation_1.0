using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Globalization;
using UIAutomation_1._0.PageObject;

namespace UIAutomation_1._0
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

           /* ѕќ–≈Ўј“№
            driver.FindElement(MainPageObject.pricingTab).Click();
            Thread.Sleep(time);

            SelectElement pricingElement = new SelectElement(driver.FindElement(By.XPath("//summary[contains(text(),'Pricing')]")));
            pricingElement.SelectByText("Compare plans");
            Thread.Sleep(time);
            */

        [Test]
        public void GetText_ContactSales_WhenItIs_AreEqual()
        {
            var mainPage = new MainPageObject(driver); //создаем экземпл€р класса MainPageObject
            var enterprisePage = new EnterprisePageObject (driver); //создаем экземпл€р класса EnterprisePageObject

            mainPage
                .GoToEnterprisePage(); //переходим на страницу Enterprise

            string actualContactSales = enterprisePage.GetText_ContactSales(); //находим текст кнопки "Contact Sales"
            Assert.AreEqual(EnterprisePageObject.expectedContactSales, actualContactSales,  "Expected Contact Sales button is not equal the actual button");

            mainPage
                .GoToMainPage(); //переходим на главную страницу
        }

        [Test]
        public void CheckExpectedCount_WhenItIs_AreEqual()
        {
            var mainPage = new MainPageObject(driver); //создаем экземпл€р класса MainPageObject
            var searchResultPage = new SearchResultPageObject(driver);

            mainPage
                .InsertValue_RestSharp(); //вводим текст в поле Search

            var actualCount = searchResultPage.GetText_ResualCount(); //находим текст количества результатов
            var expectedCount = SearchResultPageObject.countResults;
            Assert.AreEqual(expectedCount, actualCount, "Expected count of job is not equal the actual count");

            searchResultPage
                .GoToRestSharpLink();
            mainPage
                .GoToMainPage();
        }
    }
}