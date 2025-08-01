// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automated test suite using Selenium WebDriver and NUnit.
// It is provided as-is for educational or testing purposes only.
// -------------------------------------------------------------------------------------------------

using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test scenarios for validating the Challenging DOM page
    /// on the HerokuApp using Selenium WebDriver.
    /// </summary>
    public class ChallengingDOMPageScenarios
    {
        private ChromeDriver driver; // WebDriver instance for Chrome
        private IChallengingDOM challengingDOMPage; // Page object for Challenging DOM page

        /// <summary>
        /// Sets up the WebDriver and page objects before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup logic to be implemented (driver initialization, navigation, etc.)
        }

        /// <summary>
        /// Cleans up and disposes of the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // Properly dispose to clean up resources
        }

        /// <summary>
        /// Verifies that the page title and description text are correct.
        /// </summary>
        [Test]
        public void PageTitleAndDescription_AreCorrect()
        {
            string title = challengingDOMPage.GetPageTitle();
            string description = challengingDOMPage.GetDescriptionText();

            Assert.AreEqual("Challenging DOM", title);
            Assert.IsTrue(description.Contains("The hardest part in automated web testing is finding the best locators (e.g., ones that well named, unique, and unlikely to change). It's more often than not that the application you're testing was not built with this concept in mind. This example demonstrates that with unique IDs, a table with no helpful locators, and a canvas element."));
        }

        /// <summary>
        /// Ensures clicking each button does not throw an exception.
        /// </summary>
        [Test]
        public void ClickButtons_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => challengingDOMPage.ClickBlueButton());
            Assert.DoesNotThrow(() => challengingDOMPage.ClickRedButton());
            Assert.DoesNotThrow(() => challengingDOMPage.ClickGreenButton());
        }

        /// <summary>
        /// Verifies that the table headers contain the expected values.
        /// </summary>
        [Test]
        public void TableHeaders_AreCorrect()
        {
            List<string> headers = challengingDOMPage.GetTableHeaders();
            Assert.IsTrue(headers.Count > 0);
            Assert.Contains("Lorem", headers);
            Assert.Contains("Ipsum", headers);
            Assert.Contains("Dolor", headers);
            Assert.Contains("Sit", headers);
            Assert.Contains("Amet", headers);
            Assert.Contains("Diceret", headers);
            Assert.Contains("Action", headers);
        }

        /// <summary>
        /// Ensures table rows exist and match the header column count.
        /// </summary>
        [Test]
        public void TableRows_Exist()
        {
            List<List<string>> rows = challengingDOMPage.GetTableRows();
            Assert.IsTrue(rows.Count > 0);
            Assert.AreEqual(rows[0].Count, challengingDOMPage.GetTableHeaders().Count);
        }

        /// <summary>
        /// Ensures Edit and Delete actions do not throw any exceptions.
        /// </summary>
        [Test]
        public void EditAndDeleteRow_NoExceptionThrown()
        {
            Assert.DoesNotThrow(() => challengingDOMPage.ClickEdit(0));
            Assert.DoesNotThrow(() => challengingDOMPage.ClickDelete(0));
        }

        /// <summary>
        /// Verifies that the Edit button triggers the modal popup.
        /// </summary>
        [Test]
        public void IsEditButtonWorking()
        {
            challengingDOMPage.ClickEdit(0);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".modal")).Displayed, "Edit modal should be displayed.");
        }

        /// <summary>
        /// Verifies that the Delete button triggers a confirmation alert.
        /// </summary>
        [Test]
        public void IsDeleteButtonWorking()
        {
            challengingDOMPage.ClickDelete(0);
            Assert.IsTrue(driver.SwitchTo().Alert().Text.Contains("Are you sure"), "Delete confirmation alert should appear.");
        }
    }
}
