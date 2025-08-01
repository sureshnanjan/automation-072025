/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: RedirectScenarios.cs
* Purpose: Test scenarios for verifying redirection functionality 
*          in the HerokuApp "Redirector" page.
* 
* Description:
* This file contains NUnit test cases for the `IRedirect` interface 
* in the `HerokuOperations` namespace. It tests the page title, 
* paragraph content, redirection link, and final redirected page.
*******************************************************/

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test scenarios for verifying redirection functionality
    /// on the HerokuApp Redirector page.
    /// </summary>
    [TestFixture]
    public class RedirectScenarios
    {
        private IWebDriver driver;
        private IRedirect redirect;

        /// <summary>
        /// Initializes the Chrome driver and page object before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize Chrome WebDriver
            driver = new ChromeDriver();

            // Navigate to the redirector page
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/redirector");

            // TODO: Initialize the concrete implementation of IRedirect
            // Example: redirect = new RedirectPage(driver);
        }

        /// <summary>
        /// Closes the browser after each test.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        /// <summary>
        /// Verifies that the page title of the Redirector page is correct.
        /// </summary>
        [Test]
        public void GetTitle_ShouldReturnCorrectText()
        {
            string title = redirect.GetTitle();
            Assert.That(title, Is.EqualTo("Redirection"), "The page title does not match the expected value.");
        }

        /// <summary>
        /// Verifies that the paragraph text on the Redirector page contains the keyword 'redirect'.
        /// </summary>
        [Test]
        public void GetParagraphText_ShouldContainExpectedMessage()
        {
            string paragraph = redirect.GetParagraphText();
            StringAssert.Contains("redirect", paragraph, "The paragraph does not contain the expected keyword.");
        }

        /// <summary>
        /// Verifies that clicking the 'Click here' link redirects to the Status Codes page.
        /// </summary>
        [Test]
        public void ClickhereLink_ShouldRedirectToStatusCodesPage()
        {
            redirect.ClickhereLink();
            Assert.That(driver.Url, Does.Contain("/status_codes"), "The page did not redirect to the Status Codes page.");
        }

        /*
         *  Test Cases (to be implemented):
         * 
         * 1. GetTitle() - Validate heading of the Redirector page.
         * 2. GetContent() - Verify the content of the page.
         * 3. GetLogo() - Check if a logo is present.
         * 4. ClickHere() - Verify redirection to the next page:
         *    4.1. Clickhere() - Should redirect to the next page.
         *    4.2. GetTitleStatusCode() - Validate the title of the Status Codes page.
         *    4.3. GetContentStatusCode() - Validate the paragraph content.
         *    4.4. Get200() - Verify navigation to the 200 Status Code page.
         */
    }
}
