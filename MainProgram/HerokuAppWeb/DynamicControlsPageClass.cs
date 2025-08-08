/*
* Copyright © 2025 Varun Kumar Reddy D
* All rights reserved.
*/

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implements the dynamic controls interactions including checkbox and input field operations.
    /// </summary>
    public class DynamicControlsPage : IDynamicControlsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By checkbox = By.CssSelector("#checkbox");
        private readonly By checkboxButton = By.CssSelector("#checkbox-example button");
        private readonly By checkboxMessage = By.CssSelector("#checkbox-example #message");
        private readonly By inputField = By.CssSelector("#input-example input");
        private readonly By inputButton = By.CssSelector("#input-example button");
        private readonly By inputMessage = By.CssSelector("#input-example #message");

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicControlsPage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance to use.</param>
        public DynamicControlsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // -------- Checkbox Section --------

        /// <inheritdoc/>
        public void RemoveOrAddButton()
        {
            _driver.FindElement(checkboxButton).Click();
            _wait.Until(d =>
            {
                var message = d.FindElement(checkboxMessage).Text;
                return message.Contains("gone") || message.Contains("It's back!");
            });
        }

        /// <inheritdoc/>
        public bool IsCheckboxDisplayed()
        {
            try
            {
                return _driver.FindElement(checkbox).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public string GetCheckboxMessage()
        {
            return _wait.Until(d => d.FindElement(checkboxMessage)).Text;
        }

        // -------- Input Field Section --------

        /// <inheritdoc/>
        public void EnableOrDisableButton()
        {
            _driver.FindElement(inputButton).Click();
            _wait.Until(d =>
            {
                var input = d.FindElement(inputField);
                return input.Enabled;
            });
        }

        /// <inheritdoc/>
        public bool IsInputEnabled()
        {
            return _driver.FindElement(inputField).Enabled;
        }

        /// <inheritdoc/>
        public void EnterText(string text)
        {
            var input = _driver.FindElement(inputField);
            if (!input.Enabled)
            {
                throw new InvalidOperationException("Input field is disabled.");
            }
            input.Clear();
            input.SendKeys(text);
        }

        /// <inheritdoc/>
        public string GetInputMessage()
        {
            return _wait.Until(d => d.FindElement(inputMessage)).Text;
        }
    }
}
