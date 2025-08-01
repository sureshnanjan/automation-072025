using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    public class FormAuthenticationScenarios
    {
        private IWebDriver _driver;
        private IFormAuthentication _formAuth;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _formAuth = new FormAuthenticationImplementation(_driver);
            _formAuth.GoToPage();
        }  

        [Test]
        public void LoginPage_Should_Display_Title_And_Description()
        {
            string title = _formAuth.GetTitle();
            string description = _formAuth.GetDescription();

            Assert.AreEqual("Login Page", title);
            Assert.IsTrue(description.Contains("Enter tomsmith for the username"));
        }

        [Test]
        public void Login_Should_Succeed_With_Valid_Credentials()
        {
            _formAuth.EnterUserName("tomsmith");
            _formAuth.EnterPassWord("SuperSecretPassword!");
            _formAuth.ClickLogin();

            Assert.IsTrue(_formAuth.IsLoginSuccessful(), "Expected successful login with valid credentials.");
        }

        [Test]
        public void Login_Should_Fail_With_Invalid_Credentials()
        {
            _formAuth.EnterUserName("wronguser");
            _formAuth.EnterPassWord("wrongpass");
            _formAuth.ClickLogin();

            string error = _formAuth.GetErrorMessage();
            Assert.IsTrue(error.Contains("Your username is invalid!") || error.Contains("Your password is invalid!"));
        }

        [Test]
        public void Logout_Should_Redirect_To_Login_Page()
        {
            _formAuth.EnterUserName("tomsmith");
            _formAuth.EnterPassWord("SuperSecretPassword!");
            _formAuth.ClickLogin();

            Assert.IsTrue(_formAuth.IsLoginSuccessful());

            _formAuth.ClickLogout();

            string title = _formAuth.GetTitle();
            Assert.AreEqual("Login Page", title, "After logout, user should be redirected to login page.");
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose(); // This explicitly disposes the driver and avoids warnings
            }
        }

    }
}
