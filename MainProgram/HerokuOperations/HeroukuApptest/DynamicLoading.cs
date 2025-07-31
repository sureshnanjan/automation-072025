using OpenQA.Selenium;
using System;

namespace HerokuOperations
{
    public class DynamicLoading : IDynamicLoading
    {
        private readonly IWebDriver _driver;

        public DynamicLoading(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public void NavigateToExample(int exampleNumber)
        {
            if (exampleNumber < 1 || exampleNumber > 2)
                throw new ArgumentOutOfRangeException(nameof(exampleNumber), "Example number must be 1 or 2.");

            _driver.Navigate().GoToUrl($"https://the-internet.herokuapp.com/dynamic_loading/{exampleNumber}");
        }

        public void ClickStartButton()
        {
            var startButton = _driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();
        }

        public void WaitForLoadingToFinish()
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                var loadingElement = driver.FindElement(By.Id("loading"));
                return !loadingElement.Displayed;
            });
        }

        public string GetResultText()
        {
            var resultElement = _driver.FindElement(By.Id("finish"));
            return resultElement.Text;
        }

        public bool IsLoadingIndicatorVisible()
        {
            try
            {
                var loadingElement = _driver.FindElement(By.Id("loading"));
                return loadingElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
