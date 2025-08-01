// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicContentPage.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file defines the interface for interacting with the Dynamic Content page
//   on the-internet.herokuapp.com, enabling automated access to text and image elements.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Dynamic Content page.
    /// Provides methods to retrieve page headings and access individual row data.
    /// </summary>
    public interface IDynamicContentPage
    {
        /// <summary>
        /// Gets the main title of the page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle or introductory paragraph text.
        /// </summary>
        /// <returns>The subtitle as a string.</returns>
        string GetSubTitle();

        /// <summary>
        /// Gets the number of dynamic content rows displayed on the page.
        /// </summary>
        /// <returns>The total number of content rows.</returns>
        int GetRowCount();

        /// <summary>
        /// Retrieves the text content from a specific dynamic row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <returns>The text content of the specified row.</returns>
        string GetTextFromRow(int rowIndex);

        /// <summary>
        /// Retrieves the image source URL from a specific dynamic row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <returns>The image source (src) URL of the specified row.</returns>
        string GetImageSourceFromRow(int rowIndex);
    }
}
