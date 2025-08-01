// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iinput.cs" 
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
    /// Interface for testing the Inputs page.
    /// </summary>
    public interface Iinput
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Gets the title of the Inputs page.
        /// </summary>
        /// <returns>The page title.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle or description of the Inputs page.
        /// </summary>
        /// <returns>The description text.</returns>
        string GetDescription();

        // ───────────── INPUT FIELD INTERACTION METHODS ─────────────

        /// <summary>
        /// Enters a numeric value into the input field.
        /// </summary>
        /// <param name="value">The number to input.</param>
        void EnterNumber(int value);

        /// <summary>
        /// Clears the input field.
        /// </summary>
        void ClearInput();

        /// <summary>
        /// Gets the current value from the input field.
        /// </summary>
        /// <returns>The current input value.</returns>
        string GetInputValue();

        /// <summary>
        /// Checks if non-numeric input is blocked or handled properly.
        /// </summary>
        /// <param name="text">The non-numeric string.</param>
        /// <returns>True if non-numeric input is rejected or ignored; otherwise, false.</returns>
        bool IsNonNumericInputHandled(string text);

        // ───────────── FOOTER VALIDATION METHODS ─────────────

        /// <summary>
        /// Verifies the visibility of the "Powered by Elemental Selenium" footer.
        /// </summary>
        /// <returns>True if the footer is visible; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Verifies the visibility of the GitHub ribbon.
        /// </summary>
        /// <returns>True if the ribbon is visible and clickable; otherwise, false.</returns>
        bool IsGitHubRibbonVisible();
    }

    /// <summary>
    /// Interface for testing the Windows page (Multiple Windows).
    /// </summary>
    public interface IWindowsPage
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Gets the title of the Windows page.
        /// </summary>
        /// <returns>The page title.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description or instructions shown on the page.
        /// </summary>
        /// <returns>The description text.</returns>
        string GetDescription();

        // ───────────── WINDOW HANDLING METHODS ─────────────

        /// <summary>
        /// Clicks the link to open a new window.
        /// </summary>
        void OpenNewWindow();

        /// <summary>
        /// Switches to the newly opened window.
        /// </summary>
        void SwitchToNewWindow();

        /// <summary>
        /// Gets the title of the new window.
        /// </summary>
        /// <returns>The new window title.</returns>
        string GetNewWindowTitle();

        /// <summary>
        /// Closes the new window and switches back to the original.
        /// </summary>
        void CloseNewWindowAndReturn();

        // ───────────── FOOTER VALIDATION METHODS ─────────────

        /// <summary>
        /// Verifies the visibility of the "Powered by Elemental Selenium" footer.
        /// </summary>
        /// <returns>True if the footer is visible; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Verifies the visibility of the GitHub ribbon.
        /// </summary>
        /// <returns>True if the ribbon is visible and clickable; otherwise, false.</returns>
        bool IsGitHubRibbonVisible();
    }
}
