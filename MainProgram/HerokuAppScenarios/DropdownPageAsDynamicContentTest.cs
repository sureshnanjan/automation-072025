/*
* -----------------------------------------------------------------------------
* Project     : HerokuAppTests
* File        : DropdownPageTests.cs
* Description : Tests for the dropdown list page at /dropdown.
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
using System.Collections.Generic;

namespace HerokuAppTests
{
    /// NUnit test suite for validating the dropdown list page using IDynamicContentPage interface.
    [TestFixture]
    public class DropdownPageTests
    {
        private IWebDriver driver;
        private IDynamicContentPage dropdownPage;

        /// Initializes WebDriver and navigates to the dropdown page.
        [SetUp]
        public void SetUp()
        {
           
        }

        /// Disposes of the WebDriver.
        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }

        [Test]
        public void ShouldReturnCorrectTitle()
        {
            // Act
            var title = dropdownPage.GetTitle();

            // Assert
            Assert.AreEqual("Dropdown List", title, "Page title does not match.");
        }

        [Test]
        public void ShouldReturnNonEmptySubTitle()
        {
            // Act
            var subtitle = dropdownPage.GetSubTitle();

            // Assert
            Assert.IsNotNull(subtitle, "Subtitle should not be null.");
            Assert.IsNotEmpty(subtitle, "Subtitle should not be empty.");
        }

        [Test]
        public void ShouldReturnMoreThanOneOption()
        {
            // Act
            int count = dropdownPage.GetRowCount();

            // Assert
            Assert.Greater(count, 1, "There should be more than one dropdown option.");
        }

        [Test]
        public void EachOption_ShouldHaveText()
        {
            // Arrange
            int count = dropdownPage.GetRowCount();

            // Act & Assert
            for (int i = 0; i < count; i++)
            {
                var text = dropdownPage.GetTextFromRow(i);

                Assert.IsNotNull(text, $"Option {i} text is null.");
                Assert.IsNotEmpty(text, $"Option {i} text is empty.");
            }
        }

        [Test]
        public void GetImageSource_ShouldReturnNA()
        {
            // Act
            string image = dropdownPage.GetImageSourceFromRow(0);

            // Assert
            Assert.AreEqual("N/A - No images on this page", image);
        }

        [Test]
        public void InvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dropdownPage.GetTextFromRow(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => dropdownPage.GetTextFromRow(999));
        }

        [Test]
        public void FirstOption_ShouldContainSelect()
        {
            // Act
            var firstOption = dropdownPage.GetTextFromRow(0);

            // Assert
            StringAssert.Contains("Select", firstOption, "First option should be a placeholder.");
        }

        [Test]
        public void AllOptions_ShouldBeUnique()
        {
            // Arrange
            int count = dropdownPage.GetRowCount();
            var seen = new HashSet<string>();

            // Act & Assert
            for (int i = 0; i < count; i++)
            {
                var text = dropdownPage.GetTextFromRow(i);

                Assert.IsFalse(seen.Contains(text), $"Duplicate option: {text}");
                seen.Add(text);
            }
        }

        [Test]
        public void OptionCount_ShouldRemainSameAfterRefresh()
        {
            // Arrange
            int beforeRefresh = dropdownPage.GetRowCount();

            // Act
            driver.Navigate().Refresh();
            int afterRefresh = dropdownPage.GetRowCount();

            // Assert
            Assert.AreEqual(beforeRefresh, afterRefresh, "Dropdown option count changed after refresh.");
        }
        /// <summary>
        /// Verifies that the GitHub ribbon is displayed on the page.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Act
            bool isVisible = ShiftingContentPage.IsGitHubRibbonVisible();

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
            string url = ShiftingContentPage.GetGitHubRibbonUrl();

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
            bool isLoaded = ShiftingContentPage.IsGitHubRibbonImageLoaded();

            // Assert
            Assert.IsTrue(isLoaded, "GitHub ribbon image should be completely loaded.");
        }
    }
}
