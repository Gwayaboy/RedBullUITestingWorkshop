using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopWebFunctionalTests.Configuration
{
    [TestClass]
    public abstract class FunctionalUITest
    {
        private readonly Func<BrowserHost> _browserHostFactory;
        protected BrowserHost Browser { get; private set; }

        public FunctionalUITest(Func<BrowserHost> browserHostFactory)
        {
            _browserHostFactory = browserHostFactory;
        }

        [TestInitialize]
        public virtual void RunBeforeEachTests()
        {
            Browser = _browserHostFactory();
        }


        [TestCleanup]
        public virtual void RunAfterEachTests()
        {
            if (Browser != null)
            {
                Browser.Dispose();
                Browser = null;
            }
        }
    }
}
