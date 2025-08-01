using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class SortableDataTables : ISortableDataTables
    {
        private IWebDriver driver;
        private string url = "https://the-internet.herokuapp.com/tables";

        public SortableDataTables()
        {
            driver = new ChromeDriver();
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetInformation()
        {
            return driver.FindElement(By.TagName("h3")).Text;
        }

        public int GetRowCount()
        {
            var rows = driver.FindElements(By.CssSelector("#table1 tbody tr"));
            return rows.Count;
        }

        public int GetColumnCount()
        {
            var cols = driver.FindElements(By.CssSelector("#table1 thead tr th"));
            return cols.Count;
        }

        public string GetCellValue(int row, int column)
        {
            var cell = driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row}) td:nth-child({column})"));
            return cell.Text;
        }

        public void ClickEditButton(int row)
        {
            var editButton = driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row}) .edit"));
            editButton.Click();
        }

        public void ClickDeleteButton(int row)
        {
            var deleteButton = driver.FindElement(By.CssSelector($"#table1 tbody tr:nth-child({row}) .delete"));
            deleteButton.Click();
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}
