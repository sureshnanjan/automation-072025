// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IinfiniteScroll.cs" 
//   Copyright (c) 2025 Varun Kumar Reddy. All rights reserved.
//   This file contains an interface that defines automation methods for interacting with the
//   Infinite Scroll page on the HerokuApp test site. Redistribution or modification of this file
//   is prohibited without explicit permission from the author.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Infinite Scroll component.
    /// </summary>
    public interface IinfiniteScroll
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Retrieves the page title.
        /// </summary>
        /// <returns>The page title text.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves the subtitle/description text on the page.
        /// </summary>
        /// <returns>The page subtitle text.</returns>
        string GetDescription();

        // ───────────── SCROLL INTERACTION METHODS ─────────────

        /// <summary>
        /// Scrolls to the bottom of the page to load more content.
        /// </summary>
        void ScrollToBottom();

        /// <summary>
        /// Scrolls back to the top of the page.
        /// </summary>
        void ScrollToTop();

        /// <summary>
        /// Gets the current vertical scroll position.
        /// </summary>
        /// <returns>Y coordinate of scroll position.</returns>
        int GetScrollY();

        /// <summary>
        /// Gets the number of paragraphs currently visible.
        /// </summary>
        /// <returns>The count of paragraph elements loaded.</returns>
        int GetParagraphCount();

        /// <summary>
        /// Verifies that new paragraphs are loaded upon scrolling.
        /// </summary>
        /// <returns>True if new paragraphs were added; otherwise, false.</returns>
        bool IsContentLoadedOnScroll();

        /// <summary>
        /// Checks if the vertical scrollbar size decreases as new content loads.
        /// </summary>
        /// <returns>True if scrollbar shrinks with more content; otherwise, false.</returns>
        bool IsScrollbarShrinkingWithScroll();

        // ───────────── RESPONSIVENESS TESTS ─────────────

        /// <summary>
        /// Verifies scroll functionality on mobile viewports.
        /// </summary>
        /// <returns>True if scroll works properly on mobile layout.</returns>
        bool IsMobileScrollResponsive();

        // ───────────── FOOTER VALIDATION METHODS ─────────────

        /// <summary>
        /// Verifies that the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        /// <returns>True if footer is present; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Checks whether the "Fork me on GitHub" ribbon is present and clickable.
        /// </summary>
        /// <returns>True if GitHub ribbon is visible and interactable.</returns>
        bool IsGitHubRibbonVisible();
    }
}