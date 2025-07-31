using OpenQA.Selenium;  // Provides interfaces and classes to interact with web elements using Selenium WebDriver

namespace DynamicContentPage
{
    /// <summary>
    /// Interface class for interacting with the dynamic content page at https://the-internet.herokuapp.com/dynamic_content
    /// </summary>
    public class DynamicContentInterface
    {
        private readonly IWebDriver driver;  
        // IWebDriver is used to control the browser session and interact with web elements.

        public DynamicContentInterface(IWebDriver webDriver)
        {
            driver = webDriver;  // Constructor injection for WebDriver instance.
        }

        public IWebElement PageHeader => driver.FindElement(By.CssSelector("h3"));
        // Locates the main heading (<h3>) on the page.

        public IList<IWebElement> ContentRows => driver.FindElements(By.CssSelector("#content .row"));
        // Locates all content rows containing dynamic images and text.

        public IWebElement GetImageElementInRow(int rowIndex)
        {
            return ContentRows[rowIndex].FindElement(By.CssSelector(".large-2 img"));
            // Retrieves the <img> element from the specified content row (column with image).
        }

        public IWebElement GetTextElementInRow(int rowIndex)
        {
            return ContentRows[rowIndex].FindElement(By.CssSelector(".large-10"));
            // Retrieves the text content element from the specified row (column with dynamic text).
        }

        public IWebElement ExampleText => driver.FindElement(By.CssSelector("#content > div > div > div"));
        // Grabs an inner content division that may hold example text or dynamic output.

        public IWebElement PoweredByText => driver.FindElement(By.CssSelector(".example p"));
        // Finds the "Powered by..." text located in the footer or example section.
    }
}
