// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
// 
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This interface defines the contract for interacting with the Basic Auth page functionality,
// including navigation, credential handling via browser alerts, and content validation.
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
        void NavigateToPage(string username, string password);

        /// <summary>
        /// Handles browser Basic Auth via alert prompt by injecting credentials directly.
        /// </summary>
        void HandleAuthAlert(string username, string password);


        /// <summary>
        /// Checks if the credentials provided grant access to the Basic Auth page.
        /// </summary>
        bool IsCredentialIsCorrect(string username, string password);

        /// <summary>
        /// Gets the page title after a successful login.
        /// </summary>
        string GetPageTitle();

        /// <summary>
        /// Gets the description text displayed on the Basic Auth page.
        /// </summary>
        string GetPageDescription();


        /// <summary>
        /// Gets the HTTP status code of the response when accessing the page.
        /// </summary>
        int GetHttpStatusCode();

        /// <summary>
        /// Verifies whether the login was successful based on UI elements.
        /// </summary>
        bool IsLoginSuccessful();

        /// <summary>
        /// Gets the error message displayed after a failed login attempt.
        /// </summary>
        string GetLoginErrorMessage();

        /// <summary>
        /// Checks if the login form or basic auth prompt is currently visible.
        /// </summary>
        bool IsLoginPromptVisible();

        /// <summary>
        /// Logs out from the Basic Auth session, if applicable.
        /// </summary>
        void Logout();

        /// <summary>
        /// Verifies if the user session is still active.
        /// </summary>
        bool IsSessionActive();

        /// <summary>
        /// Waits for the Basic Auth page to fully load.
        /// </summary>
        void WaitForPageToLoad();

        /// <summary>
        /// Refreshes the current Basic Auth page.
        /// </summary>
        void RefreshPage();

        /// <summary>
        /// Checks if the footer "Powered by Elemental Selenium" is visible.
        /// </summary>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Checks if the GitHub ribbon is visible.
        /// </summary>
        bool IsGitHubRibbonVisible();

    }
}
