<<<<<<< HEAD
﻿// -------------------------------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This test class validates the Broken Images page functionality by covering navigation,
// image count verification, broken image detection, alt text validation, and page refresh checks.
// -------------------------------------------------------------------------------------------------
=======
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrokenImagesPageTests.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains automated test cases for validating the 'Broken Images' page functionality
//   used in web automation testing scenarios. Redistribution or modification of this file
//   is subject to author permissions.
//   Date Created: August 1, 2025
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3

using NUnit.Framework;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
<<<<<<< HEAD
    /// NUnit test class for verifying Broken Images page behavior using the IBrokenImages interface.
    /// Ensures all contract methods are tested with positive, negative, and edge case scenarios.
=======
    /// Contains NUnit test scenarios for validating that all images on the
    /// "Broken Images" page are displayed and loaded correctly.
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
    /// </summary>
    [TestFixture]
    public class BrokenImagesPageTests
    {
<<<<<<< HEAD
        private IBrokenImages _brokenImagesPage;

        [SetUp]
        public void Setup()
        {
            // Normally, you'd initialize a concrete implementation of IBrokenImages here.
            // Example:
            // _brokenImagesPage = new BrokenImagesPageImplementation();
        }

        /// <summary>
        /// Validates successful navigation to the Broken Images page.
        /// </summary>
        [Test]
        public void NavigateToPage_ShouldLoadSuccessfully()
        {
            Assert.DoesNotThrow(() => _brokenImagesPage.NavigateToPage(),
                "Navigation to Broken Images page should not throw any exception.");
        }

        /// <summary>
        /// Validates that the page title is correctly displayed.
        /// </summary>
        [Test]
        public void GetPageTitle_ShouldReturnExpectedTitle()
=======
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
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            _brokenImagesPage.NavigateToPage();
            string title = _brokenImagesPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("Broken Images"),
                "Page title does not match the expected value.");
        }

        /// <summary>
<<<<<<< HEAD
        /// Ensures that image count on the page is greater than zero.
        /// </summary>
        [Test]
        public void GetImageCount_ShouldReturnPositiveValue()
=======
        /// Validates that no images on the page are broken (failed to load).
        /// </summary>
        [Test]
        public void PageShouldNotHaveBrokenImages()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            _brokenImagesPage.NavigateToPage();
            int count = _brokenImagesPage.GetImageCount();

            Assert.That(count, Is.GreaterThan(0), "There should be at least one image on the page.");
        }

        /// <summary>
<<<<<<< HEAD
        /// Verifies that broken image count is returned correctly.
        /// </summary>
        [Test]
        public void GetBrokenImageCount_ShouldReturnNonNegativeNumber()
=======
        /// Validates that the list of broken image URLs is returned correctly
        /// if any images fail to load.
        /// </summary>
        [Test]
        public void PageShouldReturnBrokenImageUrlsWhenImagesAreBroken()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            _brokenImagesPage.NavigateToPage();
            int brokenCount = _brokenImagesPage.GetBrokenImageCount();

            Assert.That(brokenCount, Is.GreaterThanOrEqualTo(0),
                "Broken image count should be zero or greater.");
        }

        /// <summary>
        /// Validates that the method returns a list of broken image URLs if any exist.
        /// </summary>
        [Test]
        public void GetBrokenImageUrls_ShouldReturnListOfUrls()
        {
            _brokenImagesPage.NavigateToPage();
            List<string> brokenUrls = _brokenImagesPage.GetBrokenImageUrls();

            Assert.That(brokenUrls, Is.Not.Null, "Broken image URLs list should not be null.");
            Assert.That(brokenUrls, Is.InstanceOf<List<string>>(), "Result should be a list of URLs.");
        }

        /// <summary>
        /// Validates that valid image count matches total images minus broken ones.
        /// </summary>
        [Test]
        public void GetValidImageCount_ShouldBeConsistentWithTotalImages()
        {
            _brokenImagesPage.NavigateToPage();
            int total = _brokenImagesPage.GetImageCount();
            int broken = _brokenImagesPage.GetBrokenImageCount();
            int valid = _brokenImagesPage.GetValidImageCount();

            Assert.That(valid, Is.EqualTo(total - broken),
                "Valid image count should match total minus broken images.");
        }

        /// <summary>
        /// Ensures that all images are valid if broken image count is zero.
        /// </summary>
        [Test]
        public void AreAllImagesValid_ShouldReturnTrueIfNoBrokenImages()
        {
            _brokenImagesPage.NavigateToPage();
            bool allValid = _brokenImagesPage.AreAllImagesValid();

            Assert.That(allValid, Is.EqualTo(_brokenImagesPage.GetBrokenImageCount() == 0),
                "All images should be valid when there are no broken images.");
        }

        /// <summary>
        /// Ensures no exceptions occur while waiting for images to load.
        /// </summary>
        [Test]
        public void WaitForImagesToLoad_ShouldCompleteWithoutErrors()
        {
            _brokenImagesPage.NavigateToPage();
            Assert.DoesNotThrow(() => _brokenImagesPage.WaitForImagesToLoad(),
                "Waiting for images to load should not throw exceptions.");
        }

        /// <summary>
        /// Ensures page refresh does not throw exceptions.
        /// </summary>
        [Test]
        public void RefreshPage_ShouldReloadWithoutErrors()
        {
            _brokenImagesPage.NavigateToPage();
            Assert.DoesNotThrow(() => _brokenImagesPage.RefreshPage(),
                "Refreshing the page should not cause any errors.");
        }

        /// <summary>
        /// Ensures alt text of broken images is returned for accessibility validation.
        /// </summary>
        [Test]
        public void GetAltTextOfBrokenImages_ShouldReturnListOfAltTexts()
        {
            _brokenImagesPage.NavigateToPage();
            List<string> altTexts = _brokenImagesPage.GetAltTextOfBrokenImages();

            Assert.That(altTexts, Is.Not.Null, "Alt text list should not be null.");
            Assert.That(altTexts, Is.InstanceOf<List<string>>(), "Result should be a list of alt texts.");
        }
    }
}
