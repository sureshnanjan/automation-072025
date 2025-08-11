  /* --------------------------------------------------------------------------------------------------------------------
 <copyright file="SortableDataTables.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface representing actions and properties for the Sortable Data Tables page.
    /// </summary>
    public interface ISortableDataTables
    {
        /// <summary>
        /// Navigates to the Sortable Data Tables page.
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the information text displayed on the page.
        /// </summary>
        /// <returns>The information text as a string.</returns>
        string GetInformation();

        /// <summary>
        /// Gets the total number of rows in the data table.
        /// </summary>
        /// <returns>The row count as an integer.</returns>
        int GetRowCount();

        /// <summary>
        /// Gets the total number of columns in the data table.
        /// </summary>
        /// <returns>The column count as an integer.</returns>
        int GetColumnCount();

        /// <summary>
        /// Gets the value of a specific cell in the table.
        /// </summary>
        /// <param name="row">The row index (zero-based).</param>
        /// <param name="column">The column index (zero-based).</param>
        /// <returns>The value of the cell as a string.</returns>
        string GetCellValue(int row, int column);

        /// <summary>
        /// Clicks the Edit button for a specified row.
        /// </summary>
        /// <param name="row">The row index (zero-based) to edit.</param>
        void ClickEditButton(int row);

        /// <summary>
        /// Clicks the Delete button for a specified row.
        /// </summary>
        /// <param name="row">The row index (zero-based) to delete.</param>
        void ClickDeleteButton(int row);

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