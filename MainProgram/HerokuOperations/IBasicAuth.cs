// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automation framework interfaces.
// It defines the contract for interacting with the Basic Auth page functionality.
// -------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Basic Auth page in the HerokuApp.
    /// Provides methods for navigation, credential verification, and content retrieval.
    /// </summary>
    public interface IBasicAuth
    {
        /// <summary>
        /// Navigates to the Basic Auth page using the provided credentials.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        void NavigateToPage(string username, string password);

        /// <summary>
        /// Checks if the credentials provided grant access to the Basic Auth page.
        /// </summary>
        /// <param name="username">The username to verify.</param>
        /// <param name="password">The password to verify.</param>
        /// <returns>True if credentials are correct; otherwise, false.</returns>
        bool IsCredentialIsCorrect(string username, string password);

        /// <summary>
        /// Gets the page title after a successful login.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Gets the description text displayed on the Basic Auth page.
        /// </summary>
        /// <returns>The description text as a string.</returns>
        string GetPageDescription();
    }
}
