using OpenQA.Selenium;  // Required for IWebDriver, IWebElement, and By selectors

namespace DynamicContentPage
{
    /// <summary>
    /// Interface class for identifying web elements on the dynamic content page.
    /// This interface allows interaction with text, images, and headers on the page.
    /// </summary>
    public class DynamicContentInterface
    {
        private readonly IWebDriver driver;  
        // Controls the browser session and lets us find elements on the page.

        // Represents the header/title at the top of the page.
        public IWebElement PageHeader => driver.FindElement(By.CssSelector("h3"));

        // Represents all dynamic content rows on the page (usually 3 rows).
        public IList<IWebElement> ContentRows => driver.FindElements(By.CssSelector("#content .row"));

        // Represents the image element in a specific row.
        public IWebElement GetImageElementInRow(int rowIndex) =>
            ContentRows[rowIndex].FindElement(By.CssSelector(".large-2 img"));

        // Represents the text element in a specific row.
        public IWebElement GetTextElementInRow(int rowIndex) =>
            ContentRows[rowIndex].FindElement(By.CssSelector(".large-10"));

        // Captures a generic block of example text within the page content.
        public IWebElement ExampleText => driver.FindElement(By.CssSelector("#content > div > div > div"));

        // Identifies the "Powered by..." or similar footer label in the page's .example section.
        public IWebElement PoweredByText => driver.FindElement(By.CssSelector(".example p"));
    }
}
