// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IinfiniteScroll.cs" 
//   Copyright (c) 2025 Varun Kumar Reddy. All rights reserved.
//   This file contains an interface that defines automation methods for interacting with the
//   Infinite Scroll page on the HerokuApp test site. Redistribution or modification of this file
//   is prohibited without explicit permission from the author.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace HerokuOperations
{
    /// <summary>
    /// Interface defining methods for automating the Multiple Windows page
    /// on the HerokuApp website. It includes navigation and window-switching operations.
    /// </summary>
    public interface IWindowPage
    {
        /// <summary>
        /// Navigates the WebDriver to the Multiple Windows page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Retrieves the title text displayed on the main (parent) window.
        /// </summary>
        /// <returns>The title string from the main page.</returns>
        string GetTitle();

        /// <summary>
        /// Clicks the "Click Here" link to open a new browser window.
        /// </summary>
        void ClickHereLink();

        /// <summary>
        /// Switches the WebDriver's context to the newly opened browser window.
        /// </summary>
        void SwitchToNewWindow();

        /// <summary>
        /// Switches the WebDriver's context back to the original (main) window.
        /// </summary>
        void SwitchToMainWindow();

        /// <summary>
        /// Retrieves the text content displayed in the newly opened window.
        /// </summary>
        /// <returns>The string content of the new window.</returns>
        string GetNewWindowText();
    }
}
