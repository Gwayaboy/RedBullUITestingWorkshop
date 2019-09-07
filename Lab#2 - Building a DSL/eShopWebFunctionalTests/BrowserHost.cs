using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eShopWebFunctionalTests
{
    public class BrowserHost : IDisposable
    {
        private IWebDriver _webdriver;

        private BrowserHost(IWebDriver webDriver)
        {
            _webdriver = webDriver;
            _webdriver.Manage().Window.Maximize();
        }

        public TPage NavigateToInitial<TPage>(string url)
          where TPage : Page, new()
        {
            return Page.NavigateToInitial<TPage>(_webdriver, url);
        }

        public static BrowserHost Chrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");

            return new BrowserHost(new ChromeDriver(Directory.GetCurrentDirectory(), options));
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_webdriver != null)
                    {
                        _webdriver.Quit();
                        _webdriver.Dispose();
                        _webdriver = null;
                    }
                }
                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }
}
