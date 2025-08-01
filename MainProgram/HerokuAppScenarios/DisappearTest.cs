// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisappearTest.cs" author="Jagadeeswar Reddy Arava">
//   © 2025 Jagadeeswar Reddy Arava. All rights reserved.
// </copyright>
//

using HerokuAppScenarios;
using HerokuOperations.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Tests to verify the behavior of the Disappearing Elements page.
    /// </summary>
    public class DisappearTest
    {
        public IWebDriver _driver;
        public Disappear _page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/disappearing_elements");
            _page = new Disappear(_driver);
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
            string expectedTitle = "Disappearing Elements";

            // Act
            string actualTitle = _page.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected.");
        }

        [Test]
        public void Subtitle_ShouldBeCorrect()
        {
            // Arrange
            string expectedSubtitleStart = "This example demonstrates";

            // Act
            string actualSubtitle = _page.GetSubTitle();

            // Assert
            StringAssert.StartsWith(expectedSubtitleStart, actualSubtitle, "Subtitle does not start as expected.");
        }


        [Test]
        public void NavigationItems_ShouldContainExpectedLinks()
        {
            // Arrange
            var possibleItems = new[] { "Home", "About", "Contact Us", "Portfolio", "Gallery" };

            // Act
            var visibleItems = _page.GetVisibleNavigationItems();

            // Assert
            Assert.IsTrue(visibleItems.Length >= 3, "There should be at least 3 navigation items.");

            foreach (string item in visibleItems)
            {
                CollectionAssert.Contains(possibleItems, item, $"Unexpected nav item: {item}");
            }
        }
    }
}
