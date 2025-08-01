using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuOperationsTests
{
    [TestClass]
    public class ShadowDomHandlerTests
    {
        private IWebDriver driver;
        private ShadowDomHandler shadowDom;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
            shadowDom = new ShadowDomHandler(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GetFirstShadowHostText_ReturnsExpectedText()
        {
            // Arrange
            var expectedText = "My default text";
            // Act
            var actualText = shadowDom.GetFirstShadowHostText();
            // Assert
            Assert.AreEqual(expectedText, actualText, "First Shadow Host text did not match expected value.");
        }

        [TestMethod]
        public void GetSecondShadowHostText_ReturnsExpectedText()
        {
            // Arrange
            var expectedText = "Let's have some different text!";
            // Act
            var actualText = shadowDom.GetSecondShadowHostText();
            // Assert
            Assert.AreEqual(expectedText, actualText, "Second Shadow Host text did not match expected value.");
        }
        [TestMethod]
        public void GetNestedShadowText_ReturnsExpectedText()
        {
            // Arrange
            var expectedText = "Let's have some different text!";
            // Act
            var actualText = shadowDom.GetNestedShadowText();
            // Assert
            Assert.AreEqual(expectedText, actualText, "Nested Shadow DOM text did not match expected value.");
        }
    }
}
