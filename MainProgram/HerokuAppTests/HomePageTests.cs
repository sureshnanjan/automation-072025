using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace HerokuAppTests
{
    /// <summary>
    /// Contains UI tests for validating the home page of the-internet.herokuapp.com.
    /// These tests check that key page elements are present and correct.
    /// </summary>
    [TestClass]
    public sealed class HomePageTests
    {
        /// <summary>
        /// Verifies that the main title (h1 tag) on the home page matches the expected text.
        /// </summary>
        [TestMethod]
        public void TitleisOK()
        {
            var expectedTitle = "Welcome to the-internet";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            var actualTitle = driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual(expectedTitle, actualTitle);
            driver.Quit();
        }

        /// <summary>
        /// Verifies that the sub-title (h2 tag) on the home page matches the expected text.
        /// </summary>
        [TestMethod]
        public void SubTitleisOK()
        {
            var expectedSubTitle = "Available Examples";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            var actualSubTitle = driver.FindElement(By.TagName("h2")).Text;
            Assert.AreEqual(expectedSubTitle, actualSubTitle);
            driver.Quit();
        }

        /// <summary>
        /// Verifies that the home page lists exactly 44 example links in the unordered list.
        /// </summary>
        [TestMethod]
        public void ExamplesCountis44()
        {
            var expectedCount = 44;
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            var actualCount = driver.FindElements(By.CssSelector("ul li")).Count;
            Assert.AreEqual(expectedCount, actualCount);
            driver.Quit();
        }
    }
}
