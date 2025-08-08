/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="ForgotPassword.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.

 This file is part of the HerokuOperations project.
 It provides the implementation for the Forgot Password page interactions.
 Redistribution is allowed for educational or internal use only.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements the operations available on the "Forgot Password" page
    /// of the Heroku web application.
    /// </summary>
    public class ForgotPassword : IForgotPassword
    {
        private readonly IWebDriver _driver;

        // Locators
        private readonly By _emailField = By.Id("email");
        private readonly By _submitButton = By.CssSelector("button.radius");
        private readonly By _confirmationMessage = By.Id("content");

        /// <summary>
        /// Constructor to initialize WebDriver instance.
        /// </summary>
        /// <param name="driver">WebDriver instance.</param>
        public ForgotPassword(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <inheritdoc/>
        public void EnterEmail(string email)
        {
            _driver.FindElement(_emailField).Clear();
            _driver.FindElement(_emailField).SendKeys(email);
        }

        /// <inheritdoc/>
        public void Submit()
        {
            _driver.FindElement(_submitButton).Click();
        }

        /// <inheritdoc/>
        public bool IsEmailFieldAcceptingInput()
        {
            try
            {
                var emailElement = _driver.FindElement(_emailField);
                return emailElement.Enabled && emailElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public string GetConfirmationMessage()
        {
            try
            {
                return _driver.FindElement(_confirmationMessage).Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public bool IsSubmitButtonVisible()
        {
            try
            {
                return _driver.FindElement(_submitButton).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public string GetEmailPlaceholder()
        {
            try
            {
                return _driver.FindElement(_emailField).GetAttribute("placeholder");
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        /// <inheritdoc/>
        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}
