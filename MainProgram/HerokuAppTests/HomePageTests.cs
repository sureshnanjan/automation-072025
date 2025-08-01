using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
namespace HerokuAppTests
{
    [TestClass]
    public sealed class HomePageTests
    {
        [TestInitialize]
        public void Init() {
            // Read from app.config
            //AppContext appContext = Confi
           
        }
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
<<<<<<< HEAD
            var expectedTitle = "Welcome to the-internet";
=======
            //var expectedTitle = "Welcome to the-internet1";
>>>>>>> a41a9228532f222f252ff64a077b287a183eed45
            // Launch the browser and navigae to 
            IWebDriver driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
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

>>>>>>> 3d17e9183df2285ed5d9df27ce6b940ae8a994b3
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
=======
             // This test verifies that the number of example links on the homepage is 44

            // Arrange - expected number of list items (each example is in a <li>)
            int expectedCount = 44;

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Link is given in a list tag, so I am using tagname as "li"
            var listItems = driver.FindElements(By.TagName("li"));

            // Act - count how many list items are found
            int actualCount = listItems.Count;

            // Assert - check if the actual count matches the expected count
            Assert.AreEqual(expectedCount, actualCount);

            // Cleanup - close the browser
            driver.Quit();
>>>>>>> 3d17e9183df2285ed5d9df27ce6b940ae8a994b3
        }
<<<<<<< HEAD
        [TestMethod]
        public void TenthExampleisOK()
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

            // Launch the browser and navigate to the page
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act: Find the 10th <li> element using XPath
            IWebElement tenthElement = driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[10]/a")); // XPath is 1-based index
            var actualText = tenthElement.Text;

            // Assert
            Assert.AreEqual(expectedText, actualText);

        }

=======

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
>>>>>>> 8773420fc6cc29e183334d2d4275828caaab1a6a
    }
}
