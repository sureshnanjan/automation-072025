/*
 * ------------------------------------------------------------------------------
 * © 2025 Teja Reddy. All rights reserved.
 * This interface is part of the HerokuApp automated test suite.
 * For internal, educational, or evaluation purposes only.
 * ------------------------------------------------------------------------------
 */

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Frames and iFrame sections of the HerokuApp website.
    /// Provides methods for navigating and interacting with nested frames and WYSIWYG editor.
    /// </summary>
    public interface IFrames
    {
        // ------------------ Common Frames Page ------------------

        /// <summary>
        /// Gets the heading text of the Frames page.
        /// </summary>
        string GetHeading();

        /// <summary>
        /// Clicks the link to navigate to the Nested Frames page.
        /// </summary>
        void ClickNestedFrameLink();

        /// <summary>
        /// Clicks the link to navigate to the iFrame editor page.
        /// </summary>
        void ClickIFrameLink();

        // ------------------ Nested Frames ------------------

        /// <summary>
        /// Retrieves the text from the left frame.
        /// </summary>
        string GetLeftFrameText();

        /// <summary>
        /// Retrieves the text from the middle frame.
        /// </summary>
        string GetMiddleFrameText();

        /// <summary>
        /// Retrieves the text from the right frame.
        /// </summary>
        string GetRightFrameText();

        /// <summary>
        /// Retrieves the text from the bottom frame.
        /// </summary>
        string GetBottomFrameText();

        /// <summary>
        /// Determines if the frame layout includes a horizontal split.
        /// </summary>
        /// <returns>True if horizontally split; otherwise false.</returns>
        bool IsHorizontallySplit();

        /// <summary>
        /// Determines if the top frame includes a vertical split.
        /// </summary>
        /// <returns>True if vertically split; otherwise false.</returns>
        bool IsVerticallySplit();

        /// <summary>
        /// Gets the margin value of the top frame.
        /// </summary>
        int GetTopFrameMargin();

        /// <summary>
        /// Gets the margin value of the bottom frame.
        /// </summary>
        int GetBottomFrameMargin();

        // ------------------ iFrame Editor ------------------

        /// <summary>
        /// Gets the heading of the iFrame editor page.
        /// </summary>
        string GetIFramePageHeading();

        /// <summary>
        /// Gets the current text inside the editor iframe.
        /// </summary>
        string GetTextFromEditor();

        /// <summary>
        /// Clears the text content inside the editor.
        /// </summary>
        void ClearEditorText();

        /// <summary>
        /// Enters the specified text into the editor.
        /// </summary>
        /// <param name="text">Text to be entered.</param>
        void EnterTextInEditor(string text);

        /// <summary>
        /// Selects all the text inside the editor.
        /// </summary>
        void SelectAllText();

        /// <summary>
        /// Clicks the Bold button on the editor toolbar.
        /// </summary>
        void ClickBoldButton();

        /// <summary>
        /// Verifies if the given toolbar option (e.g., "Bold", "Italic") is visible.
        /// </summary>
        /// <param name="option">Toolbar option name.</param>
        /// <returns>True if visible, otherwise false.</returns>
        bool IsToolbarOptionVisible(string option);

        /// <summary>
        /// Checks if the selected text is bold.
        /// </summary>
        /// <returns>True if bold, otherwise false.</returns>
        bool IsTextBold();

        /// <summary>
        /// Checks whether the "Powered by Tiny" link is visible.
        /// </summary>
        /// <returns>True if visible, otherwise false.</returns>
        bool IsPoweredByTinyLinkVisible();
    }
}
