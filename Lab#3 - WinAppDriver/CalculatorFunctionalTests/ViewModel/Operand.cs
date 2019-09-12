using AccessibilityIdAttribute = System.ComponentModel.DescriptionAttribute;

namespace CalculatorFunctionalTests.ViewModel
{
    public enum Operand
    {
        [AccessibilityId("num1Button")]
        One,

        [AccessibilityId("num2Button")]
        Two,

        [AccessibilityId("num3Button")]
        Three,
    }
}
