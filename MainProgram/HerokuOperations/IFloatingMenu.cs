/*
* ------------------------------------------------------------------------------
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* 
* This file is part of the HerokuOperations project.
* It defines the interface for interacting with the Floating Menu page.
* Redistribution is allowed for educational or internal use only.
* ------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Defines operations for interacting with the Floating Menu page.
    /// </summary>
    public interface IFloatingMenuPage
    {
        /// <summary>
        /// Checks if a specified menu item (e.g., "Home", "About") is visible on the page.
        /// </summary>
        /// <param name="menuItem">The name of the menu item.</param>
        /// <returns>True if the menu item is visible; otherwise, false.</returns>
        bool IsMenuVisible(string menuItem);

        /// <summary>
        /// Scrolls the page to the bottom to test floating menu visibility.
        /// </summary>
        void ScrollToBottom();

        /// <summary>
        /// Scrolls the page to the middle height to verify if the menu remains visible.
        /// </summary>
        void ScrollToMiddle();

        /// <summary>
        /// Checks whether the floating menu remains visible after scrolling.
        /// </summary>
        /// <returns>True if the menu is still visible; otherwise, false.</returns>
        bool IsFloatingMenuStillVisible();

        /// <summary>
        /// Clicks a specific floating menu item and returns the ID of the section navigated to.
        /// </summary>
        /// <param name="menuItem">The menu item to click (e.g., "News").</param>
        /// <returns>The section ID the page navigated to (e.g., "news").</returns>
        string ClickMenu(string menuItem);

        /// <summary>
        /// Gets the main heading text of the floating menu page.
        /// </summary>
        /// <returns>The page heading (e.g., "Floating Menu").</returns>
        string GetHeading();

        /// <summary>
        /// Retrieves all paragraph elements present on the page.
        /// </summary>
        /// <returns>A list or collection of paragraph texts or elements.</returns>
        IList<string> GetParagraphs();

        /// <summary>
        /// Checks whether the floating menu can be navigated using keyboard input (e.g., Tab key).
        /// </summary>
        /// <returns>True if the floating menu is keyboard-accessible; otherwise, false.</returns>
        bool CanAccessMenuWithKeyboard();
    }
}
