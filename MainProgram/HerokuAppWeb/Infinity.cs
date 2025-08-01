using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace HerokuAppWeb
{
    // Implements IInfinity without using JavaScript
    public class InfinityClassApp : HerokuOperations.IInfinity
    {
        private readonly IWebDriver driver;
        private readonly By paragraphLocator = By.ClassName("jscroll-added");

        public InfinityClassApp(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        // Navigate to the Infinite Scroll test page
        public void GotoPage()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/infinite_scroll");
            driver.Manage().Window.Maximize();
        }

        // Scrolls down using the 'Page Down' key to simulate user scrolling
        public void ScrollDown(int times)
        {
            Actions actions = new Actions(driver);
            for (int i = 0; i < times; i++)
            {
                actions.SendKeys(Keys.PageDown).Perform(); // Scroll down one page
                Thread.Sleep(1000); // Wait for content to load
            }
        }

        // Returns the number of paragraph elements (jscroll-added)
        public int GetParagraphCount()
        {
            return driver.FindElements(paragraphLocator).Count;
        }

        // ScrollY can't be accessed without JavaScript, so return dummy value or skip
        public int GetScrollY()
        {
            // Not available without JavaScript — return -1 or remove from interface
            return -1;
        }

        // Scroll to the bottom using repeated PageDown keys
        public void ScrollToBottom()
        {
            Actions actions = new Actions(driver);
            for (int i = 0; i < 10; i++)
            {
                actions.SendKeys(Keys.PageDown).Perform();
                Thread.Sleep(500);
            }
        }

        // Scroll to the top using Home key
        public void ScrollToTop()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Home).Perform();
        }

        // Closes the browser
        public void Close()
        {
            driver.Quit();
        }
    }
}
