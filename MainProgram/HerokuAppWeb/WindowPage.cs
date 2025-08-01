using HerokuOperations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HerokuAppWeb
{
    public class WindowPage : IWindowPage
    {
        private ChromeDriver driver;                // Chrome WebDriver instance
        private string url;                         // URL of the test page
        private string mainWindowHandle;            // To store the original window handle
        private By clickHereLinkLocator;            // Locator for the "Click Here" link
        private By headerLocator;                   // Locator for header text

        public WindowPage()
        {
            // Initialize WebDriver and open the page
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();

            this.url = "https://the-internet.herokuapp.com/windows";
            this.driver.Navigate().GoToUrl(this.url);

            // Define element locators
            this.clickHereLinkLocator = By.LinkText("Click Here");
            this.headerLocator = By.TagName("h3");

            // Save the handle of the main/original window
            this.mainWindowHandle = driver.CurrentWindowHandle;
        }

        // Navigates to the main page again (if needed)
        public void GotoPage()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        // Gets the title text from the main window
        public string GetTitle()
        {
            return this.driver.FindElement(this.headerLocator).Text;
        }

        // Clicks on the "Click Here" link to open a new window
        public void ClickHereLink()
        {
            this.driver.FindElement(this.clickHereLinkLocator).Click();
            Thread.Sleep(1000); // Allow time for window to open
        }

        // Switches control to the newly opened window
        public void SwitchToNewWindow()
        {
            foreach (string handle in this.driver.WindowHandles)
            {
                if (handle != this.mainWindowHandle)
                {
                    this.driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        // Switches control back to the original/main window
        public void SwitchToMainWindow()
        {
            this.driver.SwitchTo().Window(this.mainWindowHandle);
        }

        // Gets the text from the new window
        public string GetNewWindowText()
        {
            return this.driver.FindElement(this.headerLocator).Text;
        }

        // Optional: Close all browser windows and cleanup
        public void Close()
        {
            this.driver.Quit();
        }
    }
}
