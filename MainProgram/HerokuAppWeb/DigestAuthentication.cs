/*
* -------------------------------------------------------------------------------------
*  Copyright (c) 2025 Sowmya Sridhar
*  All Rights Reserved.
*  
*  Permission is hereby granted to use and modify this code for personal 
*  and educational purposes only. Redistribution or commercial use without 
*  prior written consent is prohibited.
* -------------------------------------------------------------------------------------
*/

using System;
using HerokuOperations;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations.Implementations
{
    /// <summary>
    /// Represents the Digest Authentication page in the application using the Page Object Model pattern.
    /// Provides methods to perform login, check authentication state, and logout.
    /// </summary>
    internal class DigestAuthenticationPage : IDigestAuthentication
    {
        private readonly WebDriverWrapper _driver;

        // Locators for authentication validation
        private readonly ElementLocator _loggedInMessageLocator = new ElementLocator(By.XPath("//p[contains(text(), 'Congratulations!')]"), "Logged-In Success Message");
        private readonly ElementLocator _logoutLinkLocator = new ElementLocator(By.LinkText("Logout"), "Logout Link");
        private readonly ElementLocator _currentUserLocator = new ElementLocator(By.Id("current-user"), "Current Logged-in User");

        private const string PageUrl = "https://the-internet.herokuapp.com/digest_auth";

        /// <summary>
        /// Initializes a new instance of the <see cref="DigestAuthenticationPage"/> class.
        /// </summary>
        /// <param name="driver">Instance of WebDriverWrapper for interacting with the browser.</param>
        /// <exception cref="ArgumentNullException">Thrown when driver is null.</exception>
        public DigestAuthenticationPage(WebDriverWrapper driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the Digest Authentication page.
        /// </summary>
        public void GoToPage()
        {
            _driver.Driver.Navigate().GoToUrl(PageUrl);
        }

        /// <summary>
        /// Retrieves the title of the current page.
        /// </summary>
        /// <returns>The title of the browser page as a string.</returns>
        public string GetPageTitle()
        {
            return _driver.Driver.Title;
        }

        /// <summary>
        /// Performs login by embedding username and password into the page URL.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        public void Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be null or empty.", nameof(password));

            string authUrl = $"https://{username}:{password}@the-internet.herokuapp.com/digest_auth";
            _driver.Driver.Navigate().GoToUrl(authUrl);
        }

        /// <summary>
        /// Checks if the user is successfully logged in.
        /// </summary>
        /// <returns>True if logged in, otherwise false.</returns>
        public bool IsLoggedIn()
        {
            return _driver.IsElementPresent(_loggedInMessageLocator);
        }

        /// <summary>
        /// Performs logout if the logout link is available.
        /// </summary>
        public void Logout()
        {
            if (_driver.IsElementPresent(_logoutLinkLocator))
            {
                _driver.Click(_logoutLinkLocator);
            }
        }

        /// <summary>
        /// Retrieves the currently logged-in username from the page.
        /// </summary>
        /// <returns>The username as a string, or null if not found.</returns>
        public string GetCurrentUser()
        {
            if (_driver.IsElementPresent(_currentUserLocator))
            {
                return _driver.GetText(_currentUserLocator);
            }
            return null;
        }
    }
}
