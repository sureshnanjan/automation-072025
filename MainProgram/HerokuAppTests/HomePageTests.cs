using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;

namespace HerokuAppTests
{
    // This class contains automated UI tests for the homepage of the-internet.herokuapp.com
    [TestClass]
    public sealed class HomePageTests
    {
        [TestInitialize]


        public void Init()
        {

        }

        [TestMethod]
        public void TitleisOK()
        {
            // This test verifies that the main heading (h1) on the homepage is "Welcome to the-internet"

            var expectedTitle = "Welcome to the-internet";

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Locate the main heading element (h1)

        public void Init() {
            // Read from app.config
            //AppContext appContext = Confi
           
        }
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet1";
            // Launch the browser and navigae to 
            ISearchContext driver = new ChromeDriver();
            driver = new FirefoxDriver();
            ((IWebDriver)driver).Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            IWebElement pageheading = driver.FindElement(By.TagName("h1"));

            // Act - get the actual heading text
            var actualTitle = pageheading.Text;

            // Assert - check if the actual heading matches the expected heading
            Assert.AreEqual(expectedTitle, actualTitle);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void SubTitleisOK()
        {
            // This test verifies that the subtitle (h2) on the homepage is "Available Examples"

            // Arrange - expected subtitle
            var expectedSubTitle = "Available Examples";

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Locate the subtitle element in a "h2"
            IWebElement pageheading = driver.FindElement(By.TagName("h2"));

            // Act - get the actual subtitle text
            var actualSubTitle = pageheading.Text;

            // Assert - check if the actual subtitle matches the expected subtitle
            Assert.AreEqual(expectedSubTitle, actualSubTitle);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            // This test verifies that the number of example links on the homepage is 44

            // Arrange - expected number of list items (each example is in a <li>)
            int expectedCount = 44;

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Link is given in a list tag, so I am using tagname as "li"
            var listItems = driver.FindElements
                
                    (By.TagName("li"));

            // Act - count how many list items are found
            int actualCount = listItems.Count;

            // Assert - check if the actual count matches the expected count
            Assert.AreEqual(expectedCount, actualCount);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void TenthExampleisOkUsingID()
        {
            // Arrange
            var expectedText = "Drag and Drop";

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            var content = driver.FindElement(By.Id("content"));  // Find parent by ID
            var links = content.FindElements(By.TagName("a"));   // Get all <a> tags inside
            var actualText = links[9].Text;  // 10th link (index 9)

            // Assert
            Assert.AreEqual(expectedText, actualText);

            // Cleanup
            driver.Quit();
        }


        [TestMethod]

        public void TenthExampleIsOkUsingXPATH()
        {
            var expectedText = "Drag and Drop";

            // Arrange
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // Use XPath to get the 10th <a> tag inside the <ul> list
            var actualText = driver.FindElement(By.XPath("(//ul/li/a)[10]")).Text;

            // Assert
            Assert.AreEqual(expectedText, actualText);

            // Cleanup
            driver.Quit();
        }
    }
}
