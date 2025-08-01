/*
 * ------------------------------------------------------------------------------
 * © 2025 Sowmya Sridhar. All rights reserved.
 * This test file is part of the HerokuApp automated test suite.
 * For internal, educational, or evaluation purposes only.
 * ------------------------------------------------------------------------------
 */

using NUnit.Framework;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test Design Strategy:
    /// • Black-box Testing — test cases validate UI behavior without inspecting implementation.
    /// • Modular Testing — each frame or layout section is verified independently.
    /// • UI Layout Testing: Ensures visual frame structure meets expected layout
    /// </summary>
    public class NestedFramesTests
    {
        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// Verifies that the left frame displays the expected text "LEFT".
        /// </summary>
        [Test]
        public void NestedFrames_LeftFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "LEFT";
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            string actual = nestedFramesPage.GetLeftFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the middle frame displays the expected text "MIDDLE".
        /// </summary>
        [Test]
        public void NestedFrames_MiddleFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "MIDDLE";
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            string actual = nestedFramesPage.GetMiddleFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the right frame displays the expected text "RIGHT".
        /// </summary>
        [Test]
        public void NestedFrames_RightFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "RIGHT";
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            string actual = nestedFramesPage.GetRightFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the bottom frame displays the expected text "BOTTOM".
        /// </summary>
        [Test]
        public void NestedFrames_BottomFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "BOTTOM";
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            string actual = nestedFramesPage.GetBottomFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates that the nested frames layout has a horizontal split 
        /// (i.e., a top and bottom frame).
        /// </summary>
        [Test]
        public void NestedFrames_FrameLayout_HasHorizontalSplit()
        {
            // Arrange
            bool expected = true;
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            bool actual = nestedFramesPage.IsHorizontallySplit();

            // Assert
            Assert.AreEqual(expected, actual, "Expected a horizontal frame split between top and bottom frames.");
        }

        /// <summary>
        /// Validates that the top frame is split vertically 
        /// into left, middle, and right frames.
        /// </summary>
        [Test]
        public void NestedFrames_FrameLayout_HasVerticalSplit()
        {
            // Arrange
            bool expected = true;
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            bool actual = nestedFramesPage.IsVerticallySplit();

            // Assert
            Assert.AreEqual(expected, actual, "Expected a vertical frame split inside the top frame.");
        }

        /// <summary>
        /// Checks that the top frame has the expected margin.
        /// </summary>
        [Test]
        public void NestedFrames_TopFrame_HasCorrectMargin()
        {
            // Arrange
            int expectedMargin = 0;
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            int actualMargin = nestedFramesPage.GetTopFrameMargin();

            // Assert
            Assert.AreEqual(expectedMargin, actualMargin, "Top frame margin does not match expected value.");
        }

        /// <summary>
        /// Checks that the bottom frame has the expected margin.
        /// </summary>
        [Test]
        public void NestedFrames_BottomFrame_HasCorrectMargin()
        {
            // Arrange
            int expectedMargin = 0;
            INestedFrames nestedFramesPage = new NestedFrames();

            // Act
            int actualMargin = nestedFramesPage.GetBottomFrameMargin();

            // Assert
            Assert.AreEqual(expectedMargin, actualMargin, "Bottom frame margin does not match expected value.");
        }
    }
}
