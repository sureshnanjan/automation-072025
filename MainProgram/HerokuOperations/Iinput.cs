// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInput.cs">
//     Copyright (c) 2025 Varun Kumar Reddy. All rights reserved.
// </copyright>
// <summary>
//     Interface defining all interactions for the Inputs page at https://the-internet.herokuapp.com/inputs
//     Methods include navigation, input handling, and page metadata retrieval.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;

namespace HerokuOperations
{
    /// <summary>
    /// Contract for Inputs page operations (follows Interface Segregation and OCP from SOLID).
    /// </summary>
    public interface Iinput
    {
        /// <summary>
        /// Navigate to the Inputs page.
        /// </summary>
        void NavigateToInputsPage();

        /// <summary>
        /// Clears the input field.
        /// </summary>
        void ClearInput();

        /// <summary>
        /// Enters the given number or string into the input field.
        /// </summary>
        /// <param name="number">The value to input.</param>
        void EnterNumber(string number);

        /// <summary>
        /// Sends special keys (e.g., backspace) to the input field.
        /// </summary>
        /// <param name="key">Key to send (e.g., Keys.Backspace).</param>
        void SendKey(string key);

        /// <summary>
        /// Returns the value currently in the input field.
        /// </summary>
        /// <returns>Input field value as a string.</returns>
        string GetInputValue();

        /// <summary>
        /// Returns the header text of the page.
        /// </summary>
        /// <returns>Header as string (e.g., "Inputs").</returns>
        string GetHeaderText();

        /// <summary>
        /// Returns the page title.
        /// </summary>
        /// <returns>Page title as string (e.g., "The Internet").</returns>
        string GetPageTitle();
    }
}
