<<<<<<< HEAD
﻿// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HerokuOperations;
=======
﻿/*
 * IHoverProfile Interface
 * 
 * This interface defines the contract for performing hover operations and validations
 * on the "Hovers" page of the HerokuApp site (https://the-internet.herokuapp.com/hovers).
 * It includes methods to get the title, description, profile details, and handle hover actions.
 * 
 * Author: Teja Reddy
 * Created: August 2025
 * License: For educational or internal use only.
 * 
 * © 2025 Teja Reddy. All rights reserved.
 */

>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
using System;

namespace HerokuOperations
{
    /// <summary>
<<<<<<< HEAD
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
=======
    /// Interface to define operations related to the Hover feature on HerokuApp.
    /// </summary>
    public interface IHoverProfile
    {
        /// <summary>
        /// Gets the main heading title of the page.
        /// </summary>
        /// <returns>The title text, e.g., "Hovers".</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description text of the page (if any).
        /// </summary>
        /// <returns>The description string.</returns>
        string Description();
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb

        /// <summary>
        /// Gets the name of the user shown after hovering over the profile image.
        /// </summary>
        /// <param name="index">Index of the profile image (0-based).</param>
        /// <returns>User name string like "name: user1".</returns>
        string GetProfileName(int index);

        /// <summary>
        /// Gets the profile link shown in the caption after hovering.
        /// </summary>
        /// <param name="index">Index of the profile image (0-based).</param>
        /// <returns>URL string, e.g., "/users/1".</returns>
        string GetProfileLink(int index);

        /// <summary>
        /// Checks if the caption (name and link) is displayed after hovering.
        /// </summary>
        /// <param name="index">Index of the profile image (0-based).</param>
        /// <returns>True if caption is visible; otherwise, false.</returns>
        bool IsProfileInfoDisplayed(int index);

        /// <summary>
        /// Gets the total number of profile images available for hovering.
        /// </summary>
        /// <returns>Integer count of profile images.</returns>
        int GetProfileCount();

        /// <summary>
        /// Performs hover action over the profile image at the given index.
        /// </summary>
        /// <param name="index">Index of the profile image (0-based).</param>
        void HoverOverProfileImage(int index);
    }
}

