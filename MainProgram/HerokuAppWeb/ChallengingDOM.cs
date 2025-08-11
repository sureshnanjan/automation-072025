// Author: Siva Sree
// Date Created: 2025-07-30
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# class implements the IChallengingDOM interface to automate interaction 
// with the Challenging DOM page on HerokuApp (https://the-internet.herokuapp.com/challenging_dom).
// It provides methods to click colored buttons, retrieve button text and dynamic content,
// access and manipulate table data, verify edit/delete actions per row, and simulate UI interactions.
// Selenium WebDriver operations are wrapped by WebDriverWrapper to facilitate stable UI test automation.

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations
{
    /// <summary>
    /// Provides automation methods to interact with the Challenging DOM page on HerokuApp.
    /// </summary>
    public class ChallengingDOMPage : IChallengingDOM
    {
        private readonly WebDriverWrapper _wrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengingDOMPage"/> class.
        /// </summary>
        /// <param name="wrapper">The WebDriver wrapper used for Selenium interactions.</param>
        public ChallengingDOMPage(WebDriverWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        /// <summary>
        /// Gets the title of the page.
        /// </summary>
        public string Title => _wrapper.Driver.Title;

        /// <summary>
        /// Gets the main description paragraph text.
        /// </summary>
        public string Description =>
            _wrapper.GetText(ElementLocator.ByXPath("//div[@class='example']/p", "Main description paragraph"));

        /// <summary>
        /// Clicks the blue button.
        /// </summary>
        public void ClickBlueButton() =>
            _wrapper.Click(ElementLocator.ByCss(".button", "Blue button"));

        /// <summary>
        /// Clicks the red button.
        /// </summary>
        public void ClickRedButton() =>
            _wrapper.Click(ElementLocator.ByCss(".button.alert", "Red button"));

        /// <summary>
        /// Clicks the green button.
        /// </summary>
        public void ClickGreenButton() =>
            _wrapper.Click(ElementLocator.ByCss(".button.success", "Green button"));

        /// <summary>
        /// Gets the text from the answer box, which updates dynamically after button clicks.
        /// </summary>
        /// <returns>The text content of the answer box.</returns>
        public string GetAnswerBoxText() =>
            _wrapper.GetText(ElementLocator.ByCss("div#content > script + div", "Answer box (dynamic id)"));

        /// <summary>
        /// Gets the text of the blue button.
        /// </summary>
        /// <returns>The blue button text.</returns>
        public string GetBlueButtonText() =>
            _wrapper.GetText(ElementLocator.ByCss(".button", "Blue button text"));

        /// <summary>
        /// Gets the text of the red button.
        /// </summary>
        /// <returns>The red button text.</returns>
        public string GetRedButtonText() =>
            _wrapper.GetText(ElementLocator.ByCss(".button.alert", "Red button text"));

        /// <summary>
        /// Gets the text of the green button.
        /// </summary>
        /// <returns>The green button text.</returns>
        public string GetGreenButtonText() =>
            _wrapper.GetText(ElementLocator.ByCss(".button.success", "Green button text"));

        /// <summary>
        /// Clicks a button using the provided action, then returns the updated answer box text.
        /// </summary>
        /// <param name="clickAction">The action to perform the button click.</param>
        /// <returns>The updated answer box text after the click.</returns>
        public string ClickButtonAndReturnAnswer(Action clickAction)
        {
            clickAction.Invoke();
            return GetAnswerBoxText();
        }

        /// <summary>
        /// Gets the list of table header texts.
        /// </summary>
        /// <returns>List of strings representing each table header.</returns>
        public List<string> GetTableHeaders()
        {
            var headers = _wrapper.FindElements(ElementLocator.ByCss("table thead tr th", "Table headers"));
            return headers.Select(h => h.Text.Trim()).ToList();
        }

        /// <summary>
        /// Gets the number of rows in the table body.
        /// </summary>
        /// <returns>The count of table rows.</returns>
        public int GetTableRowCount() =>
            _wrapper.FindElements(ElementLocator.ByCss("table tbody tr", "Table rows")).Count;

        /// <summary>
        /// Gets the number of columns (cells) in the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the table row.</param>
        /// <returns>The count of columns in the row.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if rowIndex is out of bounds.</exception>
        public int GetColumnCountInRow(int rowIndex)
        {
            var rows = _wrapper.FindElements(ElementLocator.ByCss("table tbody tr", "Table rows"));
            if (rowIndex >= rows.Count)
                throw new IndexOutOfRangeException("Row index out of bounds.");
            return rows[rowIndex].FindElements(By.TagName("td")).Count;
        }

        /// <summary>
        /// Gets the list of cell text values in the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the table row.</param>
        /// <returns>List of strings for each cell's text.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if rowIndex is out of bounds.</exception>
        public List<string> GetRowData(int rowIndex)
        {
            var rows = _wrapper.FindElements(ElementLocator.ByCss("table tbody tr", "Table rows"));
            if (rowIndex >= rows.Count)
                throw new IndexOutOfRangeException("Row index out of bounds.");
            return rows[rowIndex].FindElements(By.TagName("td")).Select(td => td.Text.Trim()).ToList();
        }

        /// <summary>
        /// Checks if the specified row is editable by verifying if the "edit" link is present.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <returns>True if the row has an edit button; otherwise, false.</returns>
        public bool IsRowEditable(int rowIndex) => HasEditButton(rowIndex);

        /// <summary>
        /// Clicks the edit button on the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        public void ClickEdit(int rowIndex)
        {
            var locator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td/a[text()='edit']", $"Edit button for row {rowIndex}");
            _wrapper.Click(locator);
        }

        /// <summary>
        /// Clicks the delete button on the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        public void ClickDelete(int rowIndex)
        {
            var locator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td/a[text()='delete']", $"Delete button for row {rowIndex}");
            _wrapper.Click(locator);
        }

        /// <summary>
        /// Checks whether the edit button is present on the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <returns>True if the edit button is present; otherwise, false.</returns>
        public bool HasEditButton(int rowIndex)
        {
            try
            {
                var locator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td/a[text()='edit']", $"Edit button for row {rowIndex}");
                return _wrapper.IsElementPresent(locator);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the delete button is present on the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <returns>True if the delete button is present; otherwise, false.</returns>
        public bool HasDeleteButton(int rowIndex)
        {
            try
            {
                var locator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td/a[text()='delete']", $"Delete button for row {rowIndex}");
                return _wrapper.IsElementPresent(locator);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if an edit modal or section is currently visible on the page.
        /// </summary>
        /// <returns>True if an edit modal or form is visible; otherwise, false.</returns>
        public bool IsEditModalDisplayed()
        {
            var locator = ElementLocator.ByCss(".edit-modal, .edit-form", "Edit modal or section");
            return _wrapper.IsElementVisible(locator);
        }

        /// <summary>
        /// Updates the value of a specific cell in the table.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <param name="columnIndex">Zero-based index of the column.</param>
        /// <param name="newValue">The new value to set in the cell.</param>
        public void UpdateCell(int rowIndex, int columnIndex, string newValue)
        {
            var cellLocator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td[{columnIndex + 1}]", $"Editable cell [{rowIndex}, {columnIndex}]");
            _wrapper.Click(cellLocator);
            _wrapper.SendKeys(cellLocator, newValue);
        }

        /// <summary>
        /// Clicks the save button for the specified row.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        public void SaveEdit(int rowIndex)
        {
            var locator = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td/a[text()='save']", $"Save button for row {rowIndex}");
            _wrapper.Click(locator);
        }

        /// <summary>
        /// Gets the text value of a specific table cell.
        /// </summary>
        /// <param name="rowIndex">Zero-based index of the row.</param>
        /// <param name="columnIndex">Zero-based index of the column.</param>
        /// <returns>The text content of the specified cell.</returns>
        public string GetCellValue(int rowIndex, int columnIndex)
        {
            var cell = ElementLocator.ByXPath($"//table/tbody/tr[{rowIndex + 1}]/td[{columnIndex + 1}]", $"Cell [{rowIndex}, {columnIndex}]");
            return _wrapper.GetText(cell);
        }

        /// <summary>
        /// Gets the text content of the page footer.
        /// </summary>
        /// <returns>The footer text.</returns>
        public string GetFooterText()
        {
            var locator = ElementLocator.ByCss("div#page-footer", "Footer");
            return _wrapper.GetText(locator);
        }

        /// <summary>
        /// Gets the text content of the GitHub ribbon link.
        /// </summary>
        /// <returns>The GitHub ribbon text.</returns>
        public string GetGitHubRibbonText()
        {
            var locator = ElementLocator.ByCss("a[aria-label='Fork me on GitHub']", "GitHub Ribbon");
            return _wrapper.GetText(locator);
        }
    }
}
