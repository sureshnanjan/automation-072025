// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddRemoveElementsPage.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains an interface defining actions for interacting with the Add/Remove Elements page
//   used for automation testing purposes.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface representing actions on the Add/Remove Elements page.
    /// Defines the contract for test automation without implementation.
    /// </summary>
    public interface IAddRemoveElements
    {
        /// <summary>
        /// Clicks on the "Add Element" button to dynamically add a new element on the page.
        /// </summary>
        void AddElements();

        /// <summary>
        /// Clicks on the "Delete" button to remove an element from the page.
        /// </summary>
        void DeleteElements();

        /// <summary>
        /// Checks whether the "Delete" button is visible on the page.
        /// </summary>
        /// <returns>True if the delete button is displayed, otherwise false.</returns>
        bool IsDeleteButtonDisplayed();

        /// <summary>
        /// Gets the total number of delete buttons currently displayed on the page.
        /// </summary>
        /// <returns>The count of dynamically added elements.</returns>
        int GetDeleteButtonCount();

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
