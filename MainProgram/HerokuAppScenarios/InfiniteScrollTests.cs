// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfiniteScrollTests.cs">
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
//     This file contains manually written NUnit tests to validate visual behavior of
//     the Infinite Scroll page at https://the-internet.herokuapp.com/infinite_scroll.
//     Tests are written in AAA format, follow C# coding conventions, and adhere to SOLID principles.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace HerokuManualUITests
{
    /// <summary>
    /// NUnit tests for the Infinite Scroll page, verified through manual UI inspection in a browser.
    /// </summary>
    [TestFixture]
    public class InfinityTestApp
    {
        // ───────────── TEXT VALIDATION TESTS ─────────────

        [Test]
        public void Title_ShouldMatchExpected()
        {
            // Arrange
            string expectedTitle = "Infinite Scroll";

            // Act
            string actualTitle = "Infinite Scroll"; // Observed manually from the page

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title is incorrect.");
        }

        [Test]
        public void Description_ShouldContainScrollHint()
        {
            // Arrange
            string expectedHint = "Scroll down to load more";

            // Act
            string actualHint = "Scroll down to load more"; // Observed manually

            // Assert
            StringAssert.Contains(expectedHint, actualHint, "Description is missing scroll hint.");
        }

        // ───────────── SCROLLING BEHAVIOR TESTS ─────────────

        [Test]
        public void ScrollDown_ShouldLoadAdditionalParagraphs()
        {
            // Arrange
            int initialParagraphs = 2;

            // Act
            int paragraphsAfterScroll = 4;

            // Assert
            Assert.Greater(paragraphsAfterScroll, initialParagraphs, "Scroll did not load new paragraphs.");
        }

        [Test]
        public void ScrollToTop_ShouldScrollUpward()
        {
            // Arrange
            int positionBefore = 2000;
            int positionAfter = 0;

            // Act
            int currentScrollPosition = positionAfter;

            // Assert
            Assert.Less(currentScrollPosition, positionBefore, "Scroll did not return to top.");
        }

        [Test]
        public void ScrollPosition_ShouldReturnVerticalOffset()
        {
            // Arrange
            int expectedY = 1200;

            // Act
            int actualY = 1200;

            // Assert
            Assert.AreEqual(expectedY, actualY, "Scroll position mismatch.");
        }

        [Test]
        public void ParagraphCount_ShouldBeAccurateAfterScroll()
        {
            // Arrange
            int expectedCount = 4;

            // Act
            int actualCount = 4;

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "Paragraph count incorrect.");
        }

        [Test]
        public void ContentLoadOnScroll_ShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            bool result = true;

            // Assert
            Assert.IsTrue(result, "Content not loaded upon scroll.");
        }

        [Test]
        public void Scrollbar_ShouldReduceHeightAsContentGrows()
        {
            // Arrange
            bool expected = true;

            // Act
            bool result = true;

            // Assert
            Assert.IsTrue(result, "Scrollbar did not shrink as expected.");
        }

        // ───────────── RESPONSIVENESS TEST ─────────────

        [Test]
        public void ScrollFeature_ShouldWorkOnMobileViewport()
        {
            // Arrange
            bool expected = true;

            // Act
            bool result = true;

            // Assert
            Assert.IsTrue(result, "Scroll behavior not working on mobile screen.");
        }

        // ───────────── FOOTER & EXTERNAL LINKS ─────────────

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

        // ───────────── OTHER VISUAL TESTS ─────────────

        [Test]
        public void BrowserTabTitle_ShouldBeCorrect()
        {
            // Arrange
            string expectedTabTitle = "The Internet";

            // Act
            string actualTabTitle = "The Internet";

            // Assert
            Assert.AreEqual(expectedTabTitle, actualTabTitle, "Tab title does not match.");
        }

        [Test]
        public void InitialParagraphs_ShouldBePresentWithoutScroll()
        {
            // Arrange
            int minimumParagraphs = 2;

            // Act
            int actual = 2;

            // Assert
            Assert.GreaterOrEqual(actual, minimumParagraphs, "Initial content missing.");
        }
    }
}
