// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# NUnit test class defines UI behavior validations for the Notification Message feature
// on the HerokuApp, using the INotificationMessagePage interface. These tests abstract the driver 
// implementation and validate the correctness, persistence, randomness, stability, and format of 
// notifications triggered through the UI.

using NUnit.Framework;
using HerokuOperations;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class for verifying notification message behavior via the INotificationMessagePage interface.
    /// </summary>
    public class NotificationMessageTests
    {
        /// <summary>
        /// ✅ Verifies the heading is correct and visible.
        /// </summary>
        [Test]
        public void Heading_IsDisplayedCorrectly()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act
            string actual = notificationPage.GetPageHeading();

            // Assert
            Assert.AreEqual("Notification Message", actual);
        }

        /// <summary>
        /// ✅ Verifies that a notification message appears after the trigger link is clicked.
        /// </summary>
        [Test]
        public void Message_ShowsAfterTrigger()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act
            notificationPage.ClickTriggerLink();
            string message = notificationPage.GetNotificationMessage();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(message), "Notification message should appear after trigger.");
        }

        /// <summary>
        /// ✅ Verifies that clicking the trigger link multiple times generates varying messages.
        /// </summary>
        [Test]
        public void Message_VariesOnRepeatedTrigger()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();
            HashSet<string> uniqueMessages = new();

            // Act
            for (int i = 0; i < 10; i++)
            {
                notificationPage.ClickTriggerLink();
                string message = notificationPage.GetNotificationMessage();
                uniqueMessages.Add(message);
            }

            // Assert
            Assert.Greater(uniqueMessages.Count, 1, "Messages are not varying on multiple clicks.");
        }

        /// <summary>
        /// ✅ Verifies message content format is proper (ends with close symbol '×').
        /// </summary>
        [Test]
        public void Message_HasProperCloseSymbol()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act
            notificationPage.ClickTriggerLink();
            string message = notificationPage.GetNotificationMessage();

            // Assert
            Assert.IsTrue(message.Trim().EndsWith("×"), "Message should end with the close symbol '×'.");
        }

        /// <summary>
        /// ✅ Verifies message disappears only on user action or remains floating.
        /// </summary>
        [Test]
        public void Message_IsStickyUntilClosed()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act
            notificationPage.ClickTriggerLink();
            string messageBefore = notificationPage.GetNotificationMessage();
            string messageAfter = notificationPage.GetNotificationMessage();

            // Assert
            Assert.AreEqual(messageBefore, messageAfter, "Message should persist unless closed manually.");
        }

        /// <summary>
        /// ✅ Verifies the message shows "Action successful" at least once after repeated triggers.
        /// </summary>
        [Test]
        public void Message_CanBeSuccess()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();
            bool successSeen = false;

            // Act
            for (int i = 0; i < 10; i++)
            {
                notificationPage.ClickTriggerLink();
                string msg = notificationPage.GetNotificationMessage();
                if (msg.Contains("Action successful"))
                {
                    successSeen = true;
                    break;
                }
            }

            // Assert
            Assert.IsTrue(successSeen, "'Action successful' message never appeared in multiple attempts.");
        }

        /// <summary>
        /// ✅ Verifies clicking the trigger 100+ times still does not break or crash message logic.
        /// </summary>
        [Test]
        public void Trigger_HandlesHighClickVolume()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                for (int i = 0; i < 150; i++)
                {
                    notificationPage.ClickTriggerLink();
                    notificationPage.GetNotificationMessage();
                }
            }, "Triggering the link repeatedly should not cause any exceptions.");
        }

        /// <summary>
        /// ✅ Verifies no hidden message is shown unless explicitly triggered.
        /// </summary>
        [Test]
        public void Message_IsNotVisibleInitially()
        {
            // Arrange
            INotificationMessagePage notificationPage = new NotificationMessagePage();

            // Act
            string initial = notificationPage.GetNotificationMessage();

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(initial) || initial.Trim().Length == 0,
                "Message should not appear before any interaction.");
        }
    }
}
