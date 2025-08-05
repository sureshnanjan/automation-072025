using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Provides functionality to automate interactions with the
    /// Multiple Windows page on https://the-internet.herokuapp.com/windows.
    /// </summary>
    public class MultipleWindowsPage : IWindowPage
    {
        private readonly IWebDriver driver;
        private string mainWindowHandle;

        /// <summary>
        /// URL for the Multiple Windows test page.
        /// </summary>
        private const string PageUrl = "https://the-internet.herokuapp.com/windows";

        /// <summary>
        /// Locator for the "Click Here" link to open a new window.
        /// Uses visible link text.
        /// </summary>
        private readonly By clickHereLinkLocator = By.LinkText("Click Here");

        /// <summary>
        /// Locator for the header text element (tag <h3>) on both pages.
        /// </summary>
        private readonly By headerLocator = By.TagName("h3");

        /// <summary>
        /// Constructor that accepts a Selenium WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver to use for browser automation.</param>
        public MultipleWindowsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <inheritdoc />
        public void GotoPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
            mainWindowHandle = driver.CurrentWindowHandle;
        }

        /// <inheritdoc />
        public string GetTitle()
        {
            return driver.FindElement(headerLocator).Text;
        }

        /// <inheritdoc />
        public void ClickHereLink()
        {
            driver.FindElement(clickHereLinkLocator).Click();
        }

        /// <inheritdoc />
        public void SwitchToNewWindow()
        {
            IReadOnlyCollection<string> allWindowHandles = driver.WindowHandles;

            foreach (var handle in allWindowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        /// <inheritdoc />
        public void SwitchToMainWindow()
        {
            driver.SwitchTo().Window(mainWindowHandle);
        }

        /// <inheritdoc />
        public string GetNewWindowText()
        {
            return driver.FindElement(headerLocator).Text;
        }
    }
}
