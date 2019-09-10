using eShopWebFunctionalTests.Configuration;
using eShopWebFunctionalTests.Step_1.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace eShopWebFunctionalTests.Step_1
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

            //Act
            var actualPage = homePage.AddToBasketByProductId(2);

            //Assert
            Assert.IsInstanceOfType(actualPage, typeof(BasketPage));
            Assert.IsTrue(actualPage.Url.EndsWith("/Basket"));
            Assert.AreEqual(actualPage.Title, "Basket - Microsoft.eShopOnWeb");
            Assert.AreEqual(actualPage.Items.Count(),1);
            Assert.AreEqual(actualPage.Items[0].Id, 2);
            Assert.AreEqual(actualPage.Items[0].Description, ".NET Black & White Mug");

        }

    }
}
