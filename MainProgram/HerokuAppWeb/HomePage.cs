using HerokuOperations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace HerokuAppWeb
{
    public class HomePage : IHomePage
    {
        private By titlelocator;
        private By subtitleLocator;
        private By exampleLocator;
        private By repoLocator;
        private IWebDriver driver;

        public HomePage()
        {
            this.driver = new ChromeDriver();
            this.repoLocator = By.XPath("/html/body/div[2]/a/img");
            this.titlelocator = By.TagName("h1");
            this.subtitleLocator = By.TagName("h2");
            this.exampleLocator = By.TagName("li");
            this.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }

        public string[] getAvailableExamples()
        {
            throw new NotImplementedException();
        }

        public string GetRepoUrl()
        {
            return this.driver.FindElement(this.repoLocator).GetAttribute("alt");
        }

        public string GetSubTitle()
        {
            return this.driver.FindElement(this.subtitleLocator).Text;
        }

        public string GetTitle()
        {
            return this.driver.FindElement(this.titlelocator).Text;
        }

        public void GoToExample(string exampleName)
        {
            this.driver.FindElement(By.LinkText(exampleName)).Click();
        }
    }
}