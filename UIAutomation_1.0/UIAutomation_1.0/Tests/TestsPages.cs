using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Globalization;
using UIAutomation_1._0.PageObject;
using FluentAssertions;

namespace UIAutomation_1._0
{
    [TestFixture]
    public class TestsPages : BasicClass
    {
        [Test]
        public void GetText_ContactSales_WhenItIs_AreEqual()
        {
            var mainPage = new MainPageObject(_driver); //������� ��������� ������ MainPageObject
            var enterprisePage = new EnterprisePageObject (_driver); //������� ��������� ������ EnterprisePageObject
            
            mainPage
                .GoToEnterprisePage(); //��������� �� �������� Enterprise
            ShouldLocate(_driver, DataBase.enterprisePage); //�������� 

            string actualContactSales = enterprisePage.GetText_ContactSales(); //������� ����� ������ "Contact Sales"
            //Assert.AreEqual(EnterprisePageObject.expectedContactSales, actualContactSales,  "Expected Contact Sales button is not equal the actual button");
            
            //FluentAssertions
            actualContactSales.Should().Be(EnterprisePageObject.expectedContactSales, "Expected Contact Sales button is not equal the actual button");

            mainPage
                .GoToMainPage(); //��������� �� ������� ��������
            ShouldLocate(_driver, DataBase.targetUrl); //�������� 
        }

        [Test]
        public void CheckEnterprisePrise_WhenItIs_AreEqual()
        {
            var mainPage = new MainPageObject(_driver); //������� ��������� ������ MainPageObject
            var pricingPage = new PricingPageObject(_driver); //������� ��������� ������ PricingPageObject

            mainPage
                .GoToPricingPage() //��������� �� �������� Pricing
                .GetText_EnterprisePrice();
            WaitElement(_driver, PricingPageObject.enterprisePrice);

            string actualEnterprisePrice = pricingPage.GetText_EnterprisePrice(); //������� ��������� ������ enterprise
            actualEnterprisePrice.Should().Be(DataBase.enterprisePrice, "Expected enterprise price is not equal the actual price");
        }
        

        [Test]
        public void CheckResultCount_WhenItIs_AreEqual()
        {
            var mainPage = new MainPageObject(_driver); //������� ��������� ������ MainPageObject
            var searchResultPage = new SearchResultPageObject(_driver);

            mainPage
                .InsertValue_RestSharp(); //������ ����� � ���� Search
            WaitElement(_driver, SearchResultPageObject.countRepozitory);

            string actualCount = searchResultPage.GetText_ResualCount(); //������� ����� ���������� �����������
            //Assert.AreEqual(SearchResultPageObject.countResults, actualCount, "Expected count of job is not equal the actual count");

            //FluentAssertions
            actualCount.Should().Be(DataBase.countResults, "Expected count of job is not equal the actual count");

            searchResultPage
                .GoToRestSharpLink();
            WaitElement(_driver, SearchResultPageObject.restSharpPage);

            mainPage
                .GoToMainPage();
            ShouldLocate(_driver, DataBase.targetUrl); //�������� 
        }
    }
}