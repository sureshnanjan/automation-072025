// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HerokuOperations;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Horizontal Slider component.
    /// </summary>
    public interface IHorizontalSlider
    {
        // ───────────── UI TEXT VALIDATION METHODS ─────────────

        /// <summary>
        /// Retrieves the title of the slider page.
        /// </summary>
        /// <returns>The title text.</returns>
        string GetTitle();

        /// <summary>
        /// Retrieves the description or instructions shown on the slider page.
        /// </summary>
        /// <returns>The description text.</returns>
        string GetDescription();

        // ───────────── SLIDER FUNCTIONALITY METHODS ─────────────

        /// <summary>
        /// Brings focus to the slider control for keyboard interaction.
        /// </summary>
        void FocusSlider();

        /// <summary>
        /// Moves the slider to the left by the specified number of steps (each step = 0.5).
        /// </summary>
        /// <param name="steps">Number of steps to move left.</param>
        /// <returns>The updated slider value.</returns>
        double MoveSliderLeft(int steps);

        /// <summary>
        /// Moves the slider to the right by the specified number of steps (each step = 0.5).
        /// </summary>
        /// <param name="steps">Number of steps to move right.</param>
        /// <returns>The updated slider value.</returns>
        double MoveSliderRight(int steps);

        /// <summary>
        /// Sets the slider to a specific value.
        /// </summary>
        /// <param name="value">The target value to set (e.g., 3.5).</param>
        /// <returns>True if the value was set successfully; otherwise, false.</returns>
        bool SetSliderValue(double value);

        /// <summary>
        /// Retrieves the current value of the slider.
        /// </summary>
        /// <returns>The current slider value.</returns>
        double GetSliderValue();

        // ───────────── SLIDER STATE & BOUNDARY TESTING ─────────────

        /// <summary>
        /// Checks if the slider is present and visible on the page.
        /// </summary>
        /// <returns>True if visible; otherwise, false.</returns>
        bool IsSliderVisible();

        /// <summary>
        /// Checks if the slider is enabled and interactable.
        /// </summary>
        /// <returns>True if enabled; otherwise, false.</returns>
        bool IsSliderEnabled();

        /// <summary>
        /// Checks if the slider is currently at its minimum value.
        /// </summary>
        /// <returns>True if at minimum; otherwise, false.</returns>
        bool IsAtMin();

        /// <summary>
        /// Checks if the slider is currently at its maximum value.
        /// </summary>
        /// <returns>True if at maximum; otherwise, false.</returns>
        bool IsAtMax();

        /// <summary>
        /// Retrieves the minimum possible value of the slider.
        /// </summary>
        /// <returns>The minimum slider value (e.g., 0.0).</returns>
        double GetMinValue();

        /// <summary>
        /// Retrieves the maximum possible value of the slider.
        /// </summary>
        /// <returns>The maximum slider value (e.g., 5.0).</returns>
        double GetMaxValue();

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
