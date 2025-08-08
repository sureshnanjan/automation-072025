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
    /// Concrete implementation of the IDynamicLoading interface.
    /// Handles dynamic loading examples from the-internet.herokuapp.com.
    /// </summary>
    public class DynamicLoadingPage : IDynamicLoading
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string BaseUrl = "https://the-internet.herokuapp.com/dynamic_loading";

        public DynamicLoadingPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateToExample(int exampleNumber)
        {
            if (exampleNumber != 1 && exampleNumber != 2)
                throw new ArgumentException("Only example 1 and 2 are supported.");

            _driver.Navigate().GoToUrl($"{BaseUrl}/{exampleNumber}");
        }

        public void ClickStartButton()
        {
            IWebElement startButton = _driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();
        }

        public void WaitForLoadingToFinish()
        {
            _wait.Until(driver => !IsLoadingIndicatorVisible());
            _wait.Until(driver => driver.FindElement(By.Id("finish")).Displayed);
        }

        public string GetResultText()
        {
            IWebElement result = _driver.FindElement(By.Id("finish"));
            return result.Text;
        }

        public bool IsLoadingIndicatorVisible()
        {
            try
            {
                IWebElement
