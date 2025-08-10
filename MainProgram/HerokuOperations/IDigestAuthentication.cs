using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IDigestAuthentication
    {
        void GoToPage();// Navigate to the digest authentication page

        string GetPageTitle();// Get the title of the page
        void Login(string username, string password);// Perform login with the provided username and password
        bool IsLoggedIn();// Check if the user is logged in
        void Logout();// Perform logout
        string GetCurrentUser();// Get the current logged-in user


    }
