/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="IDigestAuthentication.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface representing the Digest Authentication page and its actions.
    /// </summary>
    public interface IDigestAuthentication
    {
        /// <summary>
        /// Navigates to the Digest Authentication page.
        /// </summary>
        /// <returns>True if navigation was successful, otherwise false.</returns>
        bool NavigateToPage();

        /// <summary>
        /// Gets the title of the Digest Authentication prompt/page.
        /// </summary>
        /// <returns>The title text.</returns>
        string GetAuthPromptTitle();

        /// <summary>
        /// Performs login using the specified username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void Login(string username, string password);

        /// <summary>
        /// Checks if the user is currently logged in.
        /// </summary>
        /// <returns>True if logged in; otherwise false.</returns>
        bool IsLoggedIn();

        /// <summary>
        /// Logs out the currently logged-in user.
        /// </summary>
        void Logout();

        /// <summary>
        /// Gets the username of the currently logged-in user.
        /// </summary>
        /// <returns>The current user's username.</returns>
        string GetCurrentUser();

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        void RefreshPage();

        /// <summary>
        /// Navigates back to the previous page.
        /// </summary>
        void NavigateBack();


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
