// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddRemoveElementsPageTests.cs">
//   Copyright © 2025 Varun Kumar Reddy D.
//   All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited.
//   Proprietary and confidential.
//   Written by Varun Kumar Reddy D <your_email@example.com>, 2025.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuTests
{
    /// <summary>
    /// Unit tests for verifying behavior of the IAddRemoveElementsPage interface methods.
    /// </summary>
    [TestFixture]
    public class AddRemoveElementsPageTests
    {
        // D — Dependency Inversion Principle:
        // Depends on abstraction (interface) instead of concrete implementation.
        private IAddRemoveElementsPage _page;

        [Test]
        public void ClickAddElementButton_WhenCalled_ShouldAddNewElement()
        {
            // S — Single Responsibility: Adds one element and checks for change in count

            // Arrange
            int initialCount = _page.GetDeleteButtonCount();

            // Act
            _page.ClickAddElementButton();
            int updatedCount = _page.GetDeleteButtonCount();

            // Assert
            Assert.Greater(updatedCount, initialCount);
        }

        [Test]
        public void ClickDeleteButton_WhenCalled_ShouldRemoveAnElement()
        {
            // S — Single Responsibility: Adds and deletes one element and checks for count

            // Arrange
            _page.ClickAddElementButton(); // Ensure at least one element exists
            int countBeforeDelete = _page.GetDeleteButtonCount();

            // Act
            _page.ClickDeleteButton();
            int countAfterDelete = _page.GetDeleteButtonCount();

            // Assert
            Assert.Less(countAfterDelete, countBeforeDelete);
        }

        [Test]
        public void IsDeleteButtonDisplayed_WhenElementPresent_ShouldReturnTrue()
        {
            // S — Single Responsibility: Validates visibility of delete button

            // Arrange
            _page.ClickAddElementButton();

            // Act
            bool isVisible = _page.IsDeleteButtonDisplayed();

            // Assert
            Assert.IsTrue(isVisible);
        }

        [Test]
        public void GetDeleteButtonCount_WhenNoElementAdded_ShouldReturnZero()
        {
            // S — Single Responsibility: Checks default count without additions

            // Act
            int count = _page.GetDeleteButtonCount();

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void GetDeleteButtonCount_WhenElementsAdded_ShouldReturnCorrectCount()
        {
            // S — Single Responsibility: Adds multiple elements and checks total

            // Arrange
            _page.ClickAddElementButton();
            _page.ClickAddElementButton();

            // Act
            int count = _page.GetDeleteButtonCount();

            // Assert
            Assert.AreEqual(2, count);
        }

        [Test]
        public void IsFooterPoweredByVisible_WhenCalled_ShouldReturnTrueIfVisible()
        {
            // S — Single Responsibility: Footer validation only

            // Act
            bool isFooterVisible = _page.IsFooterPoweredByVisible();

            // Assert
            Assert.IsTrue(isFooterVisible);
        }

        [Test]
        public void IsGitHubRibbonVisible_WhenCalled_ShouldReturnTrueIfVisible()
        {
            // S — Single Responsibility: GitHub ribbon visibility only

            // Act
            bool isGitHubVisible = _page.IsGitHubRibbonVisible();

            // Assert
            Assert.IsTrue(isGitHubVisible);
        }
    }
}
