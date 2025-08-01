/*
 * ------------------------------------------------------------------------------
 * © 2025 Teja Reddy. All rights reserved.
 * This interface is part of the HerokuApp automated test suite.
 * For internal, educational, or evaluation purposes only.
 * ------------------------------------------------------------------------------
 */

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Form Authentication functionality on HerokuApp.
    /// Encapsulates login, logout, and validation methods for secure area behavior.
    /// </summary>
    public interface IFormAuthentication
    {
        /// <summary>
        /// Gets the title of the login page.
        /// </summary>
        string GetTitle();

        /// <summary>
        /// Gets the description text from the login page.
        /// </summary>
        string GetDescriptionText();

        /// <summary>
        /// Logs in using the provided credentials.
        /// </summary>
        /// <param name="username">The username to enter.</param>
        /// <param name="password">The password to enter.</param>
        /// <returns>A string containing the resulting success or error message.</returns>
        string LoginWith(string username, string password);

        /// <summary>
        /// Gets the title displayed in the secure area after a successful login.
        /// </summary>
        string GetSecureAreaTitle();

        /// <summary>
        /// Checks if the logout button is visible in the secure area.
        /// </summary>
        /// <returns>True if logout button is visible; otherwise false.</returns>
        bool IsLogoutButtonVisible();

        /// <summary>
        /// Logs the user out and returns the URL of the redirected page.
        /// </summary>
        /// <returns>The URL of the login page after logout.</returns>
        string LogoutAndGetRedirectedUrl();

        /// <summary>
        /// Retrieves the logout message shown after logging out from the secure area.
        /// </summary>
        /// <returns>A string containing the logout confirmation message.</returns>
        string GetLogoutMessage();

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
