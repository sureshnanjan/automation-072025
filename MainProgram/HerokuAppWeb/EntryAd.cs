/*******************************************************
* Copyright (c) 2025, Arpita Neogi
* All rights reserved.
* 
* File: EntryAdPage.cs
* Purpose: Implements IEntryAd interface to interact with
*          the Entry Ad modal using Selenium WebDriver.
*******************************************************/
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IEntryAd interface for handling
    /// the Entry Ad modal interactions on the test page.
    /// </summary>
    public class EntryAdPage : IEntryAd
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Locators
        private readonly By modalLocator = By.Id("modal");
        private readonly By modalTitleLocator = By.CssSelector("#modal .modal-title h3");
        private readonly By modalContentLocator = By.CssSelector("#modal .modal-body p");
        private readonly By closeModalButton = By.CssSelector("#modal .modal-footer p");
        private readonly By reEnableLink = By.LinkText("click here");

        /// <summary>
        /// Constructor to initialize WebDriver and WebDriverWait.
        /// </summary>
        public EntryAdPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <inheritdoc/>
        public bool IsModalVisible()
        {
            try
            {
                return _driver.FindElement(modalLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void CloseModal()
        {
            if (IsModalVisible())
            {
                _driver.FindElement(closeModalButton).Click();
                _wait.Until(d => !IsModalVisible());
            }
        }

        /// <inheritdoc/>
        public void ReEnableModal()
        {
            _driver.FindElement(reEnableLink).Click();
        }

        /// <inheritdoc/>
        public string GetModalTitle()
        {
            return IsModalVisible()
                ? _driver.FindElement(modalTitleLocator).Text.Trim()
                : string.Empty;
        }

        /// <inheritdoc/>
        public string GetModalContent()
        {
            return IsModalVisible()
                ? _driver.FindElement(modalContentLocator).Text.Trim()
                : string.Empty;
        }

        /// <inheritdoc/>
        public bool ShouldModalAppearOnLoad()
        {
            return IsModalVisible();
        }
    }
}
