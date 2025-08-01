using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HerokuOperations
{
    // Interface definition for Shadow DOM interactions
    internal interface ShadowDOM
    {
        string GetFirstShadowHostText();
        string GetSecondShadowHostText();
        string GetNestedShadowText();
    }

    // Implementation class for ShadowDOM using Selenium JS execution
    public class ShadowDOMPage : ShadowDOM
    {
        private readonly IWebDriver _driver;

        public ShadowDOMPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
        }

        // Gets paragraph text from first shadow root
        public string GetFirstShadowHostText()
        {
            var js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript(@"
                const shadowRoot = document.querySelector('my-paragraph').shadowRoot;
                return shadowRoot.querySelector('span').textContent.trim();
            ");
        }

        // Gets paragraph text from second shadow host
        public string GetSecondShadowHostText()
        {
            var js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript(@"
                const shadowRoot = document.querySelectorAll('my-paragraph')[1].shadowRoot;
                return shadowRoot.querySelector('span').textContent.trim();
            ");
        }

        // Gets nested shadow DOM text (if any)
        public string GetNestedShadowText()
        {
            var js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript(@"
                const host = document.querySelector('my-paragraph-nested');
                const root1 = host.shadowRoot;
                const nestedHost = root1.querySelector('nested-child');
                const nestedRoot = nestedHost.shadowRoot;
                return nestedRoot.querySelector('span').textContent.trim();
            ");
        }
    }

    // Test class using MSTest framework
    [TestClass]
    public class ShadowDOMTests
    {
        private IWebDriver driver;
        private ShadowDOM shadowDom;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            shadowDom = new ShadowDOMPage(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test_GetFirstShadowHostText()
        {
            string text = shadowDom.GetFirstShadowHostText();
            Assert.AreEqual("My default text", text);
        }

        [TestMethod]
        public void Test_GetSecondShadowHostText()
        {
            string text = shadowDom.GetSecondShadowHostText();
            Assert.AreEqual("Let's have some different text!", text);
        }

        [TestMethod]
        public void Test_NestedShadowText()
        {
            string text = shadowDom.GetNestedShadowText();
            Assert.AreEqual("Nested default text", text);
        }

        [TestMethod]
        public void Test_PageTitle()
        {
            Assert.AreEqual("The Internet", driver.Title);
        }
    }
}
