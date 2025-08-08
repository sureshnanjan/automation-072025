/*
* Copyright (c) 2025 Gayathri Thalapathi
* 
* This interface is part of the HerokuOperations project.
* It defines the contract for interacting with the "Challenging DOM" page
* on the-internet.herokuapp.com.
* 
* Licensed under the MIT License. You may obtain a copy of the License at
* https://opensource.org/licenses/MIT
*/

using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Represents actions and data access methods for the Challenging DOM page
    /// on https://the-internet.herokuapp.com/challenging_dom.
    /// </summary>
    public interface IChallengingDOM
    {
        /// <summary>
        /// Gets the page title.
        /// </summary>
        string Title { get; }

       /// <summary>
        /// Gets the main description text of the page.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Clicks the blue button.
        /// </summary>
        void ClickBlueButton();

        /// <summary>
        /// Clicks the red button.
        /// </summary>
        void ClickRedButton();

        /// <summary>
        /// Clicks the green button.
        /// </summary>
        void ClickGreenButton();

        /// <summary>
        /// Gets the current text inside the dynamic answer box.
        /// </summary>
        /// <returns>Answer text as string.</returns>
        string GetAnswerBoxText();

        /// <summary>
        /// Gets the label text of the blue button.
        /// </summary>
        string GetBlueButtonText();

        /// <summary>
        /// Gets the label text of the red button.
        /// </summary>
        string GetRedButtonText();

        /// <summary>
        /// Gets the label text of the green button.
        /// </summary>
        string GetGreenButtonText();

        /// <summary>
        /// Executes a button click and returns updated answer box text.
        /// </summary>
        /// <param name="clickAction">Action that performs a button click.</param>
        /// <returns>Updated answer text.</returns>
        string ClickButtonAndReturnAnswer(System.Action clickAction);

        /// <summary>
        /// Returns the list of table header labels.
        /// </summary>
        List<string> GetTableHeaders();

        /// <summary>
        /// Returns the number of rows in the table.
        /// </summary>
        int GetTableRowCount();

        /// <summary>
        /// Returns the number of columns in a specific row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        int GetColumnCountInRow(int rowIndex);

        /// <summary>
        /// Gets all cell text values from the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        List<string> GetRowData(int rowIndex);

        /// <summary>
        /// Returns whether the specified row is currently editable.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        bool IsRowEditable(int rowIndex);

        /// <summary>
        /// Clicks the Edit button in a specific row.
        /// </summary>
        /// <param name="rowIndex">Zero-based row index.</param>
        void ClickEdit(int rowIndex);

        /// <summary>
        /// Clicks the Delete button in a specific row.
        /// </summary>
        /// <param name="rowIndex">Zero-based row index.</param>
        void ClickDelete(int rowIndex);

        /// <summary>
        /// Returns whether the Edit button is present in the given row.
        /// </summary>
        bool HasEditButton(int rowIndex);

        /// <summary>
        /// Returns whether the Delete button is present in the given row.
        /// </summary>
        bool HasDeleteButton(int rowIndex);

        /// <summary>
        /// Returns whether the edit modal or edit section is currently displayed.
        /// </summary>
        bool IsEditModalDisplayed();

        /// <summary>
        /// Updates the content of a specific cell during editing.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <param name="newValue">New value to insert.</param>
        void UpdateCell(int rowIndex, int columnIndex, string newValue);

        /// <summary>
        /// Saves the edits for the specified row.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        void SaveEdit(int rowIndex);

        /// <summary>
        /// Retrieves the value of a specific cell.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>Cell text as string.</returns>
        string GetCellValue(int rowIndex, int columnIndex);


        /// <summary>
        /// Returns the text content of the page footer.
        /// </summary>
        string GetFooterText();

        /// <summary>
        /// Returns the GitHub ribbon message (if any).
        /// </summary>
        string GetGitHubRibbonText();

    }
}