using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using eShopWebFunctionalTests.Step_1.Pages;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;

namespace eShopWebFunctionalTests.Step_2.Assertions
{

    public class BasketPageAssertions : PageAssertions<BasketPage, BasketPageAssertions>
    {
        public BasketPageAssertions(BasketPage page) : base(page) { }

        public AndConstraint<BasketPageAssertions> OnlyHave(ProductViewModel expectedProduct)
        {
            var actualbasketItems = Subject.Items;

            Execute
               .Assertion
               .ForCondition(actualbasketItems.Single(a => AreEqual(a, expectedProduct)) != null)
               .FailWith($"\r\nExpected basket with : " +
               $"\r\n{Display(expectedProduct)}, \r\n but was {Display(actualbasketItems)}");

            return new AndConstraint<BasketPageAssertions>(this);
        }

        private bool AreEqual(ProductViewModel actualProduct, ProductViewModel expectedProduct)
        {
            return
                string.Equals(actualProduct.Description, expectedProduct.Description, StringComparison.InvariantCultureIgnoreCase);
        }

        private string Display(params ProductViewModel[] products)
        {
            return products.Length == 0 ?
                    "empty" :
                    ":\r\n" + string.Join(":\r\n\t-----------------\r\n", products.Select(a => Display(a)));
        }

        private string Display(ProductViewModel product)
        {
            return "\t" + JsonConvert.SerializeObject(product,
                                                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
