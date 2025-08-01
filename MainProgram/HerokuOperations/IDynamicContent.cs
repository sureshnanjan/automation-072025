/*
 * -----------------------------------------------------------------------------
 * Project     : HerokuAppTests
 * File        : IDynamicContentPage.cs
 * Description : Interface defining contracts for accessing elements of the dynamic content page.
 * Author      : Keyur Nagvekar
 * Created     : 2025-08-01
 * License     : MIT License
 * -----------------------------------------------------------------------------
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Defines behavior expected from the dynamic content page (/dynamic_content).
    /// Provides methods to retrieve page title, subtitles, and dynamic row contents.
    /// </summary>
    public interface IDynamicContentPage
    {
        /// <summary>
        /// Gets the main page title (usually "Dynamic Content").
        /// </summary>
        /// <returns>Title of the dynamic content page.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle or paragraph beneath the title.
        /// </summary>
        /// <returns>Subtitle or description text.</returns>
        string GetSubTitle();

        /// <summary>
        /// Gets the total number of visible content rows.
        /// Typically expected to be 3.
        /// </summary>
        /// <returns>Number of content rows.</returns>
        int GetRowCount();

        /// <summary>
        /// Retrieves the dynamic text of the specified row.
        /// </summary>
        /// <param name="rowIndex">The index of the row (0-based).</param>
        /// <returns>Dynamic text content of the row.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is invalid.</exception>
        string GetTextFromRow(int rowIndex);

        /// <summary>
        /// Retrieves the image URL (src) from the specified row.
        /// </summary>
        /// <param name="rowIndex">The index of the row (0-based).</param>
        /// <returns>URL of the image in the row.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index is invalid.</exception>
        string GetImageSourceFromRow(int rowIndex);
    }
}
