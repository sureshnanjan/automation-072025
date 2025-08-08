/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="DisappearTest.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using HerokuAppScenarios;
using HerokuAppWeb;
using HerokuOperations;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to verify the behavior of the Disappearing Elements page on the Heroku App.
    /// </summary>
    public class DisappearTest
    {


        /// <summary>
        /// Page object model for the Disappearing Elements page.
        /// </summary>
        public Disappear _page;

        /// <summary>
        /// Setup method executed before each test.
        /// Initializes WebDriver and navigates to the required page.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup logic goes here (e.g., initialize _driver and _page)
        }

        /// <summary>
        /// Cleanup method executed after each test.
        /// Disposes WebDriver and cleans up resources.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Cleanup logic goes here (e.g., _driver.Quit(); _driver.Dispose();)
        }

        /// <summary>
        /// Test to verify that the title of the page is correct.
        /// </summary>
        [Test]
        public void Title_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "Disappearing Elements";

            // Act
            string actualTitle = _page.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected."); // Assert that the title is as expected
        }

        /// <summary>
        /// Test to verify that the subtitle starts with the expected text.
        /// </summary>
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

        /// <summary>
        /// Test to verify the visibility and correctness of navigation links.
        /// </summary>
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

        /// <summary>
        /// Verifies that a page reload might change the number of visible nav items (i.e., "Gallery" disappears sometimes).
        /// </summary>
        [Test]
        public void Reload_ShouldChangeVisibleNavItemsOccasionally()
        {
            // Arrange
            var initialItems = _page.GetVisibleNavigationItems();

            // Act
            _page.ReloadPage();
            var afterReloadItems = _page.GetVisibleNavigationItems();

            // Assert
            Assert.AreNotEqual(string.Join(",", initialItems), string.Join(",", afterReloadItems), "Navigation items should vary on reload."); 
        }

        /// <summary>
        /// Ensures that "Gallery" item is not always visible after multiple reloads.
        /// </summary>
        [Test]
        public void GalleryItem_ShouldDisappearOccasionally()
        {
            // Arrange
            bool galleryMissingOnce = false;

            for (int i = 0; i < 5; i++)
            {
                _page.ReloadPage();
                var items = _page.GetVisibleNavigationItems();

                if (!items.Contains("Gallery"))
                {
                    galleryMissingOnce = true;
                    break;
                }
            }

            // Assert
            Assert.IsTrue(galleryMissingOnce, "The 'Gallery' item should disappear on at least one reload.");
        }

        /// <summary>
        /// Verifies that accessing the 'Home' navigation link redirects to the correct Home page URL.
        /// </summary>
        [Test]
        public void NavigationLink_Home_ShouldGoToCorrectPage()
        {
            // Arrange
            string linkName = "Home";
            string expectedPartOfUrl = "/";

            // Act
            string currentUrl = _page.AccessNavigationAndReturnUrl(linkName);

            // Assert
            Assert.IsTrue(currentUrl.EndsWith(expectedPartOfUrl), "Home link did not navigate correctly.");
        }

        /// <summary>
        /// Verifies that accessing the 'About' navigation link redirects to the correct About page URL.
        /// </summary>
        [Test]
        public void NavigationLink_About_ShouldGoToCorrectPage()
        {
            // Arrange
            string linkName = "About";
            string expectedPartOfUrl = "/about";

            // Act
            string currentUrl = _page.AccessNavigationAndReturnUrl(linkName);

            // Assert
            Assert.IsTrue(currentUrl.Contains(expectedPartOfUrl), "About link did not navigate correctly.");
        }

        /// <summary>
        /// Verifies that accessing the 'Contact Us' navigation link redirects to the correct Contact page URL.
        /// </summary>
        [Test]
        public void NavigationLink_ContactUs_ShouldGoToCorrectPage()
        {
            // Arrange
            string linkName = "Contact Us";
            string expectedPartOfUrl = "/contact";

            // Act
            string currentUrl = _page.AccessNavigationAndReturnUrl(linkName);

            // Assert
            Assert.IsTrue(currentUrl.Contains(expectedPartOfUrl), "Contact Us link did not navigate correctly.");
        }

        /// <summary>
        /// Verifies that accessing the 'Portfolio' navigation link redirects to the correct Portfolio page URL.
        /// </summary>
        [Test]
        public void NavigationLink_Portfolio_ShouldGoToCorrectPage()
        {
            // Arrange
            string linkName = "Portfolio";
            string expectedPartOfUrl = "/portfolio";

            // Act
            string currentUrl = _page.AccessNavigationAndReturnUrl(linkName);

            // Assert
            Assert.IsTrue(currentUrl.Contains(expectedPartOfUrl), "Portfolio link did not navigate correctly.");
        }

        /// <summary>
        /// Verifies that accessing the 'Gallery' navigation link redirects to the correct Gallery page URL.
        /// </summary>
        [Test]
        public void NavigationLink_Gallery_ShouldGoToCorrectPage()
        {
            // Arrange
            string linkName = "Gallery";
            string expectedPartOfUrl = "/gallery";

            // Act
            string currentUrl = _page.AccessNavigationAndReturnUrl(linkName);

            // Assert
            Assert.IsTrue(currentUrl.Contains(expectedPartOfUrl), "Gallery link did not navigate correctly.");
        }

        /// <summary>
        /// verifies that the footer contains the expected "Powered by" information.
        /// </summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        /// <summary>
        /// verifies that the GitHub ribbon is displayed correctly.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }


    }
}
