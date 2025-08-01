// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automated test suite using Selenium WebDriver and NUnit.
// It is provided as-is for educational or internal testing purposes only.
// -------------------------------------------------------------------------------------------------

using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test scenarios for validating the behavior of the
    /// Status Codes page on HerokuApp using Selenium WebDriver.
    /// </summary>
    public class StatusCodesPageScenarios
    {
        private IWebDriver driver;
        private IStatusCodes statusCodesPage;

        /// <summary>
        /// Initializes browser driver and page objects before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup logic should initialize driver and navigate to Status Codes page
        }

        /// <summary>
        /// Closes and quits the browser driver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        /// <summary>
        /// Verifies that the page title and description text are correct.
        /// </summary>
        [Test]
        public void PageTitleAndDescription_AreCorrect()
        {
            string title = statusCodesPage.GetPageTitle();
            string description = statusCodesPage.GetDescriptionText();

            Assert.AreEqual("Status Codes", title);
            Assert.IsTrue(description.Contains("HTTP status codes are a standard set of numbers used to communicate from a web server to your browser to indicate the outcome of the request being made (e.g. Success, Redirection, Client Error, Server Error). For a complete list of status codes, go here."));
        }

        /// <summary>
        /// Clicks a given HTTP status code link and verifies that the correct message is displayed.
        /// </summary>
        /// <param name="code">HTTP status code to click.</param>
        /// <param name="expectedMessage">Expected message fragment shown after clicking the code.</param>
        [TestCase("200", "This page returned a 200 status code.")]
        [TestCase("301", "This page returned a 301 status code.")]
        [TestCase("404", "This page returned a 404 status code.")]
        [TestCase("500", "This page returned a 500 status code.")]
        public void ClickStatusCode_DisplaysCorrectMessage(string code, string expectedMessage)
        {
            statusCodesPage.ClickStatusCode(code);
            string message = statusCodesPage.GetStatusMessage();
            Assert.IsTrue(message.Contains(expectedMessage));
        }
    }
}
