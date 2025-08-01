<<<<<<< HEAD
﻿// -------------------------------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
=======
// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This test class validates the Basic Authentication page functionality by testing navigation,
// credential verification, login success/failure scenarios, session management, and page behavior.
// -------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;
using System;

namespace HerokuAppScenarios
{
    /// <summary>
<<<<<<< HEAD
    /// NUnit test class for verifying the Basic Auth page behavior using the IBasicAuth interface.
    /// Covers positive, negative, and edge cases to ensure secure and functional authentication handling.
=======
    /// Test scenarios for Basic Authentication pop-up handling.
    /// Implements NUnit test cases following SOLID principles for quality automation.
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
    /// </summary>
    [TestFixture]
    public class BasicAuthPageTests
    {
<<<<<<< HEAD
        private IBasicAuth _basicAuthPage;

        [SetUp]
        public void Setup()
        {
            // Normally, you'd initialize a concrete implementation of IBasicAuth here.
            // Example:
            // _basicAuthPage = new BasicAuthPageImplementation();
        }

        /// <summary>
        /// Ensures navigating to the Basic Auth page with valid credentials succeeds.
        /// </summary>
        [Test]
        public void NavigateToPage_WithValidCredentials_ShouldLoadSuccessfully()
=======
        private IBasicAuthPage _basicAuthPage;

        /// <summary>
        /// Validates that navigating to the Basic Auth page with valid credentials
        /// displays the expected page title.
        /// </summary>
        [Test]
        public void NavigationPageWithValidCredentials()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            Assert.DoesNotThrow(() => _basicAuthPage.NavigateToPage("admin", "admin"),
                "Navigation with valid credentials should not throw exceptions.");
        }

        /// <summary>
        /// Ensures that invalid credentials result in an unsuccessful login.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void IsCredentialIsCorrect_WithInvalidCredentials_ShouldReturnFalse()
        {
            bool result = _basicAuthPage.IsCredentialIsCorrect("invalid", "wrong");
            Assert.IsFalse(result, "Invalid credentials should return false.");
        }

        /// <summary>
        /// Verifies that valid credentials return true when checked.
        /// </summary>
        [Test]
        public void IsCredentialIsCorrect_WithValidCredentials_ShouldReturnTrue()
        {
            bool result = _basicAuthPage.IsCredentialIsCorrect("admin", "admin");
            Assert.IsTrue(result, "Valid credentials should return true.");
        }

        /// <summary>
        /// Verifies that the page title is displayed correctly after login.
        /// </summary>
        [Test]
        public void GetPageTitle_AfterLogin_ShouldReturnCorrectTitle()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            string title = _basicAuthPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("The Internet"), "Page title should match expected value.");
        }

        /// <summary>
        /// Verifies that a success message is displayed after successful login.
        /// </summary>
        [Test]
        public void GetPageDescription_AfterSuccessfulLogin_ShouldContainSuccessMessage()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            string description = _basicAuthPage.GetPageDescription();

            Assert.That(description, Does.Contain("Congratulations"), "Success message should be displayed.");
        }

        /// <summary>
        /// Ensures that login failure message is returned for wrong credentials.
        /// </summary>
        [Test]
        public void GetLoginErrorMessage_WithInvalidCredentials_ShouldReturnErrorMessage()
        {
            _basicAuthPage.NavigateToPage("invalid", "wrong");
            string errorMsg = _basicAuthPage.GetLoginErrorMessage();

            Assert.That(errorMsg, Is.Not.Null.And.Not.Empty, "Error message should be displayed for invalid login.");
        }

        /// <summary>
        /// Ensures the HTTP status code for valid login is 200 (OK).
        /// </summary>
        [Test]
        public void GetHttpStatusCode_WithValidCredentials_ShouldReturn200()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            int statusCode = _basicAuthPage.GetHttpStatusCode();

            Assert.That(statusCode, Is.EqualTo(200), "Status code should be 200 for successful login.");
        }

        /// <summary>
        /// Ensures login prompt is visible before entering credentials.
        /// </summary>
        [Test]
        public void IsLoginPromptVisible_BeforeLogin_ShouldReturnTrue()
        {
            bool isVisible = _basicAuthPage.IsLoginPromptVisible();
            Assert.IsTrue(isVisible, "Login prompt should be visible before entering credentials.");
        }

        /// <summary>
        /// Verifies that a user can log out successfully after login.
        /// </summary>
        [Test]
        public void Logout_AfterSuccessfulLogin_ShouldTerminateSession()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            _basicAuthPage.Logout();

            bool isSessionActive = _basicAuthPage.IsSessionActive();
            Assert.IsFalse(isSessionActive, "Session should not be active after logout.");
        }

        /// <summary>
        /// Ensures WaitForPageToLoad completes without errors after navigation.
        /// </summary>
        [Test]
        public void WaitForPageToLoad_AfterNavigation_ShouldNotThrowExceptions()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            Assert.DoesNotThrow(() => _basicAuthPage.WaitForPageToLoad(),
                "Page load should complete without exceptions.");
        }

        /// <summary>
        /// Ensures page refresh does not break authentication.
        /// </summary>
        [Test]
        public void RefreshPage_AfterLogin_ShouldMaintainSession()
        {
            _basicAuthPage.NavigateToPage("admin", "admin");
            _basicAuthPage.RefreshPage();

            bool sessionActive = _basicAuthPage.IsSessionActive();
            Assert.IsTrue(sessionActive, "Session should remain active after page refresh.");
=======
        public void PageDescriptionGivingSuccessfullyMessageForLogin()
        {
            // Arrange
            const string username = "admin";
            const string password = "admin";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            var description = _basicAuthPage.GetPageDescription();

            // Assert
            Assert.That(description, Does.Contain("Logged in Successfully")
                .Or.Contain("Congratulations"), "Description should indicate successful login.");
        }

        /// <summary>
        /// Validates that attempting login with incorrect credentials 
        /// does not allow access to the page.
        /// </summary>
        [Test]
        public void NavigationPageWithInvalidCredentials_ShouldFailLogin()
        {
            // Arrange
            const string username = "wrongUser";
            const string password = "wrongPass";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            var title = _basicAuthPage.GetPageTitle();

            // Assert
            Assert.That(title, Is.Not.EqualTo("The Internet"),
                "Page title should not match expected value for invalid credentials.");
        }

        /// <summary>
        /// Validates that attempting login with empty username and password
        /// shows authentication required prompt.
        /// </summary>
        [Test]
        public void NavigationPageWithEmptyCredentials_ShouldShowAuthRequired()
        {
            // Arrange
            const string username = "";
            const string password = "";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _basicAuthPage.NavigateToPage(username, password));
            Assert.That(ex.Message, Does.Contain("Username and password cannot be empty"));
        }

        /// <summary>
        /// Validates that cancelling login attempt does not allow access to the page.
        /// </summary>
        [Test]
        public void CancelLogin_ShouldNotAllowAccess()
        {
            // Arrange
            const string username = "admin";
            const string password = "admin";

            // Act
            _basicAuthPage.CancelAuthentication(); // Assuming CancelAuthentication is implemented
            var title = _basicAuthPage.GetPageTitle();

            // Assert
            Assert.That(title, Is.Not.EqualTo("The Internet"),
                "Page should not be accessible if login is cancelled.");
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        }
    }
}
