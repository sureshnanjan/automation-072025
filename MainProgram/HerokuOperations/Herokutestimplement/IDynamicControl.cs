// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicControlsPage.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file contains an implementation of the IDynamicControlsPage interface,
//   providing automated interaction with checkbox and input field controls
//   on the Dynamic Controls page for testing purposes.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IDynamicControlsPage interface.
    /// Handles interaction with dynamic checkbox and input field.
    /// </summary>
    public class DynamicControlsPage : IDynamicControlsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public DynamicControlsPage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickRemoveOrAddButton()
        {
            var button = driver.FindElement(By.XPath("//form[@id='checkbox-example']//button"));
            button.Click();

            wait.Until(d =>
            {
                var message = d.FindElement(By.Id("message"));
                return message.Displayed && !string.IsNullOrEmpty(message.Text);
            });
        }

        public bool IsCheckboxDisplayed()
        {
            try
            {
                return driver.FindElement(By.Id("checkbox")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetCheckboxMessage()
        {
            return driver.FindElement(By.Id("message")).Text;
        }

        public void ClickEnableOrDisableButton()
        {
            var button = driver.FindElement(By.XPath("//form[@id='input-example']//button"));
            button.Click();

            wait.Until(d =>
            {
                var input = d.FindElement(By.XPath("//form[@id='input-example']/input"));
                return input.Enabled || !input.Enabled;
            });

            wait.Until(d => d.FindElement(By.Id("message")).Displayed);
        }

        public bool IsInputEnabled()
        {
            return driver.FindElement(By.XPath("//form[@id='input-example']/input")).Enabled;
        }

        public void EnterText(string text)
        {
            var input = driver.FindElement(By.XPath("//form[@id='input-example']/input"));
            if (input.Enabled)
            {
                input.Clear();
                input.SendKeys(text);
            }
        }

        public string GetInputMessage()
        {
            return driver.FindElement(By.Id("message")).Text;
        }
    }
}
