// -------------------------------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This NUnit test class validates the Basic Authentication page functionality using the IBasicAuth interface.
// Test cases cover navigation, credential verification, login success/failure scenarios, session handling,
// HTTP response validation, and UI element visibility checks for better coverage.
// -------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to validate Basic Auth functionality for the HerokuApp using IBasicAuth interface.
    /// </summary>
    [TestFixture]
    public class BasicAuthInterfaceTests
    {
        private IBasicAuth _basicAuthPage;

        [SetUp]
        public void Setup()
        {
            // Normally, a concrete implementation of IBasicAuth is initialized here.
            // Example: _basicAuthPage = new BasicAuthPageImplementation();
        }

        /// <summary>
        /// Test to verify navigation with valid credentials is successful.
        /// </summary>
        [Test]
        public void NavigateToPage_ValidCredentials_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => _basicAuthPage.NavigateToPage("admin", "admin"),
                "Valid credentials should allow navigation without exceptions.");
        }

        /// <summary>
        /// Test to verify navigation with invalid credentials fails gracefully.
        /// </summary>
        [Test]
        public void NavigateToPage_InvalidCredentials_ShouldShowErrorMessage()
        {
            _basicAuthPage.NavigateToPage("invalid", "wrong");
            string errorMessage = _basicAuthPage.GetLoginErrorMessage();

            Assert.That(errorMessage, Is.Not.Null.And.Not.Empty,
                "Invalid credentials should show an error message.");
        }

        /// <summary>
        /// Test to ensure valid credentials return true when checked.
        /// </summary>
        [Test]
        public void IsCredentialIsCorrect_ValidCredentials_ShouldReturnTrue()
        {
            bool isValid = _basicAuthPage.IsCredentialIsCorrect("admin", "admin");
            Assert.IsTrue(isValid, "Valid credentials should return true.");
        }

        /// <summary>
        /// Test to ensure invalid credentials return false.
        /// </summary>
        [Test]
        public void IsCredentialIsCorrect_InvalidCredentials_ShouldReturnFalse()
        {
            bool isValid = _basicAuthPage.IsCredentialIsCorrect("user", "wrong");
            Assert.IsFalse(isValid, "Invalid credentials should return false.");
        }

        /// <summary>
        /// Test to verify page title after successful login.
        /// </summary>
        [Test]
        public void GetPageTitle_AfterLogin_ShouldReturnExpectedTitle()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            string title = _basicAuthPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("The Internet"), "Page title should match 'The Internet'.");
        }

        /// <summary>
        /// Test to verify page description after successful login.
        /// </summary>
        [Test]
        public void GetPageDescription_AfterLogin_ShouldContainSuccessMessage()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            string description = _basicAuthPage.GetPageDescription();

            Assert.That(description, Does.Contain("Congratulations"),
                "Page description should indicate successful login.");
        }

        /// <summary>
        /// Test to verify HTTP status code for successful login is 200.
        /// </summary>
        [Test]
        public void GetHttpStatusCode_ValidLogin_ShouldReturn200()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            int statusCode = _basicAuthPage.GetHttpStatusCode();

            Assert.That(statusCode, Is.EqualTo(200), "Expected HTTP 200 after successful login.");
        }

        /// <summary>
        /// Test to ensure login prompt is visible before login attempt.
        /// </summary>
        [Test]
        public void IsLoginPromptVisible_BeforeLogin_ShouldReturnTrue()
        {
            bool isPromptVisible = _basicAuthPage.IsLoginPromptVisible();
            Assert.IsTrue(isPromptVisible, "Login prompt should be visible before entering credentials.");
        }

        /// <summary>
        /// Test to verify successful logout terminates the session.
        /// </summary>
        [Test]
        public void Logout_AfterLogin_ShouldDeactivateSession()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            _basicAuthPage.Logout();

            Assert.IsFalse(_basicAuthPage.IsSessionActive(),
                "Session should not remain active after logout.");
        }

        /// <summary>
        /// Test to verify session remains active after successful login.
        /// </summary>
        [Test]
        public void IsSessionActive_AfterLogin_ShouldReturnTrue()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            bool isActive = _basicAuthPage.IsSessionActive();

            Assert.IsTrue(isActive, "Session should remain active after successful login.");
        }

        /// <summary>
        /// Test to verify page waits for load completion after navigation.
        /// </summary>
        [Test]
        public void WaitForPageToLoad_ShouldNotThrowExceptions()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            Assert.DoesNotThrow(() => _basicAuthPage.WaitForPageToLoad(),
                "Page loading should complete without exceptions.");
        }

        /// <summary>
        /// Test to verify refresh maintains session state.
        /// </summary>
        [Test]
        public void RefreshPage_AfterLogin_ShouldKeepSessionActive()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            _basicAuthPage.RefreshPage();

            Assert.IsTrue(_basicAuthPage.IsSessionActive(),
                "Refreshing page should not log the user out.");
        }

        /// <summary>
        /// Test to verify "Powered by Elemental Selenium" footer visibility.
        /// </summary>
        [Test]
        public void IsFooterPoweredByVisible_ShouldReturnTrue()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            bool isFooterVisible = _basicAuthPage.IsFooterPoweredByVisible();

            Assert.IsTrue(isFooterVisible, "Footer 'Powered by Elemental Selenium' should be visible.");
        }

        /// <summary>
        /// Test to verify "Fork me on GitHub" ribbon visibility.
        /// </summary>
        [Test]
        public void IsGitHubRibbonVisible_ShouldReturnTrue()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            bool isRibbonVisible = _basicAuthPage.IsGitHubRibbonVisible();

            Assert.IsTrue(isRibbonVisible, "GitHub ribbon should be visible and clickable.");
        }
    }
}
