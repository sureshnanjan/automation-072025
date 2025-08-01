using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class ChallengingDOMClassApp : IChallengingDOM
    {
        private readonly IWebDriver driver;

        // Locators
        private readonly By titleLocator = By.TagName("h3");
        private readonly By descriptionLocator = By.TagName("p");
        private readonly By blueButtonLocator = By.CssSelector(".button");
        private readonly By redButtonLocator = By.CssSelector(".button.alert");
        private readonly By greenButtonLocator = By.CssSelector(".button.success");
        private readonly By tableHeaderLocator = By.CssSelector("table thead tr th");
        private readonly By tableRowLocator = By.CssSelector("table tbody tr");

        public ChallengingDOMClassApp(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");
        }

        public string GetPageTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        public string GetDescriptionText()
        {
            return driver.FindElement(descriptionLocator).Text;
        }

        public void ClickBlueButton()
        {
            driver.FindElement(blueButtonLocator).Click();
        }

        public void ClickRedButton()
        {
            driver.FindElement(redButtonLocator).Click();
        }

        public void ClickGreenButton()
        {
            driver.FindElement(greenButtonLocator).Click();
        }

        public List<string> GetTableHeaders()
        {
            var headers = new List<string>();
            var headerElements = driver.FindElements(tableHeaderLocator);
            foreach (var header in headerElements)
            {
                headers.Add(header.Text.Trim());
            }
            return headers;
        }

        public List<List<string>> GetTableRows()
        {
            var tableData = new List<List<string>>();
            var rowElements = driver.FindElements(tableRowLocator);
            foreach (var row in rowElements)
            {
                var rowData = new List<string>();
                var cells = row.FindElements(By.TagName("td"));
                foreach (var cell in cells)
                {
                    rowData.Add(cell.Text.Trim());
                }
                tableData.Add(rowData);
            }
            return tableData;
        }

        public void ClickEdit(int rowIndex)
        {
            var rows = driver.FindElements(tableRowLocator);
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
            var rows = driver.FindElements(tableRowLocator);
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
