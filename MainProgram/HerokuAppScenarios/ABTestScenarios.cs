// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ABTestPageTests.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   Licensed under the MIT License.
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
//
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Contains automated test scenarios for verifying functionalities of the A/B Test page
    /// in the Heroku web application using Selenium WebDriver and NUnit framework.
    /// </summary>
    [TestFixture]
    public class ABTestPageTests
    {
        
        private ABTestPage _abTestPage;

        /// <summary>
        /// Sets up the browser instance and initializes the ABTestPage object before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary>
        /// Validates that the page title matches one of the expected A/B Testing variants.
        /// </summary>
        [Test]
        public void GetTitle_ShouldReturnABTestingTitle()
        {
            // Act
            string title = _abTestPage.GetTitle();

            // Assert
            Assert.That(title, Is.EqualTo("A/B Test Variation 1").Or.EqualTo("A/B Test Control"),
                "Page title should match one of the A/B Testing variants.");
        }

        /// <summary>
        /// Validates that the A/B Test page description is not null or empty.
        /// </summary>
        [Test]
        public void GetDescription_ShouldReturnValidDescription()
        {
            // Act
            string description = _abTestPage.GetDescription();

            // Assert
            Assert.That(description, Is.Not.Null.And.Not.Empty,
                "Description text should not be empty.");
        }

        /// <summary>
        /// Validates that disabling the A/B test updates the URL to include the 'optout=true' query parameter.
        /// </summary>
        [Test]
        public void DisableABTest_ShouldNavigateToOptOutVersion()
        {
            // Act
            _abTestPage.DisableABTest();

            // Assert
            Assert.That(_driver.Url, Does.Contain("optout=true"),
                "URL should indicate A/B test is disabled.");
        }

        /// <summary>
        /// Cleans up resources and closes the browser after test execution.
        /// Ensures no browser instances remain open after tests complete.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
