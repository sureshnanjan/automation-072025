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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Test scenarios for Basic Authentication page automation.
    /// Implements NUnit test cases following SOLID principles for quality automation.
    /// </summary>
    [TestFixture]
    public class BasicAuthPageScenarios
    {
        private IBasicAuthPage _basicAuthPage;

        /// <summary>
        /// Setup method executed before each test.
        /// Initializes the Chrome WebDriver and page object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary>
        /// Validates that navigating to the Basic Auth page with valid credentials
        /// displays the expected page title.
        /// </summary>
        [Test]
        public void NavigateToPage_WithValidCredentials_ShouldDisplayCorrectTitle()
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
        public void GetPageDescription_ShouldReturnSuccessMessage()
        {
            // Arrange
            const string username = "admin";
            const string password = "admin";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            var description = _basicAuthPage.GetPageDescription();

            // Assert
            Assert.That(description, Does.Contain("Congratulations"),
                "Description should indicate successful login.");
        }

        /// <summary>
        /// TearDown method executed after each test to ensure proper cleanup.
        /// Closes browser session and releases WebDriver resources.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
