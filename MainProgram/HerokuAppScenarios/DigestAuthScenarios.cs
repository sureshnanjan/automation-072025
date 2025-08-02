// --------------------------------------------------------------------------------------------------
// <copyright>
//     © 2025 Gayathri Thalapathi. All rights reserved.
//     This software is provided "as is," without warranty of any kind.
//     You may use, modify, or distribute this code with proper attribution.
// </copyright>
// --------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains unit tests for verifying Digest Authentication functionality on the HerokuApp.
    /// </summary>

    public class DigestAuthScenarios
    {
        private IDigestAuthentication _digestAuth;

        /// <summary>
        /// Initializes the test environment before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _digestAuth = new DigestAuthentication();
        }

        /// <summary>
        /// Verifies that the Digest Authentication page can be navigated to successfully.
        /// </summary>
        [Test]
        public void Should_Navigate_To_DigestAuthPage_Successfully()
        {
            bool result = _digestAuth.NavigateToPage();
            Assert.IsTrue(result, "Failed to navigate to Digest Authentication page.");
        }

        /// <summary>
        /// Validates that the authentication prompt is displayed with the correct title.
        /// </summary>
        [Test]
        public void Should_Display_AuthPrompt_With_Correct_Title()
        {
            string title = _digestAuth.GetAuthPromptTitle();
            StringAssert.Contains("Authentication Required", title, "Authentication prompt title mismatch.");
        }

        /// <summary>
        /// Ensures successful login using valid credentials.
        /// </summary>
        [Test]
        public void Should_Login_Successfully_With_Valid_Credentials()
        {
            _digestAuth.Login("admin", "admin");
            Assert.IsTrue(_digestAuth.IsLoggedIn(), "Login failed with valid credentials.");
        }

        /// <summary>
        /// Validates that login fails when using an invalid username.
        /// </summary>
        [Test]
        public void Should_Fail_Login_With_Invalid_Username()
        {
            _digestAuth.Login("wronguser", "admin");
            Assert.IsFalse(_digestAuth.IsLoggedIn(), "Login succeeded with incorrect username.");
        }

        /// <summary>
        /// Validates that login fails when using an invalid password.
        /// </summary>
        [Test]
        public void Should_Fail_Login_With_Invalid_Password()
        {
            _digestAuth.Login("admin", "wrongpass");
            Assert.IsFalse(_digestAuth.IsLoggedIn(), "Login succeeded with incorrect password.");
        }

        /// <summary>
        /// Verifies that the user session is retained after refreshing the page.
        /// </summary>
        [Test]
        public void Should_Retain_Session_After_Page_Refresh()
        {
            _digestAuth.Login("admin", "admin");
            _digestAuth.RefreshPage();
            Assert.IsTrue(_digestAuth.IsLoggedIn(), "Authenticated session was lost after refresh.");
        }

        /// <summary>
        /// Checks that navigating back does not require re-authentication.
        /// </summary>
        [Test]
        public void Should_Not_Require_Reauthentication_On_Back_Navigation()
        {
            _digestAuth.Login("admin", "admin");
            _digestAuth.NavigateBack();
            Assert.IsTrue(_digestAuth.IsLoggedIn(), "Back navigation required re-authentication.");
        }

        /// <summary>
        /// Verifies that IsLoggedIn returns true after a successful login.
        /// </summary>
        [Test]
        public void Should_Return_True_If_User_Is_LoggedIn()
        {
            _digestAuth.Login("admin", "admin");
            bool isLoggedIn = _digestAuth.IsLoggedIn();
            Assert.IsTrue(isLoggedIn, "User is not recognized as logged in.");
        }

        /// <summary>
        /// Ensures that the session is cleared after logging out.
        /// </summary>
        [Test]
        public void Should_Clear_Session_On_Logout()
        {
            _digestAuth.Login("admin", "admin");
            _digestAuth.Logout();
            Assert.IsFalse(_digestAuth.IsLoggedIn(), "User session still active after logout.");
        }

        /// <summary>
        /// Checks that the current logged-in user is correctly returned as "admin".
        /// </summary>
        [Test]
        public void Should_Return_LoggedIn_Username_As_Admin()
        {
            _digestAuth.Login("admin", "admin");
            string currentUser = _digestAuth.GetCurrentUser();
            Assert.AreEqual("admin", currentUser, "Current logged-in user is incorrect.");
        }
        /// <summary>
        /// verifies that the footer contains the expected "Powered by" information.
        /// </summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        /// <summary>
        /// verifies that the GitHub ribbon is displayed correctly.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }
    }
}
