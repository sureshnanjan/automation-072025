// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlowResourceTest.cs" author="Jagadeeswar Reddy Arava">
//   © 2025 Jagadeeswar Reddy Arava. All rights reserved.
// </copyright>
//

using HerokuOperations;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to verify behavior of the Slow Resources page.
    /// </summary>
    public class SlowResourcesTest
    {
        private IWebDriver _driver;
        private SlowResource _page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/slow");
            _page = new SlowResource(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Title_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "The Internet";

            // Act
            string actualTitle = _page.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected.");
        }

        [Test]
        public void Description_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expectedTextStart = "This page demonstrates";

            // Act
            string actualText = _page.GetDescription();

            // Assert
            StringAssert.StartsWith(expectedTextStart, actualText, "Description text does not start as expected.");
        }


    }
}
