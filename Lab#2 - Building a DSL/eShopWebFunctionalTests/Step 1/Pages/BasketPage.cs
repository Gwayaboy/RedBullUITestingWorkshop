using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShopWebFunctionalTests.Step_1.Pages
{
    public class BasketPage : Page
    {
        public int NumberOfItems
        {
            get
            {
                var count = WebDriver.FindElements(By.CssSelector("article.esh-basket-items.row")).Count();
                return count == 0 ? 0 : count - 2;
            }
        }



        public ProductViewModel[] Items => new ProductViewModel[0];

    }
}