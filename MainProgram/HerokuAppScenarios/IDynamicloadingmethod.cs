using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;
using System.Threading;

namespace HerokuOperationsTests
{
    [TestClass]
    public class DynamicLoadingTests
    {
        private IWebDriver driver;
        private DynamicLoading dynamicLoading;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            dynamicLoading = new DynamicLoading(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Example1_LoadsHelloWorldSuccessfully()
        {
            // Arrange
            dynamicLoading.NavigateToExample(1);

            // Act
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            var resultText = dynamicLoading.GetResultText();

            // Assert
            Assert.AreEqual("Hello World!", resultText, "The result text after loading was incorrect.");
        }

        [TestMethod]
        public void Example2_LoadsHelloWorldSuccessfully()
        {
            // Arrange
            dynamicLoading.NavigateToExample(2);

            // Act
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            var resultText = dynamicLoading.GetResultText();

            // Assert
            Assert.AreEqual("Hello World!", resultText, "The result text after loading was incorrect.");
        }

        [TestMethod]
        public void LoadingIndicator_IsVisibleDuringLoad()
        {
            // Arrange
            dynamicLoading.NavigateToExample(2);

            // Act
            dynamicLoading.ClickStartButton();

            // Small delay to allow spinner to appear before checking
            Thread.Sleep(500);
            bool isVisible = dynamicLoading.IsLoadingIndicatorVisible();

            // Assert
            Assert.IsTrue(isVisible, "Loading spinner was not visible after clicking Start.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NavigateToExample_InvalidExampleNumber_ThrowsException()
        {
            // Act
            dynamicLoading.NavigateToExample(3); // Only 1 and 2 allowed
        }
    }
}
