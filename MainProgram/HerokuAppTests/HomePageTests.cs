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
            var expectedTitle = "Welcome to the-internet1";
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
<<<<<<< HEAD



=======
>>>>>>> 4c83d42b69d81bf5f64327afb32b0617c28e862f
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
<<<<<<< HEAD

=======
>>>>>>> 4c83d42b69d81bf5f64327afb32b0617c28e862f
        }
    }
}
