using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class DynamicContentPage : IDynamicContentPage
    {
        private readonly IWebDriver driver;

        public DynamicContentPage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        // Gets the page title (e.g., "Dynamic Content")
        public string GetTitle()
        {
            return driver.FindElement(By.TagName("h3")).Text;
        }

        // Gets the subtitle below the header, if present
        public string GetSubTitle()
        {
            var elements = driver.FindElements(By.CssSelector(".example > p"));
            return elements.Count > 0 ? elements[0].Text : string.Empty;
        }

        // Gets number of dynamic content rows (typically 3)
        public int GetRowCount()
        {
            return driver.FindElements(By.CssSelector("#content .row")).Count;
        }

        // Gets text content from a specific row
        public string GetTextFromRow(int rowIndex)
        {
            var rows = driver.FindElements(By.CssSelector("#content .row"));
            if (rowIndex < 0 || rowIndex >= rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index out of range.");

            var textElement = rows[rowIndex].FindElement(By.CssSelector(".large-10"));
            return textElement.Text;
        }

        // Gets image URL from a specific row
        public string GetImageSourceFromRow(int rowIndex)
        {
            var rows = driver.FindElements(By.CssSelector("#content .row"));
            if (rowIndex < 0 || rowIndex >= rows.Count)
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index out of range.");
            
            var imageElement = rows[rowIndex].FindElement(By.CssSelector(".large-2 img"));
            return imageElement.GetAttribute("src");
        }
    }
}

