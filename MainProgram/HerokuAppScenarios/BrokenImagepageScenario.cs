// -------------------------------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This NUnit test class validates the Broken Images page functionality using the IBrokenImages interface.
// The test suite ensures navigation, image validation, broken image detection, accessibility compliance,
// and UI element visibility (footer and GitHub ribbon) are functioning as expected.
// -------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to validate Broken Images functionality for the HerokuApp using the IBrokenImages interface.
    /// </summary>
    [TestFixture]
    public class BrokenImagesPageTests
    {
        private IBrokenImages _brokenImagesPage;

        [SetUp]
        public void Setup()
        {
            // Normally, a concrete implementation of IBrokenImages is initialized here.
            // Example: _brokenImagesPage = new BrokenImagesPageImplementation();
        }

        /// <summary>
        /// Test to verify that navigation to the Broken Images page is successful.
        /// </summary>
        [Test]
        public void NavigateToPage_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _brokenImagesPage.NavigateToPage(),
                "Navigation to Broken Images page should not throw exceptions.");
        }

        /// <summary>
        /// Test to verify the page title is displayed correctly.
        /// </summary>
        [Test]
        public void GetPageTitle_ShouldReturnExpectedTitle()
        {
            _brokenImagesPage.NavigateToPage();
            string title = _brokenImagesPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("Broken Images"), "Page title should match 'Broken Images'.");
        }

        /// <summary>
        /// Test to ensure the page has at least one image element.
        /// </summary>
        [Test]
        public void GetImageCount_ShouldBeGreaterThanZero()
        {
            _brokenImagesPage.NavigateToPage();
            int imageCount = _brokenImagesPage.GetImageCount();

            Assert.Greater(imageCount, 0, "Page should contain at least one image element.");
        }

        /// <summary>
        /// Test to verify broken image count matches expected scenario.
        /// </summary>
        [Test]
        public void GetBrokenImageCount_ShouldReturnValidCount()
        {
            _brokenImagesPage.NavigateToPage();
            int brokenCount = _brokenImagesPage.GetBrokenImageCount();

            Assert.That(brokenCount, Is.GreaterThanOrEqualTo(0), "Broken image count should be zero or more.");
        }

        /// <summary>
        /// Test to verify broken image URLs are correctly retrieved.
        /// </summary>
        [Test]
        public void GetBrokenImageUrls_ShouldReturnList()
        {
            _brokenImagesPage.NavigateToPage();
            List<string> brokenUrls = _brokenImagesPage.GetBrokenImageUrls();

            Assert.IsNotNull(brokenUrls, "Broken image URL list should not be null.");
            Assert.IsInstanceOf<List<string>>(brokenUrls, "Result should be a list of string URLs.");
        }

        /// <summary>
        /// Test to verify valid image count equals total images minus broken images.
        /// </summary>
        [Test]
        public void GetValidImageCount_ShouldMatchExpected()
        {
            _brokenImagesPage.NavigateToPage();
            int total = _brokenImagesPage.GetImageCount();
            int broken = _brokenImagesPage.GetBrokenImageCount();
            int valid = _brokenImagesPage.GetValidImageCount();

            Assert.That(valid, Is.EqualTo(total - broken),
                "Valid image count should match total images minus broken images.");
        }

        /// <summary>
        /// Test to verify all images are valid when there are no broken images.
        /// </summary>
        [Test]
        public void AreAllImagesValid_ShouldReturnTrueIfNoBrokenImages()
        {
            _brokenImagesPage.NavigateToPage();
            bool allValid = _brokenImagesPage.AreAllImagesValid();

            Assert.That(allValid, Is.EqualTo(_brokenImagesPage.GetBrokenImageCount() == 0),
                "All images valid should return true only when broken image count is zero.");
        }

        /// <summary>
        /// Test to verify the page can wait for images to fully load without exceptions.
        /// </summary>
        [Test]
        public void WaitForImagesToLoad_ShouldNotThrowException()
        {
            _brokenImagesPage.NavigateToPage();
            Assert.DoesNotThrow(() => _brokenImagesPage.WaitForImagesToLoad(),
                "Waiting for images to load should not throw exceptions.");
        }

        /// <summary>
        /// Test to verify page refresh maintains image count consistency.
        /// </summary>
        [Test]
        public void RefreshPage_ShouldKeepImageCountStable()
        {
            _brokenImagesPage.NavigateToPage();
            int initialCount = _brokenImagesPage.GetImageCount();

            _brokenImagesPage.RefreshPage();
            int refreshedCount = _brokenImagesPage.GetImageCount();

            Assert.That(refreshedCount, Is.EqualTo(initialCount),
                "Image count should remain consistent after page refresh.");
        }

        /// <summary>
        /// Test to verify alt text for broken images is retrieved for accessibility testing.
        /// </summary>
        [Test]
        public void GetAltTextOfBrokenImages_ShouldReturnList()
        {
            _brokenImagesPage.NavigateToPage();
            List<string> altTexts = _brokenImagesPage.GetAltTextOfBrokenImages();

            Assert.IsNotNull(altTexts, "Alt text list should not be null even if empty.");
            Assert.IsInstanceOf<List<string>>(altTexts, "Result should be a list of alt text strings.");
        }

        /// <summary>
        /// Test to verify "Powered by Elemental Selenium" footer is visible on the page.
        /// </summary>
        [Test]
        public void IsFooterPoweredByVisible_ShouldReturnTrue()
        {
            _brokenImagesPage.NavigateToPage();
            bool isFooterVisible = _brokenImagesPage.IsFooterPoweredByVisible();

            Assert.IsTrue(isFooterVisible, "Footer 'Powered by Elemental Selenium' should be visible.");
        }

        /// <summary>
        /// Test to verify "Fork me on GitHub" ribbon is visible and clickable.
        /// </summary>
        [Test]
        public void IsGitHubRibbonVisible_ShouldReturnTrue()
        {
            _brokenImagesPage.NavigateToPage();
            bool isRibbonVisible = _brokenImagesPage.IsGitHubRibbonVisible();

            Assert.IsTrue(isRibbonVisible, "GitHub ribbon should be visible and interactable.");
        }
    }
}
