using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace HerokuOperations
{
    public class SeleniumContextMenu : ContextMenu
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://the-internet.herokuapp.com/context_menu";

        public SeleniumContextMenu()
        {
            // Launch the Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetInformation()
        {
            return driver.FindElement(By.TagName("h3")).Text;
        }
        public void RIghtClickOnBox()
        {
            IWebElement box = driver.FindElement(OpenQA.Selenium.By.Id("hot-spot"));
            Actions actions = new Actions(driver);
            actions.ContextClick(box).Perform();
        }
        public string GetAlertText()
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert.Text!;
        }

        public void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void Close()
        {
            driver.Quit();
        }

        // public void RIghtClickOnBox()
        //{
        //throw new NotImplementedException();
        //}
    }
}
