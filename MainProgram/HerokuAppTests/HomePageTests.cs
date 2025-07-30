using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
<<<<<<< HEAD
using OpenQA.Selenium.Firefox;
=======
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
namespace HerokuAppTests
{
    [TestClass]
    public sealed class HomePageTests
    {
<<<<<<< HEAD
        [TestInitialize]
        public void Init() {
            // Read from app.config
            //AppContext appContext = Confi
           
        }
=======
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet";
<<<<<<< HEAD
            // Launch the browser and navigae to 
            ISearchContext driver = new ChromeDriver();
            driver = new FirefoxDriver();
            ((IWebDriver)driver).Navigate().GoToUrl("https://the-internet.herokuapp.com/");
=======
            // Launch the browser and navigate to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
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
<<<<<<< HEAD
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
=======
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
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
<<<<<<< HEAD

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
=======
            // Arrange
            var expectedCount = 44;
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
<<<<<<< HEAD
            // XPath to select the 10th list item under the list of links
            // That <ul> is inside a <div id='content'>
            IWebElement tenthElement = driver.FindElement(By.XPath("//div[@id='content']//ul/li[10]"));
            string actualText = tenthElement.Text;

            // Assert
            Assert.AreEqual(expectedText, actualText);

          
        }

    }
}
=======
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
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
