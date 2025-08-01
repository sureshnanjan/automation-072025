// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IABTest.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file defines an interface for interacting with the A/B Testing page
//   used in automation testing scenarios. The interface provides methods to 
//   retrieve page information and control A/B testing state.
//   Redistribution or modification of this file is subject to author permissions.
//   Date Created: August 1, 2025
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Represents an interface defining contract methods for interacting with the A/B Testing page.
    /// Provides functionality to:
    /// - Retrieve the title of the page.
    /// - Retrieve the description displayed on the page.
    /// - Disable A/B testing during test execution.
    /// </summary>
    public interface IABTest
    {
        /// <summary>
        /// Retrieves the main title of the A/B Testing page.
        /// </summary>
        string GetTitle();

        /// <summary>
        /// Retrieves the description text displayed on the A/B Testing page.
        /// </summary>
        string GetDescription();


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
