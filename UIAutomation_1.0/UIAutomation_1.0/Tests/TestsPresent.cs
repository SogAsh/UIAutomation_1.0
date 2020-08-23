using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace UIAutomation_1._0
{
    public class TestsPresent : BasicClass
    {
        public static By singIn = By.XPath("//div/a[@href='/login']");
        public static string usernameForm = "Username";

        public TestsPresent(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Test]
        public void WhenIsTrue_Present_WhenIsFalse_TrowException() 
        {
            var signInButton = new TestsPresent(driver);
            Assert.IsTrue(signInButton.UsernameForm_WhenIsNotPresent_ThrowException(), "sign in form is exist");
        }

        bool UsernameForm_WhenIsNotPresent_ThrowException()
        {
            driver.FindElement(singIn).Click();
            Thread.Sleep(time);
            try
            {
                driver.PageSource.Contains(usernameForm);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
