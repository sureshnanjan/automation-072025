using OpenQA.Selenium;

namespace DynamicContentPage
{
    public class DynamicContentInterface
    {
        private readonly IWebDriver driver;

        public DynamicContentInterface(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IWebElement PageHeader => driver.FindElement(By.CssSelector("h3"));

        public IList<IWebElement> ContentRows => driver.FindElements(By.CssSelector("#content .row"));

        public IWebElement GetImageElementInRow(int rowIndex)
        {
            return ContentRows[rowIndex].FindElement(By.CssSelector(".large-2 img"));
        }

        public IWebElement GetTextElementInRow(int rowIndex)
        {
            return ContentRows[rowIndex].FindElement(By.CssSelector(".large-10"));
        }

        public IWebElement ExampleText => driver.FindElement(By.CssSelector("#content > div > div > div"));

        public IWebElement PoweredByText => driver.FindElement(By.CssSelector(".example p"));
    }
}
