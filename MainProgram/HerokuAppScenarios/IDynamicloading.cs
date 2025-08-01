// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicLoading.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file implements the IDynamicLoading interface to handle operations such as navigation,
//   start interaction, and dynamic content verification on the Dynamic Loading examples page.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Handles operations for dynamic loading examples on the-internet.herokuapp.com.
    /// Implements IDynamicLoading interface.
    /// </summary>
    public class DynamicLoading : IDynamicLoading
    {
        private readonly IWebDriver driver;
        private WebDriverWait wait;

        public DynamicLoading(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void NavigateToExample(int exampleNumber)
        {
            if (exampleNumber != 1 && exampleNumber != 2)
                throw new ArgumentException("Only example 1 and 2 are supported.");

            string url = $"https://the-internet.herokuapp.com/dynamic_loading/{exampleNumber}";
            driver.Navigate().GoToUrl(url);
        }

        public void ClickStartButton()
        {
            var startButton = driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();
        }

        public void WaitForLoadingToFinish()
        {
            wait.Until(d =>
            {
                try
                {
                    var result = d.FindElement(By.Id("finish"));
                    return result.Displayed && !string.IsNullOrWhiteSpace(result.Text);
                }
                catch
                {
                    return false;
                }
            });
        }

        public string GetResultText()
        {
            return driver.FindElement(By.Id("finish")).Text;
        }

        public bool IsLoadingIndicatorVisible()
        {
            try
            {
                var spinner = driver.FindElement(By.Id("loading"));
                return spinner.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
