using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implements the IinfiniteScroll interface to automate interactions
    /// with the Infinite Scroll page of HerokuApp.
    /// </summary>
    public class InfiniteScrollPage : IinfiniteScroll
    {
        private readonly IWebDriver driver;
        private readonly IJavaScriptExecutor jsExecutor;
        private const string PageUrl = "https://the-internet.herokuapp.com/infinite_scroll";

        // Locators
        private readonly By titleLocator = By.TagName("h1");           // "Infinite Scroll"
        private readonly By subtitleLocator = By.TagName("h2");        // "Scroll down to load more"
        private readonly By footerLocator = By.CssSelector(".footer"); // Contains "Powered by Elemental Selenium"
        private readonly By githubRibbonLocator = By.CssSelector("a[href*='github']"); // "Fork me on GitHub" ribbon

        /// <summary>
        /// Constructor for InfiniteScrollPage.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance.</param>
        public InfiniteScrollPage(IWebDriver driver)
        {
            this.driver = driver;
            this.jsExecutor = (IJavaScriptExecutor)driver;
        }

        /// <inheritdoc />
        public void GotoPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        /// <inheritdoc />
        public string GetTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        /// <inheritdoc />
        public string GetSubTitle()
        {
            return driver.FindElement(subtitleLocator).Text;
        }

        /// <inheritdoc />
        public void ScrollToBottom()
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        /// <inheritdoc />
        public int GetScrollHeight()
        {
            return Convert.ToInt32(jsExecutor.ExecuteScript("return document.body.scrollHeight;"));
        }

        /// <inheritdoc />
        public int GetScrollWidth()
        {
            return Convert.ToInt32(jsExecutor.ExecuteScript("return document.body.scrollWidth;"));
        }

        /// <inheritdoc />
        public void ScrollToTop()
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
        }

        /// <inheritdoc />
        public void ScrollToLeft()
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, window.scrollY);");
        }

        /// <inheritdoc />
        public void ScrollToRight()
        {
            jsExecutor.ExecuteScript("window.scrollTo(document.body.scrollWidth, window.scrollY);");
        }

        /// <inheritdoc />
        public int GetScrollX()
        {
            return Convert.ToInt32(jsExecutor.ExecuteScript("return window.scrollX;"));
        }

        /// <inheritdoc />
        public int GetScrollY()
        {
            return Convert.ToInt32(jsExecutor.ExecuteScript("return window.scrollY;"));
        }

        /// <inheritdoc />
        public void ScrollTo(int x, int y)
        {
            jsExecutor.ExecuteScript($"window.scrollTo({x}, {y});");
        }

        /// <inheritdoc />
        public bool IsFooterPoweredByVisible()
        {
            try
            {
                var footer = driver.FindElement(footerLocator);
                return footer.Displayed && footer.Text.Contains("Powered by Elemental Selenium");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc />
        public bool IsGitHubRibbonVisible()
        {
            try
            {
                var ribbon = driver.FindElement(githubRibbonLocator);
                return ribbon.Displayed && ribbon.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
