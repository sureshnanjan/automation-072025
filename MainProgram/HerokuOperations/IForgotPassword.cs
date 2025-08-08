/*
* ------------------------------------------------------------------------------
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* 
* This file is part of the HerokuOperations project.
* It defines the interface for interacting with the Forgot Password page.
* Redistribution is allowed for educational or internal use only.
* ------------------------------------------------------------------------------
*/
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Represents the operations available on the "Forgot Password" page
    /// of the Heroku web application.
    /// </summary>    
    public interface IForgotPassword
    {
        /// <summary>
        /// Enters the specified email into the email input field.
        /// </summary>
        /// <param name="email">Email address to input.</param>
        void EnterEmail(string email);

        /// <summary>
        /// Submits the Forgot Password form.
        /// </summary>
        void Submit();

        /// <summary>
        /// Returns true if the email input field accepts user input.
        /// </summary>
        /// <returns>Boolean indicating input acceptance.</returns>
        bool IsEmailFieldAcceptingInput();

        /// <summary>
        /// Gets the message shown after form submission, such as a success or error message.
        /// </summary>
        /// <returns>Displayed confirmation or error message.</returns>
        string GetConfirmationMessage();

        /// <summary>
        /// Returns true if the submit button is visible to the user.
        /// </summary>
        /// <returns>Boolean indicating submit button visibility.</returns>
        bool IsSubmitButtonVisible();

        /// <summary>
        /// Retrieves the placeholder text displayed inside the email input field.
        /// </summary>
        /// <returns>Email field placeholder text.</returns>
        string GetEmailPlaceholder();

        /// <summary>
        /// Gets the current page URL of the Forgot Password screen.
        /// </summary>
        /// <returns>The current page URL.</returns>
        string GetCurrentUrl();

        /// <summary>
        /// Gets the title of the current page.
        /// </summary>
        /// <returns>Page title string.</returns>
        string GetPageTitle();
    }
}