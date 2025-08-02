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

using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Represents actions and state checks for the Checkboxes page
    /// on https://the-internet.herokuapp.com/checkboxes.
    /// </summary>
    public interface ICheckBoxes
    {

        /// <summary>
        /// Gets the title of the Checkboxes page.
        /// </summary>
        /// <returns>Title of the page as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Returns whether a checkbox is clickable at the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the checkbox.</param>
        /// <returns>True if the checkbox is clickable; otherwise, false.</returns>
        bool IsCheckboxClickable(int index);

        /// <summary>
        /// Checks the first checkbox.
        /// </summary>
        void CheckFirstBox();

        /// <summary>
        /// Checks the second checkbox.
        /// </summary>
        void CheckSecondBox();

        /// <summary>
        /// Unchecks the first checkbox.
        /// </summary>
        void UncheckFirstBox();

        /// <summary>
        /// Unchecks the second checkbox.
        /// </summary>
        void UncheckSecondBox();

        /// <summary>
        /// Returns whether the first checkbox is currently checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        bool IsFirstBoxChecked();

        /// <summary>
        /// Returns whether the second checkbox is currently checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        bool IsSecondBoxChecked();

        /// <summary>
        /// Gets the list of checkbox states in the current page session.
        /// </summary>
        /// <returns>List of boolean values representing checkbox checked states.</returns>
        List<bool> GetAllCheckboxStates();

        /// <summary>
        /// Toggles the first checkbox state.
        /// </summary>
        void ToggleFirstBox();

        /// <summary>
        /// Toggles the second checkbox state.
        /// </summary>
        void ToggleSecondBox();

        /// <summary>
        /// Retrieves the main content text of the page.
        /// </summary>
        /// <returns>Content string.</returns>
        string GetMainContent();

        /// <summary>
        /// Returns whether any browser console errors are detected.
        /// </summary>
        /// <returns>True if console errors exist; otherwise, false.</returns>
        bool HasConsoleErrors();

        /// <summary>
        /// Brings focus to the checkbox at the given index for keyboard interaction.
        /// </summary>
        /// <param name="index">Zero-based checkbox index.</param>
        void FocusCheckbox(int index);

        /// <summary>
        /// Simulates a keyboard space key press event on the currently focused element.
        /// </summary>
        void PressSpaceKey();

        /// <summary>
        /// Navigates away from the Checkboxes page.
        /// </summary>
        void NavigateAway();

        /// <summary>
        /// Navigates back to the Checkboxes page.
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// Refreshes the current browser page.
        /// </summary>
        void RefreshPage();
    }
}
