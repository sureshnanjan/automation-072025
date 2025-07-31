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
        /// Retrieves the page heading or title (typically "Forgot Password").
        /// </summary>
        /// <returns>The title of the forgot password page.</returns>
        string GetTitle();

        /// <summary>
        /// Enters the specified email address into the email input field.
        /// </summary>
        /// <param name="email">The email address to be entered.</param>
        void EnterEmail(string email);

        /// <summary>
        /// Clicks the "Retrieve password" button to submit the form.
        /// </summary>
        void ClickRetrievePassword();

        /// <summary>
        /// Retrieves the confirmation message shown after submitting the form.
        /// </summary>
        /// <returns>The confirmation message text.</returns>
        string GetConfirmationMessage();
    }
}
