// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMultipleWindowPage.cs" 
//   Copyright (c) 2025 Varun Kumar Reddy. All rights reserved.
//   This file contains an interface that defines automation methods for interacting with the
//   Infinite Scroll page on the HerokuApp test site. Redistribution or modification of this file
//   is prohibited without explicit permission from the author.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Multiple Windows component.
    /// </summary>
    public interface IWindow
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Retrieves the title of the Multiple Windows page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the instruction or subtitle displayed on the page.
        /// </summary>
        /// <returns>The instruction text.</returns>
        string GetDescription();

        /// <summary>
        /// Gets the anchor text of the "Click Here" link.
        /// </summary>
        /// <returns>The link text.</returns>
        string GetLinkText();

        // ───────────── WINDOW HANDLING METHODS ─────────────

        /// <summary>
        /// Clicks the "Click Here" link to open a new window.
        /// </summary>
        void ClickHereToOpenNewWindow();

        /// <summary>
        /// Switches the driver's focus to the newly opened window.
        /// </summary>
        void SwitchToNewWindow();

        /// <summary>
        /// Gets the title text of the newly opened window.
        /// </summary>
        /// <returns>The new window's title.</returns>
        string GetNewWindowTitle();

        /// <summary>
        /// Gets the message text shown in the new window.
        /// </summary>
        /// <returns>The message text.</returns>
        string GetNewWindowMessage();

        /// <summary>
        /// Closes the newly opened window and switches back to the original.
        /// </summary>
        void CloseNewWindowAndReturn();

        // ───────────── EDGE CASE VALIDATION ─────────────

        /// <summary>
        /// Ensures that clicking multiple times opens separate new windows.
        /// </summary>
        /// <param name="clickCount">Number of times to click the link.</param>
        /// <returns>True if each click opens a new window; otherwise, false.</returns>
        bool AreMultipleWindowsOpened(int clickCount);

        /// <summary>
        /// Ensures the original window remains open and unchanged.
        /// </summary>
        /// <returns>True if the original window is intact; otherwise, false.</returns>
        bool IsOriginalWindowPreserved();

        // ───────────── FOOTER VALIDATION METHODS ─────────────

        /// <summary>
        /// Verifies if the "Powered by Elemental Selenium" footer is present and visible.
        /// </summary>
        /// <returns>True if the footer is visible; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Checks if the "Fork me on GitHub" ribbon is visible and clickable.
        /// </summary>
        /// <returns>True if the ribbon is present and interactable; otherwise, false.</returns>
        bool IsGitHubRibbonVisible();
    }
}