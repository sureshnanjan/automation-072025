// Copyright © 2025 Varun Kumar Reddy D.
// All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// Written by Varun Kumar Reddy D <your_email@example.com>, 2025.

using NUnit.Framework;
using HerokuOperations;

namespace HerokuTests
{
    [TestFixture]
    public class TinyMCEEditorPageTests
    {
        // D — Dependency Inversion Principle:
        // High-level modules (test logic) do not depend on low-level modules (page implementation). Both depend on abstractions.
        private ITinyMCEEditorPage _editorPage;

        // ───────────── NAVIGATION & FRAME METHODS ─────────────

        [Test]
        public void GotoPage_WhenCalled_ShouldNavigateToEditorPage()
        {
            // S — Single Responsibility Principle:
            // This test only verifies that the editor page is accessible.

            // Act
            _editorPage.GotoPage();

            // Assert
            string content = _editorPage.GetEditorContent();
            Assert.IsNotNull(content);
        }

        [Test]
        public void SwitchToEditorFrame_WhenCalled_ShouldSwitchToEditorFrameSuccessfully()
        {
            // S — Single Responsibility Principle:
            // This test focuses only on frame switching logic.

            // Act
            _editorPage.SwitchToEditorFrame();

            // Assert
            Assert.DoesNotThrow(() => _editorPage.GetEditorContent());
        }

        [Test]
        public void SwitchToMainContent_WhenCalled_ShouldSwitchBackWithoutError()
        {
            // S — Single Responsibility Principle:
            // Ensures main frame context is properly restored.

            // Act
            _editorPage.SwitchToEditorFrame();
            _editorPage.SwitchToMainContent();

            // Assert
            Assert.Pass("Switched back to main content without exception.");
        }

        // ───────────── TEXT EDITING METHODS ─────────────

        [Test]
        public void ClearEditorContent_ShouldRemoveAllTextFromEditor()
        {
            // S — Single Responsibility Principle:
            // Tests only the clearing of text content.

            // Arrange
            _editorPage.EnterTextInEditor("Sample text");

            // Act
            _editorPage.ClearEditorContent();

            // Assert
            Assert.IsEmpty(_editorPage.GetEditorContent());
        }

        [Test]
        public void EnterTextInEditor_ShouldAddSpecifiedText()
        {
            // S — Single Responsibility Principle:
            // Only validates correct text entry.

            // Arrange
            string text = "Hello TinyMCE!";

            // Act
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor(text);

            // Assert
            string result = _editorPage.GetEditorContent();
            Assert.AreEqual(text, result);
        }

        [Test]
        public void AppendTextInEditor_ShouldAddTextWithoutRemovingExistingContent()
        {
            // S — Single Responsibility Principle:
            // Focused on appending logic.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("Hello");
            string append = " World!";

            // Act
            _editorPage.AppendTextInEditor(append);

            // Assert
            string result = _editorPage.GetEditorContent();
            Assert.AreEqual("Hello World!", result);
        }

        [Test]
        public void GetEditorContent_ShouldReturnTextInsideEditor()
        {
            // S — Single Responsibility Principle:
            // Tests retrieval of content only.

            // Arrange
            string expected = "Some test content";
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor(expected);

            // Act
            string actual = _editorPage.GetEditorContent();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ───────────── TEXT FORMATTING METHODS ─────────────

        [Test]
        public void ApplyBold_ShouldMakeSelectedTextBold()
        {
            // S — Single Responsibility Principle:
            // Verifies bold formatting feature.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("BoldText");

            // Act
            _editorPage.ApplyBold();

            // Assert
            Assert.IsTrue(_editorPage.IsBoldApplied());
        }

        [Test]
        public void ApplyItalic_ShouldMakeSelectedTextItalic()
        {
            // S — Single Responsibility Principle:
            // Checks italic formatting.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("ItalicText");

            // Act
            _editorPage.ApplyItalic();

            // Assert
            Assert.IsTrue(_editorPage.IsItalicApplied());
        }

        [Test]
        public void ApplyUnderline_ShouldUnderlineSelectedText()
        {
            // S — Single Responsibility Principle:
            // Tests underline formatting.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("UnderlineText");

            // Act
            _editorPage.ApplyUnderline();

            // Assert
            Assert.IsTrue(_editorPage.IsUnderlineApplied());
        }

        [Test]
        public void IsBoldApplied_WhenBoldApplied_ShouldReturnTrue()
        {
            // S — Single Responsibility Principle:
            // Isolated check for bold status.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("Bold");
            _editorPage.ApplyBold();

            // Act + Assert
            Assert.IsTrue(_editorPage.IsBoldApplied());
        }

        [Test]
        public void IsItalicApplied_WhenItalicApplied_ShouldReturnTrue()
        {
            // S — Single Responsibility Principle:
            // Isolated check for italic status.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("Italic");
            _editorPage.ApplyItalic();

            // Act + Assert
            Assert.IsTrue(_editorPage.IsItalicApplied());
        }

        [Test]
        public void IsUnderlineApplied_WhenUnderlineApplied_ShouldReturnTrue()
        {
            // S — Single Responsibility Principle:
            // Isolated check for underline status.

            // Arrange
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor("Underline");
            _editorPage.ApplyUnderline();

            // Act + Assert
            Assert.IsTrue(_editorPage.IsUnderlineApplied());
        }
    }
}
