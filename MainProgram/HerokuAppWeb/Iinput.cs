using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace HerokuOperations
{
    /// <summary>
    /// Implements the IInputPage interface for automating the Inputs page
    /// on HerokuApp. Supports typing numbers and using arrow keys.
    /// </summary>
    public class InputPage : IInputPage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        /// <summary>
        /// URL of the Inputs test page.
        /// </summary>
        private const string PageUrl = "https://the-internet.herokuapp.com/inputs";

        /// <summary>
        /// Locator for the numeric input element.
        /// </summary>
        private readonly By inputLocator = By.TagName("input");

        /// <summary>
        /// Constructor to initialize the WebDriver and Actions.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance.</param>
        public InputPage(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new Actions(driver);
        }

        /// <inheritdoc />
        public void GotoPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        /// <inheritdoc />
        public void EnterNumber(string number)
        {
            var input = driver.FindElement(inputLocator);
            input.Clear();
            input.SendKeys(number);
        }

        /// <inheritdoc />
        public void IncreaseValue(int steps)
        {
            var input = driver.FindElement(inputLocator);
            input.Click();
            for (int i = 0; i < steps; i++)
            {
                actions.SendKeys(Keys.ArrowUp).Perform();
                Thread.Sleep(50); // Optional delay for stability
            }
        }

        /// <inheritdoc />
        public void DecreaseValue(int steps)
        {
            var input = driver.FindElement(inputLocator);
            input.Click();
            for (int i = 0; i < steps; i++)
            {
                actions.SendKeys(Keys.ArrowDown).Perform();
                Thread.Sleep(50); // Optional delay for stability
            }
        }

        /// <inheritdoc />
        public string GetInputValue()
        {
            return driver.FindElement(inputLocator).GetAttribute("value");
        }
    }
}
