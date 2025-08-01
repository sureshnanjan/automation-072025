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
//
// --------------------------------------------------------------------------------------

using HerokuOperations;
using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class BrokenImagesPageTests
    {
        private IBrokenImagesPage _brokenImagesPage;

        [SetUp]
        public void Setup()
        {
            // Normally, you'd initialize a concrete implementation of IBrokenImagesPage here.
            // Example:
            // _brokenImagesPage = new BrokenImagesPageImplementation();
        }

        [Test]
        public void NavigateToPage_ShouldReturnExpectedTitle()
        {
            // Arrange
            string expectedTitle = "Broken Images";

            // Act
            _brokenImagesPage.NavigateToPage();
            string actualTitle = _brokenImagesPage.GetPageTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match the expected value.");
        }

        [Test]
        public void Page_ShouldHaveImagesDisplayed()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int imageCount = _brokenImagesPage.GetImageCount();

            // Assert
            Assert.Greater(imageCount, 0, "No images were found on the page.");
        }

        [Test]
        public void Page_ShouldNotHaveBrokenImages()
        {
            // Arrange
            _brokenImagesPage.NavigateToPage();

            // Act
            int brokenImageCount = _brokenImagesPage.GetBrokenImageCount();

            // Assert
            Assert.AreEqual(0, brokenImageCount, "Some images failed to load on the page.");
        }

        [Test]
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
