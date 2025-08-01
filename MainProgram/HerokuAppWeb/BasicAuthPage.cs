using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IBasicAuthPage interface for automating
    /// Basic Authentication page on https://the-internet.herokuapp.com/basic_auth
    /// </summary>
    public class BasicAuthPage : IBasicAuth
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://the-internet.herokuapp.com/basic_auth";

        /// <summary>
        /// Constructor to initialize WebDriver instance.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        public BasicAuthPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the Basic Auth page using the provided credentials.
        /// </summary>
        /// <param name="username">Username for login.</param>
        /// <param name="password">Password for login.</param>
        public void NavigateToPage(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password cannot be empty.");

            // Combine credentials with the base URL
            var uri = new Uri(_baseUrl);
            string authUrl = $"https://{username}:{password}@{uri.Host}{uri.AbsolutePath}";
            _driver.Navigate().GoToUrl(authUrl);
        }

        /// <summary>
        /// Gets the page title after successful login.
        /// </summary>
        /// <returns>Page title as string.</returns>
        public string GetPageTitle()
        {
            // Wait for page to load and title to be available
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => !string.IsNullOrEmpty(d.Title));
            return _driver.Title;
        }

        /// <summary>
        /// Gets the description text on the page after login.
        /// </summary>
        /// <returns>Page description as string.</returns>
        public string GetPageDescription()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                var descriptionElement = wait.Until(d => d.FindElement(By.CssSelector("div.example p")));
                return descriptionElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                return "Description not found";
            }
        }
    }
}
