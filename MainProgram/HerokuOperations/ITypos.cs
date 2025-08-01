// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automation framework interfaces.
// It defines the contract for interacting with the Typos test page.
// -------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Typos page in the HerokuApp.
    /// Provides methods for navigation, text content retrieval, and typo detection.
    /// </summary>
    internal interface ITypos
    {
        /// <summary>
        /// Navigates to the Typos page.
        /// </summary>
        void NavigateToPage();

        /// <summary>
        /// Gets the page title after successful navigation.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Gets the description text displayed on the page.
        /// </summary>
        /// <returns>The page description as a string.</returns>
        string GetPageDescription();

        /// <summary>
        /// Returns a boolean indicating whether any typos were found on the page.
        /// </summary>
        /// <returns>True if typos are present; otherwise, false.</returns>
        bool HasTypos();
    }
}
