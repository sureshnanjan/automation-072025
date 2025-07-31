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
            loader = new DynamicLoadingPage(driver); // ← Replace with your actual class
        }

        [TestCleanup]
        public void Teardown() => driver.Quit();

        [TestMethod]
        public void Test_LoadsExample1()
        {
            loader.NavigateToExample(1);
            loader.ClickStartButton();
            loader.WaitForLoadingToFinish();
            Assert.AreEqual("Hello World!", loader.GetResultText());
        }

        [TestMethod]
        public void Test_LoadsExample2()
        {
            loader.NavigateToExample(2);
            loader.ClickStartButton();
            loader.WaitForLoadingToFinish();
            Assert.AreEqual("Hello World!", loader.GetResultText());
        }
    }
}
