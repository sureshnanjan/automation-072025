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
    /// Implements dropdown functionality for /dropdown page.
    /// </summary>
    public class DropdownPage : IDropdownPage
    {
        private readonly IWebDriver driver;
        private readonly By titleLocator = By.TagName("h3");
        private readonly By subtitleLocator = By.TagName("p");
        private readonly By dropdownLocator = By.Id("dropdown");
        private readonly By optionLocator = By.CssSelector("#dropdown option");

        public DropdownPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
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
            return driver.FindElements(optionLocator).Count;
        }

        public string GetTextFromRow(int rowIndex)
        {
            var options = driver.FindElements(optionLocator);
            if (rowIndex < 0 || rowIndex >= options.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid dropdown index.");
            return options[rowIndex].Text;
        }

        public string GetImageSourceFromRow(int rowIndex)
        {
            return "No image available for dropdown options.";
        }
    }
}
