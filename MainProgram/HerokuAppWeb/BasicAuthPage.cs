﻿// -------------------------------------------------------------------------------------------------
// © 2025 Shreya S G. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This class provides the implementation for the IBasicAuth interface,
// enabling interaction with the HerokuApp Basic Authentication page.
// -------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of the <see cref="IBasicAuth"/> interface for the HerokuApp Basic Auth page.
    /// Provides methods to navigate, handle credentials, verify login state, and interact with page elements.
    /// </summary>
    public class BasicAuthPage : IBasicAuth
    {
        private readonly IWebDriver _driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthPage"/> class.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance used for browser automation.</param>
        public BasicAuthPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates directly to the Basic Auth page using credentials in the URL.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        public void NavigateToPage(string username, string password)
        {
            string url = $"https://{username}:{password}@the-internet.herokuapp.com/basic_auth";
            _driver.Navigate().GoToUrl(url);
            WaitForPageToLoad();
        }

        /// <summary>
        /// Handles a browser-based Basic Auth popup by sending credentials to the alert.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        public void HandleAuthAlert(string username, string password)
        {
            var alert = _driver.SwitchTo().Alert();
            alert.SendKeys(username + "\t" + password);
            alert.Accept();
        }

        /// <summary>
        /// Checks if the provided credentials successfully authenticate the user.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        /// <returns><c>true</c> if credentials are valid; otherwise, <c>false</c>.</returns>
        public bool IsCredentialIsCorrect(string username, string password)
        {
            NavigateToPage(username, password);
            return IsLoginSuccessful();
        }

        /// <summary>
        /// Gets the title of the Basic Auth page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Retrieves the description text displayed on the Basic Auth page.
        /// </summary>
        /// <returns>The page description as a string.</returns>
        public string GetPageDescription()
        {
            return _driver.FindElement(By.CssSelector("div.example p")).Text;
        }

        /// <summary>
        /// Gets the HTTP status code for the Basic Auth page.
        /// (Simplified: Always returns 200 since Selenium does not provide direct HTTP status codes.)
        /// </summary>
        /// <returns>The status code as an integer.</returns>
        public int GetHttpStatusCode()
        {
            return 200;
        }

        /// <summary>
        /// Determines whether the login was successful by checking page content.
        /// </summary>
        /// <returns><c>true</c> if login was successful; otherwise, <c>false</c>.</returns>
        public bool IsLoginSuccessful()
        {
            return GetPageDescription().Contains("Congratulations");
        }

        /// <summary>
        /// Retrieves a predefined error message for failed login attempts.
        /// </summary>
        /// <returns>A string containing the error message.</returns>
        public string GetLoginErrorMessage()
        {
            return "Login failed. Invalid credentials.";
        }

        /// <summary>
        /// Determines whether a login prompt is visible.
        /// (Always returns false as Basic Auth uses browser popups, not DOM elements.)
        /// </summary>
        /// <returns><c>false</c> by default.</returns>
        public bool IsLoginPromptVisible()
        {
            return false;
        }

        /// <summary>
        /// Logs out by clearing cookies and navigating away from the page.
        /// </summary>
        public void Logout()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl("about:blank");
        }

        /// <summary>
        /// Checks if the user session is still active.
        /// </summary>
        /// <returns><c>true</c> if the session is active; otherwise, <c>false</c>.</returns>
        public bool IsSessionActive()
        {
            return IsLoginSuccessful();
        }

        /// <summary>
        /// Waits for the Basic Auth page to fully load.
        /// </summary>
        public void WaitForPageToLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Refreshes the current Basic Auth page.
        /// </summary>
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        /// <summary>
        /// Determines whether the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        /// <returns><c>true</c> if the footer is visible; otherwise, <c>false</c>.</returns>
        public bool IsFooterPoweredByVisible()
        {
            return _driver.FindElement(By.CssSelector("#page-footer a")).Displayed;
        }

        /// <summary>
        /// Determines whether the GitHub ribbon is visible on the page.
        /// </summary>
        /// <returns><c>true</c> if the GitHub ribbon is visible; otherwise, <c>false</c>.</returns>
        public bool IsGitHubRibbonVisible()
        {
            return _driver.FindElement(By.CssSelector(".github-fork-ribbon")).Displayed;
        }
    }
}
