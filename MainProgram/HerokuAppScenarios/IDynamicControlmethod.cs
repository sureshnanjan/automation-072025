// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicControlsPageTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file provides automated NUnit test cases for verifying the dynamic behavior of 
//   checkbox and input controls on the Dynamic Controls page of the-internet.herokuapp.com.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Contains NUnit test cases for validating the functionality of the <see cref="DynamicControlsPage"/> class.
    /// These tests cover checkbox visibility toggling, input field enabling/disabling, and input value interaction.
    /// The target page for these tests is https://the-internet.herokuapp.com/dynamic_controls.
    /// </summary>
    [TestFixture]
    public class DynamicControlsPageTests
    {
        private DynamicControlsPage dynamicControls;

        /// <summary>
        /// Validates that the checkbox is visible when the page loads.
        /// </summary>
        [Test]
        public void Checkbox_InitiallyPresent_ShouldBeVisible()
        {
            Assert.IsTrue(dynamicControls.IsCheckboxDisplayed(), "Checkbox should be visible initially.");
        }

        /// <summary>
        /// Tests that the checkbox can be removed and that the correct confirmation message appears.
        /// </summary>
        [Test]
        public void Checkbox_WhenRemoved_ShouldNotBeVisible_AndShowRemovalMessage()
        {
            dynamicControls.ClickRemoveOrAddButton();
            Assert.IsFalse(dynamicControls.IsCheckboxDisplayed(), "Checkbox should be removed.");
            Assert.AreEqual("It's gone!", dynamicControls.GetCheckboxMessage());
        }

        /// <summary>
        /// Tests that the checkbox, after being removed, can be added again and the correct message is shown.
        /// </summary>
        [Test]
        public void Checkbox_WhenRemovedAndAddedBack_ShouldBeVisibleAgain()
        {
            dynamicControls.ClickRemoveOrAddButton(); // Remove
            dynamicControls.ClickRemoveOrAddButton(); // Add
            Assert.IsTrue(dynamicControls.IsCheckboxDisplayed(), "Checkbox should be added again.");
            Assert.AreEqual("It's back!", dynamicControls.GetCheckboxMessage());
        }

        /// <summary>
        /// Ensures the input field is disabled by default.
        /// </summary>
        [Test]
        public void Input_InitiallyDisabled_ShouldNotBeEditable()
        {
            Assert.IsFalse(dynamicControls.IsInputEnabled(), "Input field should be disabled initially.");
        }

        /// <summary>
        /// Validates that enabling the input field works and displays the correct message.
        /// </summary>
        [Test]
        public void Input_AfterEnable_ShouldBeEditable_AndShowEnableMessage()
        {
            dynamicControls.ClickEnableOrDisableButton();
            Assert.IsTrue(dynamicControls.IsInputEnabled(), "Input should be enabled.");
            Assert.AreEqual("It's enabled!", dynamicControls.GetInputMessage());
        }

        /// <summary>
        /// Validates that after enabling and then disabling, the input field returns to the disabled state.
        /// </summary>
        [Test]
        public void Input_AfterEnableDisableToggle_ShouldBeBackToDisabled()
        {
            dynamicControls.ClickEnableOrDisableButton(); // Enable
            dynamicControls.ClickEnableOrDisableButton(); // Disable
            Assert.IsFalse(dynamicControls.IsInputEnabled(), "Input should be disabled again.");
            Assert.AreEqual("It's disabled!", dynamicControls.GetInputMessage());
        }

        /// <summary>
        /// Tests that the input field accepts text after being enabled.
        /// </summary>
        [Test]
        public void Input_Enabled_CanAcceptText()
        {
            dynamicControls.ClickEnableOrDisableButton();
            dynamicControls.EnterText("Hello Test");
            string text = dynamicControls.GetInputValue();
            Assert.AreEqual("Hello Test", text);
        }

        /// <summary>
        /// Verifies that attempting to input text when disabled results in an exception.
        /// </summary>
        [Test]
        public void Input_Disabled_CannotAcceptText()
        {
            dynamicControls.ClickEnableOrDisableButton(); // Enable
            dynamicControls.ClickEnableOrDisableButton(); // Disable

            Assert.Throws<InvalidOperationException>(() =>
            {
                dynamicControls.EnterText("Should Fail");
            }, "Entering text while input is disabled should throw exception.");
        }

        /// <summary>
        /// Ensures the checkbox displays the correct message after multiple rapid toggles.
        /// </summary>
        [Test]
        public void Checkbox_Message_AfterRapidToggle_ShouldBeLatestState()
        {
            dynamicControls.ClickRemoveOrAddButton(); // Remove
            dynamicControls.ClickRemoveOrAddButton(); // Add

            string latestMessage = dynamicControls.GetCheckboxMessage();
            Assert.AreEqual("It's back!", latestMessage);
        }

        /// <summary>
        /// Ensures the input displays the correct message after multiple toggles.
        /// </summary>
        [Test]
        public void Input_Message_AfterRapidToggle_ShouldBeLatestState()
        {
            dynamicControls.ClickEnableOrDisableButton(); // Enable
            dynamicControls.ClickEnableOrDisableButton(); // Disable

            string latestMessage = dynamicControls.GetInputMessage();
            Assert.AreEqual("It's disabled!", latestMessage);
        }

        /// <summary>
        /// Checks that the checkbox can be toggled multiple times without error.
        /// </summary>
        [Test]
        public void Checkbox_CanToggleMultipleTimesWithoutCrash()
        {
            for (int i = 0; i < 5; i++)
            {
                dynamicControls.ClickRemoveOrAddButton();
            }

            Assert.Pass("Toggling checkbox multiple times did not crash the test.");
        }

        /// <summary>
        /// Checks that the input field can be toggled multiple times without error.
        /// </summary>
        [Test]
        public void Input_CanToggleMultipleTimesWithoutCrash()
        {
            for (int i = 0; i < 5; i++)
            {
                dynamicControls.ClickEnableOrDisableButton();
            }

            Assert.Pass("Toggling input multiple times did not crash the test.");
        }

        /// <summary>
        /// Verifies the input field's enabled state matches expectations after specific toggle patterns.
        /// </summary>
        [Test]
        public void Input_EnabledState_MatchesExpectedToggleSequence()
        {
            Assert.IsFalse(dynamicControls.IsInputEnabled());

            dynamicControls.ClickEnableOrDisableButton(); // Enable
            Assert.IsTrue(dynamicControls.IsInputEnabled());

            dynamicControls.ClickEnableOrDisableButton(); // Disable
            Assert.IsFalse(dynamicControls.IsInputEnabled());
        }

        /// <summary>
        /// Verifies the checkbox's visibility matches expectations after toggle patterns.
        /// </summary>
        [Test]
        public void Checkbox_DisplayState_MatchesExpectedToggleSequence()
        {
            Assert.IsTrue(dynamicControls.IsCheckboxDisplayed());

            dynamicControls.ClickRemoveOrAddButton(); // Remove
            Assert.IsFalse(dynamicControls.IsCheckboxDisplayed());

            dynamicControls.ClickRemoveOrAddButton(); // Add
            Assert.IsTrue(dynamicControls.IsCheckboxDisplayed());
        }

        /// <summary>
        /// Validates that the input field can accept multiple text values sequentially.
        /// </summary>
        [Test]
        public void Input_CanAcceptMultipleTextInputs()
        {
            dynamicControls.ClickEnableOrDisableButton(); // Enable

            dynamicControls.EnterText("First");
            Assert.AreEqual("First", dynamicControls.GetInputValue());

            dynamicControls.EnterText("Second");
            Assert.AreEqual("Second", dynamicControls.GetInputValue());
        }

        /// <summary>
        /// Tests that empty string input is accepted and correctly registered.
        /// </summary>
        [Test]
        public void Input_EmptyTextEntry_ShouldBeAccepted()
        {
            dynamicControls.ClickEnableOrDisableButton(); // Enable
            dynamicControls.EnterText(string.Empty);
            Assert.AreEqual(string.Empty, dynamicControls.GetInputValue());
        }

        /// <summary>
        /// Ensures checkbox returns to original visibility after two toggles.
        /// </summary>
        [Test]
        public void Checkbox_ToggleTwice_ShouldReturnToOriginalState()
        {
            bool initialState = dynamicControls.IsCheckboxDisplayed();

            dynamicControls.ClickRemoveOrAddButton(); // Toggle
            dynamicControls.ClickRemoveOrAddButton(); // Toggle back

            bool finalState = dynamicControls.IsCheckboxDisplayed();
            Assert.AreEqual(initialState, finalState, "Checkbox should return to its original state after two toggles.");
        }

        /// <summary>
        /// Ensures input field returns to original enabled state after two toggles.
        /// </summary>
        [Test]
        public void Input_ToggleTwice_ShouldReturnToOriginalState()
        {
            bool initialState = dynamicControls.IsInputEnabled();

            dynamicControls.ClickEnableOrDisableButton(); // Toggle
            dynamicControls.ClickEnableOrDisableButton(); // Toggle back

            bool finalState = dynamicControls.IsInputEnabled();
            Assert.AreEqual(initialState, finalState, "Input should return to original enabled state after two toggles.");
        }
    }
}
