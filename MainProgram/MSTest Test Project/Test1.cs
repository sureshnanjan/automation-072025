using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerokuAppTests
{
    [TestClass]
    public sealed class HomePageTests
    {
        [TestMethod]
        public void TitleisOK()
        {
            var expectedTitle = "Welcome to the-internet";
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
                IWebElement heading = driver.FindElement(By.TagName("h1"));
                string actualTitle = heading.Text;
                Assert.AreEqual(expectedTitle, actualTitle);
            }
        }

        [TestMethod]
        public void SubTitleisOK()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
                IWebElement subtitle = driver.FindElement(By.TagName("h2"));
                string actualSubtitle = subtitle.Text;
                Assert.AreEqual("Available Examples", subtitle.Text);
            }
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
                var links = driver.FindElements(By.CssSelector("ul > li > a"));
                Assert.AreEqual(44, links.Count);
            }
        }
    }
}
