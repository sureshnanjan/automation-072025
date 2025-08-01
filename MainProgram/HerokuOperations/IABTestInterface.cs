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

namespace HerokuOperations.PageInterface
{
    public interface IABTest
    {
        string GetTitle();
        string GetDescription(); 

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