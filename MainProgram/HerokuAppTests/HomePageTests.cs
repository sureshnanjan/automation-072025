using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
>>>>>>> 8773420fc6cc29e183334d2d4275828caaab1a6a
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
<<<<<<< HEAD
            ISearchContext driver = new ChromeDriver();
            driver = new FirefoxDriver();
            ((IWebDriver)driver).Navigate().GoToUrl("https://the-internet.herokuapp.com/");
=======
            // Launch the browser and navigate to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
=======
            IWebDriver driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
>>>>>>> 8773420fc6cc29e183334d2d4275828caaab1a6a
            IWebElement pageheading = driver.FindElement(By.TagName("h1"));
            NetworkManager network = new NetworkManager(driver);
            NetworkAuthenticationHandler auth = new NetworkAuthenticationHandler();
            auth.Credentials = new PasswordCredentials("admin", "admin");
            auth.UriMatcher = uri => true;
            network.AddAuthenticationHandler(auth);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/basic_auth");

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

        [TestMethod]
        public async Task NetworkAuthenticationBiDi()
        {
            // FirefoxOptions options = new FirefoxOptions();
            //options.Enable
            ChromeOptions options = new ChromeOptions();
            ChromeDriver driver = new ChromeDriver(options);
            
            try
            {
                var devTools = driver.GetDevToolsSession();
                driver.ExecuteCdpCommand("Network.enable", new Dictionary<string, object>());
                //var networkInspector = devTools.
            }
            catch (Exception)
            {

                throw;
            }
            //Command

        }
    }
}
>>>>>>> db678ac573450ce1a0523e5e90e890c6e87cc9cf
