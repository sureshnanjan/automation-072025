// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Key Presses component.
    /// </summary>
    public interface IKeyPresses
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Retrieves the title text displayed on the Key Presses page.
        /// </summary>
        /// <returns>The page title.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves the instruction or description text on the page.
        /// </summary>
        /// <returns>The page description.</returns>
        string GetDescription();

        // ───────────── KEYBOARD INTERACTION METHODS ─────────────

        /// <summary>
        /// Sends a single key to the input field.
        /// </summary>
        /// <param name="key">The key to send (e.g., 'A', 'Enter').</param>
        void SendKey(string key);

        /// <summary>
        /// Retrieves the result text shown after a key is pressed.
        /// </summary>
        /// <returns>The result string (e.g., "You entered: A").</returns>
        string GetResultText();

        /// <summary>
        /// Verifies if the displayed result matches the expected key.
        /// </summary>
        /// <param name="expectedKey">The expected key text.</param>
        /// <returns>True if the result matches; otherwise, false.</returns>
        bool IsCorrectKeyDisplayed(string expectedKey);

        // ───────────── EDGE & BOUNDARY TESTS ─────────────

        /// <summary>
        /// Checks if non-alphanumeric keys (e.g., Arrow keys, Enter) are captured correctly.
        /// </summary>
        /// <param name="specialKey">The special key to test.</param>
        /// <returns>True if the special key is displayed correctly; otherwise, false.</returns>
        bool IsSpecialKeyCaptured(string specialKey);

        /// <summary>
        /// Verifies that key combinations (like Ctrl+S) only show the last key.
        /// </summary>
        /// <param name="keyCombo">The key combo to send.</param>
        /// <returns>True if only the final key is shown; otherwise, false.</returns>
        bool DoesIgnoreModifierKeys(string keyCombo);

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