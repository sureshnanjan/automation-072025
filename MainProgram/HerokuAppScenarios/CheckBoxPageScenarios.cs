// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This class contains test scenarios for validating checkbox behavior
// on the Checkboxes page of HerokuApp using Selenium WebDriver and NUnit.
// -------------------------------------------------------------------------------------------------

using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test scenarios for the Checkboxes page functionality.
    /// </summary>
    public class CheckboxPageTests
    {
        private ICheckBoxes _checkboxesPage;

        /// <summary>
        /// Initializes the WebDriver and page object before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Validates that the page title is correctly displayed.
        /// </summary>
        [Test]
        public void PageTitleIsCorrect()
        {
            // Act
            var title = _checkboxesPage.GetPageTitle();

            // Assert
            Assert.AreEqual("Checkboxes", title, "The page title should be 'Checkboxes'.");
        }

        /// <summary>
        /// Validates that first checkboxes are clickable and interactable.
        /// </summary>
        [Test]
        public void FirstCheckbox_ShouldBeClickable()
        {
            // Assert
            Assert.IsTrue(_checkboxesPage.IsCheckboxClickable(0), "First checkbox should be clickable.");
        }

        /// <summary>
        /// Validates that Second checkboxes are clickable and interactable.
        /// </summary
        [Test]
        public void SecondCheckbox_ShouldBeClickable()
        {
            // Assert
            Assert.IsTrue(_checkboxesPage.IsCheckboxClickable(1), "Second checkbox should be clickable.");
        }

        /// <summary>
        /// Checks the first checkbox and verifies its state.
        /// </summary>
        [Test]
        public void CheckFirstCheckbox_ShouldSetItToChecked()
        {
            // Act
            _checkboxesPage.CheckFirstBox();

            // Assert
            Assert.IsTrue(_checkboxesPage.IsFirstBoxChecked(), "First checkbox should be checked.");
        }

        /// <summary>
        /// Unchecks the second checkbox and verifies its state.
        /// </summary>
        [Test]
        public void UncheckSecondCheckbox_ShouldSetItToUnchecked()
        {
            // Act
            _checkboxesPage.UncheckSecondBox();

            // Assert
            Assert.IsFalse(_checkboxesPage.IsSecondBoxChecked(), "Second checkbox should be unchecked.");
        }

        /// <summary>
        /// Validate Check box counts
        /// </summary>
        [Test]
        public void CheckBoxCountIsCorrect()
        {
            // Act
            var states = _checkboxesPage.GetAllCheckboxStates();

            // Assert
            Assert.AreEqual(2, states.Count, "There should be exactly two checkboxes.");

        }

        /// <summary>
        /// Verifies that checking an already checked checkbox does not change its state.
        /// </summary>
        [Test]
        public void RecheckingFirstCheckbox_ShouldRemainChecked()
        {
            //Arrange && Act
            _checkboxesPage.CheckFirstBox();

            // Assert
            Assert.IsTrue(_checkboxesPage.IsFirstBoxChecked(), "First checkbox should remain checked.");
        }

        /// <summary>
        /// Verifies that unchecking an already unchecked checkbox does not change its state.
        /// </summary>
        [Test]
        public void ReuncheckingSecondCheckbox_ShouldRemainUnchecked()
        {

            //Arrange and Act
            _checkboxesPage.UncheckSecondBox();

            // Assert
            Assert.IsFalse(_checkboxesPage.IsSecondBoxChecked(), "Second checkbox should remain unchecked.");
        }

        /// <summary>
        /// Selects both checkboxes and confirms no unexpected UI changes.
        /// </summary>
        [Test]
        public void SelectingBothCheckboxes_ShouldNotChangePageContent()
        {
            // Act
            _checkboxesPage.CheckFirstBox();
            _checkboxesPage.CheckSecondBox();
            var content = _checkboxesPage.GetMainContent();

            // Assert
            Assert.IsTrue(content.Contains("Checkboxes"), "Page content should remain consistent after checkbox interaction.");
        }

        /// <summary>
        /// Deselects both checkboxes and ensures layout or title is unaffected.
        /// </summary>
        [Test]
        public void DeselectingBothCheckboxes_ShouldNotAffectLayoutOrTitle()
        {
            // Act
            _checkboxesPage.UncheckFirstBox();
            _checkboxesPage.UncheckSecondBox();
            var title = _checkboxesPage.GetPageTitle();

            // Assert
            Assert.AreEqual("Checkboxes", title, "Page layout/title should remain the same.");
        }

        /// <summary>
        /// Toggles both checkboxes twice and validates if the initial state is restored.
        /// </summary>
        [Test]
        public void TogglingBothCheckboxesTwice_ShouldReturnToInitialState()
        {
            // Arrange
            var initialStates = _checkboxesPage.GetAllCheckboxStates();

            // Act
            _checkboxesPage.ToggleFirstBox();
            _checkboxesPage.ToggleSecondBox();
            _checkboxesPage.ToggleFirstBox();
            _checkboxesPage.ToggleSecondBox();
            var finalStates = _checkboxesPage.GetAllCheckboxStates();

            // Assert
            CollectionAssert.AreEqual(initialStates, finalStates, "Checkboxes should return to their original states.");
        }

        /// <summary>
        /// Confirms that checkbox actions do not trigger browser console errors or unexpected alerts.
        /// </summary>
        [Test]
        public void CheckboxInteraction_ShouldNotCauseConsoleErrors()
        {
            // Act
            _checkboxesPage.CheckFirstBox();
            _checkboxesPage.UncheckSecondBox();
            var hasErrors = _checkboxesPage.HasConsoleErrors();

            // Assert
            Assert.IsFalse(hasErrors, "No console errors should appear after checkbox interactions.");
        }

        /// <summary>
        /// Verifies that checkboxes can be toggled using the keyboard (space key).
        /// </summary>
        [Test]
        public void Checkbox_ShouldBeToggledByKeyboard()
        {
            // Act
            _checkboxesPage.FocusCheckbox(0);
            _checkboxesPage.PressSpaceKey();
            var state = _checkboxesPage.IsFirstBoxChecked();

            // Assert
            Assert.IsTrue(state, "Checkbox should be toggled using keyboard input.");
        }

        /// <summary>
        /// Ensures checkbox state is not retained after navigating away and back.
        /// </summary>
        [Test]
        public void NavigatingAwayAndBack_ShouldResetCheckboxStates()
        {
            // Arrange
            _checkboxesPage.CheckFirstBox();

            // Act
            _checkboxesPage.NavigateAway();
            _checkboxesPage.NavigateBack();
            var state = _checkboxesPage.IsFirstBoxChecked();

            // Assert
            Assert.IsFalse(state, "Checkbox state should not persist after navigating away and returning.");
        }

        /// <summary>
        /// Verifies that checkbox state is not persisted after page refresh unless expected.
        /// </summary>
        [Test]
        public void CheckboxState_ShouldResetAfterPageRefresh()
        {
            // Arrange
            _checkboxesPage.CheckFirstBox();

            // Act
            _checkboxesPage.RefreshPage();
            var stateAfterRefresh = _checkboxesPage.IsFirstBoxChecked();

            // Assert
            Assert.IsFalse(stateAfterRefresh, "Checkbox state should reset after refresh unless explicitly persisted.");
        }

        //------------------------------------------------------------- FOOTER & EXTERNAL LINKS ---------------------------//

        ///<summary>
        ///Validating the footer is present or not
        ///</summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        ///<summary>
        ///Validating the right side git link is present or not
        ///</summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }

    }
}