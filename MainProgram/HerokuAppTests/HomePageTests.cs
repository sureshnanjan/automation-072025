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

        // Launch the browser and navigate to the URL
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

    // Launch browser using 'using' to ensure cleanup
    using (ChromeDriver driver = new ChromeDriver())
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

        // The examples are inside the <ul> under <div id="content">
        var exampleLinks = driver.FindElements(By.CssSelector("#content ul li"));

        // Act
        int actualCount = exampleLinks.Count;

        // Assert
        Assert.AreEqual(expectedCount, actualCount);
    }
        }
    }
}