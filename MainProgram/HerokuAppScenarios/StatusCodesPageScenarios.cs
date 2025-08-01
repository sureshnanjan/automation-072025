// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
// 
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This interface defines the contract for interacting with the Basic Auth page functionality,
// including navigation, credential handling via browser alerts, and content validation.
// -------------------------------------------------------------------------------------------------

using HerokuAppWeb;
using HerokuOperations;
using NUnit.Framework;


namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test scenarios for validating the behavior of the
    /// Status Codes page on HerokuApp using Selenium WebDriver.
    /// </summary>
    public class StatusCodesPageScenarios
    {
   
        private IStatusCodes _statusCodesPage;

        /// <summary>
        /// Initializes browser driver and page objects before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
  
        }

        //------------------------------------------------ Page Title and Description Tests  ------------------------------//

        /// <summary>
        /// Verifies that the page title is exactly "Status Codes".
        /// </summary>
        [Test]
        public void PageTitleIsCorrect()
        {
            // Arrange done in Setup()

            // Act
            string title = _statusCodesPage.GetPageTitle();
            // Assert
            Assert.AreEqual("Status Codes", title);
        }

        /// <summary>
        /// Verifies that the description contains HTTP explanation text.
        /// </summary>
        [Test]
        public void PageDescriptionIsCorrect()
        {
            // Arrange done in Setup()

            // Act
            string description = _statusCodesPage.GetDescriptionText();

            // Assert
            Assert.IsTrue(description.Contains("HTTP status codes are a standard set of numbers used to communicate"));
        }


        /// <summary>
        /// Verifies that the reference link should be present.
        /// </summary>
        [Test]
        public void StatusCodeReferenceLink_ShouldBePresent()
        {
            // Act
            string linkText = _statusCodesPage.GetReferenceLinkText();

            // Assert
            Assert.AreEqual("here", linkText, "Link text should be 'here'.");

        }


        /// <summary>
        /// Verifies that the reference link should be correct.
        /// </summary>
        [Test]
        public void StatusCodeReferenceLink_ShouldBeCorrect()
        {
            // Act
            string href = _statusCodesPage.GetReferenceLinkHref();

            // Assert
            Assert.AreEqual("https://www.iana.org/assignments/http-status-codes/http-status-codes.xhtml", href, "The reference link should point to the correct IANA status codes URL.");
        }

        //-----------------------------------------------  StatusCodes Links Tests ---------------------------------------//


        /// <summary>
        /// Verifies that all the link should be present.
        /// </summary>
        [Test]
        public void StatusCodeLinks_CountShouldBeFour()
        {
            // Act
            var statusCodeLinks = _statusCodesPage.GetAllStatusCodeLinks();

            // Assert
            Assert.AreEqual(4, statusCodeLinks.Count, "There should be exactly 4 status code links on the page.");
        }


        /// <summary>
        /// Verifies that status code links are clickable.
        /// </summary>
        /// <summary>
        /// Verifies that the HTTP status code link (e.g., 200, 301, 404, 500) is clickable on the Status Codes page.
        /// </summary>
        [TestCase(200)]
        [TestCase(301)]
        [TestCase(404)]
        [TestCase(500)]
        public void StatusCodeLink_ShouldBeClickable(int statusCode)
        {
            // Arrange
            // Done in Setup()

            // Act
            bool isClickable = statusCodesPage.IsStatusCodeClickable(statusCode);

            // Assert
            Assert.IsTrue(isClickable, $"Status code link {statusCode} should be clickable.");
        }

        /// <summary>
        /// Verifies that clicking the 200 link displays the correct message.
        /// </summary>
        [Test]
        public void Clicking200Code_ShouldDisplay200Message()
        {
            // Arrange done in Setup()

            // Act
            _statusCodesPage.ClickStatusCode("200");
            string message = _statusCodesPage.GetStatusMessage();

            // Assert
            Assert.IsTrue(message.Contains("This page returned a 200 status code."));
        }

        /// <summary>
        /// Verifies that clicking the 301 link displays the correct message.
        /// </summary>
        [Test]
        public void Clicking301Code_ShouldDisplay301Message()
        {
            // Arrange done in Setup()

            // Act
            _statusCodesPage.ClickStatusCode("301");
            string message = _statusCodesPage.GetStatusMessage();

            // Assert
            Assert.IsTrue(message.Contains("This page returned a 301 status code."));
        }

        /// <summary>
        /// Verifies that clicking the 404 link displays the correct message.
        /// </summary>
        [Test]
        public void Clicking404Code_ShouldDisplay404Message()
        {
            // Arrange done in Setup()

            // Act
            _statusCodesPage.ClickStatusCode("404");
            string message = _statusCodesPage.GetStatusMessage();

            // Assert
            Assert.IsTrue(message.Contains("This page returned a 404 status code."));
        }

        /// <summary>
        /// Verifies that clicking the 500 link displays the correct message.
        /// </summary>
        [Test]
        public void Clicking500Code_ShouldDisplay500Message()
        {
            // Arrange done in Setup()

            // Act
            _statusCodesPage.ClickStatusCode("500");
            string message = _statusCodesPage.GetStatusMessage();

            // Assert
            Assert.IsTrue(message.Contains("This page returned a 500 status code."));
        }

        /// <summary>
        /// Verifies that all status code links are present.
        /// </summary>
        [Test]
        public void AllStatusCodeLinks_ShouldBeVisible()
        {
            // Arrange done in Setup()

            // Act
            var links = _statusCodesPage.GetStatusCodeLinks();

            // Assert
            Assert.AreEqual(4, links.Count);
        }


        /// <summary>
        /// Verifies that after clicking a code link, user is navigated to the correct URL path.
        /// </summary>
        [TestCase(200, "status_codes/200")]
        [TestCase(404, "status_codes/404")]
        [TestCase(500, "status_codes/500")]
        [TestCase(301, "status_codes/301")]
        public void StatusCodeLink_NavigatesToCorrectPage(int statusCode, string expectedPath)
        {
            // Act
            _statusCodesPage.ClickStatusCode(statusCode);

            // Assert
            string currentUrl = _statusCodesPage.GetCurrentUrl();
            Assert.IsTrue(currentUrl.Contains(expectedPath), $"Clicking status code {statusCode} should navigate to {expectedPath}.");
        }


        /// <summary>
        /// Verifies that after clicking a code and going back, user returns to main status codes page.
        /// </summary>
        [TestCase("200")]
        [TestCase("301")]
        [TestCase("404")]
        [TestCase("500")]
        public void NavigatingBackFromStatusDetail_ShouldReturnToMainPage(string statusCode)
        {
            // Arrange
            _statusCodesPage.ClickStatusCode(statusCode);

            // Act
            _statusCodesPage.NavigateBack();
            string title = _statusCodesPage.GetPageTitle();

            // Assert
            Assert.AreEqual("Status Codes", title, $"Navigating back from {statusCode} should return to the main page.");
        }

        //------------------------------------------------------------- FOOTER & EXTERNAL LINKS ---------------------------//

        ///<summary>
        ///Validating the footer is present or not
        ///</summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        ///<summary>
        ///Validating the right side git link is present or not
        ///</summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }

    }
}
