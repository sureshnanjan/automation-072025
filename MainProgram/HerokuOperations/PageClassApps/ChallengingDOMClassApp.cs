using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using HerokuOperations.PageInterfaces;

namespace HerokuOperations.PageClassApps
{
    /// <summary>
    /// Implements the IChallengingDOM interface for interacting with the Challenging DOM page.
    /// </summary>
    public class ChallengingDOMClassApp : IChallengingDOM
    {
        private readonly IWebDriver driver;

        public ChallengingDOMClassApp(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public string GetPageTitle()
        {
            return driver.FindElement(By.TagName("h3")).Text;
        }

        public string GetDescriptionText()
        {
            return driver.FindElement(By.TagName("p")).Text;
        }

        public void ClickBlueButton()
        {
            driver.FindElement(By.CssSelector(".button")).Click();
        }

        public void ClickRedButton()
        {
            driver.FindElement(By.CssSelector(".button.alert")).Click();
        }

        public void ClickGreenButton()
        {
            driver.FindElement(By.CssSelector(".button.success")).Click();
        }

        public List<string> GetTableHeaders()
        {
            var headers = new List<string>();
            var headerElements = driver.FindElements(By.CssSelector("table thead tr th"));

            foreach (var header in headerElements)
            {
                headers.Add(header.Text.Trim());
            }

            return headers;
        }

        public List<List<string>> GetTableRows()
        {
            var tableData = new List<List<string>>();
            var rowElements = driver.FindElements(By.CssSelector("table tbody tr"));

            foreach (var row in rowElements)
            {
                var rowData = new List<string>();
                var cellElements = row.FindElements(By.TagName("td"));

                foreach (var cell in cellElements)
                {
                    rowData.Add(cell.Text.Trim());
                }

                tableData.Add(rowData);
            }

            return tableData;
        }

        public void ClickEdit(int rowIndex)
        {
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            if (rowIndex >= 0 && rowIndex < rows.Count)
            {
                var editLink = rows[rowIndex].FindElement(By.LinkText("edit"));
                editLink.Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid row index for edit.");
            }
        }

        public void ClickDelete(int rowIndex)
        {
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            if (rowIndex >= 0 && rowIndex < rows.Count)
            {
                var deleteLink = rows[rowIndex].FindElement(By.LinkText("delete"));
                deleteLink.Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid row index for delete.");
            }
        }
    }
}
