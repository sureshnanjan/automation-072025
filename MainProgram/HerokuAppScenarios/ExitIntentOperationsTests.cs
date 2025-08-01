/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Unit tests for the ExitIntentOperations class.
    /// Verifies the behavior of the exit intent popup including visibility,
    /// content, and user interactions like trigger and close.
    /// </summary>
    [TestFixture]
    public class ExitIntentOperationsTests
    {
        private IExitIntent exitIntent;

        /// <summary>
        /// Initializes a new instance of ExitIntentOperations before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            exitIntent = new ExitIntentOperations();
        }

        /// <summary>
        /// Verifies that the popup title is initially empty before triggering.
        /// </summary>
        [Test]
        public void GetPopupTitle_ShouldBeEmpty_Initially()
        {
            // Arrange
            // (No setup required beyond initialization)

            // Act
            var title = exitIntent.GetPopupTitle();

            // Assert
            Assert.AreEqual(string.Empty, title);
        }

        /// <summary>
        /// Verifies that the popup content is initially empty before triggering.
        /// </summary>
        [Test]
        public void GetPopupContent_ShouldBeEmpty_Initially()
        {
            // Arrange
            // (No setup required beyond initialization)

            // Act
            var content = exitIntent.GetPopupContent();

            // Assert
            Assert.AreEqual(string.Empty, content);
        }

        /// <summary>
        /// Ensures the popup displays the correct title and content when triggered.
        /// </summary>
        [Test]
        public void TriggerExitIntent_ShouldMakePopupVisible()
        {
            // Arrange
            // (No specific setup beyond object instantiation)

            // Act
            exitIntent.TriggerExitIntent();
            var title = exitIntent.GetPopupTitle();
            var content = exitIntent.GetPopupContent();

            // Assert
            Assert.AreEqual("This is a modal window", title);
            Assert.AreEqual("It's commonly used to show exit intent messages.", content);
        }

        /// <summary>
        /// Confirms that closing the popup hides the title and content.
        /// </summary>
        [Test]
        public void ClosePopup_ShouldMakePopupInvisible()
        {
            // Arrange
            exitIntent.TriggerExitIntent();

            // Act
            exitIntent.ClosePopup();
            var titleAfterClose = exitIntent.GetPopupTitle();
            var contentAfterClose = exitIntent.GetPopupContent();

            // Assert
            Assert.AreEqual(string.Empty, titleAfterClose);
            Assert.AreEqual(string.Empty, contentAfterClose);
        }
    }
}

