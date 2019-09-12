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
        public CalculatorWindow Calculator { get; private set; }


        [TestInitialize]
        public void Setup()
        {
            Calculator = WindowHost.StartMain<CalculatorWindow>();
            Calculator.Clear();
        }

        [TestMethod]
        public void CanAdd2Numbers()
        {
            //Arrange
            WindowHost
                .StartMain<CalculatorWindow>()
                .Clear()
                .SelectNumber(1)
                .SelectOperator(Operator.Addition)
                .SelectNumber(1);

            Calculator.PerformOperation();

            //Act
            Assert.AreEqual("2", Calculator.Result);
        }

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
