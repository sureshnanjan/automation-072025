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
    public class RedirectScenarios
    {
        /// <summary>
        /// Validate that the page title is "Redirection".
        /// </summary>
        [Test]
        public void GetTitle_ShouldReturnRedirection()
        {
            IRedirect redirect = new RedirectPage();
            string title = redirect.GetTitle();
            Assert.That(title, Is.EqualTo("Redirection"));
        }

        /// <summary>
        /// Validate that the paragraph text contains the word "redirect".
        /// </summary>
        [Test]
        public void GetParagraphText_ShouldContainRedirect()
        {
            IRedirect redirect = new RedirectPage();
            string paragraph = redirect.GetParagraphText();
            StringAssert.Contains("redirect", paragraph.ToLower());
        }

        /// <summary>
        /// Validate that clicking "here" navigates to the Status Codes page.
        /// </summary>
        [Test]
        public void ClickhereLink_ShouldNavigateToStatusCodesPage()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            string currentUrl = redirect.GetCurrentUrl();
            Assert.That(currentUrl, Does.Contain("/status_codes"));
        }

        /// <summary>
        /// Validate that the Status Codes page shows the correct title.
        /// </summary>
        [Test]
        public void GetStatusPageTitle_ShouldReturnStatusCodes()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            string title = redirect.GetStatusPageTitle();
            Assert.That(title, Is.EqualTo("Status Codes"));
        }

        /// <summary>
        /// Validate that the Status Codes page contains descriptive content.
        /// </summary>
        [Test]
        public void GetStatusPageContent_ShouldContainStatusCodes()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            string content = redirect.GetStatusPageContent();
            StringAssert.Contains("status codes", content.ToLower());
        }

        /// <summary>
        /// Validate that clicking the 200 link navigates to the correct page.
        /// </summary>
        [Test]
        public void ClickStatusCodeLink_200_ShouldShowCorrectContent()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("200");
            string content = redirect.GetStatusPageContent();
            StringAssert.Contains("200 status code", content.ToLower());
        }

        /// <summary>
        /// Validate that clicking the 301 link navigates to the correct page.
        /// </summary>
        [Test]
        public void ClickStatusCodeLink_301_ShouldShowCorrectContent()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("301");
            string content = redirect.GetStatusPageContent();
            StringAssert.Contains("301 status code", content.ToLower());
        }

        /// <summary>
        /// Validate that clicking the 404 link navigates to the correct page.
        /// </summary>
        [Test]
        public void ClickStatusCodeLink_404_ShouldShowCorrectContent()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("404");
            string content = redirect.GetStatusPageContent();
            StringAssert.Contains("404 status code", content.ToLower());
        }

        /// <summary>
        /// Validate that clicking the 500 link navigates to the correct page.
        /// </summary>
        [Test]
        public void ClickStatusCodeLink_500_ShouldShowCorrectContent()
        {
            IRedirect redirect = new RedirectPage();
            redirect.ClickhereLink();
            redirect.ClickStatusCodeLink("500");
            string content = redirect.GetStatusPageContent();
            StringAssert.Contains("500 status code", content.ToLower());
        }
    }
}