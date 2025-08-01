/*
* -----------------------------------------------------------------------------
* Project     : HerokuAppTests
* File        : DynamicContentPageTests.cs
* Description : Tests for the dynamic content page at /dynamic_content.
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

namespace HerokuAppTests
{
    /// NUnit test suite for validating the dynamic content behavior.
    [TestFixture]
    public class DynamicContentPageTests
    {
        private IDynamicContentPage dynamicContentPage;

        /// Initializes WebDriver and navigates to the dynamic content page.
        [SetUp]
        public void SetUp()
        {
         

            //dynamicContentPage = new DynamicContentPage(driver); // Assume implementation exists
        }

        /// Cleans up browser resources.
        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }

        [Test]
        public void ShouldReturnCorrectTitle()
        {
            // Arrange done in SetUp

            // Act
            var title = dynamicContentPage.GetTitle();

            // Assert
            Assert.AreEqual("Dynamic Content", title, "The page title does not match the expected value.");
        }

        [Test]
        public void ShouldReturnNonEmptySubTitle()
        {
            // Act
            var subtitle = dynamicContentPage.GetSubTitle();

            // Assert
            Assert.IsNotNull(subtitle, "Subtitle should not be null.");
            Assert.IsNotEmpty(subtitle, "Subtitle should not be empty.");
        }

        [Test]
        public void ShouldReturnExactlyThreeRows()
        {
            // Act
            var rowCount = dynamicContentPage.GetRowCount();

            // Assert
            Assert.AreEqual(3, rowCount, "There should be exactly 3 content rows.");
        }

        [Test]
        public void EachRow_ShouldHaveTextAndImage()
        {
            // Arrange
            int rowCount = dynamicContentPage.GetRowCount();

            // Act & Assert
            for (int i = 0; i < rowCount; i++)
            {
                string text = dynamicContentPage.GetTextFromRow(i);
                string image = dynamicContentPage.GetImageSourceFromRow(i);

                Assert.IsNotEmpty(text, $"Row {i} text is empty.");
                Assert.IsTrue(image.StartsWith("http"), $"Row {i} image URL is invalid.");
            }
        }

        [Test]
        public void InvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicContentPage.GetTextFromRow(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicContentPage.GetImageSourceFromRow(999));
        }

        [Test]
        public void Content_ShouldChange_AfterRefresh()
        {
            // Arrange
            string textBefore = dynamicContentPage.GetTextFromRow(0);

            // Act
            driver.Navigate().Refresh();
            string textAfter = dynamicContentPage.GetTextFromRow(0);

            // Assert
            Assert.AreNotEqual(textBefore, textAfter, "Content text did not change after refresh.");
        }

        [Test]
        public void ImageSource_ShouldChange_OnRefresh()
        {
            // Arrange
            string imageBefore = dynamicContentPage.GetImageSourceFromRow(1);

            // Act
            driver.Navigate().Refresh();
            string imageAfter = dynamicContentPage.GetImageSourceFromRow(1);

            // Assert
            Assert.AreNotEqual(imageBefore, imageAfter, "Image source did not change after refresh.");
        }
        /// <summary>
        /// Verifies that the GitHub ribbon is displayed on the page.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Act
            bool isVisible = dynamicContentPage.IsGitHubRibbonVisible();

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
            string url = dynamicContentPage.GetGitHubRibbonUrl();

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
            bool isLoaded = dynamicContentPage.IsGitHubRibbonImageLoaded();

            // Assert
            Assert.IsTrue(isLoaded, "GitHub ribbon image should be completely loaded.");
        }
    }
}


