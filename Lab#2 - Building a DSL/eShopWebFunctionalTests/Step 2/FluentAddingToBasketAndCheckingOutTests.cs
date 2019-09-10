using eShopWebFunctionalTests.Configuration;
using eShopWebFunctionalTests.Step_1.Pages;
using eShopWebFunctionalTests.Step_2.Assertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace eShopWebFunctionalTests.Step_2
{
    [TestClass]
    public class AddingToBasketAndCheckingOutTests : FunctionalUITest
    {
        public AddingToBasketAndCheckingOutTests() : base(BrowserHost.Chrome) { }

        [TestMethod]
        public void Can_add_selected_item_basket()
        {
            //Arrange
            var homePage = Browser.NavigateToInitial<HomePage>("http://localhost:5106");
            var expectedDotNetBlackAndWhiteMug = new ProductViewModel { Description = ".NET Black & White Mug" };

            //Act
            var actualPage = homePage.AddToBasketByProductId(2);

            //Assert
            actualPage
                .Should()
                .Be<BasketPage>(withExpectedTitle: "Basket - Microsoft.eShopOnWeb")
                               .And
                               .OnlyHave(expectedDotNetBlackAndWhiteMug);
        }

    }
}
