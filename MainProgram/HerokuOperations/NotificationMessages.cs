using OpenQA.Selenium;

namespace HerokuOperations
{
    /// <summary>
    /// Implements the INotificationMessages interface for interacting with
    /// the Notification Messages page of the Heroku web application.
    /// </summary>
    public class NotificationMessages : INotificationMessages
    {
        private readonly IWebDriver _driver;

        // Locators
        private readonly By _messageLocator = By.Id("flash"); // Notification banner
        private readonly By _headingLocator = By.TagName("h3"); // Static page heading
        private readonly By _clickHereLinkLocator = By.LinkText("Click here"); // Link to load message

        public NotificationMessages(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetNotificationMessage()
        {
            try
            {
                return _driver.FindElement(_messageLocator).Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        public string GetHeading()
        {
            return _driver.FindElement(_headingLocator).Text.Trim();
        }

        public void ClickLoadNewMessageLink()
        {
            _driver.FindElement(_clickHereLinkLocator).Click();
        }

        public string GetLinkHref()
        {
            return _driver.FindElement(_clickHereLinkLocator).GetAttribute("href");
        }
    }
}
