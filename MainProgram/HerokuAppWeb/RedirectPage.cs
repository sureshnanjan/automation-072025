// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan R. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Author: Elangovan R
// Created On: [Insert Date Here, e.g., 2025-08-05]
//
// Description:
// [Briefly describe the purpose of this file, e.g.]
// This class implements the RedirectPage functionality to verify HTTP redirection behavior
// using Selenium WebDriver.
// -------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of the <see cref="IRedirect"/> interface for automating redirect verification using Selenium.
    /// Provides functionality to interact with the redirect page, click links, and verify status code redirections.
    /// </summary>
    public class RedirectPage : IRedirect
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://the-internet.herokuapp.com/redirector";

        // Locators
        private readonly By headingLocator = By.TagName("h3");
        private readonly By paragraphLocator = By.TagName("p");
        private readonly By clickHereLink = By.LinkText("here");
        private readonly By statusCodeLinks = By.CssSelector(".example a");

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectPage"/> class and navigates to the redirector page.
        /// </summary>
        /// <param name="driver">Instance of Selenium WebDriver.</param>
        /// <exception cref="ArgumentNullException">Thrown if driver is null.</exception>
        public RedirectPage()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Optional: headless mode for speed
            _driver = new ChromeDriver(chromeOptions);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        /// <summary>
        /// Retrieves the main heading text from the redirect page.
        /// </summary>
        /// <returns>The heading text as a string.</returns>
        public string GetTitle()
        {
            return _driver.FindElement(headingLocator).Text;
        }

        /// <summary>
        /// Retrieves the paragraph text from the redirect page.
        /// </summary>
        /// <returns>The paragraph text as a string.</returns>
        public string GetParagraphText()
        {
            return _driver.FindElement(paragraphLocator).Text;
        }

        /// <summary>
        /// Clicks the "here" link to trigger the redirect.
        /// </summary>
        public void ClickhereLink()
        {
            _driver.FindElement(clickHereLink).Click();
        }

        /// <summary>
        /// Gets the current URL after redirection.
        /// </summary>
        /// <returns>The current URL as a string.</returns>
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        /// <summary>
        /// Retrieves the main heading from the status code page after redirection.
        /// </summary>
        /// <returns>The heading text of the status page as a string.</returns>
        public string GetStatusPageTitle()
        {
            return _driver.FindElement(headingLocator).Text;
        }

        /// <summary>
        /// Retrieves the paragraph content from the status code page.
        /// </summary>
        /// <returns>The content text of the status page as a string.</returns>
        public string GetStatusPageContent()
        {
            return _driver.FindElement(paragraphLocator).Text;
        }

        /// <summary>
        /// Clicks on a specific HTTP status code link from the list of available codes.
        /// </summary>
        /// <param name="statusCode">The HTTP status code (e.g., "200", "404") to click.</param>
        /// <exception cref="NoSuchElementException">Thrown if the status code link is not found on the page.</exception>
        public void ClickStatusCodeLink(string statusCode)
        {
            var links = _driver.FindElements(statusCodeLinks);
            var codeLink = links.FirstOrDefault(a => a.Text.Trim() == statusCode);

            if (codeLink == null)
                throw new NoSuchElementException($"Status code link '{statusCode}' not found.");

            codeLink.Click();
        }
    }
}
