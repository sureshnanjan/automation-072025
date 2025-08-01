// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HerokuOperations;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Hovers page.
    /// </summary>
    public interface IHovers
    {
        /// <summary>
        /// Navigates to the Hovers page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Retrieves the page title.
        /// </summary>
        /// <returns>The page title text.</returns>
        string GetTitle();

        /// <summary>
        /// Hovers over a user avatar by index (0-based).
        /// </summary>
        /// <param name="index">Index of the avatar (0, 1, or 2).</param>
        void HoverOverAvatar(int index);

        /// <summary>
        /// Gets the displayed username after hover.
        /// </summary>
        /// <param name="index">Index of the avatar.</param>
        /// <returns>The displayed username.</returns>
        string GetUsername(int index);

        /// <summary>
        /// Checks if the profile link is visible for the hovered avatar.
        /// </summary>
        /// <param name="index">Index of the avatar.</param>
        /// <returns>True if link is visible; otherwise, false.</returns>
        bool IsProfileLinkVisible(int index);

        /// <summary>
        /// Clicks the profile link for the given avatar.
        /// </summary>
        /// <param name="index">Index of the avatar.</param>
        void ClickProfileLink(int index);

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

