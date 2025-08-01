// -----------------------------------------------------------------------------
// © 2025 Gayathri Thalapathi. All rights reserved.
// This code is part of the HerokuApp test automation suite.
// Unauthorized use or distribution is prohibited.
// -----------------------------------------------------------------------------
using HerokuAppWeb;
using HerokuOperations;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Scenario-based test suite for validating the context menu feature on HerokuApp.
    /// </summary>
    [TestFixture]
    public class ContextMenuScenarios
    {
        private IContextMenu contextMenu;

        /// <summary>
        /// Test setup executed before each test case.
        /// </summary>
        [SetUp]
        public void InitializeTestContext()
        {
        }

        /// <summary>
        /// Verifies that the title displayed on the page matches the expected title.
        /// </summary>
        [Test]
        public void Validate_PageTitle_MatchesExpected()
        {
            // Arrange
            string expectedTitle = "The Internet";

            // Act
            string actualTitle = contextMenu.GetTitle();

            // Assert
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Mismatch in the displayed page title.");
        }

        /// <summary>
        /// Validates that the contextual description contains expected text.
        /// </summary>
        [Test]
        public void Validate_HeaderContent_IsRelevant()
        {
            // Act
            string headerContent = contextMenu.GetInformation();

            // Assert
            StringAssert.Contains("Context Menu", headerContent, "Header text does not mention 'Context Menu'.");
        }

        /// <summary>
        /// Ensures invoking a context interaction on the designated area triggers the expected system response.
        /// </summary>
        [Test]
        public void Trigger_ContextInteraction_ExpectSystemAlert()
        {
            // Act
            contextMenu.RightClickOnBox();
            string alertMessage = contextMenu.GetAlertText();

            // Assert
            Assert.That(alertMessage, Is.EqualTo("You selected a context menu"), "Unexpected alert message received.");
        }

        /// <summary>
        /// Confirms that the alert box can be programmatically dismissed after the interaction.
        /// </summary>
        [Test]
        public void Resolve_AlertDialog_Successfully()
        {
            // Arrange
            contextMenu.RightClickOnBox();

            // Act & Assert
            Assert.DoesNotThrow(() => contextMenu.AcceptAlert(), "System alert was not dismissed successfully.");
        }
        /// <summary>
        /// Verifies that performing a context click outside the target box does not trigger an alert popup.
        /// </summary>
        /// <summary>
        /// Verifies that performing a context click outside the target box does not trigger an alert popup.
        /// </summary>
        /// <summary>
        /// Verifies that performing a context click outside the target box does not trigger an alert popup.
        /// </summary>
        [Test]
        public void RightClickOutsideBox_ShouldNotTriggerAlert()
        {
            // Act & Assert
            Assert.Throws<NoAlertPresentException>(() =>
            {
                contextMenu.ContextInteractionOutsideBox();
            }, "Alert was unexpectedly triggered by right-clicking outside the designated area.");
        }


    }
}
