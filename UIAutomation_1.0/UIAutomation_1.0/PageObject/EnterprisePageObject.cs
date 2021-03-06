﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UIAutomation_1._0.PageObject
{
    public class EnterprisePageObject
    {
        private IWebDriver _driver;

        public static string expectedContactSales = "Contact Sales";
        public static By contactSales = By.LinkText("Contact Sales");

        public EnterprisePageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetText_ContactSales()  //достаем текст кнопки Contact Sales
        {
            string contactSalesButton = _driver.FindElement(contactSales).Text;
            return contactSalesButton;
        }
    }
}
