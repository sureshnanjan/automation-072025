using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HerokuOperations
{
    /// <summary>
    /// Implements the IFloatingMenu interface for interacting with the
    /// Floating Menu page of the Heroku web application.
    /// </summary>
    internal class FloatingMenu : IFloatingMenu
    {
        private readonly IWebDriver _driver;

        // Locators
        private readonly By _menuLocator = By.Id("menu");
        private readonly By _homeLink = By.LinkText("Home");
        private readonly By _newsLink = By.LinkText("News");
        private readonly By _contactLink = By.LinkText("Contact");
        private readonly By _aboutLink = By.LinkText("About");

        public FloatingMenu(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsMenuVisible()
        {
            try
            {
                return _driver.FindElement(_menuLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickHome()
        {
            _driver.FindElement(_homeLink).Click();
        }

        public void ClickNews()
        {
            _driver.FindElement(_newsLink).Click();
        }

        public void ClickContact()
        {
            _driver.FindElement(_contactLink).Click();
        }

        public void ClickAbout()
        {
            _driver.FindElement(_aboutLink).Click();
        }

        public void ScrollToBottom()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public int GetMenuYPosition()
        {
            var menu = _driver.FindElement(_menuLocator);
            return menu.Location.Y;
        }
    }
}
