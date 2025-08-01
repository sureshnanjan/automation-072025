/*
* -----------------------------------------------------------------------------
* Project     : HerokuOperations
* File        : IDisappear.cs
* Author      : Jeya Mathesh G
* Created     : 2025-08-01
* Description : Interface for interacting with pages that have disappearing elements.
* -----------------------------------------------------------------------------
*/

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for operations on the Disappearing Elements page.
    /// Follows SRP (Single Responsibility Principle) from SOLID,
    /// defining only the responsibilities related to the disappearing page.
    /// </summary>
    public interface IDisappear
    {
        /// <summary>
        /// Gets the main title of the page.
        /// </summary>
        /// <returns>The title text as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle or description under the title.
        /// </summary>
        /// <returns>The subtitle text as a string.</returns>
        string GetSubTitle();

        /// <summary>
        /// Returns the list of currently visible navigation elements
        /// (e.g., Home, About, Contact Us, etc.).
        /// This list may vary on each page load due to disappearing behavior.
        /// </summary>
        /// <returns>Array of visible navigation link names.</returns>
        string[] GetVisibleNavigationItems();

        /// <summary>
        /// Reloads the page, allowing potential visibility changes in elements.
        /// </summary>
        void ReloadPage();

        /// <summary>
        /// Clicks a navigation link by its visible name and returns the resulting URL.
        /// </summary>
        /// <param name="linkName">The visible text of the link to click.</param>
        /// <returns>The current URL after navigation.</returns>
        string AccessNavigationAndReturnUrl(string linkName);

        /// <summary>
        /// Gets the footer text, usually contains attribution like "Powered by Elemental Selenium".
        /// </summary>
        /// <returns>The footer string.</returns>
        string GetFooterText();

        /// <summary>
        /// Gets the GitHub ribbon text (usually "Fork me on GitHub").
        /// </summary>
        /// <returns>The GitHub ribbon text as a string.</returns>
        string GetGitHubRibbonText();
    }
}