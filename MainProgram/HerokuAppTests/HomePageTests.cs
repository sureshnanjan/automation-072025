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
            var expectedTitle = "Welcome to the-internet1";
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
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
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
