using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Form Authentication page on herokuapp.
    /// Defines actions like logging in, retrieving messages, and logging out.
    /// </summary>
    public interface IFormAuthentication
    {
        /// <summary>
        /// Navigates to the Form Authentication page.
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Enters the specified username into the username input field.
        /// </summary>
        /// <param name="userName">The username to enter.</param>
        void EnterUserName(string userName);

        /// <summary>
        /// Enters the specified password into the password input field.
        /// </summary>
        /// <param name="passWord">The password to enter.</param>
        void EnterPassWord(string passWord);

        /// <summary>
        /// Clicks the login button to attempt to authenticate.
        /// </summary>
        void ClickLogin();

        /// <summary>
        /// Gets the page title text.
        /// </summary>
        /// <returns>The title text of the page.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the page description or subtitle text.
        /// </summary>
        /// <returns>The description text displayed on the page.</returns>
        string GetDescription();

        /// <summary>
        /// Retrieves the error message shown after a failed login attempt.
        /// </summary>
        /// <returns>The error message text.</returns>
        string GetErrorMessage();

        /// <summary>
        /// Clicks the logout button to log out the user.
        /// </summary>
        void ClickLogout();

        /// <summary>
        /// Checks whether the login was successful.
        /// </summary>
        /// <returns>True if login succeeded; otherwise, false.</returns>
        bool IsLoginSuccessful();
    }
}
