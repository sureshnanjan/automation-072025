// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
//
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// --------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Test scenarios for Basic Authentication pop-up handling.
    /// Implements NUnit test cases following SOLID principles for quality automation.
    /// </summary>
    [TestFixture]
    public class BasicAuthPageScenarios
    {
        private IBasicAuthPage _basicAuthPage;

        /// <summary>
        /// Validates that navigating to the Basic Auth page with valid credentials
        /// displays the expected page title.
        /// </summary>
        [Test]
        public void NavigationPageWithValidCredentials()
        {
            // Arrange
            const string username = "admin";
            const string password = "admin";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            var title = _basicAuthPage.GetPageTitle();

            // Assert
            Assert.That(title, Is.EqualTo("The Internet"),
                "Page title should be 'The Internet' after successful login.");
        }

        /// <summary>
        /// Validates that after successful login, the page displays a success message.
        /// </summary>
        [Test]
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
        }
    }
}
