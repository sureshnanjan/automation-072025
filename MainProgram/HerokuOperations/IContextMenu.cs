using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IContextMenu
    {
        void GoToPage();// Navigate to the context menu page

        string GetTitle();// Get the title of the page

        string GetInformation();// Get the information text on the page

        void RIghtClickOnBox();// Perform a right-click on the box element

        string GetAlertText();// Get the text of the alert that appears after right-clicking

        void AcceptAlert();// Accept the alert that appears after right-clicking




    }
}
