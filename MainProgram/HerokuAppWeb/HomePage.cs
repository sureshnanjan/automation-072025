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
<<<<<<< HEAD
            this.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
=======
            try
            {
                this.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            }
            catch (ArgumentNullException ex)
            {

                throw;
            }
            
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
        }

        public string[] getAvailableExamples()
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======

            this.driver.FindElements(exampleLocator);
            return new string[]{"","" };
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
        }

        public string GetRepoUrl()
        {
           return this.driver.FindElement(this.repoLocator).GetAttribute("alt");
        }

        public string GetSubTitle()
        {
<<<<<<< HEAD
            return this.driver.FindElement(this.subtitleLocator).Text;
=======
            try
            {
                return this.driver.FindElement(this.subtitleLocator).Text;

            }
            catch (ArgumentNullException)
            {

                throw;
            }
            catch (NoSuchElementException elemnotfound) {
                throw;
            }
            
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
        }

        public string GetTitle()
        {
<<<<<<< HEAD
=======
            Console.WriteLine($"Fetching the Title from {this.driver.Title}");
            Console.WriteLine($"Using the locator {titlelocator}");
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
            return this.driver.FindElement(this.titlelocator).Text;
        }

        public void GoToExample(string exampleName)
        {
            this.driver.FindElement(By.LinkText(exampleName)).Click();
        }
    }
}
