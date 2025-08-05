/*
 * -----------------------------------------------------------------------------
 * Project     : HerokuAppTests
 * File        : IDropdownPage.cs
 * Description : Interface defining methods to interact with the dropdown list page.
 * Author      : Keyur Nagvekar
 * Created     : 2025-08-01
 * License     : MIT License
 * -----------------------------------------------------------------------------
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Represents contract for interacting with the dropdown list page (/dropdown).
    /// Supports retrieval of title, subtitle, and dropdown option data.
    /// </summary>
    public interface IDropdownPage
    {
        /// <summary>
        /// Gets the main title of the dropdown page (e.g., "Dropdown List").
        /// </summary>
        /// <returns>Page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description or subtitle text under the title.
        /// </summary>
        /// <returns>Subtitle text as a string.</returns>
        string GetSubTitle();

        /// <summary>
        /// Returns the total number of dropdown options.
        /// </summary>
        /// <returns>Count of dropdown options.</returns>
        int GetRowCount();

        /// <summary>
        /// Retrieves the visible text for a specific dropdown option.
        /// </summary>
        /// <param name="rowIndex">Index of the dropdown option (0-based).</param>
        /// <returns>Text of the dropdown option.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of valid range.</exception>
        string GetTextFromRow(int rowIndex);

        /// <summary>
        /// Returns the image source if applicable. If no image exists, returns a fixed message.
        /// </summary>
        /// <param name="rowIndex">Index of the option (optional, ignored here).</param>
        /// <returns>String indicating absence of image.</returns>
        string GetImageSourceFromRow(int rowIndex);
    }
}
