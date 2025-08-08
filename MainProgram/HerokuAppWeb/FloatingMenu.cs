/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="FloatingMenuPage.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.

 This class implements the IFloatingMenuPage interface, providing automated interactions
 and verifications for the Floating Menu feature on the Heroku test site.
 -------------------------------------------------------------------------------------------------------------------- */

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using HerokuOperations;
{
    
}

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements the Floating Menu page interactions using Selenium WebDriver.
    /// </summary>
    public class FloatingMenu : IFloatingMenu
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/floating_menu";

        // Locator for the floating menu container
        private readonly By menuLocator = By.Id("menu");

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatingMenuPage"/> class.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        public FloatingMenu(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Determines whether the specified menu item is visible.
        /// </summary>
        /// <param name="menuItem">The menu item name (e.g., "Home").</param>
        /// <returns>True if visible; otherwise, false.</returns>
        public bool IsMenuVisible(string menuItem)
        {
            try
            {
                var element = _driver.FindElement(By.XPath($"//div[@id='menu']//a[text()='{menuItem}']"));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Scrolls the page to the bottom.
        /// </summary>
        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        /// <summary>
        /// Scrolls the page to the middle of the document.
        /// </summary>
        public void ScrollToMiddle()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 2);");
        }

        /// <summary>
        /// Determines if the floating menu is still visible after scrolling.
        /// </summary>
        /// <returns>True if menu is still visible; otherwise, false.</returns>
        public bool IsFloatingMenuStillVisible()
        {
            try
            {
                var menu = _driver.FindElement(menuLocator);
                return menu.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Navigates to the Floating Menu test page.
        /// </summary>
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public string ClickMenu(string menuItem)
        {
            throw new NotImplementedException();
        }

        public string GetHeading()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetParagraphs()
        {
            throw new NotImplementedException();
        }

        public bool CanAccessMenuWithKeyboard()
        {
            throw new NotImplementedException();
        }
    }
}
