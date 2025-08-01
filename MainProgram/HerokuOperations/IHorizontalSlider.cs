/*
 * IHorizontalSlider Interface
 * 
 * This interface defines operations for interacting with the horizontal slider
 * feature on the HerokuApp site (https://the-internet.herokuapp.com/horizontal_slider).
 * It includes methods for focusing the slider, moving it left or right, and reading values.
 * 
 * Author: Teja Reddy
 * Created: August 2025
 * License: For educational or internal use only.
 * 
 * © 2025 Teja Reddy. All rights reserved.
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface to define operations for testing a horizontal slider UI component.
    /// </summary>
    public interface IHorizontalSlider
    {
        /// <summary>
        /// Gets the main title of the horizontal slider page.
        /// </summary>
        /// <returns>The title text as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description or instruction text from the page.
        /// </summary>
        /// <returns>The description string.</returns>
        string GetDescription();

        /// <summary>
        /// Brings focus to the slider element before performing key actions.
        /// </summary>
        void FocusSlider();

        /// <summary>
        /// Moves the slider to the left by a given number of steps.
        /// </summary>
        /// <param name="steps">Number of steps to move left.</param>
        /// <returns>The updated slider value as an integer.</returns>
        int MoveSLiderLeft(int steps);

        /// <summary>
        /// Moves the slider to the right by a given number of steps.
        /// </summary>
        /// <param name="steps">Number of steps to move right.</param>
        /// <returns>The updated slider value as an integer.</returns>
        int MoveSLiderRight(int steps);

        /// <summary>
        /// Gets the current value of the slider.
        /// </summary>
        /// <returns>The current slider value as an integer.</returns>
        int GetSliderValue();
    }
}
