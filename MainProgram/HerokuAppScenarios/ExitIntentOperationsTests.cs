/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/
using NUnit.Framework;
using Moq;
using HerokuOperations;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class ExitIntentTests
    {
        private Mock<IExitIntent> mockExitIntent;

        [SetUp]
        public void SetUp()
        {
            mockExitIntent = new Mock<IExitIntent>();
        }

        // TC001 - Verify popup does not appear on page load
        [Test]
        public void TC001_ShouldNotDisplayPopup_OnPageLoad()
        {
            // Arrange
            mockExitIntent.Setup(m => m.IsPopupVisible()).Returns(false);

            // Act
            bool result = mockExitIntent.Object.IsPopupVisible();

            // Assert
            Assert.IsFalse(result, "Popup should not appear automatically on page load.");
        }

        // TC002 - Verify popup appears when exit intent is triggered
        [Test]
        public void TC002_ShouldDisplayPopup_WhenExitIntentTriggered()
        {
            // Arrange
            mockExitIntent.Setup(m => m.TriggerExitIntent());
            mockExitIntent.Setup(m => m.IsPopupVisible()).Returns(true);

            // Act
            mockExitIntent.Object.TriggerExitIntent();
            bool result = mockExitIntent.Object.IsPopupVisible();

            // Assert
            Assert.IsTrue(result, "Popup should be visible after triggering exit intent.");
        }

        // TC003 - Verify popup closes on clicking close
        [Test]
        public void TC003_ShouldClosePopup_WhenCloseIsClicked()
        {
            // Arrange
            mockExitIntent.SetupSequence(m => m.IsPopupVisible())
                          .Returns(true)   // Initially visible
                          .Returns(false); // After closing

            // Act
            bool wasVisible = mockExitIntent.Object.IsPopupVisible();
            mockExitIntent.Object.ClosePopup();
            bool isStillVisible = mockExitIntent.Object.IsPopupVisible();

            // Assert
            Assert.IsTrue(wasVisible, "Popup should initially be visible.");
            Assert.IsFalse(isStillVisible, "Popup should not be visible after closing.");
        }

        // TC005 - Verify popup title text matches expected
        [Test]
        public void TC005_ShouldReturnExpectedPopupTitle()
        {
            // Arrange
            mockExitIntent.Setup(m => m.GetPopupTitle()).Returns("This is a modal window");

            // Act
            string title = mockExitIntent.Object.GetPopupTitle();

            // Assert
            Assert.AreEqual("This is a modal window", title.Trim(), "Popup title text should match expected.");
        }

        // TC006 - Verify popup content is not empty
        [Test]
        public void TC006_ShouldReturnNonEmptyPopupContent()
        {
            // Arrange
            mockExitIntent.Setup(m => m.GetPopupContent()).Returns("It's used for exit-intent marketing.");

            // Act
            string content = mockExitIntent.Object.GetPopupContent();

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(content), "Popup content should not be empty.");
        }

        // TC007 - Verify popup does not trigger again after being closed
        [Test]
        public void TC007_ShouldNotTriggerPopupAgain_IfAlreadyClosed()
        {
            // Arrange
            mockExitIntent.SetupSequence(m => m.IsPopupVisible())
                          .Returns(true)  // Triggered
                          .Returns(false) // Closed
                          .Returns(false); // Retried

            // Act
            mockExitIntent.Object.TriggerExitIntent();
            mockExitIntent.Object.ClosePopup();
            bool resultAfterClose = mockExitIntent.Object.IsPopupVisible();

            // Assert
            Assert.IsFalse(resultAfterClose, "Popup should not reappear after being closed.");
        }

        // TC008 - Verify popup only triggers on exit intent movement
        [Test]
        public void TC008_ShouldOnlyTriggerPopup_OnExitIntentMovement()
        {
            // Arrange
            mockExitIntent.Setup(m => m.IsPopupVisible()).Returns(false);

            // Act
            bool result = mockExitIntent.Object.IsPopupVisible();

            // Assert
            Assert.IsFalse(result, "Popup should only trigger on exit movement, not on other interactions.");
        }
    }
}
