// Author: Siva Sree
// Date Created: 2025-08-01
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# interface defines the IRedirect contract for automating interactions 
// with the HerokuApp "Redirector" feature located at https://the-internet.herokuapp.com/redirector. 
// It supports operations for retrieving the page title and paragraph content, 
// performing redirection by clicking the trigger link, and verifying content 
// on the redirected "Status Codes" page.

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the HerokuApp Redirector page and verifying redirection behavior.
    /// </summary>
    public interface IRedirect
    {
        /// <summary>
        /// Gets the heading/title text from the Redirector page.
        /// </summary>
        /// <returns>The page heading text.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves the main paragraph content from the Redirector page.
        /// </summary>
        /// <returns>The paragraph text.</returns>
        string GetParagraphText();

        /// <summary>
        /// Clicks on the 'Click here' link to initiate redirection.
        /// </summary>
        void ClickhereLink();

        /// <summary>
        /// Gets the current URL after redirection has occurred.
        /// </summary>
        /// <returns>The current browser URL as a string.</returns>
        string GetCurrentUrl();

        /// <summary>
        /// Gets the heading/title of the Status Codes page after redirection.
        /// </summary>
        /// <returns>The title text from the Status Codes page.</returns>
        string GetStatusPageTitle();

        /// <summary>
        /// Retrieves the descriptive content from the Status Codes page.
        /// </summary>
        /// <returns>The main content or paragraph from the page.</returns>
        string GetStatusPageContent();

        /// <summary>
        /// Clicks on a status code link (e.g., 200, 301, 404, 500) on the Status Codes page.
        /// </summary>
        /// <param name="statusCode">The status code as a string (e.g., "200").</param>
        void ClickStatusCodeLink(string statusCode);
    }
}
