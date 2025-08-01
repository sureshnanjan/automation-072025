// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITinyMCEEditorPage.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains an interface defining actions for interacting with the TinyMCE Editor page
//   used for automation testing purposes.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Defines the contract for automating interactions with the TinyMCE WYSIWYG Editor page
    /// This interface specifies methods for switching frames, entering, clearing, 
    /// and retrieving text within the TinyMCE editor.
    /// </summary>
    public interface ITinyMCEEditorPage
    {
        /// <summary>
        /// Switches the WebDriver context to the TinyMCE editor iframe
        /// to enable direct interaction with the editor's text area.
        /// </summary>
        void SwitchToEditorFrame();

        /// <summary>
        /// Switches the WebDriver context back to the main HTML page 
        /// from the editor's iframe.
        /// </summary>
        void SwitchToMainContent();

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
        /// Retrieves the current text content from the TinyMCE editor.
        /// </summary>
        /// <returns>The text currently present inside the TinyMCE editor.</returns>
        string GetEditorContent();
    }
}
