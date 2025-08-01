/*
﻿/*
 * Copyright © 2025 Sehwag Vijay
 * All rights reserved.
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for testing dynamic loading scenarios on a web page.
    /// Supports example navigation, starting the loader, waiting, and verifying results.
    /// </summary>
    public interface IDynamicLoading
    {
        /// <summary>
        /// Navigates to a specific dynamic loading example page.
        /// Example numbers typically refer to Example 1 or Example 2.
        /// </summary>
        void NavigateToExample(int exampleNumber);

        /// <summary>
        /// Initiates the dynamic loading process by clicking the "Start" button.
        /// </summary>
        void ClickStartButton();

        /// <summary>
        /// Waits until the dynamic content has fully loaded and the loading spinner is gone.
        /// </summary>
        void WaitForLoadingToFinish();

        /// <summary>
        /// Retrieves the result text shown after loading is complete.
        /// </summary>
        /// <returns>The text content displayed post-load.</returns>
        string GetResultText();

        /// <summary>
        /// Determines whether the loading spinner or indicator is currently visible.
        /// </summary>
        /// <returns>True if the loading indicator is visible; otherwise, false.</returns>
        bool IsLoadingIndicatorVisible();
    }
}

