/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/
using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class EntryAdTests
    {
        private Mock<IEntryAd> mockEntryAd;

        [SetUp]
        public void SetUp()
        {
            mockEntryAd = new Mock<IEntryAd>();
        }

        // TC001 – Verify modal appears on first page load
        [Test]
        public void TC001_ShouldDisplayModal_OnFirstPageLoad()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ShouldModalAppearOnLoad()).Returns(true);

            // Act
            bool result = mockEntryAd.Object.ShouldModalAppearOnLoad();

            // Assert
            Assert.IsTrue(result, "Modal should appear on first page load.");
        }

        // TC002 – Verify modal does not appear after closing and refreshing
        [Test]
        public void TC002_ShouldNotDisplayModal_AfterClosingAndRefreshing()
        {
            // Arrange
            mockEntryAd.Setup(m => m.IsModalVisible()).Returns(false);

            // Act
            bool result = mockEntryAd.Object.IsModalVisible();

            // Assert
            Assert.IsFalse(result, "Modal should not appear after closing and refreshing.");
        }

        // TC003 – Verify modal appears again on clicking “click here”
        [Test]
        public void TC003_ShouldDisplayModal_OnClickingClickHere()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ReEnableModal());
            mockEntryAd.Setup(m => m.IsModalVisible()).Returns(true);

            // Act
            mockEntryAd.Object.ReEnableModal();
            bool result = mockEntryAd.Object.IsModalVisible();

            // Assert
            Assert.IsTrue(result, "Modal should appear after clicking 'click here'.");
        }

        // TC004 – Verify close button closes the modal
        [Test]
        public void TC004_ShouldCloseModal_WhenCloseModalIsCalled()
        {
            // Arrange
            mockEntryAd.SetupSequence(m => m.IsModalVisible())
                .Returns(true)  // Initially visible
                .Returns(false); // After closing

            // Act
            bool wasVisible = mockEntryAd.Object.IsModalVisible();
            mockEntryAd.Object.CloseModal();
            bool isVisibleAfterClose = mockEntryAd.Object.IsModalVisible();

            // Assert
            Assert.IsTrue(wasVisible, "Modal should initially be visible.");
            Assert.IsFalse(isVisibleAfterClose, "Modal should not be visible after CloseModal.");
        }

        // TC005 – Verify modal does not reappear in same session
        [Test]
        public void TC005_ShouldNotReappearInSameSession_WithoutClickHere()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ShouldModalAppearOnLoad()).Returns(false);

            // Act
            bool result = mockEntryAd.Object.ShouldModalAppearOnLoad();

            // Assert
            Assert.IsFalse(result, "Modal should not reappear in the same session.");
        }

        // TC006 – Verify modal appears in new session
        [Test]
        public void TC006_ShouldAppear_OnNewSession()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ShouldModalAppearOnLoad()).Returns(true);

            // Act
            bool result = mockEntryAd.Object.ShouldModalAppearOnLoad();

            // Assert
            Assert.IsTrue(result, "Modal should appear in a new session.");
        }

        // TC008 – Verify ad stays hidden without “click here” trigger
        [Test]
        public void TC008_ShouldRemainHidden_IfClickHereNotUsed()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ShouldModalAppearOnLoad()).Returns(false);

            // Act
            bool result = mockEntryAd.Object.ShouldModalAppearOnLoad();

            // Assert
            Assert.IsFalse(result, "Modal should remain hidden if 'click here' is not triggered.");
        }

        // TC009 – Verify multiple re-enables toggle the modal
        [Test]
        public void TC009_ShouldToggleModalVisibility_OnMultipleClickHere()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ReEnableModal());
            mockEntryAd.SetupSequence(m => m.IsModalVisible())
                .Returns(true)
                .Returns(false)
                .Returns(true);

            // Act & Assert
            mockEntryAd.Object.ReEnableModal();
            Assert.IsTrue(mockEntryAd.Object.IsModalVisible(), "Modal should be visible after 1st click.");

            mockEntryAd.Object.CloseModal();
            Assert.IsFalse(mockEntryAd.Object.IsModalVisible(), "Modal should be hidden after close.");

            mockEntryAd.Object.ReEnableModal();
            Assert.IsTrue(mockEntryAd.Object.IsModalVisible(), "Modal should be visible again after 2nd click.");
        }

        // TC011 – Verify modal does not reappear on tab duplication (same session)
        [Test]
        public void TC011_ShouldNotAppear_OnTabDuplication()
        {
            // Arrange
            mockEntryAd.Setup(m => m.ShouldModalAppearOnLoad()).Returns(false);

            // Act
            bool result = mockEntryAd.Object.ShouldModalAppearOnLoad();

            // Assert
            Assert.IsFalse(result, "Modal should not appear again on tab duplication.");
        }
    }
}
