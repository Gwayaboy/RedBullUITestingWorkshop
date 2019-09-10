using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShopWebFunctionalTests.Step_1.Pages
{
    public class BasketPage : Page
    {
        private const string rowItemSelector = 
            "div.esh-catalog-items.row > article.esh-basket-items.row";

        public int NumberOfItems =>
            WebDriver.FindElements(By.CssSelector(rowItemSelector)).Count();
 
        public ProductViewModel[] Items => new ProductViewModel[0];
    }
}