/*
* -----------------------------------------------------------------------------
* Project     : HerokuOperations
* File        : IDragDrop.cs
* Author      : Jeya Mathesh G
* Created     : 2025-08-01
* -----------------------------------------------------------------------------
*/

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface representing actions and properties on the Drag and Drop page.
    /// </summary>
    public interface IDragDrop
    {
        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the text of Column A.
        /// </summary>
        /// <returns>The text content of Column A.</returns>
        string GetColumnAText();

        /// <summary>
        /// Gets the text of Column B.
        /// </summary>
        /// <returns>The text content of Column B.</returns>
        string GetColumnBText();

        /// <summary>
        /// Gets the header label of a specified column.
        /// </summary>
        /// <param name="columnId">Column identifier ("A" or "B").</param>
        /// <returns>The header label as a string.</returns>
        string GetColumnHeaderText(string columnId);

        /// <summary>
        /// Performs drag-and-drop from Column A to Column B.
        /// </summary>
        void DragAtoB();

        /// <summary>
        /// Performs drag-and-drop from Column B to Column A.
        /// </summary>
        void DragBtoA();

        /// <summary>
        /// Drags the specified column onto itself.
        /// </summary>
        /// <param name="columnId">Column identifier ("A" or "B").</param>
        void DragColumnOntoItself(string columnId);

        /// <summary>
        /// Drags Column A to an invalid location (outside drop targets).
        /// </summary>
        void DragAtoInvalidLocation();

        /// <summary>
        /// Drags Column B to an invalid location (outside drop targets).
        /// </summary>
        void DragBtoInvalidLocation();

        /// <summary>
        /// Gets the GitHub ribbon text displayed on the page.
        /// </summary>
        /// <returns>The ribbon label text.</returns>
        string GetGitHubRibbonText();

        /// <summary>
        /// Gets the footer text displayed on the page.
        /// </summary>
        /// <returns>The footer content as a string.</returns>
        string GetFooterText();
    }
}
