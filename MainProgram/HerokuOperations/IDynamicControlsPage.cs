/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for interacting with the Dynamic Controls page.
    /// This includes operations for handling checkbox visibility and input field enabling/disabling.
    /// </summary>
    public interface IDynamicControlsPage
    {
        // -------- Checkbox Section --------

        /// <summary>
        /// Clicks the button to remove or add the checkbox dynamically.
        /// </summary>
        void ClickRemoveOrAddButton();

        /// <summary>
        /// Determines whether the checkbox is currently displayed on the page.
        /// </summary>
        /// <returns>True if the checkbox is visible; otherwise, false.</returns>
        bool IsCheckboxDisplayed();

        /// <summary>
        /// Gets the message shown after the checkbox is added or removed.
        /// </summary>
        /// <returns>The feedback message related to the checkbox action.</returns>
        string GetCheckboxMessage();


        // -------- Input Field Section --------

        /// <summary>
        /// Clicks the button to enable or disable the input field dynamically.
        /// </summary>
        void ClickEnableOrDisableButton();

        /// <summary>
        /// Checks whether the input field is currently enabled.
        /// </summary>
        /// <returns>True if the input field is enabled; otherwise, false.</returns>
        bool IsInputEnabled();

        /// <summary>
        /// Enters the specified text into the input field.
        /// </summary>
        /// <param name="text">Text to be entered into the input field.</param>
        void EnterText(string text);

        /// <summary>
        /// Gets the message shown after the input field is enabled or disabled.
        /// </summary>
        /// <returns>The feedback message related to the input field action.</returns>
        string GetInputMessage();
    }
}
