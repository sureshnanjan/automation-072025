// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HerokuOperations;
using OpenQA.Selenium;
using System;

namespace HerokuAppWeb
{
    /// <summary>
    /// Handles interaction with the /dynamic_content page.
    /// </summary>
    public class DynamicContentPage : IDynamicContentPage
    {
        private readonly IWebDriver driver;
        private readonly By titleLocator = By.TagName("h3");
        private readonly By subtitleLocator = By.TagName("div");
        private readonly By contentRowLocator = By.CssSelector("#content .row");

        public DynamicContentPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_content");
        }

        public string GetTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        public string GetSubTitle()
        {
            return driver.FindElement(subtitleLocator).Text;
        }

        public int GetRowCount()
        {
            return driver.FindElements(contentRowLocator).Count;
        }

        public string GetTextFromRow(int rowIndex)
        {
            var rows = driver.FindElements(contentRowLocator);
            if (rowIndex < 0 || rowIndex >= rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid content row index.");
            return rows[rowIndex].Text;
        }

        public string GetImageSourceFromRow(int rowIndex)
        {
            var rows = driver.FindElements(contentRowLocator);
            if (rowIndex < 0 || rowIndex >= rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid content row index.");

            return rows[rowIndex].FindElement(By.TagName("img")).GetAttribute("src");
        }
    }
}
