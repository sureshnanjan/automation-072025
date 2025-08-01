// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// Implements the IRedirect interface for interacting with the redirection page
// on https://the-internet.herokuapp.com/redirector using Selenium WebDriver.

using System;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements interaction logic for the redirection page.
    /// </summary>
    internal class Redirect : IRedirect
    {
        private readonly IWebDriver _driver;

        /// <summary>
        /// Constructor to initialize the WebDriver instance.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance.</param>
        public Redirect(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Retrieves the title from the <h3> tag on the redirection page.
        /// </summary>
        /// <returns>The title string.</returns>
        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h3")).Text.Trim();
        }

        /// <summary>
        /// Clicks the "here" link to initiate redirection.
        /// </summary>
        public void ClickhereLink()
        {
            _driver.FindElement(By.LinkText("here")).Click();
        }

        /// <summary>
        /// Retrieves the paragraph text shown below the title.
        /// </summary>
        /// <returns>The paragraph text string.</returns>
        public string GetParagraphText()
        {
            return _driver.FindElement(By.TagName("p")).Text.Trim();
        }
    }
}
