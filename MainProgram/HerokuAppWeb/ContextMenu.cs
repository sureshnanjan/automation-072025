/*
* -------------------------------------------------------------------------------------
*  Copyright (c) 2025 Sowmya Sridhar
*  All Rights Reserved.
*  
*  Permission is hereby granted to use and modify this code for personal 
*  and educational purposes only. Redistribution or commercial use without 
*  prior written consent is prohibited.
* -------------------------------------------------------------------------------------
*/

using System;
using HerokuOperations;
using OpenQA.Selenium;
using WebAutomation.Core;

namespace HerokuOperations.Implementations
{
    /// <summary>
    /// Represents the Context Menu page in the application using the Page Object Model pattern.
    /// Provides methods to interact with the right-click box and verify related UI behaviors.
    /// </summary>
    public class ContextMenuPage : IContextMenu
    {
        private readonly WebDriverWrapper _driver;

        // Locators
        private readonly ElementLocator _boxLocator = new ElementLocator(By.Id("hot-spot"), "Right-Click Box");
        private readonly ElementLocator _infoTextLocator = new ElementLocator(By.XPath("//h3"), "Information Text");

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenuPage"/> class.
        /// </summary>
        /// <param name="driver">Instance of WebDriverWrapper for interacting with the browser.</param>
        /// <exception cref="ArgumentNullException">Thrown when driver is null.</exception>
        public ContextMenuPage(WebDriverWrapper driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the Context Menu page.
        /// </summary>
        public void GoToPage()
        {
            _driver.Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");
        }

        /// <summary>
        /// Retrieves the title of the current page.
        /// </summary>
        /// <returns>The title of the browser page as a string.</returns>
        public string GetTitle()
        {
            return _driver.Driver.Title;
        }

        /// <summary>
        /// Retrieves the informational text displayed on the page.
        /// </summary>
        /// <returns>The page's header text.</returns>
        public string GetInformation()
        {
            return _driver.GetText(_infoTextLocator);
        }

        /// <summary>
        /// Performs a right-click action on the designated box element.
        /// </summary>
        public void RIghtClickOnBox()
        {
            _driver.RightClick(_boxLocator);
        }

        /// <summary>
        /// Retrieves the text from the alert displayed after a right-click.
        /// </summary>
        /// <returns>The alert message as a string.</returns>
        public string GetAlertText()
        {
            return _driver.GetAlertText();
        }

        /// <summary>
        /// Accepts and closes the currently active browser alert.
        /// </summary>
        public void AcceptAlert()
        {
            _driver.AcceptAlert();
        }
    }
}
