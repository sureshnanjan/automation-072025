using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface IBrokenImages
    {
        // Navigates to the broken images test page.
        void NavigateToPage();

        //Get the Page title after successful navigation.
        string GetPageTitle();

        // Gets the total number of images on the page.
        int GetImageCount();

        // Returns the number of broken images (images that failed to load).
        int GetBrokenImageCount();

        // Returns a list of all image source URLs that failed to load.
        List<string> GetBrokenImageUrls();

    }
}
