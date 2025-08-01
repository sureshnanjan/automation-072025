using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class DropdownPageAsDynamicContent : IDynamicContentPage
    {
        private readonly IWebDriver _driver;

        public DropdownPageAsDynamicContent(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public string GetSubTitle()
        {
            // Assuming subtitle is not present, returning a fallback value.  
            return "Subtitle not available";
        }

        public int GetRowCount()
        {
            var options = _driver.FindElements(By.TagName("option"));
            return options.Count;
        }

        public string GetTextFromRow(int rowIndex)
        {
            var options = _driver.FindElements(By.TagName("option"));
            if (rowIndex < 0 || rowIndex >= options.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid row index.");
            }
            return options[rowIndex].Text;
        }

        public string GetImageSourceFromRow(int rowIndex)
        {
            // Since there are no images on the dropdown page, returning a default value.  
            return "N/A - No images on this page";
        }
    }
}
