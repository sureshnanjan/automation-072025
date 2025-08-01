using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IBasicAuthPage
    {
        // Navigates to the Basic Auth page using the provided credentials.
        void NavigateToPage(string username, string password);

        // Get the page title after successful login.
        string GetPageTitle();

        // Get the description text on the page.
        string GetPageDescription();

    }
}
