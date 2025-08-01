// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrokenImagesPageTests.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains automated test cases for validating the 'Broken Images' page functionality
//   used in web automation testing scenarios. Redistribution or modification of this file
//   is subject to author permissions.
//   Date Created: August 1, 2025
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using HerokuOperations;
using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test scenarios for validating that all images on the
    /// "Broken Images" page are displayed and loaded correctly.
    /// </summary>
    [TestFixture]
    public class BrokenImagesPageTests
    {
        /// <summary>
        /// Interface reference for Broken Images page.
        /// The actual implementation should be injected during test setup.
        /// </summary>
        private IBrokenImagesPage _brokenImagesPage;

        /// <summary>
        /// Setup method that runs before each test.
        /// Initializes the page object (implementation to be provided in actual test framework).
        /// </summary>
        

        /// <summary>
        /// Validates that the Broken Images page displays the expected title.
        /// </summary>
        [Test]
        public void NavigateToPageShouldReturnExpectedTitle()
        {
            // Arrange
            const string expectedTitle = "Broken Images";

            // Act
            _brokenImagesPage.NavigateToPage();
            string actualTitle = _brokenImagesPage.GetPageTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match the expected value.");
        }

        /// <summary>
        /// Validates that the page contains one or more images displayed on load.
        /// </summary>
        [Test]
        public void PageShouldHaveImagesDisplayed()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int imageCount = _brokenImagesPage.GetImageCount();

            // Assert
            Assert.Greater(imageCount, 0, "No images were found on the page.");
        }

        /// <summary>
        /// Validates that no images on the page are broken (failed to load).
        /// </summary>
        [Test]
        public void PageShouldNotHaveBrokenImages()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int brokenImageCount = _brokenImagesPage.GetBrokenImageCount();

            // Assert
            Assert.AreEqual(0, brokenImageCount, "Some images failed to load on the page.");
        }

        /// <summary>
        /// Validates that the list of broken image URLs is returned correctly
        /// if any images fail to load.
        /// </summary>
        [Test]
        public void PageShouldReturnBrokenImageUrlsWhenImagesAreBroken()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            List<string> brokenImageUrls = _brokenImagesPage.GetBrokenImageUrls();

            // Assert
            Assert.IsNotNull(brokenImageUrls, "Broken image URLs list should not be null.");
            Assert.IsInstanceOf<List<string>>(brokenImageUrls, "Result should be a list of URLs.");
        }
    }
}
