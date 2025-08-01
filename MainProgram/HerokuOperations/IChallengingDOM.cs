

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Represents actions and data access methods for the Challenging DOM page
    /// on https://the-internet.herokuapp.com/challenging_dom.
    /// </summary>
    public interface IChallengingDOM
    {
        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        /// <returns>The page title text.</returns>
        string GetPageTitle();

        /// <summary>
        /// Gets the description text below the title.
        /// </summary>
        /// <returns>The description paragraph text.</returns>
        string GetDescriptionText();

        /// <summary>
        /// Clicks the blue button labeled "qux".
        /// </summary>
        void ClickBlueButton();

        /// <summary>
        /// Clicks the red button labeled "foo".
        /// </summary>
        void ClickRedButton();

        /// <summary>
        /// Clicks the green button labeled "bar".
        /// </summary>
        void ClickGreenButton();

        /// <summary>
        /// Retrieves the headers of the table.
        /// </summary>
        /// <returns>List of header names as strings.</returns>
        List<string> GetTableHeaders();

        /// <summary>
        /// Retrieves the data from all table rows.
        /// </summary>
        /// <returns>
        /// A list of rows, where each row is a list of column cell values as strings.
        /// </returns>
        List<List<string>> GetTableRows();

        /// <summary>
        /// Clicks the "edit" link for a specific row in the table.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        void ClickEdit(int rowIndex);


        /// <summary>
        /// Clicks the "delete" link for a specific row in the table.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        void ClickDelete(int rowIndex);
    }
}
