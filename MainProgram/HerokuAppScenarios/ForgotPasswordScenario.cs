using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb; 
namespace HerokuAppScenarios
{
    [TestFixture]
    public class ForgotPasswordTests
    {
        private IWebDriver _driver;
        private IForgotPassword _forgotPasswordPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/forgot_password");

            // Assuming you have a class called ForgotPasswordPage that implements IForgotPassword
            _forgotPasswordPage = new ForgotPassword(_driver);
        }

        [Test]
        public void ForgotPasswordPage_Title_IsCorrect()
        {
            // Arrange
            string expectedTitle = "Forgot Password";

            // Act
            string actualTitle = _forgotPasswordPage.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match.");
        }

        [Test]
        public void ForgotPasswordPage_CanEnterEmail()
        {
            // Arrange
            string email = "example@test.com";

            // Act
            _forgotPasswordPage.EnterEmail(email);

            // There is no return value; test passes if no exceptions occur
            Assert.Pass("Email entered successfully.");
        }

        [Test]
        public void ForgotPasswordPage_CanClickRetrieveButton()
        {
            // Act
            _forgotPasswordPage.ClickRetrievePassword();

            // If no exception thrown, assume success
            Assert.Pass("Retrieve Password button clicked successfully.");
        }

        [Test]
        public void ForgotPasswordPage_ShowsConfirmationMessage()
        {
            // Arrange
            string email = "example@test.com";
            _forgotPasswordPage.EnterEmail(email);
            _forgotPasswordPage.ClickRetrievePassword();

            // Act
            string confirmationMessage = _forgotPasswordPage.GetConfirmationMessage();

            // Assert
            Assert.IsNotNull(confirmationMessage);
            Assert.IsTrue(confirmationMessage.Contains("Your e-mail's been sent!"), "Confirmation message not as expected.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
