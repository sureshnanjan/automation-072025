using HerokuOperations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;  // For scrolling using Actions
using System;
using System.Threading;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements Infinite Scroll page using Actions class instead of JavaScriptExecutor.
    /// </summary>
    public class Infinity : IInfinity
    {
        private ChromeDriver driver;
        private readonly string url = "https://the-internet.herokuapp.com/infinite_scroll";

        /// <summary>
        /// Constructor - Initializes ChromeDriver and navigates to the page.
        /// </summary>
        public Infinity()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(this.url);
        }

        /// <summary>
        /// Re-navigates to the infinite scroll page (useful in test setup).
        /// </summary>
        public void GotoPage()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        /// <summary>
        /// Scrolls down by simulating "Page Down" key multiple times.
        /// </summary>
        public void ScrollToBottom()
        {
            Actions action = new Actions(this.driver);
            for (int i = 0; i < 5; i++) // Scroll 5 times
            {
                action.SendKeys(Keys.PageDown).Perform();
                Thread.Sleep(1000); // Wait for content to load
            }
        }

        /// <summary>
        /// Scrolls up by simulating "Page Up" key multiple times.
        /// </summary>
        public void ScrollToTop()
        {
            Actions action = new Actions(this.driver);
            for (int i = 0; i < 5; i++) // Scroll up 5 times
            {
                action.SendKeys(Keys.PageUp).Perform();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Dummy scroll position (scrollY is not accessible without JS).
        /// </summary>
        public int GetScrollY()
        {
            Console.WriteLine("Warning: Exact scroll position can't be determined without JavaScript.");
            return -1; // Placeholder value
        }
    }
}
