using OpenQA.Selenium;

namespace HerokuOperations
{
    public class ABTestImplementation : IABTest
    {
        private readonly IWebDriver _driver;

        public ABTestImplementation(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        public string GetDescription()
        {
            return _driver.FindElement(By.ClassName("example")).Text;
        }

        public void DisableABTest()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/abtest?show=no");
        }
    }
}
