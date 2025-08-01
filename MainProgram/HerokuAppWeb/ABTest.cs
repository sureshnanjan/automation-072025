using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IABTest interface for interacting with the A/B Testing page
    /// on https://the-internet.herokuapp.com/abtest
    /// </summary>
    public class ABTestPage : IABTest
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://the-internet.herokuapp.com/abtest";

        /// <summary>
        /// Constructor to initialize WebDriver.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        public ABTestPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the A/B Testing page and retrieves the page title.
        /// </summary>
        /// <returns>Page title as string.</returns>
        public string GetTitle()
        {
            _driver.Navigate().GoToUrl(_baseUrl);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.TagName("h3")));

            return _driver.FindElement(By.TagName("h3")).Text;
        }

        /// <summary>
        /// Gets the description text displayed on the A/B Testing page.
        /// </summary>
        /// <returns>Page description as string.</returns>
        public string GetDescription()
        {
            _driver.Navigate().GoToUrl(_baseUrl);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("div.example p")));

            return _driver.FindElement(By.CssSelector("div.example p")).Text;
        }

        /// <summary>
        /// Disables A/B test by navigating to a variant-free page (hardcoded in this example).
        /// </summary>
        public void DisableABTest()
        {
            // There is no direct disable button on the site.
            // As an alternative, navigate to a static version of the page.
            string noABTestUrl = "https://the-internet.herokuapp.com/abtest?optout=true";
            _driver.Navigate().GoToUrl(noABTestUrl);
        }
    }
}
