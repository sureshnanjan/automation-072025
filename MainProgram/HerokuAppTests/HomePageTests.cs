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
            var expectedTitle = "Welcome to the-internet";
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
<<<<<<< HEAD
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

=======
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