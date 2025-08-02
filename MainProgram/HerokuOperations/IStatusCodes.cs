/*
* Copyright (c) 2025 Gayathri Thalapathi
* 
* This interface is part of the HerokuOperations project.
* It defines the contract for interacting with the "Status Codes" page
* on the-internet.herokuapp.com.
* 
* Licensed under the MIT License. You may obtain a copy of the License at
* https://opensource.org/licenses/MIT
*/

namespace HerokuOperations
{
    /// <summary>
    /// Represents interactions with the Status Codes page
    /// on https://the-internet.herokuapp.com/status_codes.
    /// </summary>
    public interface IStatusCodes
    {
        /// <summary>
        /// Retrieves the main heading (title) of the page.
        /// </summary>
        /// <returns>The page title text.</returns>
        string GetPageTitle();

        /// <summary>
        /// Retrieves the descriptive paragraph explaining HTTP status codes.
        /// </summary>
        /// <returns>The description text block.</returns>
        string GetDescriptionText();

        /// <summary>
        /// Gets the link text of the status code reference anchor tag.
        /// </summary>
        /// <returns>The anchor text (e.g., "here").</returns>
        string GetReferenceLinkText();

        /// <summary>
        /// Gets the hyperlink (href) URL of the status code reference.
        /// </summary>
        /// <returns>The href attribute value as a string.</returns>
        string GetReferenceLinkHref();

        /// <summary>
        /// Returns all the status code link elements displayed on the page.
        /// </summary>
        /// <returns>List of status code link texts (e.g., "200", "301").</returns>
        List<string> GetAllStatusCodeLinks();

        /// <summary>
        /// Determines whether a given status code link is interactable (clickable).
        /// </summary>
        /// <param name="statusCode">HTTP status code number (e.g., 200, 404).</param>
        /// <returns>True if clickable; otherwise, false.</returns>
        bool IsStatusCodeClickable(int statusCode);

        /// <summary>
        /// Clicks on the specified status code link.
        /// </summary>
        /// <param name="code">Status code as string (e.g., "404").</param>
        void ClickStatusCode(string code);

        /// <summary>
        /// Clicks on the specified status code link using integer input.
        /// </summary>
        /// <param name="code">Status code as integer (e.g., 500).</param>
        void ClickStatusCode(int code);

        /// <summary>
        /// Retrieves the message text that appears after clicking a status code.
        /// </summary>
        /// <returns>The status message shown on the details page.</returns>
        string GetStatusMessage();

        /// <summary>
        /// Navigates back to the previous page in the browser history.
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// Retrieves the current browser URL.
        /// </summary>
        /// <returns>Current URL as a string.</returns>
        string GetCurrentUrl();

        /// <summary>
        /// Returns all the HTTP status code links shown on the page.
        /// </summary>
        /// <returns>List of visible link texts like "200", "301", etc.</returns>
        List<string> GetStatusCodeLinks();
    }
}