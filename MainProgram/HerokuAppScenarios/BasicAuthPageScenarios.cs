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
//
// --------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using HerokuOperations;

namespace HerokuOperationsTests
{
    [TestFixture]
    public class BasicAuthPageScenarios
    {
        private IWebDriver _driver;
        private BasicAuth _basicAuthPage;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Create instance of BasicAuthPage
            _basicAuthPage = new BasicAuthPage(_driver);
        }

        [Test]
        public void NavigateToPage_WithValidCredentials_ShouldDisplayCorrectTitle()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            string title = _basicAuthPage.GetPageTitle();

            // Assert
            Assert.That(title, Is.EqualTo("The Internet"), "Page title should be 'The Internet' after successful login.");
        }

        [Test]
        public void GetPageDescription_ShouldReturnSuccessMessage()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            _basicAuthPage.NavigateToPage(username, password);
            string description = _basicAuthPage.GetPageDescription();

            // Assert
            Assert.That(description, Does.Contain("Congratulations"), "Description should indicate successful login.");
        }

        [TearDown]
        public void TearDown()
        {
            // Close browser after test
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}
