using OpenQA.Selenium;
using System;
using System.Linq;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IRedirect for automating redirect verification using Selenium.
    /// </summary>
    public class RedirectPage : IRedirect
    {
        private readonly IWebDriver _driver;

        private readonly string _baseUrl = "https://the-internet.herokuapp.com/redirector";
        private readonly By headingLocator = By.TagName("h3");
        private readonly By paragraphLocator = By.TagName("p");
        private readonly By clickHereLink = By.LinkText("here");
        private readonly By statusCodeLinks = By.CssSelector(".example a");

        public RedirectPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        public string GetTitle()
        {
            return _driver.FindElement(headingLocator).Text;
        }

        public string GetParagraphText()
        {
            return _driver.FindElement(paragraphLocator).Text;
        }

        public void ClickhereLink()
        {
            _driver.FindElement(clickHereLink).Click();
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public string GetStatusPageTitle()
        {
            return _driver.FindElement(headingLocator).Text;
        }

        public string GetStatusPageContent()
        {
            return _driver.FindElement(paragraphLocator).Text;
        }

        public void ClickStatusCodeLink(string statusCode)
        {
            var links = _driver.FindElements(statusCodeLinks);
            var codeLink = links.FirstOrDefault(a => a.Text.Trim() == statusCode);

            if (codeLink == null)
                throw new NoSuchElementException($"Status code link '{statusCode}' not found.");

            codeLink.Click();
        }
    }
}
