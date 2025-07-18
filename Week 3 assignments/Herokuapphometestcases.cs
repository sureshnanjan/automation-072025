using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerokuAppTests
{
    /// <summary>
    /// Contains UI tests for validating key elements on the Heroku demo web application's home page.
    /// </summary>
    [TestClass]
    public sealed class HomePageTests
    {
        /// <summary>
        /// Verifies that the main page title (<h1>) matches the expected value.
        /// </summary>
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet";

            // Launch browser and navigate to the home page
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Find the heading element
            IWebElement pageheading = driver.FindElement(By.TagName("h1"));

            // Act
            var actualTitle = pageheading.Text;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        /// <summary>
        /// Verifies that the subtitle (<h2>) on the home page is "Available Examples".
        /// </summary>
        [TestMethod]
        public void SubTitleisOK()
        {
            // Arrange
            var expectedSubTitle = "Available Examples";

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Find the subtitle using the <h2> tag
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));

            // Act
            var actualSubTitle = subtitleElement.Text;

            // Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle);
        }

        /// <summary>
        /// Verifies that the number of example links listed on the page is exactly 44.
        /// </summary>
        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var expectedCount = 44;

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // Example links are within <ul> as <li> elements
            var exampleItems = driver.FindElements(By.CssSelector("ul li"));
            var actualCount = exampleItems.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
