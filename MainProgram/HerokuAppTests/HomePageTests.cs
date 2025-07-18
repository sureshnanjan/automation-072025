using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            var expectedSubtitle = "Available Examples";
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));
            var actualSubtitle = subtitleElement.Text;

            // Assert
            Assert.AreEqual(expectedSubtitle, actualSubtitle);
        }


        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Optional: wait for the list to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("ul li")).Count > 0);

            // Act
            IList<IWebElement> items = driver.FindElements(By.CssSelector("ul li"));
            int count = items.Count;

            // Assert
            Assert.AreEqual(44, count);

            // Cleanup
            driver.Quit();
        }

    }
}
