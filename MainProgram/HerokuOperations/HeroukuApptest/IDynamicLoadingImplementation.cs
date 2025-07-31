using OpenQA.Selenium;

namespace HerokuOperations
{
    public class DynamicLoading : IDynamicLoading
    {
        private readonly IWebDriver _driver;

        public DynamicLoading(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToExample(int exampleNumber)
        {
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
            wait.Until(driver => driver.FindElement(By.Id("finish")).Displayed);
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
                var loadingIndicator = _driver.FindElement(By.Id("loading"));
                return loadingIndicator.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
// Update the instantiation in the test class to use the concrete implementation
loader = new DynamicLoading(driver);
