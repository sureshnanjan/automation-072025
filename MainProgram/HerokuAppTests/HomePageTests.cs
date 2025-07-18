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
            // Launch the browser and navigae to 
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
            // Arrange
            var expectedSubTitle = "Available Examples";

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));
            string actualSubTitle = subtitleElement.Text;

            // Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle);

            driver.Quit();
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            var links = driver.FindElements(By.CssSelector("#content ul li a"));
            int actualCount = links.Count;

            // Assert
            Assert.AreEqual(44, actualCount, "Expected 44 example links on the homepage.");

            driver.Quit();
        }
    }
}
