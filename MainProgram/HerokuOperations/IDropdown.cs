
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDropdownPage.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file defines an interface for interacting with the Dropdown page
//   on the-internet.herokuapp.com, allowing automated testing of dropdown behavior.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HerokuOperations
{
    /// <summary>
    /// Represents the contract for interacting with a dropdown page.
    /// Provides methods to retrieve the title, list all options,
    /// select an option, and retrieve the currently selected value.
    /// </summary>
    public interface IDropdownPage
    {
        /// <summary>
        /// Gets the title of the dropdown page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves all available options in the dropdown.
        /// </summary>
        /// <returns>An array of option texts.</returns>
        string[] GetAllOptions();

        /// <summary>
        /// Selects an option from the dropdown using visible text.
        /// </summary>
        /// <param name="optionText">The visible text of the option to select.</param>
        void SelectOptionByText(string optionText);

        /// <summary>
        /// Gets the currently selected dropdown option.
        /// </summary>
        /// <returns>The selected option's visible text.</returns>
>>>>>>> c5d62cc8ce636b3d826eccf1daee138579b236b7
        string GetSelectedOption();
    }
}
