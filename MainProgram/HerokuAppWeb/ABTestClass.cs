using HerokuOperations.PageInterface;
using OpenQA.Selenium;

namespace HerokuOperations.PageObjects
{
    public class ABTestPage : IABTest
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/abtest";

        public ABTestPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            var titleElement = _driver.FindElement(By.CssSelector("div.example h3"));
            return titleElement.Text;
        }

        public string GetDescription()
        {
            var descElement = _driver.FindElement(By.CssSelector("div.example p"));
            return descElement.Text;
        }
    }
}
