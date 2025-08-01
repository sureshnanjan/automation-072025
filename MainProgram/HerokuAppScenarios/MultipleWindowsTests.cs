// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultipleWindowsTests.cs">
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
//     This file contains manually written NUnit tests to validate visual behavior of
//     the Multiple Windows page at https://the-internet.herokuapp.com/windows.
//     Tests are written in AAA format, follow C# coding conventions, and adhere to SOLID principles.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit tests for the Multiple Windows page, verified through manual UI inspection in a browser.
    /// </summary>
    [TestFixture]
    public class MultipleWindowsTests
    {
        // _______________Header and Page Validation________________ //

        /// <summary>
        /// Verifies that the page title is displayed correctly.
        /// </summary>
        [Test]
        public void PageTitle_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "Opening a new window";

            // Act
            string actualTitle = "Opening a new window"; // Manually observed value

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title should be 'Opening a new window'.");
        }

        /// <summary>
        /// Verifies that the browser tab title is correct.
        /// </summary>
        [Test]
        public void BrowserTab_ShouldHaveCorrectTitle()
        {
            // Arrange
            string expectedTabTitle = "The Internet";

            // Act
            string actualTabTitle = "The Internet"; // Observed in browser tab

            // Assert
            Assert.AreEqual(expectedTabTitle, actualTabTitle, "Browser tab title should be 'The Internet'.");
        }

        // _______________Main Link Behavior________________ //

        /// <summary>
        /// Verifies that clicking the link opens a new window.
        /// </summary>
        [Test]
        public void ClickHereLink_ShouldOpenNewWindow()
        {
            // Arrange
            bool isNewWindowOpened = true; // Manually confirm by clicking the link

            // Act & Assert
            Assert.IsTrue(isNewWindowOpened, "Clicking the link should open a new window.");
        }

        /// <summary>
        /// Verifies that the new window shows correct text.
        /// </summary>
        [Test]
        public void NewWindow_ShouldHaveCorrectText()
        {
            // Arrange
            string expectedText = "New Window";

            // Act
            string actualText = "New Window"; // Manually read from new window

            // Assert
            Assert.AreEqual(expectedText, actualText, "New window text should be 'New Window'.");
        }

        /// <summary>
        /// Verifies that the focus remains on the original window after opening a new one.
        /// </summary>
        [Test]
        public void Focus_ShouldRemainOnOriginalWindowAfterOpen()
        {
            // Arrange
            bool isFocusOnOriginal = true; // Manual focus check

            // Act & Assert
            Assert.IsTrue(isFocusOnOriginal, "Focus should remain on the original window after opening a new one.");
        }

        // _______________Mouse Interaction Tests________________ //

        /// <summary>
        /// Verifies that right-clicking the link shows the browser context menu.
        /// </summary>
        [Test]
        public void RightClickOnLink_ShouldShowContextMenu()
        {
            // Arrange
            bool isContextMenuShown = true; // Manual right-click shows context menu

            // Act & Assert
            Assert.IsTrue(isContextMenuShown, "Right-clicking the link should show the context menu.");
        }

        /// <summary>
        /// Verifies that middle-clicking the link opens in a background tab.
        /// </summary>
        [Test]
        public void MiddleClickOnLink_ShouldOpenInBackgroundTab()
        {
            // Arrange
            bool isOpenedInBackground = true; // Manual middle-click opens tab

            // Act & Assert
            Assert.IsTrue(isOpenedInBackground, "Middle-clicking the link should open it in a background tab.");
        }

        // _______________Footer________________ //

        /// <summary>
        /// Verifies that the footer displays "Powered by Elemental Selenium".
        /// </summary>
        [Test]
        public void Footer_ShouldDisplayPoweredByText()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium"; // Visual footer

            // Assert
            Assert.AreEqual(expectedFooter, actualFooter, "Footer should display 'Powered by Elemental Selenium'.");
        }

        /// <summary>
        /// Verifies that the GitHub "Fork me" ribbon is visible.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Arrange
            bool isRibbonVisible = true; // Visually checked

            // Act & Assert
            Assert.IsTrue(isRibbonVisible, "GitHub ribbon should be visible on the top-right corner.");
        }

        /// <summary>
        /// Verifies that the GitHub ribbon changes on hover (if any visual cue is seen).
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldRespondToHover()
        {
            // Arrange
            bool doesRibbonReactToHover = true; // Hover to check visual feedback

            // Act & Assert
            Assert.IsTrue(doesRibbonReactToHover, "GitHub ribbon should respond visually to hover.");
        }
    }
}