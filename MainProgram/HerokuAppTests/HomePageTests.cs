using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace HerokuAppTests
{
    [TestClass]
    public sealed class HomePageTests
    {
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet";
            // Launch the browser and navigate to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            IWebElement pageheading = driver.FindElement(By.TagName("h1"));
            // 
            // Act
            var actualTitle = pageheading.Text;
            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }
        [TestMethod]
        public void SubTitleisOK()
        {
            var expectedSubTitle = "Available Examples";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            // Find the subtitle element (h2)
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));

            // Act
            var actualSubTitle = subtitleElement.Text;

            // Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle);

            // Cleanup
            driver.Quit();
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var expectedCount = 44;
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // Find all example links under the unordered list
            var exampleLinks = driver.FindElements(By.CssSelector("#content ul li a"));

            var actualCount = exampleLinks.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} examples, but found {actualCount}.");

            // Cleanup
            driver.Quit();
        }
    }
}
