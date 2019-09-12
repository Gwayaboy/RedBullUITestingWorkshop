using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFunctionalTests.Windows
{
    public abstract class Window
    {

        protected WindowsDriver<WindowsElement> Driver { get; private set; }

        protected TWindow StartInitial<TWindow>(By byLocator, Action<IWebElement> performAction = null)
           where TWindow : Window, new()
        {
            var action = performAction ?? (e => e.Click());
            action(Driver.FindElement(byLocator));

            return new TWindow { Driver = Driver };
        }

        internal static TWindow GoTo<TWindow>(WindowsDriver<WindowsElement> driver)
             where TWindow : Window, new()
        {
            if (driver == null) throw new ApplicationException("Please provide with an instance of web driver to proceed");

            return new TWindow { Driver = driver };
        }


    }
}
