using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IContextMenu
    {
        void GoToPage();

        string GetTitle();

        string GetInformation();

        void RightClickOnBox();

        string GetAlertText();

        void AcceptAlert();




    }
}
