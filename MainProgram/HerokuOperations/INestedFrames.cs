/*
 * ------------------------------------------------------------------------------
 * © 2025 Teja Reddy. All rights reserved.
 * This interface is part of the HerokuApp automated test suite.
 * For internal, educational, or evaluation purposes only.
 * ------------------------------------------------------------------------------
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Nested Frames page on the HerokuApp website.
    /// Defines methods to extract frame-specific text and verify frame layout structure.
    /// </summary>
    public interface INestedFrames
    {
        /// <summary>
        /// Returns the text displayed in the left frame.
        /// </summary>
        string GetLeftFrameText();

        /// <summary>
        /// Returns the text displayed in the middle frame.
        /// </summary>
        string GetMiddleFrameText();

        /// <summary>
        /// Returns the text displayed in the right frame.
        /// </summary>
        string GetRightFrameText();

        /// <summary>
        /// Returns the text displayed in the bottom frame.
        /// </summary>
        string GetBottomFrameText();

        /// <summary>
        /// Checks whether the nested frames are split horizontally
        /// (i.e., presence of both top and bottom frames).
        /// </summary>
        /// <returns>True if horizontal split exists, otherwise false.</returns>
        bool IsHorizontallySplit();

        /// <summary>
        /// Checks whether the top frame is vertically split
        /// into left, middle, and right frames.
        /// </summary>
        /// <returns>True if vertical split exists inside the top frame, otherwise false.</returns>
        bool IsVerticallySplit();

        /// <summary>
        /// Returns the margin value of the top frame.
        /// </summary>
        /// <returns>Integer representing top frame margin (in pixels).</returns>
        int GetTopFrameMargin();

        /// <summary>
        /// Returns the margin value of the bottom frame.
        /// </summary>
        /// <returns>Integer representing bottom frame margin (in pixels).</returns>
        int GetBottomFrameMargin();

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
