using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HerokuAppTests
{
    /// <summary>
    /// Contains automated UI tests for verifying key elements of the HerokuApp homepage.
    /// Follows the Arrange-Act-Assert pattern for each test case.
    /// </summary>
    [TestClass]
    public sealed class HomePageTests
    {
        /// <summary>
        /// Test to verify that the main title of the homepage is correct.
        /// 
        /// Arrange: Set the expected title and open the browser to the HerokuApp homepage.
        /// Act: Retrieve the text of the main heading (h1).
        /// Assert: Check that the actual heading matches the expected title.
        /// </summary>
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

        /// <summary>
        /// Test to verify that the subtitle under the main title is correct.
        /// 
        /// Arrange: Set the expected subtitle and open the HerokuApp homepage.
        /// Act: Locate the subtitle element (h2) and retrieve its text.
        /// Assert: Ensure the actual text matches the expected subtitle.
        /// </summary>
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

        /// <summary>
        /// Test to verify that the homepage displays exactly 44 example links.
        /// 
        /// Arrange: Open the HerokuApp homepage.
        /// Act: Wait for and count all <li> elements under the <ul> list of examples.
        /// Assert: Confirm that the count equals 44.
        /// </summary>
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
        
        [TestMethod]
        public void TenthItemIsDragAndDrop()
        {
            // Arrange
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Optional: wait until the list items are loaded
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("ul li")).Count >= 10);

            // Act
            IList<IWebElement> items = driver.FindElements(By.CssSelector("ul li"));
            string tenthItemText = items[9].Text; // Index 9 = 10th element (0-based index)

            // Assert
            Assert.AreEqual("Drag and Drop", tenthItemText);

            // Cleanup
            driver.Quit();
        }

    }
}
