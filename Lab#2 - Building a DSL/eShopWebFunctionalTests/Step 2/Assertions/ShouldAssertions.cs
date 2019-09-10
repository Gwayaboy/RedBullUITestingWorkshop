

using eShopWebFunctionalTests.Step_1.Pages;

namespace eShopWebFunctionalTests.Step_2.Assertions
{
    public static class ShouldExtensions
    {
        public static BasketPageAssertions Should(this BasketPage page)
        {
            return new BasketPageAssertions(page);
        }

    }
}
