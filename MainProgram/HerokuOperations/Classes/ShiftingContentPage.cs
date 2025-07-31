using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HerokuOperations
{
    public class ShiftingContentPage : IShiftingContentPage
    {
        private readonly IWebDriver driver;

        public ShiftingContentPage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        // Gets the title, e.g., "Shifting Content"
        public string GetTitle()
        {
            return driver.FindElement(By.TagName("h3")).Text;
        }

        // Gets the paragraph description below the title
        public string GetDescription()
        {
            var paragraphs = driver.FindElements(By.CssSelector(".example > p"));
            return paragraphs.Count > 0 ? paragraphs[0].Text : string.Empty;
        }

        // Gets all visible link texts from the page
        public string[] GetAllLinkTexts()
        {
            var links = driver.FindElements(By.CssSelector(".example a"));
            return links.Select(link => link.Text.Trim()).Where(text => !string.IsNullOrEmpty(text)).ToArray();
        }

        // Returns the number of links
        public int GetLinkCount()
        {
            return driver.FindElements(By.CssSelector(".example a")).Count;
        }
    }
}

