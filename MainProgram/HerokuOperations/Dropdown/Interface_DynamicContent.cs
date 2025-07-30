using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace DynamicContentTests
{
    [TestClass]
    public class DynamicContentTests
    {
        private IWebDriver driver;
        private const string url = "https://the-internet.herokuapp.com/dynamic_content";

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Test_PageLoadsSuccessfully()
        {
        }

        [TestMethod]
        public void Test_ContentChangesOnRefresh()
        {
        }

        private List<string> GetContentTexts()
        {
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
