using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace UIAutomation_1._0
{
    public class Tests
    {
        [Test]
        public static void CheckCountResults()
        {
            int time = 2000;

            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));

            driver.Navigate().GoToUrl("https://github.com/");
            //Thread.Sleep(time);

            driver.Manage().Window.Maximize();
            //Thread.Sleep(time);

            //Input data
            driver.FindElement(By.XPath("//input[@type = 'text']")).SendKeys("RestSharp");
            Thread.Sleep(time);

            //Find
            driver.FindElement(By.XPath("//span[@class = 'js-jump-to-badge-search-text-global']")).Click();
            Thread.Sleep(time);

            //driver.FindElement(By.LinkText("/restsharp/RestSharp")).Click();
            //Thread.Sleep(time);




            //Count of results
            IWebElement countElement = driver.FindElement(By.XPath("//div/div[3]/div/div[1]/h3"));

            var actualCount = countElement.Text;
            var expectedCount = Data.countResults;
            Assert.AreEqual(expectedCount, actualCount, "Expected count of job is not equal the actual count");

            //restsharp/RestSharp
            driver.FindElement(By.XPath("//a[@data-hydro-click-hmac = 'a10bea7d84a95907d618942261c9876dea894d78056f037649cf0a572fc76211']")).Click();
            Thread.Sleep(time);



            driver.Quit();

            //Fluent assertion
        }

        
        [Test]
        public static void OpenIncognito()
        {
            int time = 2000;

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));

            driver.Navigate().GoToUrl("https://github.com/");
            Thread.Sleep(time);

            driver.Quit();
        }
        


    }
}