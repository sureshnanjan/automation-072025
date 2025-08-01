// Copyright © 2025 Varun Kumar Reddy D.
// All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// Written by Varun Kumar Reddy D <your_email@example.com>, 2025.

using NUnit.Framework;
using HerokuOperations.PageInterface;

namespace HerokuTests
{
    [TestFixture]
    public class ABTestPageTests
    {
        // D — Dependency Inversion Principle:
        // Test class depends on the IABTest interface abstraction, not on concrete implementations.
        private IABTest _abTestPage;

        [Test]
        public void GetTitle_WhenCalled_ShouldReturnExpectedTitle()
        {
            // S — Single Responsibility Principle:
            // This test only validates the title and does nothing else.

            // Arrange
            var expectedTitle = new[] { "A/B Test Variation 1" };

            // Act
            string actualTitle = _abTestPage.GetTitle();

            // Assert
            Assert.Contains(actualTitle, expectedTitle);
        }

        [Test]
        public void GetDescription_WhenCalled_ShouldReturnExpectedText()
        {
            // S — Single Responsibility Principle:
            // This test only checks the description content of the page.

            // Arrange
            string expectedDescription = "Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).";

            // Act
            string actualDescription = _abTestPage.GetDescription();

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void IsFooterPoweredByVisible_WhenCalled_ShouldReturnTrueIfVisible()
        {
            // S — Single Responsibility Principle:
            // This test checks only the visibility of the Elemental Selenium footer.

            // Act
            bool isFooterVisible = _abTestPage.IsFooterPoweredByVisible();

            // Assert
            Assert.IsTrue(isFooterVisible);
        }

        [Test]
        public void IsGitHubRibbonVisible_WhenCalled_ShouldReturnTrueIfVisible()
        {
            // S — Single Responsibility Principle:
            // This test checks only the visibility of the GitHub ribbon.

            // Act
            bool isGitHubRibbonVisible = _abTestPage.IsGitHubRibbonVisible();

            // Assert
            Assert.IsTrue(isGitHubRibbonVisible);
        }
    }
}
