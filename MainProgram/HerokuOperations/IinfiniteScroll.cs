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
    /// Interface that defines contract methods for automating interactions 
    /// with the Infinite Scroll page of HerokuApp.
    /// Includes methods for scrolling in various directions, retrieving scroll metrics, 
    /// and navigation.
    /// </summary>
    public interface IinfiniteScroll
    {
        /// <summary>
        /// Navigates the WebDriver to the Infinite Scroll page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Gets the title text of the Infinite Scroll page.
        /// </summary>
        /// <returns>Page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle text of the Infinite Scroll page.
        /// </summary>
        /// <returns>Page subtitle as a string.</returns>
        string GetSubTitle();

        /// <summary>
        /// Scrolls vertically to the bottom of the page.
        /// Useful for triggering dynamic content loading.
        /// </summary>
        void ScrollToBottom();

        /// <summary>
        /// Returns the total vertical scroll height of the page.
        /// </summary>
        /// <returns>Integer representing the page's total scroll height in pixels.</returns>
        int GetScrollHeight();

        /// <summary>
        /// Returns the total horizontal scroll width of the page.
        /// </summary>
        /// <returns>Integer representing the page's total scroll width in pixels.</returns>
        int GetScrollWidth();

        /// <summary>
        /// Scrolls vertically to the top of the page.
        /// </summary>
        void ScrollToTop();

        /// <summary>
        /// Scrolls horizontally to the leftmost edge of the page.
        /// </summary>
        void ScrollToLeft();

        /// <summary>
        /// Scrolls horizontally to the rightmost edge of the page.
        /// </summary>
        void ScrollToRight();

        /// <summary>
        /// Returns the current horizontal scroll position (X-axis).
        /// </summary>
        /// <returns>Integer value of horizontal scroll offset.</returns>
        int GetScrollX();

        /// <summary>
        /// Returns the current vertical scroll position (Y-axis).
        /// </summary>
        /// <returns>Integer value of vertical scroll offset.</returns>
        int GetScrollY();

        /// <summary>
        /// Scrolls the page to a specific X and Y pixel coordinate.
        /// </summary>
        /// <param name="x">X-axis scroll position.</param>
        /// <param name="y">Y-axis scroll position.</param>
        void ScrollTo(int x, int y);

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
