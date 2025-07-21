using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuUITests
{
    [TestClass]
    public class HomePageTests
    {
        private IWebDriver driver;
        private const string baseUrl = "https://the-internet.herokuapp.com/";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TitleisOK()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var heading = driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual("Welcome to the-internet", heading);
        }

        [TestMethod]
        public void SubTitleisOK()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var subTitle = driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual("Available Examples", subTitle);
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var examples = driver.FindElements(By.CssSelector(".example a"));
            Assert.AreEqual(44, examples.Count);
        }
    }
}
