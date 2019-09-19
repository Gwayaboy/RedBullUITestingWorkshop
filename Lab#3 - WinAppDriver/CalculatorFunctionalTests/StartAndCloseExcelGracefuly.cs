using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace ExcelSplashScreenAutomation
{
    [TestClass]
    public class UnitTest1
    {
        public static WindowsDriver<WindowsElement> Session { get; private set; }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE");
            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
            Assert.IsNotNull(Session);
            // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
            Thread.Sleep(TimeSpan.FromSeconds(5));
            // When the application uses pre-launched existing instance, re-launching the application simply update 
            // the current application window to whatever current main window belonging to the same application 
            // process id
            Session.LaunchApp();
        }

        [TestMethod]
        public static void TestMethod1()
        {
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            if (Session == null) return;
            Session.Close();
            Session.Quit();
            Session.Dispose();
            Session = null;
        }
    }
}
