/*
* ------------------------------------------------------------------------------
* © 2025 Sowmya Sridhar. All rights reserved.
* This test file is part of the HerokuApp automated test suite.
* For internal, educational, or evaluation purposes only.
* ------------------------------------------------------------------------------
*/

using NUnit.Framework;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    /// <summary>     
    /// Test Design Techniques Used:
    /// - Black Box Testing: Verifies functionality from a user perspective.
    /// - Equivalence Partitioning: Valid and invalid credential sets.
    /// - Modular Testing: Each UI element and behavior is verified independently.
    /// </summary>
    public class FormAuthenticationPageTests
    {
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Verifies the title of the login page.
        /// </summary>
        [Test]
        public void LoginPage_Title_IsCorrect()
        {
            // Arrange
            string expected = "Login Page";
            IFormAuthentication formPage = new FormAuthentication();

            // Act
            string actual = formPage.GetTitle();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void LoginPage_Description_IsCorrect()
        {
            // Arrange
            string expected = "This is where you can log into the secure area. Enter tomsmith for the username and SuperSecretPassword! for the password.";
            IFormAuthentication formPage = new FormAuthentication();

            // Act
            string actual = formPage.GetDescriptionText();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Verifies that a valid login shows the correct success message.
        /// </summary>
        [Test]
        public void Login_WithValidCredentials_DisplaysSuccessMessage()
        {
            // Arrange
            string username = "tomsmith";
            string password = "SuperSecretPassword!";
            string expectedMessage = "You logged into a secure area!";
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            string actualMessage = loginPage.LoginWith(username, password);

            // Assert
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        /// <summary>
        /// Verifies that an invalid username shows the correct error message.
        /// </summary>
        [Test]
        public void Login_WithInvalidUsername_DisplaysErrorMessage()
        {
            // Arrange
            string username = "wronguser";
            string password = "SuperSecretPassword!";
            string expectedMessage = "Your username is invalid!";
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            string actualMessage = loginPage.LoginWith(username, password);

            // Assert
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        /// <summary>
        /// Verifies that an invalid password shows the correct error message.
        /// </summary>
        [Test]
        public void Login_WithInvalidPassword_DisplaysErrorMessage()
        {
            // Arrange
            string username = "tomsmith";
            string password = "wrongpassword";
            string expectedMessage = "Your password is invalid!";
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            string actualMessage = loginPage.LoginWith(username, password);

            // Assert
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        /// <summary>
        /// Verifies that after successful login, the secure area title is correct.
        /// </summary>
        [Test]
        public void SecureArea_AfterLogin_DisplaysCorrectTitle()
        {
            // Arrange
            string expectedTitle = "Secure Area";
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            string actualTitle = loginPage.GetSecureAreaTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        /// <summary>
        /// Verifies that after login, the logout button is visible.
        /// </summary>
        [Test]
        public void SecureArea_AfterLogin_DisplaysLogoutButton()
        {
            // Arrange
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            bool isVisible = loginPage.IsLogoutButtonVisible();

            // Assert
            Assert.IsTrue(isVisible);
        }

        /// <summary>
        /// Verifies that clicking logout redirects back to the login page.
        /// </summary>
        [Test]
        public void Logout_RedirectsToLoginPage()
        {
            // Arrange
            IFormAuthentication loginPage = new FormAuthentication();

            // Act
            string currentUrl = loginPage.LogoutAndGetRedirectedUrl();

            // Assert
            Assert.IsTrue(currentUrl.Contains("/login"));
        }

        /// <summary>
        /// Test to validate the logout pop-up message after logging out from secure area.
        /// </summary>
        [Test]
        public void LogoutMessage_Displayed_AfterLogout()
        {
            // Arrange
            string expectedMessage = "You logged out of the secure area!";

            // Act
            string actualMessage = _formAuth.GetLogoutMessage();

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "Logout message does not match expected text.");
        }


    }
}
