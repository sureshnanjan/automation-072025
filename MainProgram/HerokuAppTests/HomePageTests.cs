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
            // Launch the browser and navigae to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            IWebElement pageheading = driver.FindElement(By.TagName("h2"));
            // 
            // Act
            var actualSubTitle = pageheading.Text;
            // Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle);
        }

        [TestMethod]
        public void ExamplesCountis44()
        {

            // Arrange
            int expectedCount = 44;
            // Launch the browser and navigae to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            IWebElement pageheading = driver.FindElement(By.Id("content"));
            // 
            // Act
            var actualCount = pageheading.FindElements(By.TagName("li")).Count;
            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TenthExampleisOKbyCollection()
        {
            // Arrange
            var expectedText = "Drag and Drop";
            // Launch the browser and navigae to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            IWebElement pageheading = driver.FindElement(By.Id("content"));
            // 
            // Act
            var actualText = pageheading.FindElements(By.TagName("li"))[9].Text;
            // Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void TenthExampleisOK_UsingXPath()
        {
            // Arrange
            var expectedText = "Drag and Drop";

            // Launch the browser and navigate to the website
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // XPath to select the 10th list item under the list of links
            // That <ul> is inside a <div id='content'>
            IWebElement tenthElement = driver.FindElement(By.XPath("//div[@id='content']//ul/li[10]"));
            string actualText = tenthElement.Text;

            // Assert
            Assert.AreEqual(expectedText, actualText);

          
        }

    }
}