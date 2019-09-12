using CalculatorFunctionalTests.Configuration;
using CalculatorFunctionalTests.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFunctionalTests
{
    public abstract class FunctionalTests 
    {
        protected static WindowHost WindowHost { get; private set; }

        public static void SetUp(TestContext testContext, Func<WindowHost> windowFactory)
        {
            WindowHost = windowFactory();
        }

        public static void TearDown(TestContext testContext)
        {
            // Close the application and delete the session
            if (WindowHost != null)
            {
                WindowHost.Dispose();
                WindowHost = null;
            }
        }
    }
}
