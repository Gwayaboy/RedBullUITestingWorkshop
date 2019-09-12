using CalculatorFunctionalTests.Windows;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorFunctionalTests.Configuration
{
    public class WindowHost : IDisposable
    {
        private WindowsDriver<WindowsElement> _driver;

        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        private WindowHost(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            AppDomain.CurrentDomain.DomainUnload += CurrentDomainDomainUnload;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
        }

        private void CurrentDomainDomainUnload(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.DomainUnload -= CurrentDomainDomainUnload;
            Dispose();
        }

        public TWindow StartMain<TWindow>()
         where TWindow : Window, new()
        {
            return Window.GoTo<TWindow>(_driver);
        }

        public static WindowHost StartCalculator()
        {
            var calculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
            var appCapabilities = new DesiredCapabilities();

            appCapabilities.SetCapability("app", calculatorAppId);
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            var driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            WindowsElement header;

            // Identify calculator mode by locating the header
            try
            {
                header = driver.FindElementByAccessibilityId("Header");
            }
            catch
            {
                header = driver.FindElementByAccessibilityId("ContentPresenter");
            }

            // Ensure that calculator is in standard mode
            if (!header.Text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
            {
                driver.FindElementByAccessibilityId("TogglePaneButton").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var splitViewPane = driver.FindElementByClassName("SplitViewPane");
                splitViewPane.FindElementByName("Standard Calculator").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (!header.Text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException("Calculator is not in in standard mode");
            }

            // Locate the calculatorResult element
            var calculatorResult = driver.FindElementByAccessibilityId("CalculatorResults");
            if (calculatorResult == null) throw new NullReferenceException("cannot Locate the calculatorResult element");

            return new WindowHost(driver);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_driver != null)
                    {
                        _driver.Quit();
                        _driver.Dispose();
                        _driver = null;
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
