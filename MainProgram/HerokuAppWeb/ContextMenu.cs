using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace HerokuOperations
{
    public class ContextMenuPage : IContextMenu
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/context_menu";

        // Locators
        private readonly By _titleLocator = By.TagName("h3");
        private readonly By _infoTextLocator = By.CssSelector(".example p");
        private readonly By _boxLocator = By.Id("hot-spot");

        public ContextMenuPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public string GetTitle()
        {
            return _driver.FindElement(_titleLocator).Text;
        }

        public string GetInformation()
        {
            return _driver.FindElement(_infoTextLocator).Text;
        }

        public void RIghtClickOnBox()
        {
            IWebElement box = _driver.FindElement(_boxLocator);
            Actions actions = new Actions(_driver);
            actions.ContextClick(box).Perform(); // Right-click
        }

        public string GetAlertText()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            return alert.Text;
        }

        public void AcceptAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
