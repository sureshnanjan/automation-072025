/*
* ------------------------------------------------------------------------------
* © 2025 Sowmya Sridhar. All rights reserved.
* This test file is part of the HerokuApp automated test suite.
* For internal, educational, or evaluation purposes only.
* ------------------------------------------------------------------------------
*/

using HerokuOperations;
using NUnit.Framework;

namespace HerokuAppScenarios;

public class FramesScenarios
{
    /// <summary>
    /// Test Design Techniques Used:
    /// - Black Box Testing: Tests are written based on UI behavior without internal code knowledge.
    /// - Modular Testing: Each frame and iframe-related component is tested in isolation.
    /// - Boundary Value Analysis: Frame margins are tested against expected boundary values.
    /// - State Transition Testing: Verifies changes in editor content and toolbar states.
    /// - UI Element Verification: Ensures proper visibility and functionality of toolbar options and links.
    /// </summary>
    public class FramesTests
    {
        [SetUp]
        public void Setup()
        {
            // Initialization if needed
        }

        /// <summary>
        /// Verifies the main "Frames" page heading is displayed correctly.
        /// </summary>
        [Test]
        public void FramesPageTitleIsCorrect()
        {
            // Arrange
            string expected = "Frames";
            IFrames framesPage = new Frames();

            // Act
            string actual = framesPage.GetHeading();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the left nested frame displays the text "LEFT".
        /// </summary>
        [Test]
        public void NestedFrames_LeftFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "LEFT";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            string actual = framesPage.GetLeftFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the middle nested frame displays the text "MIDDLE".
        /// </summary>
        [Test]
        public void NestedFrames_MiddleFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "MIDDLE";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            string actual = framesPage.GetMiddleFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the right nested frame displays the text "RIGHT".
        /// </summary>
        [Test]
        public void NestedFrames_RightFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "RIGHT";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            string actual = framesPage.GetRightFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the bottom frame displays the text "BOTTOM".
        /// </summary>
        [Test]
        public void NestedFrames_BottomFrame_DisplaysCorrectText()
        {
            // Arrange
            string expected = "BOTTOM";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            string actual = framesPage.GetBottomFrameText();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates that the nested frames layout includes a horizontal split.
        /// </summary>
        [Test]
        public void NestedFrames_FrameLayout_HasHorizontalSplit()
        {
            // Arrange
            bool expected = true;
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            bool actual = framesPage.IsHorizontallySplit();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Validates that the top frame is split vertically into three sub-frames.
        /// </summary>
        [Test]
        public void NestedFrames_FrameLayout_HasVerticalSplit()
        {
            // Arrange
            bool expected = true;
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            bool actual = framesPage.IsVerticallySplit();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the top frame has the expected margin value.
        /// </summary>
        [Test]
        public void NestedFrames_TopFrame_HasCorrectMargin()
        {
            // Arrange
            int expectedMargin = 0;
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            int actualMargin = framesPage.GetTopFrameMargin();

            // Assert
            Assert.AreEqual(expectedMargin, actualMargin);
        }

        /// <summary>
        /// Verifies that the bottom frame has the expected margin value.
        /// </summary>
        [Test]
        public void NestedFrames_BottomFrame_HasCorrectMargin()
        {
            // Arrange
            int expectedMargin = 0;
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickNestedFrameLink();
            int actualMargin = framesPage.GetBottomFrameMargin();

            // Assert
            Assert.AreEqual(expectedMargin, actualMargin);
        }

        /// <summary>
        /// Verifies navigation to the iFrame editor page.
        /// </summary>
        [Test]
        public void IFrameLinkNavigatesCorrectly()
        {
            // Arrange
            string expected = "An iFrame containing the TinyMCE WYSIWYG Editor";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            string actual = framesPage.GetIFramePageHeading();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks if the iFrame editor has the default placeholder text.
        /// </summary>
        [Test]
        public void IFrameEditorHasDefaultText()
        {
            // Arrange
            string expectedText = "Your content goes here.";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            string actualText = framesPage.GetTextFromEditor();

            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        /// <summary>
        /// Verifies that the user can edit text inside the iFrame editor.
        /// </summary>
        [Test]
        public void CanEditTextInsideEditor()
        {
            // Arrange
            string newText = "Hello, Heroku!";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            framesPage.ClearEditorText();
            framesPage.EnterTextInEditor(newText);
            string actualText = framesPage.GetTextFromEditor();

            // Assert
            Assert.AreEqual(newText, actualText);
        }

        /// <summary>
        /// Verifies that editor toolbar options like Bold and Italic are visible.
        /// </summary>
        [Test]
        public void EditorToolbarOptionsDisplayed()
        {
            // Arrange
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            bool isBoldVisible = framesPage.IsToolbarOptionVisible("Bold");
            bool isItalicVisible = framesPage.IsToolbarOptionVisible("Italic");

            // Assert
            Assert.IsTrue(isBoldVisible);
            Assert.IsTrue(isItalicVisible);
        }

        /// <summary>
        /// Verifies that text can be made bold inside the iFrame editor.
        /// </summary>
        [Test]
        public void CanMakeTextBoldInEditor()
        {
            // Arrange
            string text = "BoldText";
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            framesPage.ClearEditorText();
            framesPage.EnterTextInEditor(text);
            framesPage.SelectAllText();
            framesPage.ClickBoldButton();
            bool isBold = framesPage.IsTextBold();

            // Assert
            Assert.IsTrue(isBold);
        }

        /// <summary>
        /// Verifies that the "Powered by Tiny" link is visible in the iFrame editor page.
        /// </summary>
        [Test]
        public void PoweredByTinyLinkIsPresent()
        {
            // Arrange
            IFrames framesPage = new Frames();

            // Act
            framesPage.ClickIFrameLink();
            bool isPoweredByTinyPresent = framesPage.IsPoweredByTinyLinkVisible();

            // Assert
            Assert.IsTrue(isPoweredByTinyPresent);
        }
    }
}
