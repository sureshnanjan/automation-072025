/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class ExitIntentOperationsTests : IExitIntent
    {
        private IExitIntent exitIntent;

        [SetUp]
        public void SetUp()
        {
            exitIntent = new ExitIntentOperations();
        }

        [Test]
        public void GetPopupTitle_ShouldBeEmpty_Initially()
        {
            Assert.AreEqual(string.Empty, exitIntent.GetPopupTitle());
        }

        [Test]
        public void GetPopupContent_ShouldBeEmpty_Initially()
        {
            Assert.AreEqual(string.Empty, exitIntent.GetPopupContent());
        }

        [Test]
        public void TriggerExitIntent_ShouldMakePopupVisible()
        {
            // Act
            exitIntent.TriggerExitIntent();

            // Assert
            Assert.AreEqual("This is a modal window", exitIntent.GetPopupTitle());
            Assert.AreEqual("It's commonly used to show exit intent messages.", exitIntent.GetPopupContent());
        }

        [Test]
        public void ClosePopup_ShouldMakePopupInvisible()
        {
            // Arrange
            exitIntent.TriggerExitIntent();
            exitIntent.ClosePopup();

            // Assert
            Assert.AreEqual(string.Empty, exitIntent.GetPopupTitle());
            Assert.AreEqual(string.Empty, exitIntent.GetPopupContent());
        }

        
    }
}

