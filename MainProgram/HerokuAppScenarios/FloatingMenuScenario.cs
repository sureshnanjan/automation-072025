// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# NUnit test class defines UI behavior validations for the Floating Menu feature
// on the HerokuApp, using the IFloatingMenuPage interface. These tests are written to
// abstract implementation details such as the underlying driver (e.g., Selenium) and 
// instead focus on validating the contract and behavior of the floating menu component.
// The test suite ensures visibility, stability, interactivity, accessibility, and correct
// navigation behavior for menu elements during page scrolls, clicks, and keyboard access.

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    public class FloatingMenuTests
    {
        /// <summary>
        /// Verifies that the "Home" menu item is visible when the page loads.
        /// </summary>
        [Test]
        public void HomeMenu_Visible_OnLoad()
        {
            // Arrange
            string menuItem = "Home";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            bool isVisible = menuPage.IsMenuVisible(menuItem);

            // Assert
            Assert.IsTrue(isVisible);
        }

        /// <summary>
        /// Verifies that the "About" menu item is visible when the page loads.
        /// </summary>
        [Test]
        public void AboutMenu_Visible_OnLoad()
        {
            // Arrange
            string menuItem = "About";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            bool isVisible = menuPage.IsMenuVisible(menuItem);

            // Assert
            Assert.IsTrue(isVisible);
        }

        /// <summary>
        /// Verifies that the "Contact" menu item is visible when the page loads.
        /// </summary>
        [Test]
        public void ContactMenu_Visible_OnLoad()
        {
            // Arrange
            string menuItem = "Contact";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            bool isVisible = menuPage.IsMenuVisible(menuItem);

            // Assert
            Assert.IsTrue(isVisible);
        }

        /// <summary>
        /// Verifies that the "News" menu item is visible when the page loads.
        /// </summary>
        [Test]
        public void NewsMenu_Visible_OnLoad()
        {
            // Arrange
            string menuItem = "News";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            bool isVisible = menuPage.IsMenuVisible(menuItem);

            // Assert
            Assert.IsTrue(isVisible);
        }

        /// <summary>
        /// Verifies that the floating menu remains visible while scrolling to the bottom of the page.
        /// </summary>
        [Test]
        public void Menu_Floats_WhileScrollingToBottom()
        {
            // Arrange
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            menuPage.ScrollToBottom();
            bool visible = menuPage.IsFloatingMenuStillVisible();

            // Assert
            Assert.IsTrue(visible);
        }

        /// <summary>
        /// Verifies that the floating menu remains visible while scrolling to the middle of the page.
        /// </summary>
        [Test]
        public void Menu_Floats_WhileScrollingToMiddle()
        {
            // Arrange
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            menuPage.ScrollToMiddle();
            bool visible = menuPage.IsFloatingMenuStillVisible();

            // Assert
            Assert.IsTrue(visible);
        }

        /// <summary>
        /// Ensures that clicking the "Home" menu item navigates to the correct section on the page.
        /// </summary>
        [Test]
        public void ClickHome_NavigatesToHomeSection()
        {
            // Arrange
            string menuItem = "Home";
            string expectedSection = "home";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            string actualSection = menuPage.ClickMenu(menuItem);

            // Assert
            Assert.AreEqual(expectedSection, actualSection);
        }

        /// <summary>
        /// Ensures that clicking the "News" menu item navigates to the correct section on the page.
        /// </summary>
        [Test]
        public void ClickNews_NavigatesToNewsSection()
        {
            // Arrange
            string menuItem = "News";
            string expectedSection = "news";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            string actualSection = menuPage.ClickMenu(menuItem);

            // Assert
            Assert.AreEqual(expectedSection, actualSection);
        }

        /// <summary>
        /// Verifies that the main heading of the page is displayed as "Floating Menu".
        /// </summary>
        [Test]
        public void Heading_IsCorrect()
        {
            // Arrange
            string expectedHeading = "Floating Menu";
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            string actualHeading = menuPage.GetHeading();

            // Assert
            Assert.AreEqual(expectedHeading, actualHeading);
        }

        /// <summary>
        /// Validates that the correct number of paragraphs is displayed on the page.
        /// </summary>
        [Test]
        public void Paragraphs_AreDisplayed()
        {
            // Arrange
            int expectedParagraphCount = 3;
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            var paragraphs = menuPage.GetParagraphs();

            // Assert
            Assert.AreEqual(expectedParagraphCount, paragraphs.Count);
        }

        /// <summary>
        /// Ensures the menu remains in a fixed visible position even after multiple page scrolls.
        /// </summary>
        [Test]
        public void Menu_Position_RemainsFixed_OnMultipleScrolls()
        {
            // Arrange
            int scrollCount = 5;
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            for (int i = 0; i < scrollCount; i++)
                menuPage.ScrollToBottom();
            bool visible = menuPage.IsFloatingMenuStillVisible();

            // Assert
            Assert.IsTrue(visible);
        }

        /// <summary>
        /// Verifies that rapid clicking on a menu item does not cause instability in the UI or floating menu.
        /// </summary>
        [Test]
        public void RapidClicks_MenuOptions_AreStable()
        {
            // Arrange
            string menuItem = "About";
            int clickCount = 10;
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            for (int i = 0; i < clickCount; i++)
                menuPage.ClickMenu(menuItem);
            bool visible = menuPage.IsFloatingMenuStillVisible();

            // Assert
            Assert.IsTrue(visible);
        }

        /// <summary>
        /// Confirms that the floating menu can be accessed using keyboard navigation, ensuring accessibility.
        /// </summary>
        [Test]
        public void Menu_IsAccessible_ByKeyboard()
        {
            // Arrange
            IFloatingMenuPage menuPage = new FloatingMenuPage();

            // Act
            bool accessible = menuPage.CanAccessMenuWithKeyboard();

            // Assert
            Assert.IsTrue(accessible);
        }
    }
}
