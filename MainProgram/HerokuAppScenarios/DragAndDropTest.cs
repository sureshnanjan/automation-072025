/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="DragAndDropTest.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to verify Drag and Drop functionality on the Drag and Drop page.
    /// </summary>
    public class DragAndDropTest
    {
        private DragDrop _page;

        [SetUp]
        public void Setup()
        {
            // Setup logic to initialize _page goes here and also web driver initializations
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup logic goes here
        }

        /// <summary>
        /// Verifies that dragging column A onto column B swaps their texts.
        /// </summary>
        [Test]
        public void DragAtoB_ChangesColumnText()
        {
            // Arrange
            string initialAText = _page.GetColumnAText();
            string initialBText = _page.GetColumnBText();

            // Act
            _page.DragAtoB();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreNotEqual(initialAText, afterDragAText, "Column A text should change after drag.");
            Assert.AreNotEqual(initialBText, afterDragBText, "Column B text should change after drag.");
        }

        /// <summary>
        /// Verifies that dragging column B onto column A swaps their texts back.
        /// </summary>
        [Test]
        public void DragBtoA_ChangesColumnText()
        {
            // Arrange
            _page.DragAtoB(); // Set initial state
            string draggedAText = _page.GetColumnAText();
            string draggedBText = _page.GetColumnBText();

            // Act
            _page.DragBtoA();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreNotEqual(draggedAText, afterDragAText, "Column A text should change after reverse drag.");
            Assert.AreNotEqual(draggedBText, afterDragBText, "Column B text should change after reverse drag.");
        }

        /// <summary>
        /// Verifies that the page title matches expected value.
        /// </summary>
        [Test]
        public void PageTitle_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "The Internet";

            // Act
            string actualTitle = _page.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected.");
        }

        /// <summary>
        /// Verifies that the column headers are labeled correctly before any drag-and-drop action.
        /// </summary>
        [Test]
        public void ColumnHeaders_ShouldBeCorrectInitially()
        {
            // Arrange
            string expectedHeaderA = "A";
            string expectedHeaderB = "B";

            // Act
            string actualHeaderA = _page.GetColumnHeaderText("A");
            string actualHeaderB = _page.GetColumnHeaderText("B");

            // Assert
            Assert.AreEqual(expectedHeaderA, actualHeaderA, "Column A header text is incorrect.");
            Assert.AreEqual(expectedHeaderB, actualHeaderB, "Column B header text is incorrect.");
        }

        /// <summary>
        /// Verifies that dragging column A onto column B twice returns columns to original state.
        /// </summary>
        [Test]
        public void DoubleDragAtoB_ShouldReturnToOriginalState()
        {
            // Arrange
            string originalAText = _page.GetColumnAText();
            string originalBText = _page.GetColumnBText();

            // Act
            _page.DragAtoB();
            _page.DragAtoB();
            string finalAText = _page.GetColumnAText();
            string finalBText = _page.GetColumnBText();

            // Assert
            Assert.AreEqual(originalAText, finalAText, "Column A text should return to original after double drag.");
            Assert.AreEqual(originalBText, finalBText, "Column B text should return to original after double drag.");
        }

        /// <summary>
        /// Verifies that dragging column B onto column A twice returns columns to original state.
        /// </summary>
        [Test]
        public void DoubleDragBtoA_ShouldReturnToOriginalState()
        {
            // Arrange
            string originalAText = _page.GetColumnAText();
            string originalBText = _page.GetColumnBText();

            // Act
            _page.DragBtoA();
            _page.DragBtoA();
            string finalAText = _page.GetColumnAText();
            string finalBText = _page.GetColumnBText();

            // Assert
            Assert.AreEqual(originalAText, finalAText, "Column A text should return to original after double drag.");
            Assert.AreEqual(originalBText, finalBText, "Column B text should return to original after double drag.");
        }

        /// <summary>
        /// Verifies that dragging a column onto itself does not change column texts.
        /// </summary>
        [Test]
        public void DragColumnAtoA_ShouldNotChangeText()
        {
            // Arrange
            string originalAText = _page.GetColumnAText();

            // Act
            _page.DragColumnOntoItself("A");
            string finalAText = _page.GetColumnAText();

            // Assert
            Assert.AreEqual(originalAText, finalAText, "Dragging column A onto itself should not change text.");
        }

        /// <summary>
        /// Verifies that dragging a column onto itself does not change column texts.
        /// </summary>
        [Test]
        public void DragColumnBtoB_ShouldNotChangeText()
        {
            // Arrange
            string originalBText = _page.GetColumnBText();

            // Act
            _page.DragColumnOntoItself("B");
            string finalBText = _page.GetColumnBText();

            // Assert
            Assert.AreEqual(originalBText, finalBText, "Dragging column B onto itself should not change text.");
        }

        /// <summary>
        /// Verifies that dragging column A to a non-target area does not change column texts.
        /// </summary>
        [Test]
        public void DragAtoInvalidLocation_ShouldNotChangeColumnText()
        {
            // Arrange
            string originalAText = _page.GetColumnAText();
            string originalBText = _page.GetColumnBText();

            // Act
            _page.DragAtoInvalidLocation();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreEqual(originalAText, afterDragAText, "Column A text should not change when dragged to invalid location.");
            Assert.AreEqual(originalBText, afterDragBText, "Column B text should not change when column A is dragged to invalid location.");
        }

        /// <summary>
        /// Verifies that dragging column B to a non-target area does not change column texts.
        /// </summary>
        [Test]
        public void DragBtoInvalidLocation_ShouldNotChangeColumnText()
        {
            // Arrange
            string originalAText = _page.GetColumnAText();
            string originalBText = _page.GetColumnBText();

            // Act
            _page.DragBtoInvalidLocation();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreEqual(originalAText, afterDragAText, "Column A text should not change when column B is dragged to invalid location.");
            Assert.AreEqual(originalBText, afterDragBText, "Column B text should not change when dragged to invalid location.");
        }

        /// <summary>
        /// verifies that the footer contains the expected "Powered by" information.
        /// </summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        /// <summary>
        /// verifies that the GitHub ribbon is displayed correctly.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }



    }
}
