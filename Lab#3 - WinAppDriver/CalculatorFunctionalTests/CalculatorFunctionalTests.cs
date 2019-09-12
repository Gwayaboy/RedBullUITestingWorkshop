using System;
using CalculatorFunctionalTests.Configuration;
using CalculatorFunctionalTests.ViewModel;
using CalculatorFunctionalTests.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorFunctionalTests
{
    [TestClass]
    public class CalculatorFunctionalTests : FunctionalTests
    {

        [ClassInitialize]
        public static void RunBeforeAllTests(TestContext testContext)
        {
            SetUp(testContext, WindowHost.StartCalculator);
        }

        [ClassCleanup]
        public static void RunAfterAllTests(TestContext testContext)
        {
            TearDown(testContext);
        }
    }
}
