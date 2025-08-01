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
        /// Initializes a fresh ExitIntentOperations instance before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            exitIntent = new ExitIntentOperations();
        }

        /// <summary>
        /// Verifies that the popup title is empty before it is triggered.
        /// </summary>
        [Test]
        public void GetPopupTitle_ShouldBeEmpty_Initially()
        {
            Assert.AreEqual(string.Empty, exitIntent.GetPopupTitle());
        }

        /// <summary>
        /// Verifies that the popup content is empty before it is triggered.
        /// </summary>
        [Test]
        public void GetPopupContent_ShouldBeEmpty_Initially()
        {
            Assert.AreEqual(string.Empty, exitIntent.GetPopupContent());
        }

        /// <summary>
        /// Ensures that triggering the exit intent makes the popup visible with correct title and content.
        /// </summary>
        [Test]
        public void TriggerExitIntent_ShouldMakePopupVisible()
        {
            // Act
            exitIntent.TriggerExitIntent();

            // Assert
            Assert.AreEqual("This is a modal window", exitIntent.GetPopupTitle());
            Assert.AreEqual("It's commonly used to show exit intent messages.", exitIntent.GetPopupContent());
        }

        /// <summary>
        /// Confirms that after closing the popup, it becomes invisible and its title and content are empty.
        /// </summary>
        [Test]
        public void ClosePopup_ShouldMakePopupInvisible()
        {
            // Arrange
            exitIntent.TriggerExitIntent();

            // Act
            exitIntent.ClosePopup();

            // Assert
            Assert.AreEqual(string.Empty, exitIntent.GetPopupTitle());
            Assert.AreEqual(string.Empty, exitIntent.GetPopupContent());
        }
    }
}

