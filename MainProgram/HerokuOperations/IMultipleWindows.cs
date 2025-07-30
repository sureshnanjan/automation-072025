using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface IMultipleWindows
    {
        void GotoPage(); // Navigates to the Multiple Windows page

        void OpenNewWindow(); // Opens a new browser window
        string GetTitle(); // Returns the title of the current page

        void SwitchToNewWindow(); // Switches to the newly opened window

        void SwitchToOriginalWindow(); // Switches back to the original window

    }
}
