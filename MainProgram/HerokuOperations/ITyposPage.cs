using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface ITyposPage
    {
        //Navigates to the Typos page.
        void NavigateToPage();

        //Gets the page title after successful navigation.
        string GetPageTitle();

        //Gets the description text on the page.
        string GetPageDescription();

        //Returns a boolean if any typo find on the page.
        bool HasTypos();
    }
}
