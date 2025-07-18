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
            //Arrange
            var expectedSubTitle = "Available Examples";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            //Find the subtitle with head tag element <h2>
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));

            //Act
            var actualSubTitle = subtitleElement.Text;

            //Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle);

        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var expectedCount = 44;
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // All the example links are inside <ul> with many <li> elements
            var exampleItems = driver.FindElements(By.CssSelector("ul li"));
            var actualCount = exampleItems.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);

            // Cleanup
            //driver.Quit();
        }
    }
}