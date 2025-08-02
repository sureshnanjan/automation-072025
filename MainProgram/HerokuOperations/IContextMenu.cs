/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="IContextMenu.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 -------------------------------------------------------------------------------------------------------------------- */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for operations on the HerokuApp Context Menu page.
    /// </summary>
    public interface IContextMenu
    {
        /// <summary>
        /// Navigates to the Context Menu page.
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Retrieves the title of the current page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves the information or header text displayed on the page.
        /// </summary>
        /// <returns>The header content as a string.</returns>
        string GetInformation();

        /// <summary>
        /// Performs a right-click action on the target box element.
        /// </summary>
        void RightClickOnBox();

        /// <summary>
        /// Retrieves the alert message triggered by the context menu action.
        /// </summary>
        /// <returns>The alert text as a string.</returns>
        string GetAlertText();

        /// <summary>
        /// Accepts (dismisses) the alert box after the context click.
        /// </summary>
        void AcceptAlert();

        /// <summary>
        /// Performs a right-click outside the designated target box to ensure no alert is triggered.
        /// </summary>
        void ContextInteractionOutsideBox();


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