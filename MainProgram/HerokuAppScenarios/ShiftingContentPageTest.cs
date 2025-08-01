/*
* -----------------------------------------------------------------------------
* Project     : HerokuAppTests
* File        : ShiftingContentPageTest.cs
* Description : Tests for the Shifting Content page at /shifting_content.
* Author      : Jeya Mathesh G
* Created     : 2025-08-01
* -----------------------------------------------------------------------------
*/

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb;
using System;

namespace HerokuAppScenarios
{
    /// NUnit test suite for verifying shifting content page functionality.
    [TestFixture]
    public class ShiftingContentPageTest
    {
        private ChromeDriver driver;
        private IShiftingContentPage shiftingContentPage;

        /// Initializes ChromeDriver and navigates to the shifting content page.
        [SetUp]
        public void Setup()
        {
          
        }

        /// Cleans up driver resources after test execution.
        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // Properly releases browser resources
        }

        /// Verifies that the page title is correct.
        [Test]
        public void ShouldReturnCorrectTitle()
        {
            // Act
            string title = shiftingContentPage.GetTitle();

            // Assert
            Assert.AreEqual("Shifting Content", title, "The page title does not match the expected value.");
        }

        /// Ensures that the description text on the page is not null or empty.
        [Test]
        public void ShouldReturnNonEmptyDescription()
        {
            // Act
            string description = shiftingContentPage.GetDescription();

            // Assert
            Assert.IsNotNull(description, "Description should not be null.");
            Assert.IsNotEmpty(description, "Description should not be empty.");
        }

        /// Confirms that at least one navigation link is available on the page.
        [Test]
        public void ShouldReturnAtLeastOneLink()
        {
            // Act
            int linkCount = shiftingContentPage.GetLinkCount();

            // Assert
            Assert.Greater(linkCount, 0, "Expected at least one link in the navigation bar.");
        }

        /// Verifies that the number of link texts matches the link count and all are non-empty.
        [Test]
        public void ShouldReturnLinkTextsMatchingCount()
        {
            // Act
            string[] links = shiftingContentPage.GetAllLinkTexts();
            int count = shiftingContentPage.GetLinkCount();

            // Assert
            Assert.AreEqual(count, links.Length, "Mismatch between link count and link text array length.");

            foreach (string linkText in links)
            {
                Assert.IsNotNull(linkText, "Link text should not be null.");
                Assert.IsNotEmpty(linkText, "Link text should not be empty.");
            }
        }

        /// Optional test to validate that navigation links are unique.
        [Test]
        public void AllLinkTexts_ShouldBeUnique()
        {
            // Act
            var linkTexts = shiftingContentPage.GetAllLinkTexts();

            // Assert
            CollectionAssert.AllItemsAreUnique(linkTexts, "Navigation link texts are not unique.");
        }

        /// Ensures page link count remains stable across reloads (unless content shifts randomly).
        [Test]
        public void LinkCount_ShouldRemainConsistent_AfterRefresh()
        {
            // Arrange
            int initialCount = shiftingContentPage.GetLinkCount();

            // Act
            driver.Navigate().Refresh();
            int refreshedCount = shiftingContentPage.GetLinkCount();

            // Assert
            Assert.AreEqual(initialCount, refreshedCount, "Link count changed after page refresh.");
        }
        /// <summary>
        /// Verifies that the GitHub ribbon is displayed on the page.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Act
            bool isVisible = shiftingContentPage.IsGitHubRibbonVisible();

            // Assert
            Assert.IsTrue(isVisible, "GitHub ribbon should be visible on the page.");
        }

        /// <summary>
        /// Ensures that the GitHub ribbon has a non-empty, valid URL.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldHaveValidUrl()
        {
            // Act
            string url = shiftingContentPage.GetGitHubRibbonUrl();

            // Assert
            Assert.IsNotNull(url, "GitHub ribbon URL should not be null.");
            Assert.IsNotEmpty(url, "GitHub ribbon URL should not be empty.");
            Assert.IsTrue(Uri.IsWellFormedUriString(url, UriKind.Absolute), "URL should be a valid absolute URI.");
        }

        /// <summary>
        /// Confirms that the GitHub ribbon image has been fully loaded on the page.
        /// </summary>
        [Test]
        public void GitHubRibbonImage_ShouldBeFullyLoaded()
        {
            // Act
            bool isLoaded = shiftingContentPage.IsGitHubRibbonImageLoaded();

            // Assert
            Assert.IsTrue(isLoaded, "GitHub ribbon image should be completely loaded.");
        }
    }
}
