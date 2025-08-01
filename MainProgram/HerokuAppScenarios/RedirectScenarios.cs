/**
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
*/

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit test cases for validating the Redirector page
    /// using the IRedirect interface, following AAA (Arrange-Act-Assert) pattern.
    /// </summary>
    public class RedirectScenarios
    {
        /// <summary>
        /// Verifies that the heading text on the Redirector page is correct.
        /// </summary>
        [Test]
        public void GetTitle_ShouldReturnCorrectText()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            string title = redirect.GetTitle();

            // Assert
            Assert.That(title, Is.EqualTo("Redirection"), "The page title does not match the expected value.");
        }

        /// <summary>
        /// Verifies that the paragraph text on the Redirector page contains the expected keyword.
        /// </summary>
        [Test]
        public void GetParagraphText_ShouldContainExpectedMessage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            string paragraph = redirect.GetParagraphText();

            // Assert
            StringAssert.Contains("redirect", paragraph.ToLower(), "The paragraph does not contain the expected keyword.");
        }

        /// <summary>
        /// Verifies that clicking the 'Click here' link redirects to the Status Codes page.
        /// </summary>
        [Test]
        public void ClickhereLink_ShouldRedirectToStatusCodesPage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            string currentUrl = redirect.GetCurrentUrl();

            // Assert
            Assert.That(currentUrl, Does.Contain("/status_codes"), "The page did not redirect to the Status Codes page.");
        }

        /// <summary>
        /// Verifies that the Status Codes page displays the correct title after redirection.
        /// </summary>
        [Test]
        public void AfterClickhereLink_StatusCodesPage_ShouldDisplayCorrectTitle()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            string title = redirect.GetStatusPageTitle();

            // Assert
            Assert.That(title, Is.EqualTo("Status Codes"), "The Status Codes page title does not match the expected value.");
        }

        /// <summary>
        /// Verifies that the Status Codes page contains descriptive content after redirection.
        /// </summary>
        [Test]
        public void AfterClickhereLink_StatusCodesPage_ShouldContainExpectedContent()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            string content = redirect.GetStatusPageContent();

            // Assert
            StringAssert.Contains("status codes", content.ToLower(), "The Status Codes page does not contain the expected content.");
        }

        /// <summary>
        /// Verifies that clicking on the 200 Status Code link navigates to the correct page.
        /// </summary>
        [Test]
        public void AfterClickhereLink_Click200_ShouldNavigateToCorrectStatusPage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("200");
            string content = redirect.GetStatusPageContent();

            // Assert
            StringAssert.Contains("200 status code", content.ToLower(), "The 200 Status Code page does not display the expected content.");
        }

        /// <summary>
        /// Verifies that clicking on the 301 Status Code link navigates to the correct page.
        /// </summary>
        [Test]
        public void AfterClickhereLink_Click301_ShouldNavigateToCorrectStatusPage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("301");
            string content = redirect.GetStatusPageContent();

            // Assert
            StringAssert.Contains("301 status code", content.ToLower(), "The 301 Status Code page does not display the expected content.");
        }

        /// <summary>
        /// Verifies that clicking on the 404 Status Code link navigates to the correct page.
        /// </summary>
        [Test]
        public void AfterClickhereLink_Click404_ShouldNavigateToCorrectStatusPage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("404");
            string content = redirect.GetStatusPageContent();

            // Assert
            StringAssert.Contains("404 status code", content.ToLower(), "The 404 Status Code page does not display the expected content.");
        }

        /// <summary>
        /// Verifies that clicking on the 500 Status Code link navigates to the correct page.
        /// </summary>
        [Test]
        public void AfterClickhereLink_Click500_ShouldNavigateToCorrectStatusPage()
        {
            // Arrange
            IRedirect redirect = TestObjectFactory.CreateRedirect();

            // Act
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("500");
            string content = redirect.GetStatusPageContent();

            // Assert
            StringAssert.Contains("500 status code", content.ToLower(), "The 500 Status Code page does not display the expected content.");
        }
    }
}
