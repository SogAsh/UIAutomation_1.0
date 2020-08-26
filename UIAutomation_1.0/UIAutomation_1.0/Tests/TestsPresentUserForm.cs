using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using FluentAssertions;

namespace UIAutomation_1._0
{
    public class TestsPresentUserForm : BasicClass
    {
        public static By singIn = By.XPath("//a[@href='/login']");
        public static string usernameForm = "Username";

        [Test]
        public void WhenIsTrue_Present_WhenIsFalse_TrowException() 
        {
            _driver.FindElement(singIn).Click();

            Assert.IsTrue(UsernameForm_WhenIsNotPresent_ThrowException(), "sign in form is exist");
        }

        public bool UsernameForm_WhenIsNotPresent_ThrowException()
        {
            try
            {
                _driver.PageSource.Contains(usernameForm);
                return true;
            }
                        catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
