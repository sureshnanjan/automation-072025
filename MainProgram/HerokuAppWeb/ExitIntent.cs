/*******************************************************
* Copyright (c) 2025, Arpita Neogi
* All rights reserved.
* 
* File: ExitIntentPage.cs
* Purpose: Implements IExitIntent interface for interacting
*          with the Exit Intent modal using Selenium WebDriver.
*******************************************************/
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IExitIntent interface for automating
    /// the Exit Intent popup modal interactions.
    /// </summary>
    public class ExitIntentPage : IExitIntent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _actions;

        // Locators
        private readonly By modalLocator = By.Id("ouibounce-modal");
        private readonly By modalContentLocator = By.CssSelector("#ouibounce-modal .modal-body p");
        private readonly By closeModalButton = By.CssSelector("#ouibounce-modal .modal-footer p");

        /// <summary>
        /// Constructor to initialize WebDriver, Wait, and Actions.
        /// </summary>
        public ExitIntentPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _actions = new Actions(_driver);
        }

        /// <inheritdoc/>
        public void TriggerExitIntent()
        {
            // Move mouse pointer outside the top boundary to trigger exit intent
            _actions.MoveByOffset(0, -200).Perform();
            _wait.Until(d => IsModalDisplayed());
        }

        /// <inheritdoc/>
        public bool IsModalDisplayed()
        {
            try
            {
                var modal = _driver.FindElement(modalLocator);
                return modal.Displayed && modal.GetCssValue("display") != "none";
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void CloseModal()
        {
            if (IsModalDisplayed())
            {
                _driver.FindElement(closeModalButton).Click();
                _wait.Until(d => !IsModalDisplayed());
            }
        }

        /// <inheritdoc/>
        public string GetModalContent()
        {
            return IsModalDisplayed()
                ? _driver.FindElement(modalContentLocator).Text.Trim()
                : string.Empty;
        }

        /// <inheritdoc/>
        public bool VerifyModalAppearsAfterPageLoad()
        {
            // Modal should not be visible immediately on page load
            bool initiallyVisible = IsModalDisplayed();

            // Trigger exit and verify
            TriggerExitIntent();
            bool visibleAfterTrigger = IsModalDisplayed();

            return !initiallyVisible && visibleAfterTrigger;
        }

        /// <inheritdoc/>
        public bool VerifyExitDirection(string exitDirection)
        {
            if (exitDirection.Equals("top", StringComparison.OrdinalIgnoreCase))
            {
                TriggerExitIntent();
                return IsModalDisplayed();
            }
            else
            {
                // Move mouse sideways to ensure modal does not appear
                _actions.MoveByOffset(400, 0).Perform();
                return IsModalDisplayed() == false;
            }
        }
    }
}
