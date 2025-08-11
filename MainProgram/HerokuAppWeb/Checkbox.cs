// Author: Siva Sree
// Date Created: 2025-07-30
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# class implements the ICheckBoxes interface to interact with the checkbox elements 
// on the HerokuApp checkboxes page (https://the-internet.herokuapp.com/checkboxes). 
// Using Selenium WebDriver wrapped by WebDriverWrapper, it provides methods for checking, 
// unchecking, toggling checkboxes, verifying their states, navigating the page, 
// and checking browser console errors. This supports automated UI testing of checkbox behaviors.

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with checkboxes on the HerokuApp checkboxes page.
    /// </summary>
    public class CheckBoxesPage : ICheckBoxes
    {
        private readonly WebDriverWrapper _wrapper;
        private readonly string _pageUrl = "https://the-internet.herokuapp.com/checkboxes";

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxesPage"/> class.
        /// </summary>
        /// <param name="wrapper">The WebDriver wrapper used for Selenium interactions.</param>
        public CheckBoxesPage(WebDriverWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        /// <summary>
        /// Gets the locator for a checkbox by zero-based index.
        /// </summary>
        /// <param name="index">Zero-based index of the checkbox.</param>
        /// <returns>The element locator for the checkbox.</returns>
        private ElementLocator GetCheckboxLocator(int index)
        {
            // nth-of-type is 1-based, so add 1 to index
            return ElementLocator.ByCss($"#checkboxes input:nth-of-type({index + 1})", $"Checkbox {index + 1}");
        }

        /// <summary>
        /// Gets the page title.
        /// </summary>
        /// <returns>The page title string.</returns>
        public string GetPageTitle() => _wrapper.Driver.Title;

        /// <summary>
        /// Checks if the checkbox at the specified index is clickable.
        /// </summary>
        /// <param name="index">Zero-based index of the checkbox.</param>
        /// <returns>True if clickable; otherwise, false.</returns>
        public bool IsCheckboxClickable(int index) =>
            _wrapper.IsElementClickable(GetCheckboxLocator(index));

        /// <summary>
        /// Checks (selects) the first checkbox if not already checked.
        /// </summary>
        public void CheckFirstBox()
        {
            var locator = GetCheckboxLocator(0);
            if (!_wrapper.FindElement(locator).Selected)
                _wrapper.Click(locator);
        }

        /// <summary>
        /// Checks (selects) the second checkbox if not already checked.
        /// </summary>
        public void CheckSecondBox()
        {
            var locator = GetCheckboxLocator(1);
            if (!_wrapper.FindElement(locator).Selected)
                _wrapper.Click(locator);
        }

        /// <summary>
        /// Unchecks (deselects) the first checkbox if it is currently checked.
        /// </summary>
        public void UncheckFirstBox()
        {
            var locator = GetCheckboxLocator(0);
            if (_wrapper.FindElement(locator).Selected)
                _wrapper.Click(locator);
        }

        /// <summary>
        /// Unchecks (deselects) the second checkbox if it is currently checked.
        /// </summary>
        public void UncheckSecondBox()
        {
            var locator = GetCheckboxLocator(1);
            if (_wrapper.FindElement(locator).Selected)
                _wrapper.Click(locator);
        }

        /// <summary>
        /// Determines whether the first checkbox is checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        public bool IsFirstBoxChecked() =>
            _wrapper.FindElement(GetCheckboxLocator(0)).Selected;

        /// <summary>
        /// Determines whether the second checkbox is checked.
        /// </summary>
        /// <returns>True if checked; otherwise, false.</returns>
        public bool IsSecondBoxChecked() =>
            _wrapper.FindElement(GetCheckboxLocator(1)).Selected;

        /// <summary>
        /// Gets the checked state of all checkboxes on the page.
        /// </summary>
        /// <returns>List of booleans representing each checkbox's checked state.</returns>
        public List<bool> GetAllCheckboxStates()
        {
            var checkboxes = _wrapper.FindElements(ElementLocator.ByCss("#checkboxes input", "All checkboxes"));
            return checkboxes.Select(cb => cb.Selected).ToList();
        }

        /// <summary>
        /// Toggles (clicks) the first checkbox.
        /// </summary>
        public void ToggleFirstBox() => _wrapper.Click(GetCheckboxLocator(0));

        /// <summary>
        /// Toggles (clicks) the second checkbox.
        /// </summary>
        public void ToggleSecondBox() => _wrapper.Click(GetCheckboxLocator(1));

        /// <summary>
        /// Gets the main content text of the checkboxes container.
        /// </summary>
        /// <returns>The text content of the checkboxes container.</returns>
        public string GetMainContent() =>
            _wrapper.GetText(ElementLocator.ByCss("#checkboxes", "Checkboxes container"));

        /// <summary>
        /// Checks if the browser console has any severe errors logged.
        /// </summary>
        /// <returns>True if severe console errors exist; otherwise, false.</returns>
        public bool HasConsoleErrors()
        {
            var logs = _wrapper.Driver.Manage().Logs.GetLog(LogType.Browser);
            return logs.Any(entry => entry.Level == LogLevel.Severe);
        }

        /// <summary>
        /// Focuses and clicks on the checkbox at the specified index using Actions.
        /// </summary>
        /// <param name="index">Zero-based index of the checkbox.</param>
        public void FocusCheckbox(int index)
        {
            var locator = GetCheckboxLocator(index);
            var element = _wrapper.FindElement(locator);
            _wrapper.Actions.MoveToElement(element).Click().Perform();
        }

        /// <summary>
        /// Sends the Space key to the currently focused element.
        /// </summary>
        public void PressSpaceKey() => _wrapper.Actions.SendKeys(Keys.Space).Perform();

        /// <summary>
        /// Navigates the browser away from the current page to the Heroku homepage.
        /// </summary>
        public void NavigateAway() => _wrapper.NavigateTo("https://the-internet.herokuapp.com/");

        /// <summary>
        /// Navigates back to the previous page in the browser history.
        /// </summary>
        public void NavigateBack() => _wrapper.NavigateBack();

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        public void RefreshPage() => _wrapper.RefreshPage();
    }
}
