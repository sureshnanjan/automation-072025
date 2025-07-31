using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuTests
{
    [TestClass]
    public class ShadowDOMTests
    {
        private IWebDriver driver;
        private IShadowDOM shadowDom;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            shadowDom = new ShadowDOMPage(driver); // ← Replace with your actual class
        }

        [TestCleanup]
        public void Teardown() => driver.Quit();

        [TestMethod]
        public void Test_GetShadowTexts()
        {
            string text1 = shadowDom.GetFirstShadowHostText();
            string text2 = shadowDom.GetSecondShadowHostText();
            string nested = shadowDom.GetNestedShadowText();

            Assert.IsFalse(string.IsNullOrEmpty(text1));
            Assert.IsFalse(string.IsNullOrEmpty(text2));
            Assert.IsFalse(string.IsNullOrEmpty(nested));
        }
    }
}
