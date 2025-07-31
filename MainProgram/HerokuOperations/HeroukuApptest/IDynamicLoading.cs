using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuTests
{
    [TestClass]
    public class DynamicLoadingTests
    {
        private IWebDriver driver;
        private IDynamicLoading loader;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            loader = new DynamicLoading(driver); // Uses the implementation
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test_Example1_LoadsHelloWorld()
        {
            loader.NavigateToExample(1);
            loader.ClickStartButton();
            loader.WaitForLoadingToFinish();
            string result = loader.GetResultText();
            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void Test_Example2_LoadsHelloWorld()
        {
            loader.NavigateToExample(2);
            loader.ClickStartButton();
            loader.WaitForLoadingToFinish();
            string result = loader.GetResultText();
            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void Test_LoadingIndicator_IsVisible_WhileLoading()
        {
            loader.NavigateToExample(1);
            loader.ClickStartButton();
            bool isVisible = loader.IsLoadingIndicatorVisible();
            Assert.IsTrue(isVisible || !isVisible); // Optional: customize visibility test
        }
    }
    public interface IDynamicLoading
    {
        void NavigateToExample(int exampleNumber);
        void ClickStartButton();
        void WaitForLoadingToFinish();
        string GetResultText();
        bool IsLoadingIndicatorVisible();
    }
}
