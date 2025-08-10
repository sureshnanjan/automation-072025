/*
* -------------------------------------------------------------------------------------
*  Copyright (c) 2025 Sowmya Sridhar
*  All Rights Reserved.
*  
*  Permission is hereby granted to use and modify this code for personal 
*  and educational purposes only. Redistribution or commercial use without 
*  prior written consent is prohibited.
* -------------------------------------------------------------------------------------
*/

using System;
using HerokuOperations;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations.Implementations
{
    /// <summary>
    /// Represents the Sortable Data Tables page in the application using the Page Object Model pattern.
    /// Provides methods for reading table data and performing actions like edit/delete.
    /// </summary>
    internal class SortableDataTablesPage : ISortableDataTables
    {
        private readonly WebDriverWrapper _driver;

        // Page URL
        private const string PageUrl = "https://the-internet.herokuapp.com/tables";

        // Locators
        private readonly ElementLocator _infoTextLocator = new ElementLocator(By.XPath("//h3"), "Information Text");
        private readonly ElementLocator _tableLocator = new ElementLocator(By.Id("table1"), "Main Data Table");
        private readonly ElementLocator _footerLocator = new ElementLocator(By.CssSelector("div[style*='text-align: center;']"), "Footer Text");
        private readonly ElementLocator _githubRibbonLocator = new ElementLocator(By.CssSelector("img[alt='Fork me on GitHub']"), "GitHub Ribbon");

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableDataTablesPage"/> class.
        /// </summary>
        /// <param name="driver">Instance of WebDriverWrapper for browser automation.</param>
        /// <exception cref="ArgumentNullException">Thrown when driver is null.</exception>
        public SortableDataTablesPage(WebDriverWrapper driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <inheritdoc/>
        public void GoToPage()
        {
            _driver.Driver.Navigate().GoToUrl(PageUrl);
        }

        /// <inheritdoc/>
        public string GetTitle()
        {
            return _driver.Driver.Title;
        }

        /// <inheritdoc/>
        public string GetInformation()
        {
            return _driver.GetText(_infoTextLocator);
        }

        /// <inheritdoc/>
        public int GetRowCount()
        {
            var rows = _driver.Driver.FindElements(By.CssSelector("#table1 tbody tr"));
            return rows.Count;
        }

        /// <inheritdoc/>
        public int GetColumnCount()
        {
            var columns = _driver.Driver.FindElements(By.CssSelector("#table1 thead tr th"));
            return columns.Count;
        }

        /// <inheritdoc/>
        public string GetCellValue(int row, int column)
        {
            var cell = _driver.Driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row + 1}) td:nth-child({column + 1})"));
            return cell.Text;
        }

        /// <inheritdoc/>
        public void ClickEditButton(int row)
        {
            var editButton = _driver.Driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row + 1}) a[href*='edit']"));
            editButton.Click();
        }

        /// <inheritdoc/>
        public void ClickDeleteButton(int row)
        {
            var deleteButton = _driver.Driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row + 1}) a[href*='delete']"));
            deleteButton.Click();
        }

        /// <inheritdoc/>
        public string GetFooterText()
        {
            return _driver.GetText(_footerLocator);
        }

        /// <inheritdoc/>
        public string GetGitHubRibbonText()
        {
            var ribbonImg = _driver.Driver.FindElement(_githubRibbonLocator.By);
            return ribbonImg.GetAttribute("alt");
        }
    }
}
