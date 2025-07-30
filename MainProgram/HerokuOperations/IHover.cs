using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HerokuOperations
{
    public interface IHoverProfile
    {
        string GetTitle();    // Check the Title
        string Description();   // Check the Decription
        string GetProfileName(int index);      // Checks the Profile Name
        string GetProfileLink(int index);     // Checks the Link
        bool IsProfileInfoDisplayed(int index);       // Checks if caption is shown after hovering
        int GetProfileCount();    // Total number of hoverable profile images
        void HoverOverProfileImage(int index);       // Hover over the profile image at a specific index


    }
}
