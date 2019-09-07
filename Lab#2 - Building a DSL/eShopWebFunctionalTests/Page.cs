using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopWebFunctionalTests
{
    public abstract class Page
    {
        protected IWebDriver WebDriver { get; private set; }

        public string Title => WebDriver.Title;

        public string Url  =>  WebDriver.Url;

        internal static TPage NavigateToInitial<TPage>(IWebDriver webDriver, string startUpUrl)
             where TPage : Page, new()
        {
            if (webDriver == null) throw new ApplicationException("Please provide with an instance of web driver to proceed");
            if (string.IsNullOrWhiteSpace(startUpUrl)) throw new ApplicationException("Please provide with a start up url");

            webDriver.Navigate().GoToUrl(startUpUrl);

            return new TPage { WebDriver = webDriver };
        }
    }
}
