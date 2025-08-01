// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITinyMCEEditorPage.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains an interface defining actions for interacting with the TinyMCE Editor page
//   used for automation testing purposes.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Defines the contract for automating interactions with the TinyMCE WYSIWYG Editor page.
    /// This interface specifies methods for frame handling, text editing, formatting,
    /// toolbar and menu options, and footer validation.
    /// </summary>
    public interface ITinyMCEEditorPage
    {
        // ───────────── NAVIGATION & FRAME METHODS ─────────────

        /// <summary>
        /// Navigates to the TinyMCE Editor page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Switches the WebDriver context to the TinyMCE editor iframe.
        /// </summary>
        void SwitchToEditorFrame();

        /// <summary>
        /// Switches the WebDriver context back to the main HTML page.
        /// </summary>
        void SwitchToMainContent();

        // ───────────── TEXT EDITING METHODS ─────────────

        /// <summary>
        /// Clears all existing content inside the TinyMCE editor.
        /// </summary>
        void ClearEditorContent();

        /// <summary>
        /// Enters the specified text into the TinyMCE editor's text area.
        /// </summary>
        /// <param name="text">The text to be entered into the editor.</param>
        void EnterTextInEditor(string text);

        /// <summary>
        /// Appends the specified text to the existing content inside the editor.
        /// </summary>
        /// <param name="text">The text to append.</param>
        void AppendTextInEditor(string text);

        /// <summary>
        /// Retrieves the current text content from the TinyMCE editor.
        /// </summary>
        /// <returns>The full text inside the editor.</returns>
        string GetEditorContent();

        // ───────────── TEXT FORMATTING METHODS ─────────────

        /// <summary>
        /// Applies bold formatting to the selected text.
        /// </summary>
        void ApplyBold();

        /// <summary>
        /// Applies italic formatting to the selected text.
        /// </summary>
        void ApplyItalic();

        /// <summary>
        /// Applies underline formatting to the selected text.
        /// </summary>
        void ApplyUnderline();

        /// <summary>
        /// Checks whether bold formatting is applied to selected text.
        /// </summary>
        /// <returns>True if bold is applied; otherwise, false.</returns>
        bool IsBoldApplied();

        /// <summary>
        /// Checks whether italic formatting is applied to selected text.
        /// </summary>
        /// <returns>True if italic is applied; otherwise, false.</returns>
        bool IsItalicApplied();

        /// <summary>
        /// Checks whether underline formatting is applied to selected text.
        /// </summary>
        /// <returns>True if underline is applied; otherwise, false.</returns>
        bool IsUnderlineApplied();

        // ───────────── TEXT ALIGNMENT METHODS ─────────────

        /// <summary>
        /// Aligns the selected text to the left.
        /// </summary>
        void AlignLeft();

        /// <summary>
        /// Aligns the selected text to the center.
        /// </summary>
        void AlignCenter();

        /// <summary>
        /// Aligns the selected text to the right.
        /// </summary>
        void AlignRight();

        /// <summary>
        /// Justifies the selected text.
        /// </summary>
        void AlignJustify();

        /// <summary>
        /// Gets the current alignment of the selected text.
        /// </summary>
        /// <returns>A string representing the alignment: "left", "center", "right", or "justify".</returns>
        string GetCurrentTextAlignment();

        // ───────────── PARAGRAPH FORMATTING METHODS ─────────────

        /// <summary>
        /// Selects a paragraph format from the dropdown (e.g., Heading 1, Paragraph).
        /// </summary>
        /// <param name="format">The paragraph format to apply.</param>
        void SelectParagraphFormat(string format);

        /// <summary>
        /// Gets the current paragraph format applied to the selected text.
        /// </summary>
        /// <returns>The format name currently applied.</returns>
        string GetCurrentParagraphFormat();

        // ───────────── FILE MENU METHODS ─────────────

        /// <summary>
        /// Opens the File menu from the TinyMCE toolbar.
        /// </summary>
        void OpenFileMenu();

        /// <summary>
        /// Checks whether the File menu is visible.
        /// </summary>
        /// <returns>True if the File menu is displayed; otherwise, false.</returns>
        bool IsFileMenuVisible();

        // ───────────── EDIT MENU METHODS ─────────────

        /// <summary>
        /// Opens the Edit menu from the TinyMCE toolbar.
        /// </summary>
        void OpenEditMenu();

        /// <summary>
        /// Performs an Undo action.
        /// </summary>
        void PerformUndo();

        /// <summary>
        /// Performs a Redo action.
        /// </summary>
        void PerformRedo();

        /// <summary>
        /// Cuts the selected text.
        /// </summary>
        void CutText();

        /// <summary>
        /// Copies the selected text.
        /// </summary>
        void CopyText();

        /// <summary>
        /// Pastes the text from the clipboard into the editor.
        /// </summary>
        void PasteText();

        // ───────────── VIEW MENU METHODS ─────────────

        /// <summary>
        /// Opens the View menu from the TinyMCE toolbar.
        /// </summary>
        void OpenViewMenu();

        /// <summary>
        /// Toggles fullscreen mode for the TinyMCE editor.
        /// </summary>
        void ToggleFullscreen();

        /// <summary>
        /// Checks if the editor is currently in fullscreen mode.
        /// </summary>
        /// <returns>True if in fullscreen; otherwise, false.</returns>
        bool IsFullscreenEnabled();

        // ───────────── FORMAT MENU METHODS ─────────────

        /// <summary>
        /// Opens the Format menu from the TinyMCE toolbar.
        /// </summary>
        void OpenFormatMenu();

        /// <summary>
        /// Clears all formatting from the selected text.
        /// </summary>
        void ClearFormatting();

        // ───────────── FOOTER VALIDATION METHODS ─────────────

        /// <summary>
        /// Verifies if the "Powered by Elemental Selenium" footer is present and visible.
        /// </summary>
        /// <returns>True if the footer is visible; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Checks if the "Fork me on GitHub" ribbon is visible and clickable.
        /// </summary>
        /// <returns>True if the ribbon is present and interactable; otherwise, false.</returns>
        bool IsGitHubRibbonVisible();
    }
}
