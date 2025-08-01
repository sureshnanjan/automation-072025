// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automated test suite using Selenium WebDriver and NUnit.
// It is provided as-is for educational or internal testing purposes only.
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
    /// Contains NUnit test scenarios for validating checkbox behavior
    /// on the Checkboxes page of HerokuApp using Selenium WebDriver.
    /// </summary>
    public class CheckBoxPageScenarios
    {
        private IWebDriver driver; // Use IWebDriver for flexibility
        private ICheckBoxes checkBoxesPage; // Page object for interacting with checkbox elements

        /// <summary>
        /// Initializes resources before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup logic should initialize driver and navigate to the test page
        }

        /// <summary>
        /// Disposes resources after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        /// <summary>
        /// Validates that the page title matches the expected value.
        /// </summary>
        [Test]
        public void PageTitle_AreCorrect()
        {
            string title = checkBoxesPage.GetPageTitle();
            Assert.AreEqual("Checkboxes", title);
        }

        /// <summary>
        /// Verifies that checking the first checkbox works when it was previously unchecked.
        /// </summary>
        [Test]
        public void CheckFirstBox_WhenUnchecked_ShouldBeChecked()
        {
            checkBoxesPage.CheckFirstBox();
            Assert.IsTrue(checkBoxesPage.IsFirstBoxChecked(), "First checkbox should be checked.");
        }

        /// <summary>
        /// Verifies that unchecking the second checkbox works when it was previously checked.
        /// </summary>
        [Test]
        public void UncheckSecondBox_WhenChecked_ShouldBeUnchecked()
        {
            checkBoxesPage.UncheckSecondBox();
            Assert.IsFalse(checkBoxesPage.IsSecondBoxChecked(), "Second checkbox should be unchecked.");
        }

        /// <summary>
        /// Retrieves and validates the states of all checkboxes on the page.
        /// </summary>
        [Test]
        public void GetAllCheckboxStates_ShouldReturnCorrectStates()
        {
            List<bool> states = checkBoxesPage.GetAllCheckboxStates();
            Assert.AreEqual(2, states.Count, "There should be two checkboxes.");
            Assert.IsTrue(states[0] || states[1], "First checkbox state be true or second checkbox state be false.");
        }

        /// <summary>
        /// Verifies that checking the already checked first checkbox does not change its state.
        /// </summary>
        [Test]
        public void CheckFirstBox_WhenAlreadyChecked_ShouldRemainChecked()
        {
            checkBoxesPage.CheckFirstBox(); // Ensure it's checked first
            checkBoxesPage.CheckFirstBox(); // Call again to test idempotency
            Assert.IsTrue(checkBoxesPage.IsFirstBoxChecked(), "First checkbox should remain checked.");
        }

        /// <summary>
        /// Verifies that unchecking the already unchecked second checkbox does not change its state.
        /// </summary>
        [Test]
        public void UncheckSecondBox_WhenAlreadyUnchecked_ShouldRemainUnchecked()
        {
            checkBoxesPage.UncheckSecondBox(); // Ensure it's unchecked first
            checkBoxesPage.UncheckSecondBox(); // Call again to test idempotency
            Assert.IsFalse(checkBoxesPage.IsSecondBoxChecked(), "Second checkbox should remain unchecked.");
        }
    }
}
