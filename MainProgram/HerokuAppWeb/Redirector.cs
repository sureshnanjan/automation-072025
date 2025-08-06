// -------------------------------------------------------------------------------------------------
// © 2025 Gayathri Thalapathi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Author: Gayathri Thalapathi
// Date Created: 2025-08-01
//
// Description:
// This class implements the IRedirect interface to automate the Redirector page
// located at https://the-internet.herokuapp.com/redirector using Selenium WebDriver.
// It supports operations to validate redirection, retrieve titles, and navigate through
// status code links on the redirected page.
// -------------------------------------------------------------------------------------------------

using System;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements redirection and status code page validation on HerokuApp using Selenium WebDriver.
    /// </summary>
    public class Redirector : IRedirect
    {
        private readonly IWebDriver _driver;
        private readonly string _redirectorUrl = "https://the-internet.herokuapp.com/redirector";

        // Locators for redirector page
        private readonly By headingLocator = By.TagName("h3");
        private readonly By paragraphLocator = By.CssSelector(".example p");
        private readonly By clickHereLinkLocator = By.LinkText("here");

        // Locators for status code page
        private readonly By statusHeadingLocator = By.TagName("h3");
        private readonly By statusParagraphLocator = By.CssSelector(".example p");

        public Redirector(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _driver.Navigate().GoToUrl(_redirectorUrl);
        }

        /// <summary>
        /// Gets the heading/title from the Redirector page.
        /// </summary>
        public string GetTitle()
        {
            return _driver.FindElement(headingLocator).Text;
        }

        /// <summary>
        /// Retrieves the main paragraph from the Redirector page.
        /// </summary>
        public string GetParagraphText()
        {
            return _driver.FindElement(paragraphLocator).Text;
        }

        /// <summary>
        /// Clicks the 'Click here' link to trigger redirection.
        /// </summary>
        public void ClickhereLink()
        {
            _driver.FindElement(clickHereLinkLocator).Click();
        }

        /// <summary>
        /// Gets the current URL after redirection.
        /// </summary>
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        /// <summary>
        /// Gets the title of the Status Codes page.
        /// </summary>
        public string GetStatusPageTitle()
        {
            return _driver.FindElement(statusHeadingLocator).Text;
        }

        /// <summary>
        /// Retrieves the paragraph content from the Status Codes page.
        /// </summary>
        public string GetStatusPageContent()
        {
            return _driver.FindElement(statusParagraphLocator).Text;
        }

        /// <summary>
        /// Clicks a specific status code link on the Status Codes page.
        /// </summary>
        /// <param name="statusCode">Status code to click (e.g., "200", "404").</param>
        public void ClickStatusCodeLink(string statusCode)
        {
            var linkLocator = By.LinkText(statusCode);
            _driver.FindElement(linkLocator).Click();
        }
    }
}
