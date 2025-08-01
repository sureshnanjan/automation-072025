// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IinfiniteScroll.cs" 
//   Copyright (c) 2025 Varun Kumar Reddy. All rights reserved.
//   This file contains an interface that defines automation methods for interacting with the
//   Infinite Scroll page on the HerokuApp test site. Redistribution or modification of this file
//   is prohibited without explicit permission from the author.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HerokuOperations
{
    /// <summary>
    /// Interface that defines contract methods for automating interactions 
    /// with the Inputs page of HerokuApp.
    /// This includes navigating to the page, typing numeric values, 
    /// simulating key presses, and retrieving the input value.
    /// </summary>
    public interface IInputPage
    {
        /// <summary>
        /// Navigates the WebDriver to the Inputs page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Enters a numeric value (as a string) into the input field.
        /// </summary>
        /// <param name="number">The number to type into the input box.</param>
        void EnterNumber(string number);

        /// <summary>
        /// Simulates pressing the "Arrow Up" key a specified number of times
        /// to increment the value inside the input field.
        /// </summary>
        /// <param name="steps">Number of times to press the up arrow key.</param>
        void IncreaseValue(int steps);

        /// <summary>
        /// Simulates pressing the "Arrow Down" key a specified number of times
        /// to decrement the value inside the input field.
        /// </summary>
        /// <param name="steps">Number of times to press the down arrow key.</param>
        void DecreaseValue(int steps);

        /// <summary>
        /// Retrieves the current value from the input field.
        /// </summary>
        /// <returns>The value currently present in the input box.</returns>
        string GetInputValue();
    }
}
