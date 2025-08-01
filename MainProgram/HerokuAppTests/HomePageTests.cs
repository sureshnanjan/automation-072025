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
            //var expectedTitle = "Welcome to the-internet1";
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
            var listItems = driver.FindElements(By.TagName("li"));

            // Act - count how many list items are found
            int actualCount = listItems.Count;

            // Assert - check if the actual count matches the expected count
            Assert.AreEqual(expectedCount, actualCount);

            // Cleanup - close the browser
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
