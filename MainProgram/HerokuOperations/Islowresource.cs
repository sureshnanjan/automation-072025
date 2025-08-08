/*
* -----------------------------------------------------------------------------
* Project     : HerokuOperations
* File        : ISlowResource.cs
* Author      : Jeya Mathesh G
* Created     : 2025-08-01
* -----------------------------------------------------------------------------
*/

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface representing actions and properties of the Slow Resources page.
    /// </summary>
    public interface ISlowResource
    {
        /// <summary>
        /// Gets the page title.
        /// </summary>
        /// <returns>The page title string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description text displayed on the page.
        /// </summary>
        /// <returns>The description string.</returns>
        string GetDescription();

        /// <summary>
        /// Checks whether the content is currently displayed.
        /// </summary>
        /// <returns>True if visible; otherwise, false.</returns>
        bool IsContentDisplayed();

        /// <summary>
        /// Waits for the content to appear, up to a timeout in seconds.
        /// </summary>
        /// <param name="timeoutInSeconds">Timeout duration.</param>
        /// <returns>True if content appears in time; otherwise, false.</returns>
        bool WaitForContentToAppear(int timeoutInSeconds);

        /// <summary>
        /// Checks whether the description element is enabled after content loads.
        /// </summary>
        /// <returns>True if enabled; otherwise, false.</returns>
        bool IsDescriptionEnabled();

        /// <summary>
        /// Reloads the current page.
        /// </summary>
        void ReloadPage();

        /// <summary>
        /// Gets the footer text from the page.
        /// </summary>
        /// <returns>The footer content as a string.</returns>
        string GetFooterText();

        /// <summary>
        /// Gets the GitHub ribbon text (usually "Fork me on GitHub").
        /// </summary>
        /// <returns>The ribbon text as a string.</returns>
        string GetGitHubRibbonText();
    }
}
