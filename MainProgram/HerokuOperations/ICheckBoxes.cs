

/*
* Copyright (c) 2025 Gayathri Thalapathi
* 
* This interface is part of the HerokuOperations project.
* It defines the contract for interacting with the "Checkboxes" page
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
    /// Represents actions and state checks for the Checkboxes page
    /// on https://the-internet.herokuapp.com/checkboxes.
    /// </summary>
    public interface ICheckBoxes
    {

        string GetPageTitle();

        /// <summary>
        /// Checks the first checkbox if it is not already checked.
        /// </summary>
        void CheckFirstBox();

        /// <summary>
        /// Unchecks the second checkbox if it is currently checked.
        /// </summary>
        void UncheckSecondBox();

        /// <summary>
        /// Determines whether the first checkbox is checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        bool IsFirstBoxChecked();

        /// <summary>
        /// Determines whether the second checkbox is checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        bool IsSecondBoxChecked();

        /// <summary>
        /// Retrieves the checked state of all checkboxes on the page.
        /// </summary>
        /// <returns>
        /// A list of booleans indicating checkbox states:
        /// true = checked, false = unchecked.
        /// </returns>
        List<bool> GetAllCheckboxStates();
    }
}
