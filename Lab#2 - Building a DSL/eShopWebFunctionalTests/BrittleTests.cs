using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace eShopWebFunctionalTests
{
    [TestClass]
    public class BrittleTests
    {
        private IWebDriver _browser;

        [TestInitialize]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");

            _browser = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            _browser.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Registered_User_Can_buy_a_cup_of_T()
        {
            _browser.Navigate().GoToUrl("http://localhost:5106");
            var type = new SelectElement(_browser.FindElement(By.Id("CatalogModel_TypesFilterApplied")));
            type.SelectByText("Mug");
            _browser.FindElement(By.CssSelector("body > div > section.esh-catalog-filters > div > form > input")).Click();

            _browser.FindElement(By.CssSelector("body > div > div > div.esh-catalog-items.row > div:nth-child(2) > form > input.esh-catalog-button")).Click();

            _browser.FindElement(By.CssSelector("body > div > div > form > div > div.row > section.esh-basket-item.col-xs-push-7.col-xs-4 > input")).Click();

            _browser.FindElement(By.Id("Input_Email")).SendKeys("demouser@microsoft.com");
            _browser.FindElement(By.Id("Input_Password")).SendKeys("Pass@word1");
            _browser.FindElement(By.CssSelector("body > div > div > div > div > section > form > div:nth-child(6) > button")).Click();

            _browser.FindElement(By.CssSelector("#logoutForm > section.esh-identity-section > div")).Click();
            _browser.FindElement(By.CssSelector("#logoutForm > section.esh-identity-drop > a:nth-child(1)")).Click();
            _browser.FindElement(By.CssSelector(".esh-orders-link")).Click();


            //THis test fails because & is escaped in the page source.
            // We could look for the item's description in the page using the css selector : ".esh-orders-detail-item--middle"
            Assert.IsTrue(_browser.PageSource.Contains(".NET Black & White Mug"));

        }

        [TestCleanup]
        public void TearDown()
        {
            _browser.Quit();
            _browser.Dispose();
            _browser = null;
        }
    }
}
