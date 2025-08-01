
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Page object for the Slow Resources page.
    /// </summary>
    public class SlowResource : Islowresource
    {
        private readonly IWebDriver _driver;

        private readonly By _description = By.CssSelector(".example > p");

        public SlowResource(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <inheritdoc/>
        public string GetTitle()
        {
            return _driver.Title;
        }

        /// <inheritdoc/>
        public string GetDescription()
        {
            return _driver.FindElement(_description).Text;
        }
    }
}
