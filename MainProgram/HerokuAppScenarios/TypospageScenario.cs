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

using HerokuOperations;
using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains test scenarios for validating the Typos Page functionality.
    /// Tests are written following best practices for maintainable and reusable automation.
    /// </summary>
    [TestFixture]
    public class TyposPageTests
    {
        /// <summary>
        /// Interface reference for the Typos Page object.
        /// The actual implementation should be injected or instantiated 
        /// in the Setup method to follow dependency inversion principles.
        /// </summary>
        private ITyposPage _typosPage;

        /// <summary>
        /// Setup method that executes before each test case.
        /// This is where the TyposPage implementation instance would normally be initialized.
        /// Example:
        /// <code>_typosPage = new TyposPageImplementation();</code>
        /// </summary>
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary>
        /// Test case to verify that navigating to the Typos Page returns the expected page title.
        /// </summary>
        [Test]
        public void NavigateToPage_ShouldReturnExpectedTitle()
        {
            // Arrange
            const string expectedTitle = "Typos Page";

            // Act
            _typosPage.NavigateToPage();
            string actualTitle = _typosPage.GetPageTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected value.");
        }

        /// <summary>
        /// Test case to verify that the Typos Page displays the correct description text.
        /// </summary>
        [Test]
        public void NavigateToPage_ShouldReturnExpectedDescription()
        {
            // Arrange
            const string expectedDescription = "This is a sample page to check for typos.";

            // Act
            _typosPage.NavigateToPage();
            string actualDescription = _typosPage.GetPageDescription();

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription, "Page description does not match expected value.");
        }

        /// <summary>
        /// Test case to verify that the Typos Page does not contain any spelling errors or typos.
        /// </summary>
        [Test]
        public void Page_ShouldNotContainAnyTypos()
        {
            // Arrange
            _typosPage.NavigateToPage();

            // Act
            bool hasTypos = _typosPage.HasTypos();

            // Assert
            Assert.IsFalse(hasTypos,
                "Page contains typos, which is unexpected.");
        }
    }
}
