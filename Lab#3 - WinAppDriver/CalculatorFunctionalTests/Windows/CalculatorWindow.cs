using CalculatorFunctionalTests.Extensions;
using CalculatorFunctionalTests.ViewModel;
using System;

namespace CalculatorFunctionalTests.Windows
{
    public class CalculatorWindow : Window
    {
        public string Result { get; }

        public CalculatorWindow Clear()
        {
            Driver.FindElementByName("Clear").Click();
            return this;
        }

        public CalculatorWindow SelectNumber(int operand)
        {
            throw new NotImplementedException();
        }

        public CalculatorWindow SelectOperator(Operator @operator)
        {
            throw new NotImplementedException();
        }

        public CalculatorWindow PerformOperation()
        {
            throw new NotImplementedException();
        }
    }
}
