// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
//
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// --------------------------------------------------------------------------------------

using HerokuOperations;
using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test scenarios for validating the "Broken Images" page functionality.
    /// These tests are designed following SOLID principles to ensure high-quality, 
    /// maintainable, and reusable automation scripts.
    /// </summary>
    [TestFixture]
    public class BrokenImagesPageTests
    {
        /// <summary>
        /// Interface reference for Broken Images page object.
        /// Promotes Dependency Inversion by allowing mock or different implementations.
        /// </summary>
        private IBrokenImagesPage _brokenImagesPage;

        /// <summary>
        /// Setup method executed before each test to initialize test dependencies.
        /// WebDriver initialization is expected to be handled externally
        /// (e.g., via a BaseTest class or a dependency injection container).
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Example initialization (to be handled via dependency injection in a full framework):
            // _brokenImagesPage = new BrokenImagesPageImplementation(driver);
        }

        /// <summary>
        /// Verifies that the page navigation works and returns the correct title.
        /// </summary>
        [Test]
        [Category("BrokenImages")]
        [Author("Arpita Neogi")]
        public void NavigateToPage_ShouldReturnExpectedTitle()
        {
            // Arrange
            const string expectedTitle = "Broken Images";

            // Act
            _brokenImagesPage.NavigateToPage();
            var actualTitle = _brokenImagesPage.GetPageTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match the expected value.");
        }

        /// <summary>
        /// Verifies that the page contains one or more images.
        /// </summary>
        [Test]
        [Category("BrokenImages")]
        [Author("Arpita Neogi")]
        public void Page_ShouldHaveImagesDisplayed()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int imageCount = _brokenImagesPage.GetImageCount();

            // Assert
            Assert.Greater(imageCount, 0, "No images were found on the page.");
        }

        /// <summary>
        /// Verifies that there are no broken images on the page.
        /// </summary>
        [Test]
        [Category("BrokenImages")]
        [Author("Arpita Neogi")]
        public void Page_ShouldNotHaveBrokenImages()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int brokenImageCount = _brokenImagesPage.GetBrokenImageCount();

            // Assert
            Assert.AreEqual(0, brokenImageCount, "Some images failed to load on the page.");
        }

        /// <summary>
        /// Verifies that the list of broken image URLs is returned correctly if broken images exist.
        /// </summary>
        [Test]
        [Category("BrokenImages")]
        [Author("Arpita Neogi")]
        public void Page_ShouldReturnBrokenImageUrls_WhenImagesAreBroken()
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
